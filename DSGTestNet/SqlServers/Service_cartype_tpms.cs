using DSGTestNet.Helper;
using FrameWork.Model.DFPV_DSG101;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.SqlServers
{
    /// <summary>
    /// 车型服务
    /// </summary>
    public class Service_cartype_tpms : FrameWork.Model.Comm.HelperSqlsugar
    {
        /// <summary>
        /// 获取汽车类型
        /// </summary>
        /// <returns></returns>
        public async static Task<DataTable> GetCarTypes()
        {
            try
            {
                return await sqlSugarClient.Queryable<cartype_tpms>().OrderBy(t => t.ID)
               .Select(t => new
               {
                   编号 = t.ID,
                   匹配的字母 = t.MatchLetter,
                   起始位置 = t.CodeStartIndex,
                   长度 = t.CodeLen,
                   车型 = t.CarType,
                   是否带胎压 = t.ifTPMS,
               }).ToDataTableAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error<Service_cartype_tpms>("获取汽车类型失败！", ex);
                return new DataTable();
            }
        }

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        public async static Task<List<cartype_tpms>> Queryable()
        {
            try
            {
                return await sqlSugarClient.Queryable<cartype_tpms>().OrderBy(t => t.ID).ToListAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error<Service_cartype_tpms>("获取汽车类型失败！", ex);
                return null;
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="carType"></param>
        /// <returns></returns>
        public async static Task<cartype_tpms> Queryable(string carType)
        {
            try
            {
                return await sqlSugarClient.Queryable<cartype_tpms>().Where(t => t.CarType == carType).FirstAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error<Service_cartype_tpms>("获取汽车类型失败！", ex);
                return null;
            }
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        public async static Task<int> Deleteable(int id)
        {
            try
            {
                return await sqlSugarClient.Deleteable<cartype_tpms>().Where(t => t.ID == id).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error<Service_cartype_tpms>("删除记录失败！", ex);
                return 0;
            }
            
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <returns></returns>
        public async static Task<int> Updateable(cartype_tpms cartype_Tpms)
        {
            try
            {
                return await sqlSugarClient.Updateable(cartype_Tpms).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error<Service_cartype_tpms>("更新数据失败！", ex);
                return 0;
            }
            
        }

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="cartype_Tpms"></param>
        /// <returns></returns>
        public async static Task<int> Insertable(cartype_tpms cartype_Tpms)
        {
            try
            {
                return await sqlSugarClient.Insertable(cartype_Tpms).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error<Service_cartype_tpms>("增加数据失败！", ex);
                return 0;
            }
           
        }
    }
}
