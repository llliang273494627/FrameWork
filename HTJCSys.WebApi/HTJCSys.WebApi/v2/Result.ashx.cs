﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using COM;
using DAL;
using MDL;
using HTJCSys.WebApi.Common;

namespace HTJCSys.WebApi.v2
{
    /// <summary>
    /// Result 的摘要说明
    /// </summary>
    public class Result : IHttpHandler
    {
        //CommonDAL DataDAL = new CommonDAL();
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
                    case "add":
                        this.Insert();
                        break;
                    case "upload":
                        this.Upload();
                        break;
                    case "validate":
                        this.Validate();
                        break;
                    case "testdb":
                        this.TestConnectDB();
                        break;
                    case "datetime":
                        this.GetDateTime();
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

        #region Insert Function

        #region 添加结果信息
        /// <summary>
        /// 添加结果信息
        /// </summary>
        private void Insert()
        {
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
                string ScanType = dict["ScanType"].ToString();//扫描类型

                // 减少库存
                //updated by seay at 2017-08-24
                string TraceType = "'扫描追溯','批次追溯'";
                string sql = string.Format("SELECT * FROM (SELECT t.*,n.batchno ext1,n.TID ext2 FROM (SELECT b.*, m.tablename, m.fieldname FROM productinfo p, productbominfo b, materialfield m WHERE p.productcode = b.productcode AND p.producttype = b.producttype AND b.materialcode = m.materialcode AND m.tablename='{0}') t LEFT JOIN batchno n ON t.materialcode = n.materialcode AND n.TID IN(SELECT MAX(TID) FROM BatchNo GROUP BY MaterialCode)) t WHERE  productcode='{1}' AND producttype='{2}' AND tracetype in({3});", TableName, ProductCode, ProductType, TraceType);
                DataTable table = CommonDAL.GetDataTable(sql);
                Dictionary<string, MaterialBomMDL> ht = MaterialBomDAL.GetList(table, 2);

                Dictionary<string, MaterialBomMDL> HTSelect = ht.Where(m => m.Value.TraceType == "扫描追溯").ToDictionary(k => k.Key, v => v.Value);

                //获取得到的扫描追溯信息
                //updated by seay at 2016-08-23
                Dictionary<string, MaterialBomMDL> HTResult = new Dictionary<string, MaterialBomMDL>(HTSelect);
                foreach (var item in HTReceive)
                {
                    MaterialBomMDL model = HTSelect[item.Key] as MaterialBomMDL;
                    model.Ext1 = item.Value.ToString();
                    HTResult.Remove(item.Key);
                    HTResult.Add(item.Key, model);
                }

                bool flag = true;

                //获取组装的SQL语句
                sql = AssembleSqlCode(TableName, HJBarCode, ProductCode, UserID, StationID, null, HTResult);
                //CLog.WriteErrLog(sql);
                if (!string.IsNullOrEmpty(sql))
                {
                    //执行组装的SQL语句，返回结果
                    flag = CommonDAL.ExecuteSql(sql, null);
                }

                if (flag)
                {
                    ReturnData.Code = "1";
                    ReturnData.Msg = "OK";
                }

                if (ScanType=="1")
                {
                    // 减少库存
                    //updated by seay at 2017-08-31
                    ProcessStock.Invoke(ProductType, ProductCode, ht); 
                }
            }
            catch (Exception ex)
            {
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
        private string AssembleSqlCode(string TableName, string HJBarCode, string ProductCode, string UserID, string StationID, string CreateTime, Dictionary<string, MaterialBomMDL> MaterialList)
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
                    foreach (var Entry in MaterialList)
                    {
                        MaterialBomMDL model = Entry.Value as MaterialBomMDL;

                        if (!string.IsNullOrEmpty(model.Ext1))
                        {
                            sql += string.Format("{0}='{1}',", model.FieldName, model.Ext1);
                        }
                    }
                }
                else
                {
                    return null;
                }
                #endregion
                sql += string.Format("userid='{0}',stationid='{1}'", UserID, StationID);
                sql += string.Format(" where tid={0}", TID);
            }
            else
            {
                string field = "";
                string values = "";
                #region 对应更新字段
                if (MaterialList != null && MaterialList.Count > 0)
                {
                    foreach (var Entry in MaterialList)
                    {
                        MaterialBomMDL model = Entry.Value as MaterialBomMDL;

                        if (!string.IsNullOrEmpty(model.Ext1))
                        {
                            field += model.FieldName + ",";
                            values += string.Format("'{0}',", model.Ext1);
                        }
                    }
                }
                #endregion
                if (!string.IsNullOrEmpty(CreateTime))
                {
                    field += "CreateTime,";
                    values += string.Format("'{0}',", CreateTime);
                }
                field += "barcode,productcode,userid,stationid";
                values += string.Format("'{0}','{1}','{2}','{3}'", HJBarCode, ProductCode, UserID, StationID);
                sql += string.Format("insert into {0}({1}) values({2});", TableName, field, values);
            }
            return sql;
        }
        #endregion

        #endregion End Insert Function

        #region Upload Function
        /// <summary>
        /// 数据上传
        /// </summary>
        private void Upload()
        {
            try
            {
                string sql = string.Empty;
                string param = context.Request.Params["param"].ToString();
                //获取到的json数据
                Dictionary<string, object> dict = JsonHelper.JsonDeSerializer<Dictionary<string, object>>(param);
                //解析获得result的DataTable表
                DataTable ReceiveTable = JsonHelper.JsonDeSerializer<DataTable>(dict["data"].ToString());
                List<object> list = TableHelper.TableToObj(ReceiveTable);
                string LineType = dict["LineType"].ToString();//生产线类型
                string TableName = dict["TableName"].ToString();//表名
                string ids = "";
                foreach (Dictionary<string, object> row in list)
                {
                    Dictionary<string, object> ReceiveDict = new Dictionary<string, object>();
                    ReceiveDict = row;

                    string ProductCode = ReceiveDict["productcode"].ToString();
                    string HJBarCode = ReceiveDict["barcode"].ToString();
                    string UserID = ReceiveDict["userid"].ToString();
                    string StationID = ReceiveDict["stationid"].ToString();
                    string CreateTime = ReceiveDict["createtime"].ToString();
                    string ScanType = ReceiveDict["scantype"].ToString();//扫描类型

                    //获取到扫描信息
                    //sql = string.Format("SELECT * FROM (SELECT t.* FROM (SELECT b.*, m.tablename, m.fieldname FROM productinfo p, productbominfo b, materialfield m WHERE p.productcode = b.productcode AND p.producttype = b.producttype AND b.materialcode = m.materialcode AND m.tablename='{0}') t LEFT JOIN batchno n ON t.materialcode = n.materialcode) t WHERE  productcode='{1}' AND producttype='{2}' AND tracetype in({3});", TableName, ProductCode, LineType, "'扫描追溯'");
                    //DataTable table = CommonDAL.GetDataTable(sql);
                    //Dictionary<string, MaterialBomMDL> HTSelect = MaterialBomDAL.GetList(table);
                    //Hashtable HTResult = new Hashtable(HTSelect);


                    // 减少库存
                    //updated by seay at 2017-08-31
                    sql = string.Format("SELECT * FROM (SELECT t.*,n.batchno ext1,n.TID ext2 FROM (SELECT b.*, m.tablename, m.fieldname FROM productinfo p, productbominfo b, materialfield m WHERE p.productcode = b.productcode AND p.producttype = b.producttype AND b.materialcode = m.materialcode AND m.tablename='{0}') t LEFT JOIN batchno n ON t.materialcode = n.materialcode AND n.TID IN(SELECT MAX(TID) FROM BatchNo GROUP BY MaterialCode)) t WHERE  productcode='{1}' AND producttype='{2}' AND tracetype in({3});", TableName, ProductCode, LineType, "'扫描追溯','批次追溯'");
                    DataTable table = CommonDAL.GetDataTable(sql);
                    Dictionary<string, MaterialBomMDL> ht = MaterialBomDAL.GetList(table, 2);

                    Dictionary<string, MaterialBomMDL> HTSelect = ht.Where(m => m.Value.TraceType == "扫描追溯").ToDictionary(k => k.Key, v => v.Value);
                    Dictionary<string, MaterialBomMDL> HTResult = new Dictionary<string, MaterialBomMDL>(HTSelect);

                    //获取得到的扫描追溯信息
                    foreach (var entry in HTSelect)
                    {
                        MaterialBomMDL Model = entry.Value as MaterialBomMDL;
                        if (ReceiveDict.ContainsKey(Model.FieldName) && !string.IsNullOrEmpty(ReceiveDict[Model.FieldName].ToString()))
                        {
                            Model.Ext1 = ReceiveDict[Model.FieldName].ToString();
                        }
                        HTResult.Remove(entry.Key);
                        HTResult.Add(entry.Key, Model);
                    }

                    //获取组装的SQL语句
                    sql = AssembleSqlCode(TableName, HJBarCode, ProductCode, UserID, StationID, CreateTime, HTSelect);
                    //CLog.WriteErrLog(sql);
                    bool flag = true;
                    if (!string.IsNullOrEmpty(sql))
                    {
                        //执行组装的SQL语句，返回结果
                        flag = CommonDAL.ExecuteSql(sql, null);
                    }

                    if (flag)
                    {
                        ids += string.Format("{0},", ReceiveDict["tid"].ToString());
                    }

                    // 扫描类型判断
                    //updated by seay at 2017-08-31
                    if (ScanType == "1")
                    {
                        // 减少库存
                        //updated by seay at 2017-08-31
                        ProcessStock.Invoke(LineType, ProductCode, ht);
                    }
                }

                if (ids.Length > 0)
                {
                    ids = ids.Substring(0, ids.Length - 1);
                }
                ReturnData.Code = "1";
                ReturnData.Msg = "OK";
                ReturnData.Data = ids;
            }
            catch (Exception ex)
            {
                ReturnData.Code = "0";
                ReturnData.Msg = "NOK";
                CLog.WriteErrLog(ex.Message);
            }
        }
        #endregion

        #region Validate Function
        /// <summary>
        /// 验证的方法
        /// </summary>
        private void Validate()
        {
            try
            {
                string Type = context.Request.Params["Type"].ToString();//验证的对象类型（合件、子零件）
                string TableName = context.Request.Params["TableName"].ToString();//表名称
                string BarCode = context.Request.Params["BarCode"].ToString();//条码
                string sql = "";
                switch (Type)
                {
                    case "1"://合件
                        string ProductCode = context.Request.Params["ProductCode"].ToString();//产品编码
                        sql = string.Format("select userid from {0} where barcode='{1}' and productcode='{2}'", TableName, BarCode, ProductCode);
                        break;
                    case "2"://子件
                        string Filed = context.Request.Params["Filed"].ToString();//产品编码
                        sql = string.Format("select tid from {0} where {2}='{1}'", TableName, BarCode, Filed);
                        break;
                }
                object obj = CommonDAL.ExecuteScaler(sql);
                if (obj == null || obj == "" || string.IsNullOrEmpty(obj.ToString()))
                {
                    ReturnData.Code = "0";
                    ReturnData.Msg = "NotExist";
                    ReturnData.Data = 1;
                }
                else
                {
                    ReturnData.Code = "1";
                    ReturnData.Msg = "IsExist";
                    ReturnData.Data = 0;
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                ReturnData.Code = "0";
                ReturnData.Msg = "NotExist";
                ReturnData.Data = 0;
            }
        }
        #endregion

        #region Test DB Connection Status Function
        /// <summary>
        /// Test DB Connection Status Function
        /// </summary>
        public void TestConnectDB()
        {
            try
            {
                SqlHelper helper = new SqlHelper();
                if (helper.TestConnection())
                {
                    ReturnData.Code = "1";
                    ReturnData.Msg = "OK";
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }
        #endregion

        #region Get Server Machine DateTime
        /// <summary>
        /// Get Server Machine DateTime
        /// </summary>
        private void GetDateTime()
        {
            try
            {
                object obj = DateTime.Now;
                if (obj != null)
                {
                    ReturnData.Code = "1";
                    ReturnData.Data = obj;
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
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