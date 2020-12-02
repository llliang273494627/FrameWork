using System;
using System.Data;
using System.Text;
using COM;
using System.Collections.Generic;
using XY.Util;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ProductInfo
	/// </summary>
	public partial class ProductInfoDAL
	{
        string requestUrl = BaseVariable.RequestURL + "ProductInfo.ashx";
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MDL.ProductInfoMDL GetModel(string TID, string ProductCode)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("do", "get");
            dict.Add("method", "model");
            dict.Add("TID", TID);
            dict.Add("ProductCode", ProductCode);
            string str = Http.POST(requestUrl, dict);
            var obj = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
            ReturnInfo ReturnData = (ReturnInfo)obj;
            if (ReturnData != null && ReturnData.Code == "1")
            {
                var data = JsonHelper.JsonDeSerializer<MDL.ProductInfoMDL>(ReturnData.Data.ToString());
                MDL.ProductInfoMDL Model = (MDL.ProductInfoMDL)data;
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
        public DataTable GetDataTable(string ProductType)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("do", "get");
            dict.Add("method", "search");
            dict.Add("ProductType", ProductType);
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
		public MDL.ProductInfoMDL DataRowToModel(DataRow row)
		{
			MDL.ProductInfoMDL model=new MDL.ProductInfoMDL();
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
				if(row["FeatureIndex"]!=null)
				{
					model.FeatureIndex=row["FeatureIndex"].ToString();
				}
				if(row["FeatureCode"]!=null)
				{
					model.FeatureCode=row["FeatureCode"].ToString();
				}
				if(row["BarCodeCount"]!=null)
				{
					model.BarCodeCount=row["BarCodeCount"].ToString();
                }
                if (row["HaveSub"] != null && row["HaveSub"].ToString() != "")
                {
                    if ((row["HaveSub"].ToString() == "1") || (row["HaveSub"].ToString().ToLower() == "true"))
                    {
                        model.HaveSub = true;
                    }
                    else
                    {
                        model.HaveSub = false;
                    }
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

