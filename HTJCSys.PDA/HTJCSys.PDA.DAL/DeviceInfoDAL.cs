using System;
using System.Data;
using System.Text;
using COM;
using System.Collections.Generic;
using XY.Util;

namespace DAL
{
	/// <summary>
    /// 数据访问类:DeviceInfoDAL
	/// </summary>
	public partial class DeviceInfoDAL
	{
        string requestUrl = BaseVariable.RequestURL + "DeviceInfo.ashx";
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MDL.DeviceInfoMDL GetModel(string TID,string DeviceID,string IP)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("do", "get");
            dict.Add("method", "model");
            dict.Add("TID", TID);
            dict.Add("DeviceID", DeviceID);
            dict.Add("DeviceIP", IP);
            string str = Http.POST(requestUrl, dict);
            var obj = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
            ReturnInfo ReturnData = (ReturnInfo)obj;
            if (ReturnData != null && ReturnData.Code == "1")
            {
                var data = JsonHelper.JsonDeSerializer<MDL.DeviceInfoMDL>(ReturnData.Data.ToString());
                MDL.DeviceInfoMDL Model = (MDL.DeviceInfoMDL)data;
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
        public DataTable GetAll()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("do", "get");
            dict.Add("method", "all");
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

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MDL.DeviceInfoMDL DataRowToModel(DataRow row)
		{
			MDL.DeviceInfoMDL model=new MDL.DeviceInfoMDL();
			if (row != null)
			{
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=long.Parse(row["TID"].ToString());
				}
				if(row["DeviceType"]!=null)
				{
					model.DeviceType=row["DeviceType"].ToString();
				}
				if(row["DeviceID"]!=null)
				{
					model.DeviceID=row["DeviceID"].ToString();
				}
				if(row["DeviceName"]!=null)
				{
					model.DeviceName=row["DeviceName"].ToString();
				}
				if(row["DeviceIP"]!=null)
				{
					model.DeviceIP=row["DeviceIP"].ToString();
				}
				if(row["ProductType"]!=null)
				{
					model.ProductType=row["ProductType"].ToString();
                }
                if (row["DeviceState"] != null && row["DeviceState"].ToString() != "")
                {
                    model.DeviceState = int.Parse(row["DeviceState"].ToString());
                }
                if (row["StationID"] != null)
                {
                    model.StationID = row["StationID"].ToString();
                }
				if(row["Desc"]!=null)
				{
					model.Desc=row["Desc"].ToString();
				}
			}
			return model;
		}
	}
}