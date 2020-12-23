using FrameWork.Model.DFPV_DSG101;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.SqlServers
{
    public class ServiceT_RunParam : FrameWork.Model.Comm.HelperSqlsugar
    {
        public async static Task<string> GetValue(string group, string key)
        {
            return await sqlSugarClient.Queryable<T_RunParam>()
                .Where(t => t.Group == group && t.Key == key)
                .Select(t => t.Value).FirstAsync();
        }

        /// <summary>
        /// 获取运行参数
        /// </summary>
        /// <param name="group"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async static Task<DataTable> GetRunParams(string group)
        {
            return await sqlSugarClient.Queryable<T_RunParam>().Where(t => t.Group == group)
                .Select(t => new
                {
                    编号 = t.ID,
                    组 = t.Group,
                    描述 = t.Description,
                    关键字 = t.Key,
                    值 = t.Value,
                }).ToDataTableAsync();
        }

        /// <summary>
        /// 获取运行参数组
        /// </summary>
        /// <param name="group"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async static Task<List<string>> GetGroups()
        {
            return await sqlSugarClient.Queryable<T_RunParam>() .Select(t => t.Group).ToListAsync();
        }
    }
}
