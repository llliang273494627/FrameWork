using COM;
using DAL;
using MDL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HTJCSys.WebApi
{
    /// <summary>
    /// Repair 的摘要说明
    /// </summary>
    public class Repair : IHttpHandler
    {
        CommonDAL DataDAL = new CommonDAL();
        ReturnInfo ReturnData = new ReturnInfo();
        HttpContext context = null;
        public void ProcessRequest(HttpContext _context)
        {
            context = _context;
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            ReturnData.Code = "0";
            ReturnData.Msg = "NOK";
            this.doAction();
        }

        #region 操作调用方法
        /// <summary>
        /// 操作调用方法
        /// </summary>
        private void doAction()
        {
            try
            {
                string action = context.Request.Params["do"].ToString().ToLower();
                switch (action)
                {
                    case "update":
                        this.Update();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                ReturnData.Data = ex.Message;
            }
            finally
            {
                context.Response.Write(JsonHelper.JsonSerializerObj<ReturnInfo>(ReturnData));
            }
        }
        #endregion

        #region 返修更新信息
        /// <summary>
        /// 返修更新信息
        /// </summary>
        private void Update()
        {
            string sql = "";
            try
            {
                string param = context.Request.Params["param"].ToString();
                //获取到的json数据
                Dictionary<string, object> dict = JsonHelper.JsonDeSerializer<Dictionary<string, object>>(param);
                //解析获得result的Hashtable集合
                Dictionary<string, object> HTReceive = JsonHelper.JsonDeSerializer<Dictionary<string, object>>(dict["data"].ToString());

                string TableName = dict["TableName"].ToString();//表名
                string HJBarCode = dict["HJBarCode"].ToString();//合件条码
                string UserID = dict["UserID"].ToString();//用户ID
                string StationID = dict["StationID"].ToString();//工位号
                string ProductCode = dict["ProductCode"].ToString();//产品编码
                string ProductType = dict["ProductType"].ToString();//产品类型
                string TraceType = "'扫描追溯','批次追溯'";
                sql = string.Format("SELECT * FROM (SELECT t.* FROM (SELECT b.*, m.tablename, m.fieldname FROM productinfo p, productbominfo b, materialfield m WHERE p.productcode = b.productcode AND p.producttype = b.producttype AND b.materialcode = m.materialcode AND m.tablename='{0}') t LEFT JOIN batchno n ON t.materialcode = n.materialcode) t WHERE  productcode='{1}' AND producttype='{2}' AND tracetype in({3});", TableName, ProductCode, ProductType, TraceType);
                DataTable table = CommonDAL.GetDataTable(sql);
                Dictionary<string,MaterialBomMDL> HTSelect = MaterialBomDAL.GetList(table);
                Hashtable HTResult = new Hashtable();
                foreach (var item in HTReceive)
                {
                    MaterialBomMDL model = HTSelect[item.Key] as MaterialBomMDL;
                    model.BatchBarCode = item.Value.ToString();
                    HTResult.Add(item.Key, model);
                }
                //获取组装的SQL语句
                sql = AssembleSqlCode(TableName,ProductType, HJBarCode, ProductCode, UserID, StationID, null, HTResult);
                //CLog.WriteErrLog(sql);
                if (!string.IsNullOrEmpty(sql))
                {
                    //执行组装的SQL语句，返回结果
                    bool flag = CommonDAL.ExecuteSql(sql, null);
                    if (flag)
                    {
                        ReturnData.Code = "1";
                        ReturnData.Msg = "OK";
                    } 
                }
            }
            catch (Exception ex)
            {
                CLog.WriteStationLog("SQLErr",sql);
                CLog.WriteErrLog(ex.Message);
            }
        }
        #endregion

        #region 组装SQL语句
        /// <summary>
        /// 组装SQL语句
        /// </summary>
        /// <param name="IsExit"></param>
        /// <param name="tid"></param>
        /// <returns></returns>
        private string AssembleSqlCode(string TableName,string ProductType, string HJBarCode, string ProductCode, string UserID, string StationID, string CreateTime, Hashtable MaterialList)
        {
            //查询合件是否存在
            object obj = CommonDAL.ExecuteScaler(string.Format("SELECT tid FROM {0} WHERE barcode ='{1}';", TableName, HJBarCode));
            long TID = obj != null && obj.ToString() != "0" ? long.Parse(obj.ToString()) : 0;
            string sql = "";
            if (TID != 0)
            {
                sql += string.Format("update {0} set ", TableName);
                #region 对应更新字段
                if (MaterialList != null && MaterialList.Count > 0)
                {
                    foreach (DictionaryEntry Entry in MaterialList)
                    {
                        MaterialBomMDL model = Entry.Value as MaterialBomMDL;
                        if (!string.IsNullOrEmpty(model.BatchBarCode))
                        {
                            sql += string.Format("{0}='{1}',", model.FieldName, model.BatchBarCode);
                        }
                    }
                }
                #endregion

                int num = 0;
                if (ProductType == "摇篮")
                {
                    num = 12;
                }
                else if (ProductType == "踏板")
                {
                    num = 3;
                }
                else if (ProductType == "制动泵")
                {
                    num = 2;
                }
                else if (ProductType == "散热器")
                {
                    num = 6;
                }
                if (num>0)
                {
                    for (int i = 1; i < num + 1; i++)
                    {
                        sql += string.Format("torque{0}=null,angle{0}=null,", i);
                    } 
                }
                sql += string.Format("{0}=null,", "completed");
                sql += string.Format("{0}=null,", "completetime");
                sql += string.Format("{0}={1},", "createtime", "CURRENT_TIMESTAMP");
                sql += string.Format("userid='{0}',stationid='{1}',", UserID, StationID);
                sql += string.Format("repairstate={0}", 1);
                sql += string.Format(" where tid={0}", TID);
            }
            else
            {
                sql = "";
                ReturnData.Code = "201";
                ReturnData.Msg = "合件不存在";
                #region 不用的
                //string field = "";
                //string values = "";
                //#region 对应更新字段
                //if (MaterialList != null && MaterialList.Count > 0)
                //{
                //    foreach (DictionaryEntry Entry in MaterialList)
                //    {
                //        MaterialBomMDL model = Entry.Value as MaterialBomMDL;
                //        if (!string.IsNullOrEmpty(model.Ext1))
                //        {
                //            field += model.FieldName + ",";
                //            values += string.Format("'{0}',", model.Ext1);
                //        }
                //    }
                //}
                //#endregion
                //if (!string.IsNullOrEmpty(CreateTime))
                //{
                //    field += "CreateTime,";
                //    values += string.Format("'{0}',", CreateTime);
                //}
                //field += "barcode,productcode,userid,stationid";
                //values += string.Format("'{0}','{1}','{2}','{3}'", HJBarCode, ProductCode, UserID, StationID);
                //sql += string.Format("insert into {0}({1}) values({2});", TableName, field, values); 
                #endregion
            }
            return sql;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}