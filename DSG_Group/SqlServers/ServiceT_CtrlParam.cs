﻿using DSG_Group.DGComm;
using FrameWork.Model.DFPV_DSG101;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.SqlServers
{
    /// <summary>
    /// 控制参数服务
    /// </summary>
    public class ServiceT_CtrlParam : FrameWork.Model.Comm.HelperSqlsugar
    {
        /// <summary>
        /// 获取控制参数
        /// </summary>
        /// <returns></returns>
        public async static Task<DataTable> GetCtrlParams()
        {
            try
            {
                return await sqlSugarClient.Queryable<T_CtrlParam>().OrderBy(t => t.ID)
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
                HelperLog.Error<ServiceT_CtrlParam>("获取控制参数失败！", ex);
                return new DataTable();
            }
            
        }

        /// <summary>
        /// 获取控制参数
        /// </summary>
        /// <returns></returns>
        public async static Task<DataTable> GetCtrlParams(string group)
        {
            try
            {
                return await sqlSugarClient.Queryable<T_CtrlParam>().Where(t => t.Group == group).OrderBy(t => t.ID)
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
                HelperLog.Error<ServiceT_CtrlParam>("获取控制参数失败！", ex);
                return new DataTable();
            }
            
        }

        /// <summary>
        /// 获取控制参数组
        /// </summary>
        /// <param name="group"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async static Task<List<string>> GetGroups()
        {
            try
            {
                return await sqlSugarClient.Queryable<T_CtrlParam>().Distinct().Select(t => t.Group).ToListAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<ServiceT_CtrlParam>("获取控制参数组失败！", ex);
                return new List<string>();
            }
            
        }

        /// <summary>
        /// 修改参数
        /// </summary>
        /// <param name="runParam"></param>
        /// <returns></returns>
        public async static Task<int> Updata(T_CtrlParam ctrlParam)
        {
            try
            {
                return await sqlSugarClient.Updateable(ctrlParam).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<ServiceT_CtrlParam>("修改参数失败！", ex);
                return 0;
            }
        }
    }
}
