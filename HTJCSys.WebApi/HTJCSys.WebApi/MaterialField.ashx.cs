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
    /// MaterialField 的摘要说明
    /// </summary>
    public class MaterialField : IHttpHandler
    {
        MaterialFieldDAL DataDAL = new MaterialFieldDAL();
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
                context.Response.Write(JsonHelper.JsonSerializer(ReturnData));
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
                if (method == "model")
                {
                    string MaterialCode = context.Request.Params["MaterialCode"].ToString();
                    if (!string.IsNullOrEmpty(MaterialCode))
                    {
                        sql += string.Format(" AND MaterialCode = {0}", MaterialCode);
                    }
                    MaterialFieldMDL model = DataDAL.GetModel(sql);
                    if (model != null)
                    {
                        ReturnData.Code = "1";
                        ReturnData.Msg = "OK";
                        ReturnData.Data = model;
                    }
                }
                else if (method == "search")
                {
                    string MaterialCodeList = context.Request.Params["MaterialCodeList"].ToString();
                    if (!string.IsNullOrEmpty(MaterialCodeList))
                    {
                        sql += string.Format(" AND MaterialCode in ({0})", MaterialCodeList);
                    }
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}