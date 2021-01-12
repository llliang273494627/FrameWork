using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.Helper
{
    public class HelperSetting
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string ConnString = ConfigurationManager.ConnectionStrings["ConnString"]?.ConnectionString;

        /// <summary>
        /// 版本号
        /// </summary>
        public static string Version = ConfigurationManager.AppSettings["Version"];
    }
}
