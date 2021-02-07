using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTest.Common.SqlServive.Sql_DPCAWH1_DSG101
{
    public class HelperMod
    {
        public static string getConfigValue(string  tableName , string group , string key )
        {
            string value = string.Empty;
            switch (tableName)
            {
                case "T_RunParam":
                    value = ServiceT_RunParam.GetValue(group, key);
                    break;
            }
            return value;
        }
    }
}
