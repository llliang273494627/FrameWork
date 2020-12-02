using COM;
using DAL;
using MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HTJCSys.WebApi
{
    /// <summary>
    /// BatchNoHis 的摘要说明
    /// </summary>
    public class BatchNoHis : IHttpHandler
    {
        BatchNoHisDAL DataDAL = new BatchNoHisDAL();
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

        #region 添加历史批次信息
        /// <summary>
        /// 添加历史批次信息
        /// </summary>
        private void Insert()
        {
            try
            {
                string MaterialCode = context.Request.Params["MaterialCode"].ToString();
                string BatchNo = context.Request.Params["BatchNo"].ToString();
                string BatchNumStr = context.Request.Params["BatchNum"].ToString();
                string Supplier = context.Request.Params["Supplier"].ToString();
                int BatchNum = 0;
                bool b = int.TryParse(BatchNumStr,out BatchNum);
                string CreateTime = context.Request.Params["CreateTime"].ToString();
                if (string.IsNullOrEmpty(MaterialCode) || string.IsNullOrEmpty(BatchNo))
                {
                    ReturnData.Msg = "参数错误";
                }
                else
                {
                    BatchNoHisMDL Model = new BatchNoHisMDL();
                    Model.MaterialCode = MaterialCode;
                    Model.BatchNo = BatchNo;
                    Model.Supplier = Supplier;

                    if (b)
                    {
                        Model.BatchNum = BatchNum;
                    }

                    if (!string.IsNullOrEmpty(CreateTime))
                    {
                        Model.CreateTime = DateTime.Parse(CreateTime);
                    }
                    else
                    {
                        Model.CreateTime = DateTime.Now;
                    }
                    bool flag = DataDAL.Add(Model);
                    if (flag)
                    {
                        ReturnData.Code = "1";
                        ReturnData.Msg = "OK";
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }
        #endregion

        #region 获取历史批次信息
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
                    string sql = " 1=1 ";
                    if (!string.IsNullOrEmpty(TID))
                    {
                        sql += string.Format(" AND TID = {0}", TID);
                    }
                    BatchNoHisMDL model = DataDAL.GetModel(sql);
                    if (model != null)
                    {
                        ReturnData.Code = "1";
                        ReturnData.Msg = "OK";
                        ReturnData.Data = model;
                    }
                }
                else if (method == "search")
                {
                    string sql = " 1=1 ";
                    //string ProductType = context.Request.Params["ProductType"].ToString();
                    //string ProductCode = context.Request.Params["ProductCode"].ToString();
                    //CLog.WriteErrLog(ProductType);
                    //if (!string.IsNullOrEmpty(ProductCode))
                    //{
                    //    sql += string.Format(" AND ProductCode = '{0}'", ProductCode);
                    //}
                    //if (!string.IsNullOrEmpty(ProductType))
                    //{
                    //    sql += string.Format(" AND ProductType = '{0}'", ProductType);
                    //}
                    sql += " ORDER BY TID ASC";
                    //CLog.WriteErrLog(sql);
                    DataSet set = DataDAL.GetList(sql);
                    if (set != null && set.Tables.Count > 0)
                    {
                        DataTable table = set.Tables[0];
                        if (table != null && table.Rows.Count > 0)
                        {
                            object obj = TableHelper.TableToObj(table);
                            ReturnData.Code = "1";
                            ReturnData.Msg = "OK";
                            ReturnData.Data = obj;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }
        #endregion

        #region 上传数据
        /// <summary>
        /// 上传数据
        /// </summary>
        private void Upload()
        {
            try
            {
                string Param = context.Request.Params["Param"].ToString();
                DataTable ReceiveTable = JsonHelper.JsonDeSerializer<DataTable>(Param);
                int UploadCount = 0;
                int RowCount = 0;
                string ids = "";//上传成功的ID
                if (ReceiveTable != null && ReceiveTable.Rows.Count > 0)
                {
                    RowCount = ReceiveTable.Rows.Count;
                    foreach (DataRow row in ReceiveTable.Rows)
                    {
                        BatchNoHisMDL Model = DataDAL.DataRowToModel(row);
                        bool flag = DataDAL.Add(Model);
                        if (flag)
                        {
                            UploadCount++;
                            ids += string.Format("{0},", Model.TID);
                        }
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