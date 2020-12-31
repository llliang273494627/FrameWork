using DSG_Group.DGComm;
using FrameWork.Model.DFPV_DSG101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.SqlServers
{
    public class Service_vincoll : FrameWork.Model.Comm.HelperSqlsugar
    {
        /// <summary>
        /// 初始化表
        /// </summary>
        /// <returns></returns>
        public async static Task<int> Deleteable()
        {
            try
            {
                return await sqlSugarClient.Deleteable<vincoll>().ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("删除数据失败！", ex);
                return 0;
            }
        }

        /// <summary>
        /// 获取所有 VIN 码
        /// </summary>
        /// <returns></returns>
        public async static Task<List<string>> Queryable()
        {
            try
            {
                return await sqlSugarClient.Queryable<vincoll>().OrderBy(t=>t.ID).Select(t => t.vin).ToListAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("获取所有 VIN 码失败！", ex);
                return null;
            }
        }
    }
}
