﻿using COM;
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
    /// DeviceInfo 的摘要说明
    /// </summary>
    public class DeviceInfo : IHttpHandler
    {

        DeviceInfoDAL DataDAL = new DeviceInfoDAL();
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
                        this.Select();
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
            }
            finally
            {
                context.Response.Write(JsonHelper.JsonSerializer(ReturnData));
            }
        }
        #endregion

        #region 获取设备信息
        /// <summary>
        /// 获取设备信息
        /// </summary>
        private void Select()
        {
            try
            {
                string method = context.Request.Params["method"].ToString();
                if (method == "model")
                {
                    string TID = context.Request.Params["TID"].ToString();
                    string DeviceID = context.Request.Params["DeviceID"].ToString();
                    string DeviceIP = context.Request.Params["DeviceIP"].ToString();
                    string sql = " 1=1 ";
                    if (!string.IsNullOrEmpty(TID))
                    {
                        sql += string.Format(" AND TID = {0}", TID);
                    }
                    if (!string.IsNullOrEmpty(DeviceID))
                    {
                        sql += string.Format(" AND DeviceID = '{0}'", DeviceID);
                    }
                    if (!string.IsNullOrEmpty(DeviceIP))
                    {
                        sql += string.Format(" AND DeviceIP = '{0}'", DeviceIP);
                    }
                    DeviceInfoMDL model = DataDAL.GetModel(sql);
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