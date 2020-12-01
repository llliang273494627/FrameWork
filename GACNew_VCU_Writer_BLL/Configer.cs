using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using System.Data.Odbc;
using System.Data;
using System.Data.SqlClient;
using GACNew_VCU_Writer;
using GACNew_VCU_Writer_DAL;


namespace GACNew_VCU_Writer_BLL
{
    public class Configer
    {
        #region 私有变量

        private static readonly ILog logger = LogManager.GetLogger(typeof(Configer));
        /// <summary>
        /// Upload的退出标识
        /// </summary>
        private bool canUse_Upload = true;
        /// <summary>
        /// Upload的锁对象
        /// </summary>
        private object olock_Upload = new object();
        

        #endregion

        #region 属性

        private int id = 0;
        /// <summary>
        /// 定位当前写入VCU在MTOC表中的位置
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string vin = string.Empty;
        /// <summary>
        /// VIN        
        /// </summary>
        public string VIN
        {
            get { return vin; }
            set { vin = value; }
        }

        private string connectionString = string.Empty;
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        private string serverCnnStr = string.Empty;
        /// <summary>
        /// 服务器数据库连接字符串
        /// </summary>
        public string ServerCnnStr
        {
            get { return serverCnnStr; }
            set { serverCnnStr = value; }
        }

        private string mesCnnStr = string.Empty;
        /// <summary>
        /// 大线激活岗数据库连接字符串
        /// </summary>
        public string MESCnnStr
        {
            get { return mesCnnStr; }
            set { mesCnnStr = value; }
        }

        private string mesip = string.Empty;
        /// <summary>
        /// 大线激活岗的IP地址
        /// </summary>
        public string MES_IP
        {
            get { return mesip; }
            set { mesip = value; }
        }

        private string rDBCnnStr = string.Empty;
        /// <summary>
        /// 在线返修岗数据库连接字符串
        /// </summary>
        public string RDBCnnStr
        {
            get { return rDBCnnStr; }
            set { rDBCnnStr = value; }
        }

        private string repaireip = string.Empty;
        /// <summary>
        /// 返修的IP
        /// </summary>
        public string Repaire_IP
        {
            get { return repaireip; }
            set { repaireip = value; }
        }

        private int portNum;
        /// <summary>
        /// 串口号
        /// </summary>
        public int PortNum
        {
            get { return portNum; }
            set { portNum = value; }
        }
        private int baudRate = 0;
        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate
        {
            get { return baudRate; }
            set { baudRate = value; }
        }

        private string parity = string.Empty;
        /// <summary>
        /// 波特率
        /// </summary>
        public string Parity
        {
            get { return parity; }
            set { parity = value; }
        }

        private int dataBits = 0;
        /// <summary>
        /// 波特率
        /// </summary>
        public int DataBits
        {
            get { return dataBits; }
            set { dataBits = value; }
        }

        private string stopBits = string.Empty;
        /// <summary>
        /// 波特率
        /// </summary>
        public string StopBits
        {
            get { return stopBits; }
            set { stopBits = value; }
        }

        private int mtocStartIndex = 0;
        /// <summary>
        /// mtoc码的起始地址
        /// </summary>
        public int MTOCStartIndex
        {
            get { return mtocStartIndex; }
            set { mtocStartIndex = value; }
        }

        private int mtocLen = 0;
        /// <summary>
        /// MTOC码的长度
        /// </summary>
        public int MTOCLen
        {
            get { return mtocLen; }
            set { mtocLen = value; }
        }

        private UInt32 m_devtype = 0;
        /// <summary>
        /// 设备类型
        /// </summary>
        public UInt32 DevType
        {
            get { return m_devtype; }
            set { m_devtype = value; }
        }

        private UInt32 m_devind = 0;
        /// <summary>
        /// 设备索引号
        /// </summary>
        public UInt32 DevInd
        {
            get { return m_devind; }
            set { m_devind = value; }
        }

        private int writeTimes = 0;
        /// <summary>
        /// 写入失败后尝试次数
        /// </summary>
        public int WriteTimes
        {
            get { return writeTimes; }
            set { writeTimes = value; }
        }

        private int checkStateTime = 0;
        /// <summary>
        /// 状态检查周期
        /// </summary>
        public int CheckStateTime
        {
            get { return checkStateTime; }
            set { checkStateTime = value; }
        }

        private int threadSleep = 0;
        /// <summary>
        /// 线程停止时间
        /// </summary>
        public int ThreadSleep
        {
            get { return threadSleep; }
            set { threadSleep = value; }
        }

