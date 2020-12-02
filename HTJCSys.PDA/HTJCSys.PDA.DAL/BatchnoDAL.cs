using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MDL;
using System.Data;
using COM;
using XY.Util;

namespace DAL
{
    public class BatchNoDAL
    {

        string requestUrl = BaseVariable.RequestURL + "v2/Batch.ashx";

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MDL.BatchNoMDL GetModel(long TID)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("do", "get");
            dict.Add("method", "model");
            dict.Add("TID", TID);
            string str = Http.POST(requestUrl, dict);
            var obj = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
            ReturnInfo ReturnData = (ReturnInfo)obj;
            if (ReturnData != null && ReturnData.Code == "1")
            {
                var data = JsonHelper.JsonDeSerializer<MDL.BatchNoMDL>(ReturnData.Data.ToString());
                MDL.BatchNoMDL Model = (MDL.BatchNoMDL)data;
                return Model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 新增批次信息
        /// <summary>
        /// 新增批次信息
        /// </summary>
        /// <param name="ProductType">产品类型</param>
        /// <param name="model">批次信息</param>
        /// <returns></returns>
        public bool Insert(BatchNoMDL model)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("do", "add");
            dict.Add("ProductType", model.ProductType);
            dict.Add("BarCode", model.BarCode);
            dict.Add("MaterialCode", model.MaterialCode);
            dict.Add("MaterialName", model.MaterialName);
            dict.Add("BatchNo", model.BatchNo);
            dict.Add("BatchNum", model.BatchNum);
            dict.Add("Supplier", model.Supplier);
            string str = Http.POST(requestUrl, dict);
            var obj = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
            ReturnInfo ReturnData = (ReturnInfo)obj;
            if (ReturnData != null && ReturnData.Code == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 上传批次信息
        /// <summary>
        /// 上传批次信息
        /// </summary>
        /// <param name="table">上传批次信息集合</param>
        /// <returns></returns>
        public string Upload(DataTable table)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("do", "upload");

            string data = JsonHelper.JsonSerializerObj(table);

            dict.Add("param", data);

            string str = Http.POST(requestUrl, dict);
            var obj = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
            ReturnInfo ReturnData = (ReturnInfo)obj;
            if (ReturnData != null && ReturnData.Code == "1")
            {
                return ReturnData.Data.ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 得到一个DataTable
        /// <summary>
        /// 得到一个DataTable
        /// </summary>
        /// <param name="ProductCode"></param>
        /// <param name="ProductType"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string ProductCode, string ProductType,string TableName)
        {
            try
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("do", "get");
                dict.Add("method", "search");
                dict.Add("ProductCode", ProductCode);
                dict.Add("ProductType", ProductType);
                dict.Add("TableName", TableName);
                string str = Http.POST(requestUrl, dict);
                var obj = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
                ReturnInfo ReturnData = (ReturnInfo)obj;
                if (ReturnData != null && ReturnData.Code == "1")
                {
                    var data = JsonHelper.JsonDeSerializer<DataTable>(ReturnData.Data.ToString());
                    DataTable table = (DataTable)data;
                    return table;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                return null;
            }
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BatchNoMDL DataRowToModel(DataRow row)
        {
            BatchNoMDL model = new BatchNoMDL();
            if (row != null)
            {
                if (row["TID"] != null && row["TID"].ToString() != "")
                {
                    model.TID = long.Parse(row["TID"].ToString());
                }
                if (row["MaterialCode"] != null)
                {
                    model.MaterialCode = row["MaterialCode"].ToString();
                }
                if (row["MaterialName"] != null)
                {
                    model.MaterialName = row["MaterialName"].ToString();
                }
                if (row["BatchNo"] != null)
                {
                    model.BatchNo = row["BatchNo"].ToString();
                }
                if (row["BatchNum"] != null && row["BatchNum"].ToString() != "")
                {
                    model.BatchNum = int.Parse(row["BatchNum"].ToString());
                }
                if (row["StockNum"] != null && row["StockNum"].ToString() != "")
                {
                    model.StockNum = int.Parse(row["StockNum"].ToString());
                }
                if (row["Supplier"] != null)
                {
                    model.Supplier = row["Supplier"].ToString();
                }
            }
            return model;
        } 
        #endregion
    }
}
