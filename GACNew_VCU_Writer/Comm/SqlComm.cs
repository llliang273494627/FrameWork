using FrameWork.Model.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GACNew_VCU_Writer.Comm
{
    public class SqlComm
    {
        protected static SqlSugarClient _sqlSugar = null;

        /// <summary>
        /// 实例化数据库
        /// </summary>
        /// <param name="dbtype">数据库类型  1:SqlServer</param>
        /// <param name="conneStr"></param>
        public static void Init(int dbtype, string conneStr)
        {
            try
            {
                _sqlSugar = FrameWork.Model.Comm.HelperSqlsugar.Init(dbtype, conneStr);
            }
            catch (Exception ex)
            {
                Log.Error("连接数据库失败！\r\n dbtype={dbtype},conneStr={conneStr}", ex);
            }
        }

        #region 表 T_RunParam
        /// <summary>
        /// 填充参数表
        /// </summary>
        public async static Task<DataTable> FillRunParam()
        {
            try
            {
                return await _sqlSugar.Queryable<T_RunParam>().OrderBy(t => t.id)
                    .Select(t => new
                    {
                        序号 = t.id,
                        组 = t.groups,
                        描述 = t.descriptions,
                        键 = t.keys,
                        值 = t.keyvalue,
                    }).ToDataTableAsync();
            }
            catch (Exception ex)
            {
                Log.Error("查询数据失败！", ex);
            }
            return new DataTable();
        }

        /// <summary>
        /// 更新RunParam
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async static Task<int> UpdateRunParam(T_RunParam t_RunParam)
        {
            try
            {
                return await _sqlSugar.Updateable(t_RunParam).UpdateColumns(t => new { t.keyvalue }).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"修改记录失败！\r\n keyvalue={t_RunParam.keyvalue}", ex);
            }
            return 0;
        }
        #endregion

        #region 表 T_VCUCodeList
        /// <summary>
        /// 填充TCU特制码表
        /// </summary>
        public async static Task<DataTable> FillVCUCode()
        {
            try
            {
                return await _sqlSugar.Queryable<T_VCUCodeList>().OrderBy(t => t.id)
                 .Select(t => new
                 {
                     序号 = t.id,
                     波特率 = t.baud,
                     接收地址 = t.sendaddress,
                     响应地址 = t.responseaddress
                 }).ToDataTableAsync();
            }
            catch (Exception ex)
            {
                Log.Error("查询数据失败！", ex);
            }
            return new DataTable();
        }

        /// <summary>
        /// 插入TPMSCode
        /// </summary>
        /// <returns></returns>
        public async static Task<int> InsertTPMSCode(string baud, string sendaddress, string responseaddress)
        {
            try
            {
                return await _sqlSugar.Insertable(new T_VCUCodeList { baud = baud, sendaddress = sendaddress, responseaddress = responseaddress }).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"添加记录失败！baud={baud},sendaddress={sendaddress},responseaddress={responseaddress}", ex);
            }
            return 0;
        }

        /// <summary>
        /// 更新TPMS特制码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tpmsCode"></param>
        /// <param name="carType"></param>
        /// <param name="canind"></param>
        /// <param name="baud"></param>
        /// <returns></returns>
        public async static Task<int> UpdateTPMSCode(string id, string baud, string sendaddress, string responseaddress)
        {
            try
            {
                int.TryParse(id, out int intID);
                var data = new T_VCUCodeList
                {
                    id = intID,
                    baud = baud,
                    sendaddress = sendaddress,
                    responseaddress = responseaddress,
                };
                return await _sqlSugar.Updateable(data).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"添加记录失败！id={id},baud={baud},sendaddress={sendaddress},responseaddress={responseaddress}", ex);
            }
            return 0;
        }

        /// <summary>
        /// 删除TPMS特制码
        /// </summary>
        /// <returns></returns>
        public async static Task<int> DeleteTPMSCode(string id)
        {
            try
            {
                int.TryParse(id, out int intID);
                return await _sqlSugar.Deleteable<T_VCUCodeList>().Where(t => t.id == intID).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"添加记录失败！id={id}", ex);
            }
            return 0;
        }

        /// <summary>
        /// 获得VCUCodeList
        /// </summary>
        /// <returns>取得响应地址</returns>
        public async static Task<uint> GetVCUCodeList()
        {
            try
            {
                var str = await _sqlSugar.Queryable<T_VCUCodeList>().Select(t => t.responseaddress).FirstAsync();
                var ress = uint.Parse(Convert.ToInt64(str, 16).ToString());
                return ress;
            }
            catch (Exception ex)
            {
                Log.Error($"查询记录失败！", ex);
            }
            return 0;
        }
        #endregion

        #region 表 T_DefineFlow
        /// <summary>
        /// 填充流程表
        /// </summary>
        public async static Task<DataTable> FillDefineFlow()
        {
            try
            {
                return await _sqlSugar.Queryable<T_DefineFlow>().OrderBy(t => t.id)
               .Select(t => new
               {
                   序号 = t.id,
                   流程名称 = t.flowname,
                   发送指令 = t.sendcmd,
                   接收指令 = t.receivecmd,
                   启用 = t.enabled,
                   时间间隔 = t.sleeptime,
                   接收帧数 = t.receivenum
               }).ToDataTableAsync();
            }
            catch (Exception ex)
            {
                Log.Error("查询数据失败！", ex);
            }
            return new DataTable();
        }

        /// <summary>
        /// 更新流程
        /// </summary>
        /// <returns></returns>
        public async static Task<int> UpdateDefineFlow(T_DefineFlow t_DefineFlow)
        {
            try
            {
                return await _sqlSugar.Updateable(t_DefineFlow)
                .UpdateColumns(t => new { t.flowname, t.sendcmd, t.receivecmd, t.enabled, t.sleeptime, t.receivenum })
                .ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"修改记录失败！\r\n flowname={t_DefineFlow.flowname},sendcmd={ t_DefineFlow.sendcmd},receivecmd={ t_DefineFlow.receivecmd}," +
                    $"enabled={ t_DefineFlow.enabled},sleeptime= {t_DefineFlow.sleeptime}, receivenum={t_DefineFlow.receivenum}", ex);
            }
            return 0;
        }

        /// <summary>
        /// 取出定义帧
        /// </summary>
        /// <returns></returns>
        public static List<DefineFlower> GetDefineFlower()
        {
            try
            {
                var datas = _sqlSugar.Queryable<T_DefineFlow>().Where(t => t.enabled == true).OrderBy(t => t.id).ToList();
                var refdatas = new List<DefineFlower>();
                datas.ForEach(t =>
                {
                    refdatas.Add(new DefineFlower
                    {
                        ID = t.id,
                        FlowName = t.flowname,
                        SendCmd = t.sendcmd,
                        WaitTime = t.waittime,
                        ReceiveCmd = t.receivecmd.ToUpper(),
                        Enabled = t.enabled,
                        SendAddress = uint.Parse(Convert.ToInt64(t.sendaddress, 16).ToString()),
                        SleepTime = t.sleeptime,
                        ReceiveNum = t.receivenum,
                    });
                });
                return refdatas;
            }
            catch (Exception ex)
            {
                Log.Error("查询记录失败！", ex);
            }
            return new List<DefineFlower>();
        }
        #endregion

        #region 表 T_VCUConfig
        /// <summary>
        /// 填充VCU配置表
        /// </summary>
        public async static Task<DataTable> FillStandard()
        {
            try
            {
                return await _sqlSugar.Queryable<T_VCUConfig>().OrderBy(t => t.id)
                .Select(t => new
                {
                    序号 = t.id,
                    MTOC码 = t.mtoc,
                    驱动文件名 = t.drivername,
                    驱动文件路径 = t.driverpath,
                    写入文件名 = t.binname,
                    写入文件路径 = t.binpath,
                    标定文件名 = t.calname,
                    标定文件路径 = t.calpath,
                    软件版本号 = t.softwareversion,
                    零件号 = t.elementNum,
                    硬件简码 = t.hardwarecode,
                    硬件号 = t.HW,
                    软件号 = t.SW,
                    记号 = t.sign
                }).ToDataTableAsync();
            }
            catch (Exception ex)
            {
                Log.Error("查询数据失败！", ex);
            }
            return new DataTable();
        }

        /// <summary>
        /// 删除VCU配置信息
        /// </summary>
        /// <param name="item"></param>
        public async static Task<int> DeleteVCUconfig(T_VCUConfig item)
        {
            try
            {
                return await _sqlSugar.Deleteable<T_VCUConfig>().Where(t => t.id == item.id).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"删除记录失败！\r\n id={item.id}", ex);
            }
            return 0;
        }

        /// <summary>
        /// 修改VCU相关信息
        /// </summary>
        /// <param name="item"></param>
        public async static Task<int> UpdateVCUconfig(T_VCUConfig item)
        {
            try
            {
                return await _sqlSugar.Updateable(item).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                string jsonstr = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                Log.Error($"修改记录失败！\r\n {jsonstr}", ex);
            }
            return 0;
        }

        /// <summary>
        /// 查找重复VCU信息
        /// </summary>
        /// <param name="item"></param>
        public static int RepeatVCUconfig(T_VCUConfig item)
        {
            try
            {
                return _sqlSugar.Queryable<T_VCUConfig>().Where(t => t.mtoc == item.mtoc).Count();
            }
            catch (Exception ex)
            {
                Log.Error($"查询记录失败！\r\n mtoc={item.mtoc}", ex);
            }
            return 0;
        }

        /// <summary>
        /// 保存VCU相关信息
        /// </summary>
        /// <param name="item"></param>
        public async static Task<int> SaveVCUconfig(T_VCUConfig item)
        {
            try
            {
                return await _sqlSugar.Insertable(item).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                string jsonstr = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                Log.Error($"添加记录失败！\r\n {jsonstr}", ex);
            }
            return 0;
        }

        /// <summary>
        /// 获取驱动、写入、cal文件对应的零件号、软件版本以及硬件型号信息
        /// </summary>
        /// <param name="driverPath"></param>
        /// <param name="driverName"></param>
        /// <param name="writePath"></param>
        /// <param name="writeName"></param>
        /// <param name="calPath"></param>
        /// <param name="calName"></param>
        public static string[] GetInfo(string driverPath, string driverName, string writePath, string writeName, string calPath, string calName)
        {
            string[] info = new string[6];
            try
            {
                var str = _sqlSugar.Queryable<T_VCUConfig>()
                    .Where(t => t.driverpath == driverPath && t.drivername == driverName
                    && t.binpath == writePath && t.binname == writeName
                    && t.calpath == calPath && t.calname == calName).First();
                if (str == null)
                    return info;
                else
                    info = new string[] { str.elementNum, str.softwareversion, str.hardwarecode, str.SW, str.HW, str.sign };
                return info;
            }
            catch (Exception ex)
            {
                Log.Error($"查询记录失败！\r\n driverPath={driverPath},driverName={driverName},writePath={writePath},writeName={writeName},calPath={calPath},calName={calName}", ex);
            }
            return info;
        }
        #endregion

        #region 表 T_MTOC
        /// <summary>
        /// 填充VIN对应MTOC表
        /// </summary>
        public async static Task<DataTable> FillMTOC()
        {
            try
            {
                return await _sqlSugar.Queryable<T_MTOC>().OrderBy(t => t.id).Select(t => new
                {
                    序号 = t.id,
                    VIN码 = t.vin,
                    MTOC码 = t.mtoc,
                    检测状态 = t.state,
                    零件编码 = t.element,
                    同步时间 = t.updateTime
                }).ToDataTableAsync();
            }
            catch (Exception ex)
            {
                Log.Error("查询数据失败！", ex);
            }
            return new DataTable();
        }

        /// <summary>
        /// 修改当前检测VCU的状态
        /// </summary>
        /// <param name="state"></param>
        public async static Task<int> ChangeState(bool result, string vin)
        {
            string state = (result == true) ? "2" : "1";
            try
            {
                int tmpK = await _sqlSugar.Updateable<T_MTOC>().SetColumns(t => t.state == SqlFunc.IIF(result == true, 2, 1)).Where(t => t.vin == vin).ExecuteCommandAsync();
                if (tmpK > 0)
                    Log.Info(vin + "更新写入状态" + state + "成功!");
                return tmpK;
            }
            catch (Exception ex)
            {
                Log.Error($"修改记录失败！\r\n result={result},vin={vin}", ex);
            }
            return 0;
        }

        /// <summary>
        /// 获取下一台车VIN码
        /// </summary>
        /// <param name="vin"></param>
        public async static Task<string> GetNextVIN(string vin)
        {
            try
            {
                var vining = await _sqlSugar.Queryable<T_MTOC>().Where(t => t.vin == vin).Select(t => t.updateTime).FirstAsync();
                if (vining != null)
                {
                    var nextvin = await _sqlSugar.Queryable<T_MTOC>().Where(t => t.updateTime > vining && t.state != 2).OrderBy(t => t.updateTime)
                        .Select(t => t.vin).FirstAsync();
                    if (!string.IsNullOrEmpty(nextvin))
                        return nextvin;
                    else
                        Log.Info("不存在下一台车，请核查!");
                }
                else
                {
                    Log.Info("不存在当前VIN");
                }

            }
            catch (Exception ex)
            {
                Log.Error($"查询记录失败！\r\n vin={vin}", ex);
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取MTOC码和对应写入的bin文件
        /// </summary>
        /// <param name="element"></param>
        public async static Task<string> GetMTOC(string element, string vincode, VCUconfig config)
        {
            string msg = string.Empty;
            try
            {
                var mtocentity = await _sqlSugar.Queryable<T_MTOC>().Where(t => t.vin == vincode).FirstAsync();
                if (mtocentity != null)
                {
                    // 修改对应零件号以及写入状态为0（开始写入）
                    await _sqlSugar.Updateable(new T_MTOC { element = element, state = 0 }).UpdateColumns(t => new { t.element, t.state })
                         .Where(t => t.vin == mtocentity.vin).ExecuteCommandAsync();
                    Log.Info(vincode + "更新零件号" + element + "成功,对应mtoc码为:" + mtocentity.mtoc);

                    // 查找MTOC码对应的bin文件以及软、硬件版本号等信息
                    var configentity = await _sqlSugar.Queryable<T_VCUConfig>().Where(t => t.mtoc == mtocentity.mtoc).FirstAsync();
                    if (configentity != null)
                    {
                        config.DriverName = configentity.drivername;
                        config.DriverPath = configentity.driverpath;
                        config.BinName = configentity.binname;
                        config.BinPath = configentity.binpath;
                        config.CalName = configentity.calname;
                        config.CalPath = configentity.calpath;
                        config.SoftWareVersion = configentity.softwareversion;
                        config.HardWareCode = configentity.hardwarecode;
                        config.SW = configentity.SW;
                        config.HW = configentity.HW;
                        config.ElementNum = configentity.elementNum;
                        Log.Info("下载MTOC码为" + mtocentity.mtoc + "对应相关信息成功!");
                    }
                    else
                    {
                        Log.Info("不存在MTOC码为" + mtocentity.mtoc + "对应的相关信息!");
                        msg = "不存在MTOC码为" + mtocentity.mtoc + "对应的相关信息!";
                    }
                }
                else
                {
                    Log.Info("不存在未写入的VCU");
                    msg = "不存在未写入的VCU";
                }

            }
            catch (Exception ex)
            {
                Log.Error($"查询记录失败！\r\n element={element},vincode={vincode},config={config}", ex);
                msg = "异常";
            }
            return msg;
        }
        #endregion

        #region 表 T_Result
        /// <summary>
        /// 获得历史数据
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="vin"></param>
        /// <returns></returns>
        public async static Task<DataTable> GetHistoryResult(DateTime startTime, DateTime endTime, string vin)
        {
            try
            {
                return await _sqlSugar.Queryable<T_Result>().Where(t => SqlFunc.Between(t.testtime, startTime, endTime))
                .WhereIF(!string.IsNullOrEmpty(vin), t => t.vin == vin)
                .Select(t => new
                {
                    序号 = t.id,
                    VIN码 = t.vin,
                    MTOC码 = t.mtoc,
                    驱动文件 = t.flashBin,
                    写入文件 = t.writeBin,
                    标定文件 = t.calBin,
                    软件版本 = t.softwareversion,
                    刷写时间 = t.testtime,
                    刷写状态 = SqlFunc.IIF(t.teststate == 2, "成功", "失败"),
                    是否打印 = SqlFunc.IIF(t.isprint == 1, "是", "否"),
                    追溯码 = t.tracyCode,
                    刷写端口 = t.num,
                }).ToDataTableAsync();
            }
            catch (Exception ex)
            {
                string timestr = "yyyy-MM-dd HH:mm:ss";
                Log.Error($"查询数据失败！\r\n {startTime.ToString(timestr)},{endTime.ToString(timestr)},{vin}", ex);
            }
            return new DataTable();
        }


        #endregion

        #region 表 T_Result
        /// <summary>
        /// 保存到本地数据库
        /// </summary>
        /// <param name="car"></param>
        public async static Task<int> SaveLocalResult(string element, bool state, string vin, string driver, string write, string cal)
        {
            try
            {
                var configs = await _sqlSugar.Queryable<T_VCUConfig, T_MTOC>((v, m) => new JoinQueryInfos(JoinType.Inner, v.mtoc == m.mtoc))
                    .Where((v, m) => m.vin == vin).Select((v, m) => new T_Result
                    {
                        vin = vin,
                        mtoc = v.mtoc,
                        flashBin = v.drivername,
                        writeBin = v.binname,
                        calBin = v.calname,
                        softwareversion = v.softwareversion,
                        testtime = SqlFunc.GetDate(),
                        teststate = SqlFunc.IIF(state == true, 2, 1),
                        isprint = SqlFunc.IIF(state == true, 1, 0),
                        tracyCode = element,
                        sign = v.sign
                    }).FirstAsync();

                if (configs == null)
                {
                    configs = new T_Result
                    {
                        flashBin = driver,
                        writeBin = write,
                        calBin = cal,
                        teststate = SqlFunc.IIF(state == true, 2, 1),
                        isprint = SqlFunc.IIF(state == true, 1, 0),
                    };
                }

                var tmpK = await _sqlSugar.Insertable(configs).ExecuteCommandAsync();
                if (tmpK > 0)
                    Log.Info("保持到本地数据库成功!");
                return tmpK;
            }
            catch (Exception ex)
            {
                Log.Error($"修改记录失败！\r\n element={element},state={state},vin={vin},driver={driver},write={write},cal={cal}", ex);
            }
            return 0;
        }

        /// <summary>
        /// 读取初始化参数
        /// </summary>
        /// <param name="group"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async static Task<string> GetConfigValue(string group, string key)
        {
            try
            {
                return await _sqlSugar.Queryable<T_RunParam>().Where(t => t.groups == group && t.keys == key).Select(t => t.keyvalue).FirstAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"查询记录失败！\r\n groups={group},keys={key}", ex);
            }
            return string.Empty;
        }
        #endregion

    }
}
