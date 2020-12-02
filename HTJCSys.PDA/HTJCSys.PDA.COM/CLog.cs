using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace COM
{
    /// <summary>
    /// 日志类
    /// </summary>
    public static class CLog
    {
        private static string LogPath = BaseVariable.LogPath;

        /// <summary>
        /// 将操作日志写入txt文件
        /// </summary>
        /// <param name="logType">日志类型，如:Err,是指错误日志；如Sys，是指正常的操作日志</param>
        /// <param name="logDesc">日志描述</param>
        private static void WriteLog(string logType, string logDesc)
        {
            try
            {
                string filePath = LogPath;
                string fileName = "";
                if (logType == "Sys")
                {
                    //将日志按时间的小时段来分开记录，因为日志量太大
                    filePath += "Sys\\";
                    fileName = String.Format("{0}_{1}.txt", DateTime.Now.ToString("yyyy-MM-dd"), ConvertHourToPartStr());
                }
                else if (!string.IsNullOrEmpty(logType) && !logType.Equals("Sys") && !logType.Equals("Err"))
                {
                    filePath += ""+logType+"\\";
                    fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                }
                else
                {
                    filePath += "Err\\";
                    fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                }                
                //判断是否存在Log文件夹
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                filePath += fileName;

                if (logDesc.Contains("\r\n"))
                {
                    logDesc = logDesc.Replace("\r\n", "") + "\r\n";
                }

                StreamWriter streamWriter = new StreamWriter(filePath, true);
                streamWriter.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]" + logDesc);
                streamWriter.Close();
                streamWriter.Dispose();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 将当前时间的小时分段后按字符串返回
        /// </summary>
        /// <returns></returns>
        private static string ConvertHourToPartStr()
        {
            string partStr = String.Empty;
            try
            {
                int hour = DateTime.Now.Hour;
                if (hour >= 0 && hour <= 4)
                {
                    partStr = "00_04";
                }
                else if (hour >= 5 && hour <= 8)
                {
                    partStr = "05_08";
                }
                else if (hour >= 9 && hour <= 12)
                {
                    partStr = "09_12";
                }
                else if (hour >= 13 && hour <= 16)
                {
                    partStr = "13_16";
                }
                else if (hour >= 17 && hour <= 20)
                {
                    partStr = "17_20";
                }
                else if (hour >= 21)
                {
                    partStr = "21_23";
                }
            }
            catch (Exception)
            {
                
            }
            return partStr;
        }

        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="logDesc"></param>
        public static void WriteErrLog(string logDesc)
        {
            WriteLog("Err", String.Format("[{0}]", logDesc));
        }

        /// <summary>
        /// 写错误日志，系统自动记录发生错误的方法的空间名.类名.方法名
        /// </summary>
        /// <param name="logDesc"></param>
        public static void WriteErrLogInTrace(string logDesc)
        {
            //StackTrace trace = new StackTrace(true);
            //MethodBase meth = trace.GetFrame(1).GetMethod();

            //WriteLog("Err", String.Format("[From:{0}.{1},Err:{2}]", meth.DeclaringType.FullName, meth.Name, logDesc));
        }

        /// <summary>
        /// 写操作日志
        /// </summary>
        /// <param name="logDesc"></param>
        public static void WriteSysLog(string logDesc)
        {
            WriteLog("Sys", String.Format("[{0}]", logDesc));
        }

        /// <summary>
        /// 根据工位号来写日志
        /// </summary>
        /// <param name="stationID"></param>
        /// <param name="logDesc"></param>
        public static void WriteStationLog(string stationID,string logDesc)
        {
            WriteLog(stationID, String.Format("[{0}]", logDesc));
        }
    }
}
