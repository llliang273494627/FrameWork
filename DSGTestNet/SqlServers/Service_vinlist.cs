using DSGTestNet.Helper;
using FrameWork.Model.DPCAWH1_DSG101;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.SqlServers
{
    public class Service_vinlist : FrameWork.Model.Comm.HelperSqlsugar
    {
        /// <summary>
        /// 查找第一条数据
        /// </summary>
        /// <returns></returns>
        public async static Task<int> QueryableFirst(string vin)
        {
            try
            {
                return await sqlSugarClient.Queryable<vinlist>().Where(t => t.vin == vin).OrderBy(t => t.uw5anoseq, OrderByType.Desc).Select(t=>t.uw5anoseq).FirstAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("获取所有 VIN 码失败！", ex);
                return 0;
            }
        }

        public async static Task<List <string>> QueryableVINs(int uw5)
        {
            try
            {
                return await sqlSugarClient.Queryable<vinlist>().Where(t => t.uw5anoseq > uw5).OrderBy (t => t.uw5anoseq, OrderByType.Desc).Select(t => t.vin).ToListAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("获取所有 VIN 码失败！", ex);
                return null ;
            }
        }
    }
}
