using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Common.Logging;

namespace GACNew_VCU_Writer
{
    class Log
    {
        /// <summary>
        /// 日志对象
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(FrmMain));
        /// <summary>
        /// 记录故障信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        public static void writeTxt(string content, string path)
        {
            try
            {
                //logger.Info(content);
                string time = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string filePath;
                if (path == "")
                {
                    filePath = System.Windows.Forms.Application.StartupPath + "//Logs//" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                }
                else
                {
                    filePath = path;
                }

                if (!File.Exists(filePath))
                    System.IO.File.Create(filePath).Close();
                //FileStream fst = new FileStream(filePath, FileMode.Append);
                //写数据到a.txt格式
                StreamWriter swt = new StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("utf-8"));
                //写入 
                swt.Write("[" + time + "] " + content);
                swt.WriteLine("");
                swt.Close();
                swt.Dispose();
                //fst.Close();
            }
            catch
            {

            }
        }

        public static void writeTxt(string content, string path, string splite,string vin)
        {
            try
            {
                //logger.Info(content);
                string time = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string filePath;
                if (path == "")
                {
                    filePath = System.Windows.Forms.Application.StartupPath + "//Logs//" + splite + "号刷写口" +"--"+vin.Substring(12,5)+"--"+ DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                }
                else
                {
                    filePath = path;
                }

                if (!File.Exists(filePath))
                    System.IO.File.Create(filePath).Close();
                //FileStream fst = new FileStream(filePath, FileMode.Append);
                //写数据到a.txt格式
                StreamWriter swt = new StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("utf-8"));
                //写入 
                swt.Write("[" + time + "] " + content);
                swt.WriteLine("");
                swt.Close();
                swt.Dispose();
                //fst.Close();
            }
            catch
            {

            }
        }

        /// <summary>
        /// 删除多少天前的日志文件
        /// </summary>
        /// <param name="dayNum"></param>
        public static void DeleteLog(int dayNum)
        {
            string time = System.DateTime.Now.ToString();
            string filePath = System.Windows.Forms.Application.StartupPath + "\\Logs\\";
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            string[] files = Directory.GetFiles(filePath, "*.txt", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string s = file;
                FileInfo f = new FileInfo(s);
                DateTime nowtime = DateTime.Now;
                TimeSpan t = nowtime - f.CreationTime;
                int day = t.Days;
                if (day > dayNum)
                {
                    File.Delete(s);
                }
            }
        }
        /// <summary>
        /// 获取日志字符串
        /// </summary>
        /// <param name="content"></param>
        public static string ConvertToLog(string log)
        {
            string time = System.DateTime.Now.ToString();
            return "[" + time + "] " + log;
        }

        public static void Info(string msg)
        {
            logger.Info(msg);
        }

        public static void Error(object message, Exception exception)
        {
            logger.Error(message, exception);
        }

        public static void Error(object message)
        {
            logger.Error(message);
        }
    }
}