        private string waitCode = string.Empty;
        /// <summary>
        /// 等待指令
        /// </summary>
        public string WaitCode
        {
            get { return waitCode; }
            set { waitCode = value; }
        }

        private int timeUpload = 1;
        /// <summary>
        /// 数据上传时间间隔
        /// </summary>
        public int TimeUpload
        {
            get { return timeUpload; }
            set { timeUpload = value; }
        }

        #endregion

        #region 构造函数

        public Configer()
        {

        }

        public Configer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion

        /// <summary>
        /// 读取初始化参数
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="group"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetConfigValue(string tableName, string group, string key)
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            string value = string.Empty;
            try
            {
                //打开数据库连接
                PostgresHelper.CheckConnection(conn);
                string sql = string.Format("select keyvalue from" + " " + "\"" + "GAC_New_VCU" + "\"" +"."+ "\"" + tableName + "\"" + " " + "where groups='" + group + "' and keys='" + key + "' ");
                //string sql = string.Format("select keyvalue from '"+ tableName +"' " + "where groups='" + group + "' and keys='" + key + "' ");
                DataTable dtValue = PostgresHelper.ExecuteDataTable(conn, CommandType.Text, sql);
                if (dtValue.Rows.Count == 0) throw new Exception(tableName + "中不存在" + group + "或者" + key);
                value = dtValue.Rows[0][0] + "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //关闭数据库连接
                PostgresHelper.CheckCloseConneciton(conn);
            }

            return value;
        }

