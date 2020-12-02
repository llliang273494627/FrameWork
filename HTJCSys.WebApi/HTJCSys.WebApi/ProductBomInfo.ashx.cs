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
    /// ProductBomInfo 的摘要说明
    /// </summary>
    public class ProductBomInfo : IHttpHandler
    {
        ProductBomInfoDAL DataDAL = new ProductBomInfoDAL();
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
                context.Response.Write(JsonHelper.JsonSerializerObj<ReturnInfo>(ReturnData));
            }
        }
        #endregion

        #region 获取产品BOM信息
        /// <summary>
        /// 获取产品BOM信息
        /// </summary>
        private void Select()
        {
            try
            {
                string sql = " 1=1 ";
                string method = context.Request.Params["method"].ToString();
                string ProductType = context.Request.Params["ProductType"].ToString();
                string ProductCode = context.Request.Params["ProductCode"].ToString();
                string MaterialCode = context.Request.Params["MaterialCode"].ToString();
                string TraceType = context.Request.Params["TraceType"].ToString();
                if (!string.IsNullOrEmpty(ProductType))
                {
                    sql += string.Format(" AND ProductType = '{0}'", ProductType);
                }
                if (!string.IsNullOrEmpty(ProductCode))
                {
                    sql += string.Format(" AND ProductCode = '{0}'", ProductCode);
                }
                if (!string.IsNullOrEmpty(MaterialCode))
                {
                    sql += string.Format(" AND MaterialCode = '{0}'", MaterialCode);
                }
                if (!string.IsNullOrEmpty(TraceType))
                {
                    if (TraceType == "1")
                    {
                        TraceType = "'扫描追溯'";
                    }
                    else if (TraceType == "2")
                    {
                        TraceType = "'批次追溯'";
                    }
                    else
                    {
                        TraceType = "'扫描追溯','批次追溯'";
                    }
                    sql += string.Format(" AND TraceType in ({0})", TraceType);
                }
                if (method == "model")
                {
                    string TID = context.Request.Params["TID"].ToString();
                    if (!string.IsNullOrEmpty(TID))
                    {
                        sql += string.Format(" AND TID = {0}", TID);
                    }
                    ProductBomInfoMDL model = DataDAL.GetModel(sql);
                    if (model != null)
                    {
                        ReturnData.Code = "1";
                        ReturnData.Msg = "OK";
                        ReturnData.Data = model;
                    }
                }
                else if (method == "search")
                {
                    sql += " ORDER BY TID ASC";
                    DataSet set = DataDAL.GetList(sql);
                    if (set != null && set.Tables.Count > 0)
                    {
                        DataTable table = set.Tables[0];
                        if (table != null && table.Rows.Count > 0)
                        {
                            //object obj = TableHelper.TableToObj(table);
                            ReturnData.Code = "1";
                            ReturnData.Msg = "OK";
                            ReturnData.Data = table;
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}