using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using COM;
using System.Data;
using System.Reflection;
using XY.Util;

namespace DAL
{
    public class ResultDAL
    {
        static string requestUrl = BaseVariable.RequestURL + "v2/Result.ashx";

        #region 添加结果信息
        /// <summary>
        /// 添加结果信息
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="HJBarCode"></param>
        /// <param name="ProductCode"></param>
        /// <param name="ProductType"></param>
        /// <param name="UserID"></param>
        /// <param name="StationID"></param>
        /// <param name="ScanType"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Insert(string TableName, string HJBarCode, string ProductCode, string ProductType, string UserID, string StationID, int ScanType, object obj)
        {
            try
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                object data = new { TableName = TableName, HJBarCode = HJBarCode, ProductCode = ProductCode, ProductType = ProductType, UserID = UserID, StationID = StationID, ScanType = ScanType, data = obj };
                string str = JsonHelper.JsonSerializerObj(data);
                dict.Add("do", "add");
                dict.Add("param", str);
                str = Http.POST(requestUrl, dict);
                var rs = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
                ReturnInfo ReturnData = (ReturnInfo)rs;
                if (ReturnData != null && ReturnData.Code == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                return false;
            }
        } 
        #endregion

        #region 上传结果信息
        /// <summary>
        /// 上传结果信息
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="HJBarCode"></param>
        /// <param name="ProductCode"></param>
        /// <param name="ProductType"></param>
        /// <param name="UserID"></param>
        /// <param name="StationID"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Upload(string LineType,string TableName,DataTable table)
        {
            try
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                object obj = TableHelper.TableToObj(table);
                object data = new { LineType = LineType, TableName = TableName, data = obj };
                string str = JsonHelper.JsonSerializerObj(data);
                dict.Add("do", "upload");
                dict.Add("param", str);
                str = Http.POST(requestUrl, dict);
                var rs = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
                ReturnInfo ReturnData = (ReturnInfo)rs;
                if (ReturnData != null && ReturnData.Code == "1")
                {
                    return ReturnData.Data.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                return "";
            }
        }
        #endregion

        #region 返修结果信息
        /// <summary>
        /// 返修结果信息
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="HJBarCode"></param>
        /// <param name="ProductCode"></param>
        /// <param name="ProductType"></param>
        /// <param name="UserID"></param>
        /// <param name="StationID"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int Update(string TableName, string HJBarCode, string ProductCode, string ProductType, string UserID, string StationID, object obj)
        {
            try
            {
                string url = BaseVariable.RequestURL + "v2/Repair.ashx";
                Dictionary<string, object> dict = new Dictionary<string, object>();
                object data = new { TableName = TableName, HJBarCode = HJBarCode, ProductCode = ProductCode, ProductType = ProductType, UserID = UserID, StationID = StationID, data = obj };
                string str = JsonHelper.JsonSerializerObj(data);
                dict.Add("do", "update");
                dict.Add("param", str);
                str = Http.POST(url, dict);
                var rs = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
                ReturnInfo ReturnData = (ReturnInfo)rs;
                if (ReturnData != null && ReturnData.Code == "1")
                {
                    return 1;
                }
                else if (ReturnData != null && ReturnData.Code == "201")
                {
                    return 201;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                return 0;
            }
        }
        #endregion

        public static bool Validate(string TableName, string BarCode, string ProductCode, int type, string Filed)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("do", "validate");
            dict.Add("TableName", TableName);
            dict.Add("BarCode", BarCode);
            dict.Add("Type", type);
            dict.Add("ProductCode", ProductCode);
            dict.Add("Filed", Filed);

            string str = Http.POST(requestUrl, dict);
            var obj = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
            ReturnInfo ReturnData = (ReturnInfo)obj;
            if (ReturnData != null && ReturnData.Code == "1")
            {
                return true;
            }

            return false;
        }
    }
}
