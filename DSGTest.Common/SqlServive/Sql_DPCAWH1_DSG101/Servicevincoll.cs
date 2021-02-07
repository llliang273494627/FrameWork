using FrameWork.Model.DPCAWH1_DSG101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTest.Common.SqlServive.Sql_DPCAWH1_DSG101
{
    public class Servicevincoll : FrameWork.Model.Comm.HelperSqlsugar
    {
        public static int delallColl()
        {
            return sqlSugarClient.Deleteable<vincoll>().ExecuteCommand();
        }

        public static int delColl(string vin)
        {
            return sqlSugarClient.Deleteable<vincoll>().Where(t => t.vin.Contains(vin)).ExecuteCommand();
        }

        public static int insertColl(string vin)
        {
            var coll = new vincoll
            {
                vin = vin,
            };
            return sqlSugarClient.Insertable(coll).ExecuteCommand();
        }
    }
}
