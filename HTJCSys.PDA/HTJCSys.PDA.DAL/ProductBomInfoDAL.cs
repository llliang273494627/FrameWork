using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using COM;
using XY.Util;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ProductBomInfoDAL
	/// </summary>
	public partial class ProductBomInfoDAL
	{
        string requestUrl = BaseVariable.RequestURL + "ProductBomInfo.ashx";
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MDL.ProductBomInfoMDL GetModel(string TID, string ProductType, string ProductCode, string MaterialCode, string TraceType)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("do", "get");
            dict.Add("method", "model");
            dict.Add("TID", TID);
            dict.Add("ProductType", ProductType);
            dict.Add("ProductCode", ProductCode);
            dict.Add("MaterialCode", MaterialCode);
            dict.Add("TraceType", TraceType);
            string str = Http.POST(requestUrl, dict);
            var obj = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
            ReturnInfo ReturnData = (ReturnInfo)obj;
            if (ReturnData != null && ReturnData.Code == "1")
            {
                var data = JsonHelper.JsonDeSerializer<MDL.ProductBomInfoMDL>(ReturnData.Data.ToString());
                MDL.ProductBomInfoMDL Model = (MDL.ProductBomInfoMDL)data;
                return Model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个DataTable
        /// </summary>
        /// <param name="ProductType"></param>
        /// <param name="ProductCode"></param>
        /// <param name="MaterialCode"></param>
        /// <param name="TraceType">0:扫描/批次追溯;1:扫描追溯;2:批次追溯</param>
        /// <returns></returns>
        public DataTable GetDataTable(string ProductType, string ProductCode, string MaterialCode, string TraceType)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("do", "get");
            dict.Add("method", "search");
            dict.Add("ProductType", ProductType);
            dict.Add("ProductCode", ProductCode);
            dict.Add("MaterialCode", MaterialCode);
            dict.Add("TraceType", TraceType);
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

		#region  BasicMethod
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MDL.ProductBomInfoMDL DataRowToModel(DataRow row)
		{
			MDL.ProductBomInfoMDL model=new MDL.ProductBomInfoMDL();
			if (row != null)
			{
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=long.Parse(row["TID"].ToString());
				}
				if(row["ProductType"]!=null)
				{
					model.ProductType=row["ProductType"].ToString();
				}
				if(row["ProductCode"]!=null)
				{
					model.ProductCode=row["ProductCode"].ToString();
				}
				if(row["ProductName"]!=null)
				{
					model.ProductName=row["ProductName"].ToString();
				}
				if(row["MaterialCode"]!=null)
				{
					model.MaterialCode=row["MaterialCode"].ToString();
				}
				if(row["MaterialName"]!=null)
				{
					model.MaterialName=row["MaterialName"].ToString();
				}
				if(row["MaterialNum"]!=null && row["MaterialNum"].ToString()!="")
				{
					model.MaterialNum=int.Parse(row["MaterialNum"].ToString());
				}
				if(row["FeatureIndex"]!=null)
				{
					model.FeatureIndex=row["FeatureIndex"].ToString();
				}
				if(row["FeatureCode"]!=null)
				{
					model.FeatureCode=row["FeatureCode"].ToString();
                }
                if (row["BatchNum"] != null && row["BatchNum"].ToString() != "")
                {
                    model.BatchNum = int.Parse(row["BatchNum"].ToString());
                }
                //if (row["ScannerID"] != null)
                //{
                //    model.ScannerID = row["ScannerID"].ToString();
                //}
                if (row["TraceType"] != null)
                {
                    model.TraceType = row["TraceType"].ToString();
                }
				if(row["Desc"]!=null)
				{
					model.Desc=row["Desc"].ToString();
				}
			}
			return model;
		}
		#endregion  BasicMethod
	}
}

