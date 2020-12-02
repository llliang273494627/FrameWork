using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using COM;
using DAL;
using MDL;

namespace HTJCSys.WebApi.v2
{
    /// <summary>
    /// BatchNo 的摘要说明
    /// </summary>
    public class Batch : IHttpHandler
    {
        BatchDAL DataDAL = new BatchDAL();
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
                    case "get":
                        this.Select();
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
                context.Response.Write(JsonHelper.JsonSerializer(ReturnData));
            }
        }
        #endregion

        #region 添加批次信息
        /// <summary>
        /// 添加批次信息
        /// </summary>
        private void Insert()
        {
            try
            {
                //string ProductCode = context.Request.Params["ProductCode"].ToString();
                string ProductType = context.Request.Params["ProductType"].ToString();
                string BarCode = context.Request.Params["BarCode"].ToString();
                string MaterialCode = context.Request.Params["MaterialCode"].ToString();
                string MaterialName = context.Request.Params["MaterialName"].ToString();
                string BatchNo = context.Request.Params["BatchNo"].ToString();
                string BatchNumStr = context.Request.Params["BatchNum"].ToString();
                string Supplier = context.Request.Params["Supplier"].ToString();
                int BatchNum = 0;
                bool b = int.TryParse(BatchNumStr, out BatchNum);

                BatchMDL model = new BatchMDL();
                model.ProductType = ProductType;
                model.BarCode = BarCode;
                model.MaterialCode = MaterialCode;
                model.MaterialName = MaterialName;
                model.BatchNo = BatchNo;
                model.StockNum = BatchNum;
                model.BatchNum = BatchNum;
                model.Supplier = Supplier;
                model.CreateTime = DateTime.Now;

                bool flag = DataDAL.Add(model);
                if (flag)
                {
                    ReturnData.Code = "1";
                    ReturnData.Msg = "OK";
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region 上传批次信息
        /// <summary>
        /// 上传批次信息
        /// </summary>
        private void Upload()
        {
            try
            {
                string param = context.Request.Params["param"].ToString();

                List<BatchMDL> list = JsonHelper.JsonDeSerializer<List<BatchMDL>>(param);
                string ids = "";
                foreach (var row in list)
                {
                    BatchMDL model = row;

                    if (model == null)
                    {
                        continue;
                    }

                    bool flag = DataDAL.Add(model);
                    if (flag)
                    {
                        ids += string.Format("{0},", model.TID);
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
                CLog.WriteErrLog(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region 获取批次信息
        /// <summary>
        /// 获取历史批次信息
        /// </summary>
        private void Select()
        {
            try
            {
                string method = context.Request.Params["method"].ToString();
                if (method == "model")
                {
                    string TID = context.Request.Params["TID"].ToString();
                    // string MaterialCode = context.Request.Params["MaterialCode"].ToString();
                    string sql = " 1=1 ";
                    if (!string.IsNullOrEmpty(TID))
                    {
                        sql += string.Format(" AND TID = {0}", TID);
                    }
                    //if (!string.IsNullOrEmpty(MaterialCode))
                    //{
                    //    sql += string.Format(" AND MaterialCode = '{0}'", MaterialCode);
                    //}
                    //sql = " LIMIT 1 ";
                    BatchMDL model = DataDAL.GetModel(sql);
                    if (model != null)
                    {
                        ReturnData.Code = "1";
                        ReturnData.Msg = "OK";
                        ReturnData.Data = model;
                    }
                }
                else if (method == "search")
                {
                    string ProductCode = context.Request.Params["ProductCode"].ToString();
                    string ProductType = context.Request.Params["ProductType"].ToString();
                    string TableName = context.Request.Params["TableName"].ToString();
                    string sql = string.Format("SELECT CASE WHEN n.tid > 0 then n.tid ELSE 0 END TID,t.materialcode MaterialCode,t.materialname MaterialName,n.batchno BatchNo,t.batchnum BatchNum,CASE WHEN n.stocknum > -1 then n.stocknum ELSE 0 END Stocknum FROM (SELECT b.producttype,b.productcode,b.tracetype,b.batchnum,f.materialcode,f.materialname,f.tablename FROM materialfield f INNER JOIN productbominfo b ON f.materialcode=b.materialcode) t LEFT JOIN batchno n ON t.materialcode=n.materialcode WHERE t.producttype='{0}' AND t.productcode='{1}' AND t.tablename='{2}' AND t.tracetype in({3});", ProductType, ProductCode, TableName, "'批次追溯'");
                    DataTable table = CommonDAL.GetDataTable(sql);
                    if (table != null && table.Rows.Count > 0)
                    {
                        object obj = TableHelper.TableToObj(table);
                        ReturnData.Code = "1";
                        ReturnData.Msg = "OK";
                        ReturnData.Data = obj;
                    }
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