        /// <summary>
        /// 获得VCUCodeList
        /// </summary>
        /// <returns>取得响应地址</returns>
        public uint GetVCUCodeList()
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            uint value=0;
            try
            {
                PostgresHelper.CheckConnection(conn);
                //where \"CarType\" = '{0}',car.CarType
                string sql = string.Format("SELECT id, baud, sendaddress, responseaddress FROM \"GAC_New_VCU\".\"T_VCUCodeList\";");
                DataTable dtTpmsCoderLister = PostgresHelper.ExecuteDataTable(conn, CommandType.Text, sql);
                int count = dtTpmsCoderLister.Rows.Count;
                if (count != 0)
                {
                    value = uint.Parse(Convert.ToInt64(dtTpmsCoderLister.Rows[0]["ResponseAddress"] + "", 16) + "");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DefineFlower> GetDefineFlower()
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            List<DefineFlower> lstDefineFlower = new List<DefineFlower>();

            try
            {
                PostgresHelper.CheckConnection(conn);
                string sql = string.Format("SELECT id, flowname, sendcmd, waittime, receivecmd, enabled, sendaddress,sleeptime, receivenum, canind FROM \"GAC_New_VCU\".\"T_DefineFlow\" where enabled = 1 order by id;");
                DataTable dtDefineFlower = PostgresHelper.ExecuteDataTable(conn, CommandType.Text, sql);
                if (dtDefineFlower.Rows.Count == 0) throw new Exception("T_DefineFlow中不存在");

                for (int i = 0; i < dtDefineFlower.Rows.Count; i++)
                {
                    DefineFlower defineFlower = new DefineFlower();

                    defineFlower.ID = int.Parse(dtDefineFlower.Rows[i]["ID"] + "");
                    defineFlower.FlowName = dtDefineFlower.Rows[i]["Flowname"] + "";
                    defineFlower.SendCmd = dtDefineFlower.Rows[i]["SendCmd"] + "";

                    defineFlower.WaitTime = int.Parse(dtDefineFlower.Rows[i]["WaitTime"] + "");
                    defineFlower.ReceiveCmd = (dtDefineFlower.Rows[i]["ReceiveCmd"] + "").ToUpper();
                    defineFlower.Enabled = (dtDefineFlower.Rows[i]["Enabled"] + "" == "1") ? true : false;
                    // uint.Parse(Convert.ToInt64(dtDefineFlower.Rows[i]["SendAddress"] + "", 16) + "");
                    defineFlower.SendAddress = uint.Parse(Convert.ToInt64(dtDefineFlower.Rows[i]["SendAddress"] + "", 16) + "");
                    defineFlower.SleepTime = int.Parse(dtDefineFlower.Rows[i]["SleepTime"] + "");
                    defineFlower.ReceiveNum = int.Parse(dtDefineFlower.Rows[i]["ReceiveNum"] + "");

                    lstDefineFlower.Add(defineFlower);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }

            return lstDefineFlower;
        }

        /// <summary>
        /// 获取标准数据
        /// </summary>
        /// <param name="sValues"></param>
        /// <returns></returns>
        public int GetStandard(VCUPath vcuPath)
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            DataTable dataTable = new DataTable();
            try
            {
                PostgresHelper.CheckConnection(conn);

                string sql;

                if (string.IsNullOrEmpty(vcuPath.ConditionCode))
                {
                    sql = "select * from t_TCUconfig where CarType = '" + vcuPath.CarType + "'";
                }
                else
                {
                    sql = "select * from t_TCUconfig where CarType = '" + vcuPath.CarType + "'" + " and ConditionCode = '" + vcuPath.ConditionCode + "'";
                }

                dataTable = PostgresHelper.ExecuteDataTable(conn, CommandType.Text, sql);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow dr = dataTable.Rows[0];
                    vcuPath.CarType = dr["CarType"].ToString();
                    vcuPath.ConditionCode = dr["ConditionCode"].ToString();
                    vcuPath.DriverPath = dr["DriverPath"].ToString();
                    vcuPath.BinPath = dr["BinPath"].ToString();
                    vcuPath.BinName = dr["BinName"].ToString();
                    vcuPath.DriverName = dr["DriverName"].ToString();
                    vcuPath.CalName = dr["calname"].ToString();
                    vcuPath.CalPath = dr["calpath"].ToString();
                    vcuPath.CRC1 = dr["CRC1"].ToString();
                    vcuPath.CRC2 = dr["CRC2"].ToString();
                    vcuPath.SoftWareVersion = dr["SoftWareVersion"].ToString();
                    vcuPath.SoftWareCode = dr["SoftWareCode"].ToString();

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }
        }

        /// <summary>
        /// 保存到本地数据库
        /// </summary>
        /// <param name="car"></param>
        public int SaveLocalResult(string element,bool state,string vin,string driver,string write,string cal)
        {
            int result = 0;
            string sql=string.Empty;
            try
            {
                sql = string.Format("select * from \"GAC_New_VCU\".\"T_VCUConfig\" where \"mtoc\" in (select \"mtoc\" from \"GAC_New_VCU\".\"T_MTOC\" where \"vin\"='"+vin+"')");
                DataTable exist = PostgresHelper.ExecuteDataTable(this.connectionString, CommandType.Text, sql);
                if (exist.Rows.Count != 0)
                {
                    string mtoc = exist.Rows[0]["mtoc"].ToString();
                    string flashBin = exist.Rows[0]["drivername"].ToString();
                    string writeBin = exist.Rows[0]["binname"].ToString();
                    string calBin = exist.Rows[0]["calname"].ToString();
                    string elementCode = exist.Rows[0]["elementNum"].ToString();
                    string softwareCode = exist.Rows[0]["softwareversion"].ToString();
                    string sign = exist.Rows[0]["sign"].ToString();
                    int teststate = (state) ? 2 : 1;
                    int isprint = (state) ? 1 : 0;
                    sql = string.Format("INSERT INTO \"GAC_New_VCU\".\"T_Result\"(vin, mtoc, \"flashBin\", \"writeBin\", \"calBin\",softwareversion, testtime, teststate,isprint,\"tracyCode\",\"sign\") VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}');", vin, mtoc, flashBin, writeBin, calBin, softwareCode
                        , DateTime.Now, teststate, isprint, element,sign);
                }

                else
                {
                    sql = string.Format("select * from \"GAC_New_VCU\".\"T_MTOC\" where \"vin\"= '" + vin + "'");
                    DataTable dtVIN = PostgresHelper.ExecuteDataTable(this.connectionString, CommandType.Text, sql);
                    if (dtVIN.Rows.Count != 0)
                    {
                        sql = string.Format("select * from \"GAC_New_VCU\".\"T_VCUConfig\" where \"mtoc\"='" + dtVIN.Rows[0]["mtoc"].ToString() + "'");
                        DataTable save = PostgresHelper.ExecuteDataTable(this.connectionString, CommandType.Text, sql);
                        if (save.Rows.Count != 0)
                        {
                            string mtoc = save.Rows[0]["mtoc"].ToString();
                            string flashBin = driver;
                            string writeBin = write;
                            string calBin = cal;
                            string elementCode = save.Rows[0]["elementNum"].ToString();
                            string softwareCode = save.Rows[0]["softwareversion"].ToString();
                            string sign = save.Rows[0]["sign"].ToString();
                            int teststate = (state) ? 2 : 1;
                            int isprint = (state) ? 1 : 0;
                            sql = string.Format("INSERT INTO \"GAC_New_VCU\".\"T_Result\"(vin, mtoc, \"flashBin\", \"writeBin\", \"calBin\",softwareversion, testtime, teststate,isprint,\"tracyCode\",\"sign\") VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}');", vin, mtoc, flashBin, writeBin, calBin, softwareCode
                                , DateTime.Now, teststate, isprint, element,sign);
                        }
                    }
                    else
                    {
                        string flashBin = driver;
                        string writeBin = write;
                        string calBin = cal;
                        int teststate = (state) ? 2 : 1;
                        int isprint = (state) ? 1 : 0;
                        sql = string.Format("INSERT INTO \"GAC_New_VCU\".\"T_Result\"(vin,\"flashBin\", \"writeBin\", \"calBin\",testtime, teststate,isprint,\"tracyCode\") VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');", vin,flashBin, writeBin, calBin,DateTime.Now, teststate, isprint, element);
                    }
                    
                }
                result = PostgresHelper.ExecuteNonQuery(this.connectionString, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
            return result;
        }

        /// <summary>
        /// 保存VCU相关信息
        /// </summary>
        /// <param name="item"></param>
        public void SaveVCUconfig(VCUconfig item)
        {
            try
            {
                string sql = string.Format("INSERT INTO  \"GAC_New_VCU\".\"T_VCUConfig\"(mtoc,drivername,driverpath,binname,binpath,calname,calpath,softwareversion,hardwarecode,\"elementNum\",\"HW\",\"SW\",\"sign\") VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');",
                    item.MTOC, item.DriverName, item.DriverPath, item.BinName, item.BinPath, item.CalName, item.CalPath, item.SoftWareVersion, item.HardWareCode, item.ElementNum, item.HW, item.SW,item.Sign);
                int result = PostgresHelper.ExecuteNonQuery(this.connectionString, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 查找重复VCU信息
        /// </summary>
        /// <param name="item"></param>
        public int RepeatVCUconfig(VCUconfig item)
        {
            int result = 0;
            try
            {
                string sql = string.Format("select count(*) from \"GAC_New_VCU\".\"T_VCUConfig\" where mtoc = '{0}' ", item.MTOC);
                result = Convert.ToInt32(PostgresHelper.ExecuteScalar(this.connectionString, CommandType.Text, sql));

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
            return result;
        }

        /// <summary>
        /// 修改VCU相关信息
        /// </summary>
        /// <param name="item"></param>
        public void UpdateVCUconfig(VCUconfig item)
        {
            try
            {
                string sql = string.Format("Update \"GAC_New_VCU\".\"T_VCUConfig\"  set mtoc = '{0}' ,drivername= '{1}',driverpath= '{2}',binname= '{3}',binpath= '{4}',calname= '{5}',calpath= '{6}',softwareversion= '{7}',\"elementNum\"= '{8}',\"hardwarecode\"= '{9}' ,\"HW\"= '{10}',\"SW\"= '{11}' where id = {12};", item.MTOC, item.DriverName, item.DriverPath, item.BinName,item.BinPath, item.CalName, item.CalPath, item.SoftWareVersion, item.ElementNum, item.HardWareCode,item.HW,item.SW, item.Id);
                int result = PostgresHelper.ExecuteNonQuery(this.connectionString, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 删除VCU配置信息
        /// </summary>
        /// <param name="item"></param>
        public void DeleteVCUconfig(VCUconfig item)
        {
            try
            {
                string sql = string.Format("delete from \"GAC_New_VCU\".\"T_VCUConfig\" where id = {0}", item.Id);
                int result = PostgresHelper.ExecuteNonQuery(this.connectionString, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 得到今天已经打印了多少条数据
        /// </summary>
        /// <returns></returns>
        public int GetPrintNum()
        {
            int num = 0;
            try
            {
                string endTime = DateTime.Now.ToString();
                string startTime = DateTime.Now.ToShortDateString() + " 00:00:00";
                string sql = string.Format("select count(*) from t_result where testtime > '{0}' and testtime < '{1}'", startTime, endTime);
                num = Convert.ToInt32(PostgresHelper.ExecuteScalar(this.connectionString, CommandType.Text, sql)) + 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
            return num;
        }

        /// <summary>
        /// 数据上传
        /// </summary>
        /// <param name="obj"></param>
        public void Upload_Timer()
        {
            if (!canUse_Upload)
            {
                return;
            }
            else
            {
                lock (olock_Upload)
                {
                    if (canUse_Upload)
                    {
                        canUse_Upload = false;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            try
            {

                string localSql = "select * from T_Result where uploadsign=0";
                DataTable dt = PostgresHelper.ExecuteDataTable(this.ConnectionString, CommandType.Text, localSql);

                foreach (DataRow item in dt.Rows)
                {
                    //上传数据
                    string sql = string.Format("INSERT INTO T_Upload_TcuData(cartype, conditioncode, crc1, crc2, softwareversion, softwarecode, testtime) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", item["CarType"].ToString(), item["ConditionCode"].ToString(), item["CRC1"].ToString(), item["CRC2"].ToString(), item["SoftWareVersion"].ToString(), item["SoftWareCode"].ToString(), item["testtime"].ToString());

                    int result = SQLServerHelper.ExecuteNonQuery(this.MESCnnStr, CommandType.Text, sql);

                    //把上传标识uploadsign改为1
                    if (result > 0)
                    {
                        string updateSql = string.Format("update T_Result set UploadSign = 1 where id ={0}", Convert.ToInt32(item["id"]));
                        PostgresHelper.ExecuteNonQuery(this.connectionString, CommandType.Text, updateSql);
                    }                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 上传到大线激活岗
        /// </summary>
        /// <param name="car"></param>
        //public void SaveRemoteResult(Car car)
        //{
        //    OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.mesCnnStr);

        //    try
        //    {
        //        //查询大线激活岗的数据库中是否存在该VIN
        //        PostgresHelper.CheckConnection(conn);

        //        string existSql = string.Format("SELECT count(0) FROM \"T_Result\" where \"VIN\" = '{0}';", car.VIN);
        //        string sql = string.Empty;
        //        DataTable dtExist = PostgresHelper.ExecuteDataTable(conn, CommandType.Text, existSql);

        //        //上传到大线激活岗的数据库中
        //        if (dtExist.Rows[0][0] + "" == "0")
        //        {
        //            //不存在则插入
        //            //sql = string.Format("INSERT INTO \"T_Result\"(\"VIN\", \"ID020\", \"ID022\", \"ID021\", \"ID023\", \"Dev\", \"WriteInTime\", \"IsWriteIn\", \"WriteInResult\", \"ErrorCode\", \"MTOC\", \"CarType\") VALUES (\'{0}\', \'{1}\', \'{2}\', \'{3}\',\'{4}\', \'{5}\', \'{6}\', \'{7}\',\'{8}\', \'{9}\', \'{10}\', \'{11}\');"
        //            //                                    , car.VIN, car.RFID, car.LFID, car.RRID, car.LRID, 201, DateTime.Now, true, car.WriteInResult, car.ErrorCode, car.MTOC, car.CarType);
        //        }
        //        else
        //        {
        //            //存在则更新
        //            //sql = string.Format("UPDATE \"T_Result\" SET \"Dev\"=\'{0}\', \"WriteInTime\"=\'{1}\', \"IsWriteIn\"=\'{2}\', \"WriteInResult\"=\'{3}\', \"ErrorCode\"=\'{4}\', \"MTOC\"=\'{5}\', \"CarType\"=\'{6}\' WHERE \"ID\"=\'{7}\';"
        //            //                                     ,201, DateTime.Now, true, car.WriteInResult, car.ErrorCode, car.MTOC, car.CarType,car.ID);
        //        }
        //        //打开上游数据库
        //        PostgresHelper.CheckConnection(conn);
        //        //上传
        //        PostgresHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex.Message + "***" + ex.StackTrace);
        //    }
        //    finally
        //    {
        //        PostgresHelper.CheckCloseConneciton(conn);
        //    }
        //}
        /// <summary>
        /// 获得历史数据
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="vin"></param>
        /// <returns></returns>
        public DataTable GetHistoryResult(DateTime startTime, DateTime endTime, string vin)
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            DataTable dataTable = new DataTable();

            try
            {
                PostgresHelper.CheckConnection(conn);
                string sql = string.Empty;
                if (vin != "")
                {
                    sql = string.Format("select ID as 序号, vin as VIN码,mtoc as MTOC码, \"flashBin\" as 驱动文件,\"writeBin\" as 写入文件,\"calBin\" as 标定文件,softwareversion as 软件版本,testtime as 刷写时间,case when teststate=2 then '成功' when teststate!='2' then '失败' end as 刷写状态,case when isprint=1 then '是' when isprint!=1 then '否' end as 是否打印,\"tracyCode\" as 追溯码,\"num\" as 刷写端口 FROM \"GAC_New_VCU\".\"T_Result\" where testtime >= '{0}' and testtime <= '{1}' and vin='{2}' ", startTime, endTime, vin);
                }
                else
                {
                    sql = string.Format("select ID as 序号, vin as VIN码,mtoc as MTOC码, \"flashBin\" as 驱动文件,\"writeBin\" as 写入文件,\"calBin\" as 标定文件,softwareversion as 软件版本,testtime as 刷写时间,case when teststate=2 then '成功' when teststate!='2' then '失败' end as 刷写状态,case when isprint=1 then '是' when isprint!=1 then '否' end as 是否打印,\"tracyCode\" as 追溯码,\"num\" as 刷写端口 FROM \"GAC_New_VCU\".\"T_Result\" where testtime >= '{0}' and testtime <= '{1}' ", startTime, endTime);
                }
                //string sql = string.Format("SELECT \"ID\" as 序号, \"VIN\", \"ID020\" as 右前ID, \"ID022\" as 左前ID, \"ID021\" as 右后ID, \"ID023\" as 左后ID, \"TestTime\" as 激活时间, \"UploadSign\" as 上传标识, \"WriteInTime\" as 写入时间, \"IsWriteIn\" as 写入标识, \"WriteInResult\" as 写入结果,\"ErrorCode\" as 写入过程, \"MTOC\", \"CarType\" as 车型 FROM \"T_Result\" where \"WriteInTime\" >= '{0}' and \"WriteInTime\" <= '{1}' and \"VIN\" like '%{2}%';", startTime, endTime, vin);CRC1 as CRC1校验码,CRC2 as CRC2校验码 ,
                
                dataTable = PostgresHelper.ExecuteDataTable(conn, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }

            return dataTable;
        }
        /// <summary>
        /// 取出数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataSource(string sql)
        {
            DataTable dtTable = new DataTable();
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);

            try
            {
                PostgresHelper.CheckConnection(conn);
                dtTable = PostgresHelper.ExecuteDataTable(conn, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }

            return dtTable;
        }
        /// <summary>
        /// 更新RunParam
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int UpdateRunParam(string id, string value)
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            int result = -1;
            try
            {
                string sql = string.Format("UPDATE \"GAC_New_VCU\".\"T_RunParam\" SET \"keyvalue\"='{0}' WHERE ID = '{1}';", value, id);
                result = PostgresHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }

            return result;
        }
        /// <summary>
        /// 检查TPMS特制码是否存在
        /// </summary>
        /// <param name="tpmsCode"></param>
        /// <param name="carType"></param>
        /// <returns></returns>
        public int ExistTPMSCode(string carType)
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            int result = -1;

            try
            {
                PostgresHelper.CheckConnection(conn);
                string sql = string.Format("SELECT count(0) FROM \"GAC_New_VCU\".\"T_TPMSCodeList\" where \"CarType\"='{0}';", carType);
                DataTable dtExist = PostgresHelper.ExecuteDataTable(conn, CommandType.Text, sql);
                result = int.Parse(dtExist.Rows[0][0] + "");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }

            return result;
        }
        /// <summary>
        /// 插入TPMSCode
        /// </summary>
        /// <returns></returns>
        public int InsertTPMSCode(string carType, string canind, string baud, string sendAddress, string responseAddress)
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            int result = -1;

            try
            {
                string sql = string.Format("INSERT INTO \"GAC_New_VCU\".\"T_TPMSCodeList\"(\"CarType\", \"CANIND\", \"Baud\", \"SendAddress\",\"ResponseAddress\") VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", carType, canind, baud, sendAddress, responseAddress);
                result = PostgresHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }

            return result;
        }
        /// <summary>
        /// 更新TPMS特制码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tpmsCode"></param>
        /// <param name="carType"></param>
        /// <param name="canind"></param>
        /// <param name="baud"></param>
        /// <param name="sendAddress"></param>
        /// <param name="responseAddress"></param>
        /// <returns></returns>
        public int UpdateTPMSCode(string id, string carType, string canind, string baud, string sendAddress, string responseAddress)
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            int result = -1;

            try
            {
                PostgresHelper.CheckConnection(conn);

                string sql = string.Format("UPDATE \"GAC_New_VCU\".\"T_TPMSCodeList\" SET \"CarType\"='{0}', \"CANIND\"='{1}', \"Baud\"='{2}', \"SendAddress\"='{3}', \"ResponseAddress\"='{4}' WHERE \"ID\"='{5}';", carType, canind, baud, sendAddress, responseAddress, id);
                result = PostgresHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }

            return result;
        }
        /// <summary>
        /// 删除TPMS特制码
        /// </summary>
        /// <returns></returns>
        public int DeleteTPMSCode(string id)
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            int result = -1;

            try
            {
                PostgresHelper.CheckConnection(conn);

                string sql = string.Format("DELETE FROM \"GAC_New_VCU\".\"T_TPMSCodeList\" WHERE \"ID\" = '{0}';", id);
                result = PostgresHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }

            return result;
        }
        /// <summary>
        /// 更新流程
        /// </summary>
        /// <param name="flowName"></param>
        /// <param name="sendCmd"></param>
        /// <param name="receiveCmd"></param>
        /// <param name="enable"></param>
        /// <param name="carType"></param>
        /// <param name="sleepTime"></param>
        /// <param name="receiveNum"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateDefineFlow(string flowName, string sendCmd, string receiveCmd, string enable, string sleepTime, string receiveNum, string id)
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            int result = -1;

            try
            {
                PostgresHelper.CheckConnection(conn);
                string sql = string.Format("UPDATE \"GAC_New_VCU\".\"T_DefineFlow\" SET \"Flowname\"='{0}', \"SendCmd\"='{1}', \"ReceiveCmd\"='{2}', \"Enabled\"='{3}', \"CarType\"='{4}', \"SleepTime\"='{5}', \"ReceiveNum\"='{6}' WHERE \"ID\"='{7}'", flowName, sendCmd, receiveCmd, enable, sleepTime, receiveNum, id);

                result = PostgresHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }

            return result;

        }

        /// <summary>
        /// 获取下一台车VIN码
        /// </summary>
        /// <param name="vin"></param>
        public string GetNextVIN(string vin)
        {
            string result = string.Empty;

            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            try
            {
                PostgresHelper.CheckConnection(conn);
                string sql = string.Empty;
                
                sql = string.Format("select \"updateTime\" from \"GAC_New_VCU\".\"T_MTOC\" where \"vin\"= '" + vin + "'");
                DataTable dtExist = PostgresHelper.ExecuteDataTable(conn, CommandType.Text, sql);
                if (dtExist.Rows.Count != 0)
                {
                    sql = string.Format("select * from \"GAC_New_VCU\".\"T_MTOC\" where \"updateTime\"> '" + dtExist.Rows[0][0].ToString() + "' and \"state\" !='2' order by \"updateTime\" asc limit 1");
                    DataTable dtExistVIN = PostgresHelper.ExecuteDataTable(conn, CommandType.Text, sql);

                    if (dtExistVIN.Rows.Count != 0)
                    {
                        result = dtExistVIN.Rows[0]["vin"].ToString();
                    }
                    else
                    {
                        logger.Info("不存在下一台车，请核查!");
                    }
 
                }
                else
                {
                    logger.Info("不存在当前VIN");
                }
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }
        }
        /// <summary>
        /// 获取MTOC码和对应写入的bin文件
        /// </summary>
        /// <param name="element"></param>
        public string GetMTOC(string element, string vincode,VCUconfig config)
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            string res = string.Empty;
            try
            {
                this.vin = vincode;
                PostgresHelper.CheckConnection(conn);
                //先查找第一个写入状态为-1的件，插入零件号并获取MTOC码和id
                string mtoc = string.Empty;
                int result = -1;
                string sql = string.Empty;
                sql = string.Format("select * from \"GAC_New_VCU\".\"T_MTOC\" where \"vin\"='" + vincode + "'");
                DataTable dtExist = PostgresHelper.ExecuteDataTable(conn, CommandType.Text, sql);
                if (dtExist.Rows.Count != 0)
                {
                    mtoc = dtExist.Rows[0]["mtoc"].ToString();
                    id = int.Parse(dtExist.Rows[0]["id"].ToString());
                    vin = dtExist.Rows[0]["vin"].ToString();
                    //修改对应零件号以及写入状态为0（开始写入）
                    sql = string.Format("update \"GAC_New_VCU\".\"T_MTOC\" set \"element\"='" + element + "',\"state\"='0' where \"vin\"='" + vin + "'");
                    result = PostgresHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
                    logger.Info(vin + "更新零件号" + element + "成功,对应mtoc码为:" + mtoc);                    
                    //查找MTOC码对应的bin文件以及软、硬件版本号等信息
                    sql = string.Format("select * from \"GAC_New_VCU\".\"T_VCUConfig\" where \"mtoc\"='" + mtoc + "' ");
                    DataTable Exist = PostgresHelper.ExecuteDataTable(conn, CommandType.Text, sql);
                    if (Exist.Rows.Count != 0)
                    {
                        config.DriverName = Exist.Rows[0]["drivername"] + "";
                        config.DriverPath = Exist.Rows[0]["driverpath"] + "";
                        config.BinName = Exist.Rows[0]["binname"] + "";
                        config.BinPath = Exist.Rows[0]["binpath"] + "";
                        config.CalName = Exist.Rows[0]["calname"] + "";
                        config.CalPath = Exist.Rows[0]["calpath"] + "";
                        config.SoftWareVersion = Exist.Rows[0]["softwareversion"] + "";
                        config.HardWareCode = Exist.Rows[0]["hardwarecode"] + "";
                        config.SW = Exist.Rows[0]["SW"] + "";
                        config.HW = Exist.Rows[0]["HW"] + "";
                        config.ElementNum = Exist.Rows[0]["elementNum"] + "";
                        logger.Info("下载MTOC码为"+mtoc+"对应相关信息成功!");
                    }
                    else
                    {
                        logger.Info("不存在MTOC码为" + mtoc + "对应的相关信息!");
                        res = "不存在MTOC码为" + mtoc + "对应的相关信息!";
                    }
                }
                else
                {
                    logger.Info("不存在未写入的VCU");
                    res = "不存在未写入的VCU";
                }                
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                res = ex.Message;
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }
            return res;
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
        public string[] GetInfo(string driverPath,string driverName,string writePath,string writeName,string calPath,string calName)
        {
            string[] info=new string[6];
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            try
            {
                PostgresHelper.CheckConnection(conn);
                string sql = string.Format("select * from \"GAC_New_VCU\".\"T_VCUConfig\" where \"driverpath\"='" + driverPath + "' and \"drivername\"='" + driverName + "' and \"binpath\"='" + writePath + "' and \"binname\"='" + writeName + "' and \"calpath\"='" + calPath + "' and \"calname\"='" + calName + "'");
                DataTable exist= PostgresHelper.ExecuteDataTable(conn, CommandType.Text, sql);
                if (exist.Rows.Count != 0)
                {
                    info[0] = exist.Rows[0]["elementNum"].ToString();
                    info[1] = exist.Rows[0]["softwareversion"].ToString();
                    info[2] = exist.Rows[0]["hardwarecode"].ToString();
                    info[3] = exist.Rows[0]["SW"].ToString();
                    info[4] = exist.Rows[0]["HW"].ToString();
                    info[5] = exist.Rows[0]["sign"].ToString();
                }
                else
                {
                    info = null;
                }       
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }
            return info;
        }
        /// <summary>
        /// 修改当前检测VCU的状态
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(bool result,string vin)
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            try
            {
                string state = (result == true) ? "2" : "1";
                PostgresHelper.CheckConnection(conn);
                string sql = string.Format("update \"GAC_New_VCU\".\"T_MTOC\" set \"state\"='"+state+"' where \"vin\"='" + vin + "'");
                PostgresHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
                logger.Info(vin+ "更新写入状态"+state+"成功!");  
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }
        }
        /// <summary>
        /// 检查数据库连接状态
        /// </summary>
        /// <param name="connstr"></param>
        /// <returns></returns>
        public bool CheckConnection(string connstr)
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(connstr);
            try
            {
                PostgresHelper.CheckConnection(conn);

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }
        }
        /// <summary>
        /// 删除VIN_MTOC码
        /// </summary>
        public void DeleteVIN_MTOC()
        {
            OdbcConnection conn = PostgresHelper.GetOdbcConnection(this.connectionString);
            try
            {
                PostgresHelper.CheckConnection(conn);
                string sql = string.Format("DELETE FROM \"GAC_New_VCU\".\"VIN_MTOC\"");
                PostgresHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message + "***" + ex.StackTrace);
            }
            finally
            {
                PostgresHelper.CheckCloseConneciton(conn);
            }
        }
    }
}

