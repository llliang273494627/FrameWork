using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DSGTest.Common.Helper
{
    public  class HelperLogger
    {
        private static void LogWrite(string dirPath, string fileName, string message)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), dirPath);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string fileFullName = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(fileFullName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                StreamWriter write = new StreamWriter(stream);
                write.WriteLine(DateTime.Now.ToString() + " " + message);
                write.Flush();
                write.Close();
            }
        }

        public static void LogInfo(string msg)
        {
            LogWrite("Log", DateTime.Now.ToString("yyyyMMdd") + "_Log.txt", msg);
        }
        public static void LogError(Exception ex)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(ex.Message);
            str.AppendLine(ex.StackTrace);
            LogWrite("Log", DateTime.Now.ToString("yyyyMMdd") + "_Error.txt", str.ToString());
        }
        public static void LogError(string msg, Exception ex)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(msg);
            str.AppendLine(ex.Message);
            str.AppendLine(ex.StackTrace);
            LogWrite("Log", DateTime.Now.ToString("yyyyMMdd") + "_Error.txt", str.ToString());
        }
        public static void SensorLogWritter(string msg)
        {
            LogWrite("SensorLog", DateTime.Now.ToString("yyyyMMdd") + "_Log.txt", msg);
        }

    }
}
