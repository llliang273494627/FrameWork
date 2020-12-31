using DSG_Group.DGComm;
using FrameWork.Model.DFPV_DSG101;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.SqlServers
{
    public class Service_T_Psw : FrameWork.Model.Comm.HelperSqlsugar
    {
        /// <summary>
        /// 获取第一条数据的密码
        /// </summary>
        /// <returns></returns>
        public async static Task<string> GetPSW()
        {
            try
            {
                return await sqlSugarClient.Queryable<T_Psw>().Select(t => t.psw).FirstAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<Service_T_Psw>("获取密码！", ex);
                return null;
            }
            
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public async static Task<int> Updateable(string pwd)
        {
            try
            {
                SugarParameter[] sp = new SugarParameter[1];
                sp[0]= new SugarParameter("psw", pwd);
                return await sqlSugarClient.Ado.GetCommand("UPDATE T_Psw SET psw = @psw",sp).ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<Service_T_Psw>("修改密码失败！", ex);
                return 0;
            }

        }
    }
}
