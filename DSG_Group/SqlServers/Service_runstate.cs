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
    public class Service_runstate : FrameWork.Model.Comm.HelperSqlsugar
    {
        public async static Task<runstate> Queryable()
        {
            try
            {
                return await sqlSugarClient.Queryable<runstate>().OrderBy(t => t.id, OrderByType.Desc).FirstAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("修改数据失败！", ex);
                return null;
            }
        }

        /// <summary>
        /// 重置运行状态
        /// </summary>
        /// <param name="cartype_Prono"></param>
        /// <returns></returns>
        public async static Task<int> InitRunState()
        {
            try
            {
                int id = await sqlSugarClient.Queryable<runstate>().OrderBy(t=>t.id, OrderByType.Desc).Select(t=>t.id).FirstAsync();
                var runstate = new runstate
                {
                    id=id,
                    test = false,
                    dsgrf = null,
                    dsglf = null,
                    dsgrr = null,
                    dsglr = null,
                    mdlrf = null,
                    mdllf = null,
                    mdlrr = null,
                    mdllr = null,
                    prerf = null,
                    prelf = null,
                    prerr = null,
                    prelr = null,
                    temprf = null,
                    templf = null,
                    temprr = null,
                    templr = null,
                    batteryrf = null,
                    batterylf = null,
                    batteryrr = null,
                    batterylr = null,
                    acspeedrf = null,
                    acspeedlf = null,
                    acspeedrr = null,
                    acspeedlr = null,
                    state = 9999,
                };
                return await sqlSugarClient.Updateable(runstate).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("修改数据失败！", ex);
                return 0;
            }
        }

        /// <summary>
        /// 获取运行状态
        /// </summary>
        /// <returns></returns>
        public async static Task<int> QueryableState()
        {
            try
            {
                return await sqlSugarClient.Queryable<runstate>().OrderBy(t => t.id, OrderByType.Desc).Select(t => t.state).FirstAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("修改数据失败！", ex);
                return 0;
            }
        }

        /// <summary>
        /// 是否测试
        /// </summary>
        /// <returns></returns>
        public async static Task<bool> QueryableTest()
        {
            try
            {
                return await sqlSugarClient.Queryable<runstate>().OrderBy(t => t.id, OrderByType.Desc).Select(t => t.test).FirstAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("修改数据失败！", ex);
                return false;
            }
        }

        /// <summary>
        /// 获取VIN码
        /// </summary>
        /// <returns></returns>
        public async static Task<string> QueryableVIN()
        {
            try
            {
                return await sqlSugarClient.Queryable<runstate>().OrderBy(t => t.id, OrderByType.Desc).Select(t => t.vin).FirstAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("修改数据失败！", ex);
                return null;
            }
        }

        /// <summary>
        ///  更新状态
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async static Task<int> UpdateableState(int value)
        {
            try
            {
                int id = await sqlSugarClient.Queryable<runstate>().OrderBy(t => t.id, OrderByType.Desc).Select(t => t.id).FirstAsync();
                return await sqlSugarClient.Updateable<runstate>().Where(t=>t.id==id).SetColumns(t=>t.state==value).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("修改数据失败！", ex);
                return 0;
            }
        }
        public async static Task<int> UpdateableTest(bool value)
        {
            try
            {
                int id = await sqlSugarClient.Queryable<runstate>().OrderBy(t => t.id, OrderByType.Desc).Select(t => t.id).FirstAsync();
                return await sqlSugarClient.Updateable<runstate>().Where(t => t.id == id).SetColumns(t => t.test == value).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("修改数据失败！", ex);
                return 0;
            }
        }
        public async static Task<int> UpdateableVIN(string value)
        {
            try
            {
                int id = await sqlSugarClient.Queryable<runstate>().OrderBy(t => t.id, OrderByType.Desc).Select(t => t.id).FirstAsync();
                return await sqlSugarClient.Updateable<runstate>().Where(t => t.id == id).SetColumns(t => t.vin == value).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("修改数据失败！", ex);
                return 0;
            }
        }

        

    }
}
