using DSG_Group.DGComm;
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
            try
            {
                return await sqlSugarClient.Queryable<T_RunParam>()
               .Where(t => t.Group == group && t.Key == key)
               .Select(t => t.Value).FirstAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<ServiceT_RunParam>("获取参数失败！", ex);
                return null;
            }
        }

        /// <summary>
        /// 修改参数
        /// </summary>
        /// <param name="group"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async static Task<int> Updata(string group, string key, string value)
        {
            try
            {
                return await sqlSugarClient.Updateable<T_RunParam>().SetColumns(t => t.Value == value)
               .Where(t => t.Group == group && t.Key == key).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<ServiceT_RunParam>("修改参数失败！", ex);
                return 0;
            }
        }

        /// <summary>
        /// 获取运行参数
        /// </summary>
        /// <param name="group"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async static Task<DataTable> GetRunParams(string group)
        {
            try
            {
                return await sqlSugarClient.Queryable<T_RunParam>().Where(t => t.Group == group).OrderBy(t => t.ID)
                .Select(t => new
                {
                    编号 = t.ID,
                    组 = t.Group,
                    描述 = t.Description,
                    关键字 = t.Key,
                    值 = t.Value,
                }).ToDataTableAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<ServiceT_RunParam>("获取运行参数失败！", ex);
                return new DataTable();
            }
        }

        /// <summary>
        /// 获取运行参数
        /// </summary>
        /// <returns></returns>
        public async static Task<DataTable> GetRunParams()
        {
            try
            {
                return await sqlSugarClient.Queryable<T_RunParam>().OrderBy(t => t.ID)
               .Select(t => new
               {
                   编号 = t.ID,
                   组 = t.Group,
                   描述 = t.Description,
                   关键字 = t.Key,
                   值 = t.Value,
               }).ToDataTableAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<ServiceT_RunParam>("获取运行参数失败！", ex);
                return new DataTable();
            }
        }

        /// <summary>
        /// 获取运行参数组
        /// </summary>
        /// <param name="group"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async static Task<List<string>> GetGroups()
        {
            try
            {
                return await sqlSugarClient.Queryable<T_RunParam>().Distinct().Select(t => t.Group).ToListAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<ServiceT_RunParam>("获取运行参数组失败！", ex);
                return new List<string>();
            }
        }

        /// <summary>
        /// 修改参数
        /// </summary>
        /// <param name="runParam"></param>
        /// <returns></returns>
        public async static Task<int> Updata(T_RunParam runParam)
        {
            try
            {
                return await sqlSugarClient.Updateable(runParam).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<ServiceT_RunParam>("修改参数失败！", ex);
                return 0;
            }
        }
    }
}
