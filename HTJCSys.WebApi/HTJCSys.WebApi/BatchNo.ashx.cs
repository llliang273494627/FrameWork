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
    /// BatchNo 的摘要说明
    /// </summary>
    public class BatchNo : IHttpHandler
    {
        BatchNoDAL DataDAL = new BatchNoDAL();
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
                    case "update":
                        this.Update(null);
                        break;
                    case "get":
                        this.Select();
                        break;
                    case "check":
                        this.CheckBatchTip();
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
                string MaterialCode = context.Request.Params["MaterialCode"].ToString();
                string BatchNo = context.Request.Params["BatchNo"].ToString();
                string BatchNumStr = context.Request.Params["BatchNum"].ToString();
                string Supplier = context.Request.Params["Supplier"].ToString();
                int BatchNum = 0;
                bool b = int.TryParse(BatchNumStr, out BatchNum);

                BatchNoMDL Model = null;
                string sql = string.Format("materialcode='{0}'", MaterialCode);
                Model = DataDAL.GetModel(sql);
                if (Model!=null)
                {
                    Model.BatchNo = BatchNo;
                    Model.BatchNum = (b && BatchNum > 0) ? BatchNum : Model.BatchNum;
                    Model.StockNum = Model.BatchNum;
                    Model.Supplier = Supplier;

                    this.Update(Model);
                    return;
                }
                else
                {
                    Model = new BatchNoMDL();
                    sql = string.Format("producttype='{0}' AND materialcode='{1}'", ProductType, MaterialCode);
                    ProductBomInfoDAL pb = new ProductBomInfoDAL();
                    ProductBomInfoMDL info = pb.GetModel(sql);

                    if ( b && BatchNum > 0)
                    {
                        Model.BatchNum = BatchNum;
                    }
                    else
                    {
                        if (info != null || info.BatchNum.ToString().Trim() != "")
                        {
                            Model.BatchNum = int.Parse(info.BatchNum.ToString());
                        }
                        else
                        {
                            Model.BatchNum = 1;
                        }
                    }
                    Model.StockNum = Model.BatchNum;
                    Model.MaterialCode = MaterialCode;
                    Model.MaterialName = info.MaterialName;
                    Model.BatchNo = BatchNo;
                    Model.Supplier = Supplier;

                    bool flag = DataDAL.Add(Model);
                    if (flag)
                    {
                        ReturnData.Code = "1";
                        ReturnData.Msg = "OK";
                    }

                    BatchNoHisDAL HisDAL = new BatchNoHisDAL();
                    BatchNoHisMDL HisModel = new BatchNoHisMDL();
                    HisModel.MaterialCode = Model.MaterialCode;
                    HisModel.BatchNo = BatchNo;
                    HisModel.BatchNum = Model.BatchNum;
                    HisModel.Supplier = Model.Supplier;
                    HisModel.CreateTime = DateTime.Now;
                    flag = HisDAL.Add(HisModel);
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region 更新批次信息
        /// <summary>
        /// 更新批次信息
        /// </summary>
        private void Update(BatchNoMDL model = null)
        {
            try
            {
                if (model == null)//Insert 方法传过来的
                {
                    this.Insert();
                    return;
                }
                else
                {
                    bool flag = DataDAL.Update(model);
                    if (flag)
                    {
                        ReturnData.Code = "1";
                        ReturnData.Msg = "OK";
                    }

                    BatchNoHisDAL HisDAL = new BatchNoHisDAL();
                    BatchNoHisMDL HisModel = new BatchNoHisMDL();
                    HisModel.MaterialCode = model.MaterialCode;
                    HisModel.BatchNo = model.BatchNo;
                    HisModel.BatchNum = model.BatchNum;
                    HisModel.Supplier = model.Supplier;
                    HisModel.CreateTime = DateTime.Now;
                    flag = HisDAL.Add(HisModel);
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message+ex.StackTrace);
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
                    BatchNoMDL model = DataDAL.GetModel(sql);
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

        #region 检查批次信息
        /// <summary>
        /// 检查批次信息
        /// </summary>
        private void CheckBatchTip()
        {
            try
            {
                string ProductCode = context.Request.Params["ProductCode"].ToString();
                string sql = string.Format("SELECT COUNT(productcode) FROM productbominfo p RIGHT JOIN batchno b ON p.materialcode=b.materialcode WHERE p.productcode='{0}' AND p.tracetype='批次追溯' AND b.stocknum<1",ProductCode);
                object obj = CommonDAL.ExecuteScaler(sql);
                if (obj!=null && int.Parse(obj.ToString())>0)
                {
                    ReturnData.Code = "1";
                    ReturnData.Msg = "OK";
                }
                else
                {
                    ReturnData.Code = "0";
                    ReturnData.Msg = "OK";
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