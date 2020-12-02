using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MDL;
using System.Reflection;
using System.Data;

namespace COM
{
    /// <summary>
    /// 基本变量类，如数据库连接字符串
    /// </summary>
    public static class BaseVariable
    {
        /// <summary>
        /// 远程请求的URL
        /// </summary>
        public static string RequestURL = "";//http://192.168.0.100:1216/

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string DBConnStr = String.Empty;

        /// <summary>
        /// 应用的根路径
        /// </summary>
        public static string APPRootPath = String.Empty;

        /// <summary>
        /// XML文件路径
        /// </summary>
        public static string XmlFilePath = String.Empty;

        /// <summary>
        /// 当前登陆的用户实体
        /// </summary>
        public static UserInfoMDL UserEntity = null;

        /// <summary>
        /// 当前设备工位信息实体
        /// </summary>
        public static DeviceInfoMDL DeviceEntity = null;

        /// <summary>
        /// 日志文件路径
        /// </summary>
        public static string LogPath = String.Empty;

        /// <summary>
        ///  本地数据库文件路径
        /// </summary>
        public static string LocalDbPath = String.Empty;

        /// <summary>
        /// 是否创建数据库和数据表
        /// </summary>
        public static bool IsCreateTable = false;
       
        /// <summary>
        /// 全局网络连接状态
        /// </summary>
        public static bool NetworkStatus = false;

        /// <summary>
        /// 全局服务器连接状态
        /// </summary>
        public static bool ServerStatus = false;

        /// <summary>
        /// 扫描成功的声音路径
        /// </summary>
        public static string ScanSound = string.Empty;
        /// <summary>
        /// 错误的声音路径
        /// </summary>
        public static string ErrorSound = string.Empty;
        /// <summary>
        /// 正确的声音路径
        /// </summary>
        public static string OkSound = string.Empty;
        /// <summary>
        /// 第一次运行
        /// </summary>
        public static bool IsRunFirst = false;
        /// <summary>
        /// 类型对应结果表
        /// </summary>
        public static string ResultTableName = null;
        /// <summary>
        /// 扫描发生
        /// </summary>
        public static bool ScanIsSound = false;
        /// <summary>
        /// 扫描震动
        /// </summary>
        public static bool ScanIsShake = false;
        /// <summary>
        /// 扫描打开LED灯
        /// </summary>
        public static bool ScanIsLED = false;

        /// <summary>
        /// 全局产品表
        /// </summary>
        public static DataTable ProductTable = null;

        /// <summary>
        /// 初始化系统变量
        /// </summary>
        public static void InitXmlVar()
        {
            APPRootPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\";
            LocalDbPath = APPRootPath + "LocalData.db";
            LogPath = APPRootPath + "logs\\";
            XmlFilePath = APPRootPath + "Config.xml";
            ScanSound = APPRootPath + "beeph.wav";
            ErrorSound = APPRootPath + "error.wav";
            OkSound = APPRootPath + "ok.wav";
        }

        #region 根据时间按写日志
        /// <summary>
        /// 根据时间按写日志
        /// </summary>
        /// <param name="span"></param>
        /// <param name="msg"></param>
        public static void WirteTimeSpanLog(TimeSpan span, LogType type)
        {
            try
            {
                if (span.TotalSeconds > 1)
                {
                    string msg = "";
                    switch (type)
                    {
                        case LogType.SP://合件
                            msg = "扫描合件";
                            break;
                        case LogType.SC://子件
                            msg = "扫描子件";
                            break;
                        case LogType.Y1://验证合件
                            msg = "验证合件";
                            break;
                        case LogType.Y2://验证子件
                            msg = "验证子件";
                            break;
                        case LogType.V0://声音Error
                            msg = "错误提示音";
                            break;
                        case LogType.V1://扫描OK
                            msg = "扫描提示音";
                            break;
                        case LogType.V2://声音OK
                            msg = "正确提示音";
                            break;
                        case LogType.RD://插入到数据库
                            msg = "更新到数据库";
                            break;
                        case LogType.DBOPEN://数据库连接OPEN
                            msg = "数据库连接OPEN";
                            break;
                        case LogType.DBEXECUTE://执行SQL语句
                            msg = "执行SQL语句";
                            break;
                        case LogType.REQUEST://执行SQL语句
                            msg = "Request请求";
                            break;
                    }
                    CLog.WriteStationLog("scan", msg + ":" + span);
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmScan.WirteTimeSpanLog]" + ex.Message);
            }
        }
        #endregion
    }

    #region 日志类型结构体
    /// <summary>
    /// 日志类型结构体
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 扫描合件
        /// </summary>
        SP,

        /// <summary>
        /// 扫描子件
        /// </summary>
        SC,

        /// <summary>
        /// 验证合件
        /// </summary>
        Y1,

        /// <summary>
        /// 验证子件
        /// </summary>
        Y2,

        /// <summary>
        /// 错误提示音
        /// </summary>
        V0,

        /// <summary>
        /// 扫描提示音
        /// </summary>
        V1,

        /// <summary>
        /// 正确提示音
        /// </summary>
        V2,

        /// <summary>
        /// 记录到数据库
        /// </summary>
        RD,

        /// <summary>
        /// 数据库连接Open
        /// </summary>
        DBOPEN,

        /// <summary>
        /// 数据库连接查询
        /// </summary>
        DBSELECT,

        /// <summary>
        /// 数据库连接执行
        /// </summary>
        DBEXECUTE,

        /// <summary>
        /// request请求
        /// </summary>
        REQUEST,
    }
    #endregion
}