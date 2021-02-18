using FrameWork.Model.DPCAWH1_DSG101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTest.Common.SqlServive.Sql_DPCAWH1_DSG101
{
   public  class ServiceT_CtrlParam : FrameWork.Model.Comm.HelperSqlsugar
    {
        public static string GetValue(string group, string key)
        {
            return sqlSugarClient.Queryable<T_CtrlParam>()
                    .Where(t => t.Group == group && t.Key == key)
                    .Select(t => t.Value).First();
        }
    }
}
