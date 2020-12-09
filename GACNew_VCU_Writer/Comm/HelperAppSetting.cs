using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace GACNew_VCU_Writer.Comm
{
    public class HelperAppSetting
    {
        /// <summary>
        /// SqlServer数据库连接字符串
        /// </summary>
        public static string SqlServerCnnStr { get { return ConfigurationManager.ConnectionStrings["SqlServerCnnStr"].ConnectionString; } }
    }
}
