using FrameWork.Model.DPCAWH1_DSG101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTest.Common.SqlServive.Sql_DPCAWH1_DSG101
{
    public class ServiceT_Result : FrameWork.Model.Comm.HelperSqlsugar
    {
        public static T_Result Queryable(string vin)
        {
            return sqlSugarClient.Queryable<T_Result>().Where(t => t.VIN == vin).First();
        }
    }
}
