using FrameWork.Model.Comm;
using FrameWork.Model.DFPV_DSG101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.SqlServers
{
    public class ServiceT_Psw : HelperSqlsugar
    {
        public async static Task<string> GetPSW()
        {
            return await sqlSugarClient.Queryable<T_Psw>().Select(t => t.psw).FirstAsync();
        }
    }
}
