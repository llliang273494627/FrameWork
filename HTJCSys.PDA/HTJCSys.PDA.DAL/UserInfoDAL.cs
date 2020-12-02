using System;
using System.Data;
using System.Text;
using COM;
using System.Collections.Generic;
using XY.Util;

namespace DAL
{
	/// <summary>
    /// 数据访问类:UserInfoDAL
	/// </summary>
	public partial class UserInfoDAL
	{
        string requestUrl = BaseVariable.RequestURL+"UserInfo.ashx";
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MDL.UserInfoMDL GetModel(string UserID)
		{
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("do", "get");
            dict.Add("method", "model");
            dict.Add("UserID", UserID);
			string str = Http.POST(requestUrl,dict);
            var obj = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
            ReturnInfo ReturnData = (ReturnInfo)obj;
            if (ReturnData!=null && ReturnData.Code=="1")
            {
                var data = JsonHelper.JsonDeSerializer<MDL.UserInfoMDL>(ReturnData.Data.ToString());
                MDL.UserInfoMDL Model = (MDL.UserInfoMDL)data;
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

		#region  BasicMethod
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MDL.UserInfoMDL DataRowToModel(DataRow row)
		{
			MDL.UserInfoMDL model=new MDL.UserInfoMDL();
			if (row != null)
			{
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=long.Parse(row["TID"].ToString());
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserSex"]!=null)
				{
					model.UserSex=row["UserSex"].ToString();
				}
				if(row["UserPwd"]!=null)
				{
					model.UserPwd=row["UserPwd"].ToString();
				}
				if(row["PhoneNum"]!=null)
				{
					model.PhoneNum=row["PhoneNum"].ToString();
				}
				if(row["Department"]!=null)
				{
					model.Department=row["Department"].ToString();
				}
				if(row["RoleName"]!=null)
				{
					model.RoleName=row["RoleName"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
			}
			return model;
        }
        #endregion
    }
}

