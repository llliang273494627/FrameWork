using COM;
using DAL;
using MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace HTJCSys.WebApi
{
    /// <summary>
    /// User 的摘要说明
    /// </summary>
    public class UserInfo : IHttpHandler
    {
        UserInfoDAL DataDAL = new UserInfoDAL();
        ReturnInfo ReturnData = new ReturnInfo();
        HttpContext context = null;
        public void ProcessRequest(HttpContext _context)
        {
            context = _context;
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
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
                        break;
                    case "get":
                        Select();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                ReturnData.Code = "0";
                ReturnData.Msg = "NOK";
                ReturnData.Data = ex.Message;
            }
            finally
            {
                context.Response.Write(JsonHelper.JsonSerializer(ReturnData));
            }
        }
        #endregion

        #region 获取用户信息
        /// <summary>
        /// 获取用户信息
        /// </summary>
        private void Select()
        {
            try
            {
                string method = context.Request.Params["method"].ToString();
                if (method == "model")
                {
                    string UserID = context.Request.Params["UserID"].ToString();

                    #region 测试乱码
                    //string UserName = HttpUtility.UrlDecode(context.Request.Params["UserName"].ToString(), System.Text.Encoding.GetEncoding("iso-8859-1"));
                    //foreach (EncodingInfo item in Encoding.GetEncodings())
                    //{
                    //    CLog.WriteErrLog("Encoding:" + item.Name);                        
                    //}
                    //CLog.WriteErrLog("000" + UserName);
                    //Encoding gb2312 = Encoding.GetEncoding("GB2312");
                    //UTF8Encoding utf8 = new UTF8Encoding();
                    //ASCIIEncoding ascii = new ASCIIEncoding();
                    //byte[] buffer = utf8.GetBytes(context.Request.Params["UserName"]);
                    //UserName = context.Request.Params["UserName"];
                    //CLog.WriteErrLog("0"+UserName);
                    //UserName = utf8.GetString(buffer);
                    //CLog.WriteErrLog("utf8:" + UserName);
                    //byte[] buffer32 = Encoding.Convert(utf8,gb2312, buffer);
                    //UserName = gb2312.GetString(buffer);
                    //CLog.WriteErrLog("utf8->gb2312:" + UserName);


                    //buffer = gb2312.GetBytes(context.Request.Params["UserName"]);
                    //UserName = gb2312.GetString(buffer);
                    //CLog.WriteErrLog("gb2312:" + UserName);
                    //byte[] buffer8 = Encoding.Convert(gb2312,utf8, buffer);
                    //UserName = utf8.GetString(buffer8);
                    //CLog.WriteErrLog("gb2312->utf8:" + UserName);

                    //buffer = ascii.GetBytes(context.Request.Params["UserName"]);
                    //UserName = ascii.GetString(buffer);
                    //CLog.WriteErrLog("ascii:" + UserName);
                    //buffer8 = Encoding.Convert(ascii, utf8, buffer);
                    //UserName = utf8.GetString(buffer8);
                    //CLog.WriteErrLog("ascii->utf8:" + UserName);
                    //buffer32 = Encoding.Convert(ascii, gb2312, buffer);
                    //UserName = gb2312.GetString(buffer32);
                    //CLog.WriteErrLog("ascii->gb2312:" + UserName);

                    //string UserName = context.Request.Params["UserName"];
                    //CLog.WriteErrLog("Default:" + UserName); 
                    #endregion

                    UserInfoMDL model = DataDAL.GetModel(UserID);
                    if (model != null)
                    {
                        ReturnData.Code = "1";
                        ReturnData.Msg = "OK";
                        ReturnData.Data = model;
                    }
                }
                else
                {
                    DataSet set = DataDAL.GetList("");
                    ReturnData.Code = "0";
                    ReturnData.Msg = "NOK";
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
                ReturnData.Code = "0";
                ReturnData.Msg = "NOK";
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