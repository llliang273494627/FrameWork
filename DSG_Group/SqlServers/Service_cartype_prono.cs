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
    /// <summary>
    /// 程序号服务
    /// </summary>
    public class Service_cartype_prono : FrameWork.Model.Comm.HelperSqlsugar
    {
        /// <summary>
        /// 获取程序号数据
        /// </summary>
        /// <returns></returns>
        public async static Task<DataTable> Queryable()
        {
            try
            {
                return await sqlSugarClient.Queryable<cartype_prono>().OrderBy(t => t.ID)
               .Select(t => new
               {
                   编号 = t.ID,
                   车型 = t.CarType,
                   程序号 = t.ProNum,
               }).ToDataTableAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<Service_cartype_prono>("获取程序号数据失败！", ex);
                return new DataTable();
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="carType"></param>
        /// <returns></returns>
        public async static Task<cartype_prono> Queryable(string carType)
        {
            try
            {
                return await sqlSugarClient.Queryable<cartype_prono>().Where(t => t.CarType == carType).FirstAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<Service_cartype_tpms>("获取汽车类型失败！", ex);
                return null;
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <returns></returns>
        public async static Task<int> Insertable(cartype_prono cartype_Prono)
        {
            try
            {
                return await sqlSugarClient.Insertable(cartype_Prono).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<Service_cartype_tpms>("添加数据失败！", ex);
                return 0;
            }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="cartype_Prono"></param>
        /// <returns></returns>
        public async static Task<int> Updateable(cartype_prono cartype_Prono)
        {
            try
            {
                return await sqlSugarClient.Updateable(cartype_Prono).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<Service_cartype_tpms>("修改数据失败！", ex);
                return 0;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async static Task<int> Deleteable(int id)
        {
            try
            {
                return await sqlSugarClient.Deleteable<cartype_prono>().Where(t => t.ID == id).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLog.Error<Service_cartype_tpms>("删除数据失败！", ex);
                return 0;
            }
        }
    }
}
