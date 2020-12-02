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
    /// MaterialBom 的摘要说明
    /// </summary>
    public class MaterialBom : IHttpHandler
    {
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
                string TableName = context.Request.Params["TableName"].ToString();
                string ProductType = context.Request.Params["ProductType"].ToString();
                string ProductCode = context.Request.Params["ProductCode"].ToString();
                string TraceType = context.Request.Params["TraceType"].ToString();
                if (string.IsNullOrEmpty(TraceType) || TraceType == "0")
                {
                    TraceType = "'扫描追溯','批次追溯'";
                }
                else if (TraceType == "1")
                {
                    TraceType = "'扫描追溯'";
                }
                else if (TraceType == "2")
                {
                    TraceType = "'批次追溯'";
                }
                string sql = string.Format("SELECT * FROM (SELECT t.*,n.tid ext1,n.batchno ext2,n.stocknum ext3 FROM (SELECT b.*, m.tablename, m.fieldname FROM productinfo p, productbominfo b, materialfield m WHERE p.productcode = b.productcode AND p.producttype = b.producttype AND b.materialcode = m.materialcode AND m.tablename='{0}') t LEFT JOIN batchno n ON t.materialcode = n.materialcode) t WHERE  productcode='{1}' AND producttype='{2}' AND tracetype in({3});", TableName, ProductCode, ProductType,TraceType);
                DataTable table = CommonDAL.GetDataTable(sql);
                if (table != null && table.Rows.Count > 0)
                {
                    //object obj = TableHelper.TableToObj(table);
                    Dictionary<string,MaterialBomMDL> HTMaterialTable = MaterialBomDAL.GetList(table, 3);
                    ReturnData.Code = "1";
                    ReturnData.Msg = "OK";
                    ReturnData.Data = HTMaterialTable;
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