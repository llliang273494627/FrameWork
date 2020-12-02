using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using COM;
using XY.Util;

namespace DAL
{
    public class MaterialFieldDAL
    {
        string requestUrl = BaseVariable.RequestURL + "MaterialField.ashx";
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MDL.MaterialFieldMDL GetModel(string MaterialCode)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("do", "get");
            dict.Add("method", "model");
            dict.Add("MaterialCode", MaterialCode);
            string str = Http.POST(requestUrl, dict);
            var obj = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
            ReturnInfo ReturnData = (ReturnInfo)obj;
            if (ReturnData != null && ReturnData.Code == "1")
            {
                var data = JsonHelper.JsonDeSerializer<MDL.MaterialFieldMDL>(ReturnData.Data.ToString());
                MDL.MaterialFieldMDL Model = (MDL.MaterialFieldMDL)data;
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
        public DataTable GetDataTable(string MaterialCodeList)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("do", "get");
            dict.Add("method", "search");
            dict.Add("MaterialCodeList", MaterialCodeList);
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
		public MDL.MaterialFieldMDL DataRowToModel(DataRow row)
		{
			MDL.MaterialFieldMDL model=new MDL.MaterialFieldMDL();
			if (row != null)
			{
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=long.Parse(row["TID"].ToString());
				}
				if(row["MaterialCode"]!=null)
				{
					model.MaterialCode=row["MaterialCode"].ToString();
				}
				if(row["MaterialName"]!=null)
				{
					model.MaterialName=row["MaterialName"].ToString();
				}
				if(row["TableName"]!=null)
				{
					model.TableName=row["TableName"].ToString();
				}
				if(row["FieldName"]!=null)
				{
					model.FieldName=row["FieldName"].ToString();
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
