﻿using DSGTestNet.Helper;
using FrameWork.Model.DFPV_DSG101;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.SqlServers
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

        public async static Task<int> DeleteableVIN(string vin)
        {
            try
            {
                return await sqlSugarClient.Deleteable<vincoll>()
                    .Where(t => t.vin.Contains(vin)).ExecuteCommandAsync();
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

        /// <summary>
        /// 查找 VIN 码
        /// </summary>
        /// <returns></returns>
        public async static Task<string> QueryableVIN(string vin)
        {
            try
            {
                return await sqlSugarClient.Queryable<vincoll>()
                    .Where(t => t.vin == vin).Select(t => t.vin).FirstAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("获取所有 VIN 码失败！", ex);
                return null;
            }
        }

        public async static Task<vincoll> Queryablevincoll(string vin)
        {
            try
            {
                return await sqlSugarClient.Queryable<vincoll>()
                    .Where(t => t.vin == vin).FirstAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("获取所有 VIN 码失败！", ex);
                return null;
            }
        }

        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="vincoll"></param>
        /// <returns></returns>
        public async static Task<int> Insertable(string vin, string CarType, bool ifTPMS)
        {
            try
            {
                var vininfo = new vincoll
                {
                    vin = vin,
                    cartype = CarType,
                    tpms = ifTPMS,
                };
                return await sqlSugarClient.Insertable(vininfo).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("删除数据失败！", ex);
                return 0;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="vincoll"></param>
        /// <returns></returns>
        public async static Task<int> Updateable(string vin, string CarType, bool ifTPMS)
        {
            try
            {
                return await sqlSugarClient.Updateable<vincoll>().Where(t => t.vin == vin)
                    .SetColumns(t => t.cartype == CarType)
                    .SetColumns(t => t.tpms == ifTPMS).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("删除数据失败！", ex);
                return 0;
            }
        }
    }
}
