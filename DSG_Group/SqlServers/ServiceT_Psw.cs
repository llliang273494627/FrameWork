using FrameWork.Model.DFPV_DSG101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.SqlServers
{
    public class ServiceT_Psw : FrameWork.Model.Comm.HelperSqlsugar
    {
        /// <summary>
        /// 获取第一条数据的密码
        /// </summary>
        /// <returns></returns>
        public async static Task<string> GetPSW()
        {
            return await sqlSugarClient.Queryable<T_Psw>().Select(t => t.psw).FirstAsync();
        }
    }
}
