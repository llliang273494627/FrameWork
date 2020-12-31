using DSG_Group.DGComm;
using FrameWork.Model.DFPV_DSG101;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.SqlServers
{
    public class Service_T_Result : FrameWork.Model.Comm.HelperSqlsugar
    {
        /// <summary>
        /// 测试时间段查询
        /// </summary>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        public async static Task<DataTable> Queryable(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                return await sqlSugarClient.Queryable<T_Result>()
                    .Where(t => SqlFunc.Between(t.TestTime, dateStart, dateEnd))
                    .OrderBy(t => t.TestTime).Select(t => new
                    {
                        ID = t.ID,
                        VID = t.VIN,
                        VIS = t.VIS,
                        车型 = t.CarType,
                        右前轮ID = t.ID020,
                        右后轮ID = t.ID021,
                        左前轮ID = t.ID022,
                        左后轮ID = t.ID023,
                        测试时间 = t.TestTime,
                        状态15合格 = t.TestState,
                    }).ToDataTableAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("数据库异常！", ex);
                return null;
            }
        }

        /// <summary>
        /// 统计测试数量
        /// </summary>
        /// <param name="vin"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        public async static Task<int> Queryable(string vin, DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                return await sqlSugarClient.Queryable<T_Result>()
                    .Where(t => SqlFunc.Between(t.TestTime, dateStart, dateEnd) && t.VIN.Contains(vin))
                    .Select(t => SqlFunc.AggregateCount(t.ID)).FirstAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("数据库异常！", ex);
                return 0;
            }
        }

        /// <summary>
        /// 查询合格数量
        /// </summary>
        /// <param name="vin"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        public async static Task<int> QueryableTestOK(string vin, DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                return await sqlSugarClient.Queryable<T_Result>()
                    .Where(t => SqlFunc.Between(t.TestTime, dateStart, dateEnd) && t.VIN.Contains(vin) && t.TestState == "15")
                    .Select(t => SqlFunc.AggregateCount(t.ID)).FirstAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("数据库异常！", ex);
                return 0;
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="vin"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async static Task<DataTable> Queryable(string vin, DateTime dateStart, DateTime dateEnd, int pageIndex, int pageSize)
        {
            try
            {
                return await sqlSugarClient.Queryable<T_Result>()
                    .Where(t => SqlFunc.Between(t.TestTime, dateStart, dateEnd) && t.VIN.Contains(vin))
                    .OrderBy(t => t.TestTime).Select(t => new
                    {
                        ID = t.ID,
                        VID = t.VIN,
                        VIS = t.VIS,
                        车型 = t.CarType,
                        右前轮ID = t.ID020,
                        右后轮ID = t.ID021,
                        左前轮ID = t.ID022,
                        左后轮ID = t.ID023,
                        测试时间 = t.TestTime,
                        状态15合格 = t.TestState,
                    }).ToDataTablePageAsync(pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("数据库异常！", ex);
                return null;
            }
        }
    }
}
