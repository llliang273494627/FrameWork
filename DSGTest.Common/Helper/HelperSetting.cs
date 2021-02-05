using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTest.Common.Helper
{
    public class HelperSetting
    {
        public static string ConnecString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnecString"].ConnectionString;
    }
}
