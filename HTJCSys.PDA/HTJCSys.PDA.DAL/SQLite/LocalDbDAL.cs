using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using COM;
using System.IO;

namespace DAL
{
    public class LocalDbDAL
    {
        public static string connectionString = string.Format("Data Source={0}", BaseVariable.APPRootPath);
        #region 创建数据库
        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool CreateDB()
        {
            try
            {
                if (!File.Exists(BaseVariable.LocalDbPath))
                {
                    SQLiteConnection.CreateFile(BaseVariable.LocalDbPath); 
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        } 
        #endregion

        #region 创建数据表
        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <returns></returns>
        public static bool CreateTable()
        {
            try
            {
                StringBuilder str = new StringBuilder();

                str.AppendLine("-- ----------------------------");
                str.AppendLine("-- Table structure for deviceinfo");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS deviceinfo;");
                str.AppendLine("CREATE TABLE deviceinfo (");
                str.AppendLine("  tid bigint(10) PRIMARY KEY NOT NULL,");
                str.AppendLine("  devicetype varchar(20) NOT NULL,");
                str.AppendLine("  deviceid varchar(20)  NOT NULL,");
                str.AppendLine("  devicename varchar(45) NOT NULL,");
                str.AppendLine("  deviceip varchar(30) DEFAULT NULL,");
                str.AppendLine("  producttype varchar(20) DEFAULT NULL,");
                str.AppendLine("  stationid varchar(20),");
                str.AppendLine("  devicestate int(11) DEFAULT NULL,");
                str.AppendLine("  desc varchar(128) DEFAULT NULL");
                str.AppendLine(");");

                str.AppendLine("-- ----------------------------");
                str.AppendLine("-- Table structure for materialfield");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS materialfield;");
                str.AppendLine("CREATE TABLE materialfield (");
                str.AppendLine("  tid bigint(10) PRIMARY KEY NOT NULL,");
                str.AppendLine("  materialcode varchar(20) NOT NULL,");
                str.AppendLine("  materialname varchar(45) NOT NULL,");
                str.AppendLine("  tablename varchar(45) NOT NULL,");
                str.AppendLine("  fieldname varchar(45) DEFAULT NULL,");
                str.AppendLine("  desc varchar(128) DEFAULT NULL");
                str.AppendLine(");");

                str.AppendLine("-- ----------------------------");
                str.AppendLine("-- Table structure for productbominfo");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS productbominfo;");
                str.AppendLine("CREATE TABLE productbominfo (");
                str.AppendLine("  tid bigint(10) PRIMARY KEY NOT NULL,");
                str.AppendLine("  producttype varchar(12) NOT NULL,");
                str.AppendLine("  productcode varchar(20) NOT NULL, ");
                str.AppendLine("  productname varchar(45) NOT NULL,");
                str.AppendLine("  materialcode varchar(20) NOT NULL, ");
                str.AppendLine("  materialname varchar(45) NOT NULL, ");
                str.AppendLine("  materialnum int(11),");
                str.AppendLine("  batchnum int(11),");
                str.AppendLine("  tracetype varchar(20),");
                str.AppendLine("  featureindex varchar(45),");
                str.AppendLine("  featurecode varchar(24),");
                str.AppendLine("  scannerid varchar(20),");
                str.AppendLine("  desc varchar(128)");
                str.AppendLine(");");

                str.AppendLine("-- ----------------------------");
                str.AppendLine("-- Table structure for productinfo");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS productinfo;");
                str.AppendLine("CREATE TABLE productinfo (");
                str.AppendLine("  tid bigint(10) PRIMARY KEY NOT NULL,");
                str.AppendLine("  producttype varchar(12) NOT NULL,");
                str.AppendLine("  productcode varchar(20) UNIQUE NOT NULL,");
                str.AppendLine("  productname varchar(45) NOT NULL,");
                str.AppendLine("  featureindex varchar(45) DEFAULT NULL,");
                str.AppendLine("  featurecode varchar(24) DEFAULT NULL,");
                str.AppendLine("  barcodecount varchar(30) DEFAULT NULL,");
                str.AppendLine("  printdate datetime DEFAULT (datetime(CURRENT_TIMESTAMP,'localtime')),");
                str.AppendLine("  havesub bit(1) NULL DEFAULT (1),");
                str.AppendLine("  desc varchar(128) DEFAULT NULL");
                str.AppendLine(");");

                str.AppendLine("-- ----------------------------");
                str.AppendLine("-- Table structure for stationinfo");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS stationinfo;");
                str.AppendLine("CREATE TABLE stationinfo (");
                str.AppendLine("  tid bigint(10) PRIMARY KEY NOT NULL,");
                str.AppendLine("  producttype varchar(20) NOT NULL,");
                str.AppendLine("  stationid varchar(20) UNIQUE NOT NULL,");
                str.AppendLine("  stationname varchar(45) NOT NULL,");
                str.AppendLine("  desc varchar(128) DEFAULT NULL");
                str.AppendLine(");");

                str.AppendLine("-- ----------------------------");
                str.AppendLine("-- Table structure for userinfo");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS userinfo;");
                str.AppendLine("CREATE TABLE userinfo (");
                str.AppendLine("  tid bigint(10) PRIMARY KEY NOT NULL,");
                str.AppendLine("  userid varchar(45) UNIQUE NOT NULL,");
                str.AppendLine("  username varchar(45) NOT NULL,");
                str.AppendLine("  usersex varchar(45) NOT NULL,");
                str.AppendLine("  userpwd varchar(128) NOT NULL,");
                str.AppendLine("  phonenum varchar(45) DEFAULT NULL,");
                str.AppendLine("  department longtext NOT NULL,");
                str.AppendLine("  rolename varchar(45) NOT NULL,");
                str.AppendLine("  createtime datetime DEFAULT (datetime(CURRENT_TIMESTAMP,'localtime'))");
                str.AppendLine(");");

                str.AppendLine("-- ----------------------------");
                str.AppendLine("-- Table structure for batchnohis");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS batchnohis;");
                str.AppendLine("CREATE TABLE batchnohis (");
                str.AppendLine("  tid INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,");
                str.AppendLine("  materialcode varchar(45) NOT NULL DEFAULT NULL,");
                str.AppendLine("  batchno varchar(45) DEFAULT NULL,");
                str.AppendLine("  batchnum int DEFAULT NULL,");//添加批次数量
                str.AppendLine("  supplier varchar(100) DEFAULT NULL,");//添加供应商
                str.AppendLine("  createtime datetime NOT NULL DEFAULT (datetime(CURRENT_TIMESTAMP,'localtime'))");
                str.AppendLine(");");

                str.AppendLine("-- -------------制动泵追溯信息表---------------");
                str.AppendLine("-- Table structure for brakepumpresult");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS brakepumpresult;");
                str.AppendLine("CREATE TABLE brakepumpresult (");
                str.AppendLine("  tid INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,");//自增长编号
                str.AppendLine("  barcode varchar(45) UNIQUE DEFAULT NULL,");//合件号条码
                str.AppendLine("  productcode varchar(20) DEFAULT NULL,");//产品编码
                str.AppendLine("  userid varchar(45) DEFAULT NULL,");//用户编号
                str.AppendLine("  stationid varchar(20) DEFAULT NULL,");//工位号
                str.AppendLine("  brakepumpcode varchar(45) DEFAULT NULL,");//制动泵总成
                str.AppendLine("  gasketbatchno varchar(45) DEFAULT NULL,");//密封垫批次号
                str.AppendLine("  hexagonalnutbatchno varchar(45) DEFAULT NULL,");//六角法兰面螺母
                str.AppendLine("  pressuresensorbatchno varchar(45) DEFAULT NULL,");//压力传感器
                str.AppendLine("  silencerbatchno varchar(45) DEFAULT NULL,");//隔音垫
                str.AppendLine("  connectingpipe varchar(45) DEFAULT NULL,");//连接管
                str.AppendLine("  boosterbrakepumpbracket varchar(45) DEFAULT NULL,");//助力器制动泵支架
                str.AppendLine("  completed bit(1) DEFAULT NULL,");//已完成
                str.AppendLine("  scantype int DEFAULT 0,");//扫描类型
                str.AppendLine("  createtime datetime NOT NULL DEFAULT (datetime(CURRENT_TIMESTAMP,'localtime')),");//创建时间
                str.AppendLine("  completetime datetime DEFAULT NULL DEFAULT NULL");//完成时间
                str.AppendLine(");");

                str.AppendLine("-- -------------踏板追溯信息表---------------");
                str.AppendLine("-- Table structure for pedalresult");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS pedalresult;");
                str.AppendLine("CREATE TABLE pedalresult (");
                str.AppendLine("  tid INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,");//自增长编号
                str.AppendLine("  barcode varchar(45) UNIQUE DEFAULT NULL,");//合件号条码
                str.AppendLine("  productcode varchar(20) DEFAULT NULL,");//产品编码
                str.AppendLine("  userid varchar(45) DEFAULT NULL,");//用户编号
                str.AppendLine("  stationid varchar(20) DEFAULT NULL,");//工位号
                str.AppendLine("  pedalassycode varchar(100) DEFAULT NULL,");//踏板总成
                str.AppendLine("  accelpedalcode varchar(100) DEFAULT NULL,");//加速踏板
                str.AppendLine("  cluthhandlebatchno varchar(100) DEFAULT NULL,");//离合器操纵软轴总成
                str.AppendLine("  boltbatchno varchar(45) DEFAULT NULL,");//螺栓批次号
                str.AppendLine("  nutbatchno varchar(45) DEFAULT NULL,");//螺母批次号
                str.AppendLine("  torque1 float DEFAULT NULL,");//力矩1
                str.AppendLine("  torque2 float DEFAULT NULL,");//力矩2
                str.AppendLine("  torque3 float DEFAULT NULL,");//力矩3
                str.AppendLine("  completed bit(1) DEFAULT NULL,");//已完成
                str.AppendLine("  scantype int DEFAULT 0,");//扫描类型
                str.AppendLine("  createtime datetime NOT NULL DEFAULT (datetime(CURRENT_TIMESTAMP,'localtime')),");//创建时间
                str.AppendLine("  completetime datetime DEFAULT NULL");//完成时间
                str.AppendLine(");");

                str.AppendLine("-- -------------散热器追溯信息表---------------");
                str.AppendLine("-- Table structure for radiatorresult");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS radiatorresult;");
                str.AppendLine("CREATE TABLE radiatorresult (");
                str.AppendLine("  tid INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,");//自增长编号
                str.AppendLine("  barcode varchar(45) UNIQUE DEFAULT NULL,");//合件号条码
                str.AppendLine("  productcode varchar(20) DEFAULT NULL,");//产品编码
                str.AppendLine("  userid varchar(45) DEFAULT NULL,");//用户编号
                str.AppendLine("  stationid varchar(20) DEFAULT NULL,");//工位号
                str.AppendLine("  radiatorcode varchar(100) DEFAULT NULL,");//散热器
                str.AppendLine("  condensercode varchar(100) DEFAULT NULL,");//冷凝器
                str.AppendLine("  fanassemblycode varchar(100) DEFAULT NULL,");//风扇总成
                str.AppendLine("  intercoolercode varchar(100) DEFAULT NULL,");//中冷器
                str.AppendLine("  torque1 float DEFAULT NULL ,");//力矩1
                str.AppendLine("  angle1 float DEFAULT NULL ,");//角度1
                str.AppendLine("  torque2 float DEFAULT NULL ,");//力矩2
                str.AppendLine("  angle2 float DEFAULT NULL ,");//角度2
                str.AppendLine("  torque3 float DEFAULT NULL ,");//力矩3
                str.AppendLine("  angle3 float DEFAULT NULL ,");//角度3
                str.AppendLine("  torque4 float DEFAULT NULL ,");//力矩4
                str.AppendLine("  angle4 float DEFAULT NULL ,");//角度4
                str.AppendLine("  torque5 float DEFAULT NULL ,");//力矩5
                str.AppendLine("  angle5 float DEFAULT NULL ,");//角度5
                str.AppendLine("  torque6 float DEFAULT NULL ,");//力矩6
                str.AppendLine("  angle6 float DEFAULT NULL ,");//角度6
                str.AppendLine("  completed bit(1) DEFAULT NULL,");//已完成
                str.AppendLine("  scantype int DEFAULT 0,");//扫描类型
                str.AppendLine("  createtime datetime NOT NULL DEFAULT (datetime(CURRENT_TIMESTAMP,'localtime')),");//创建时间
                str.AppendLine("  completetime datetime DEFAULT NULL");//完成时间
                str.AppendLine(");");

                str.AppendLine("-- -------------前桥追溯信息表---------------");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("-- Table structure for frontaxleresult");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS frontaxleresult;");
                str.AppendLine("CREATE TABLE frontaxleresult (");
                str.AppendLine("  tid INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,");
                str.AppendLine("  barcode varchar(45) UNIQUE DEFAULT NULL,");
                str.AppendLine("  productcode varchar(20) DEFAULT NULL,");
                str.AppendLine("  userid varchar(45) NOT NULL ,");
                str.AppendLine("  stationid varchar(20) NOT NULL ,");
                str.AppendLine("  leftsteeringbatchno varchar(100) DEFAULT NULL ,");//左转向节批次号
                str.AppendLine("  rightsteeringbatchno varchar(100) DEFAULT NULL ,");//右转向节批次号
                str.AppendLine("  bearingbatchno varchar(100) DEFAULT NULL ,");//轴承批次号
                str.AppendLine("  frontbrakediscbatchno varchar(100) DEFAULT NULL ,");//前制动盘（两种型号）批次号
                str.AppendLine("  leftfrontcaliperbatchno varchar(100) DEFAULT NULL ,");//左前卡钳（两种型号）批次号
                str.AppendLine("  rightfrontcaliperbatchno varchar(100) DEFAULT NULL ,");//右前卡钳（两种型号）批次号
                str.AppendLine("  caliperboltbatchno varchar(100) DEFAULT NULL ,");//卡钳螺栓批次号
                str.AppendLine("  lowerballpinbatchno varchar(100) DEFAULT NULL ,");//下球销批次号
                str.AppendLine("  completed bit(1) DEFAULT NULL ,");
                str.AppendLine("  scantype int DEFAULT 0,");//扫描类型
                str.AppendLine("  createtime datetime NOT NULL DEFAULT (datetime(CURRENT_TIMESTAMP,'localtime')),");
                str.AppendLine("  completetime datetime DEFAULT (datetime(CURRENT_TIMESTAMP,'localtime')),");
                str.AppendLine("  repairstate bit(1) DEFAULT NULL");//返修状态
                str.AppendLine(");");

                str.AppendLine("-- -------------后桥追溯信息表---------------");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("-- Table structure for rearaxleresult");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS rearaxleresult;");
                str.AppendLine("CREATE TABLE rearaxleresult (");
                str.AppendLine("  tid INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,");
                str.AppendLine("  barcode varchar(45) UNIQUE DEFAULT NULL,");
                str.AppendLine("  productcode varchar(20) DEFAULT NULL,");
                str.AppendLine("  userid varchar(45) NOT NULL ,");
                str.AppendLine("  stationid varchar(20) NOT NULL ,");
                str.AppendLine("  rearcrossbeambatchno varchar(100) DEFAULT NULL ,");//后横梁批次号
                str.AppendLine("  g3bearingbatchno varchar(100) DEFAULT NULL ,");//3G轴承批次号
                str.AppendLine("  bearingretainingboltbatchno varchar(100) DEFAULT NULL ,");//轴承固定螺栓批次号
                str.AppendLine("  brakediscbatchno varchar(100) DEFAULT NULL ,");//制动盘批次号
                str.AppendLine("  leftrearcaliperbatchno varchar(100) DEFAULT NULL ,");//左后卡钳（两种型号）批次号
                str.AppendLine("  rightrearcaliperbatchno varchar(100) DEFAULT NULL ,");//右后卡钳（两种型号）批次号
                str.AppendLine("  caliperboltbatchno varchar(100) DEFAULT NULL ,");//卡钳螺栓批次号
                str.AppendLine("  completed bit(1) DEFAULT NULL ,");
                str.AppendLine("  scantype int DEFAULT 0,");//扫描类型
                str.AppendLine("  createtime datetime NOT NULL DEFAULT (datetime(CURRENT_TIMESTAMP,'localtime')),");
                str.AppendLine("  completetime datetime DEFAULT (datetime(CURRENT_TIMESTAMP,'localtime')),");
                str.AppendLine("  repairstate bit(1) DEFAULT NULL");//返修状态
                str.AppendLine(");");

                str.AppendLine("-- -------------副仪表板追溯信息表---------------");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("-- Table structure for AuxiliaryFasiaResult");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS AuxiliaryFasiaResult;");
                str.AppendLine("CREATE TABLE AuxiliaryFasiaResult (");
                str.AppendLine("  tid INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,");
                str.AppendLine("  barcode varchar(45) UNIQUE DEFAULT NULL,");
                str.AppendLine("  productcode varchar(20) DEFAULT NULL,");
                str.AppendLine("  userid varchar(45) NOT NULL ,");
                str.AppendLine("  stationid varchar(20) NOT NULL ,");
                str.AppendLine("  linecode varchar(100) DEFAULT NULL ,");//线束
                str.AppendLine("  completed bit(1) DEFAULT NULL ,");
                str.AppendLine("  scantype int DEFAULT 0,");//扫描类型
                str.AppendLine("  createtime datetime NOT NULL DEFAULT (datetime(CURRENT_TIMESTAMP,'localtime')),");
                str.AppendLine("  completetime datetime DEFAULT (datetime(CURRENT_TIMESTAMP,'localtime')),");
                str.AppendLine("  repairstate bit(1) DEFAULT NULL");//返修状态
                str.AppendLine(");");

                str.AppendLine("-- ------------批次信息表----------------");
                str.AppendLine("-- Table structure for batchno");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS batchno;");
                str.AppendLine("CREATE TABLE batchno (");
                str.AppendLine("  tid INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,");
                str.AppendLine("  barcode varchar(45) NOT NULL,");
                str.AppendLine("  producttype varchar(12) NOT NULL,");
                str.AppendLine("  materialcode varchar(45) NOT NULL,");
                str.AppendLine("  materialname varchar(45) NOT NULL,");
                str.AppendLine("  batchno varchar(45) NULL,");
                str.AppendLine("  batchnum int DEFAULT NULL,");
                str.AppendLine("  supplier varchar(100) DEFAULT NULL,");//添加供应商
                str.AppendLine("  stocknum int DEFAULT NULL,");
                str.AppendLine("  createtime datetime NOT NULL DEFAULT (datetime(CURRENT_TIMESTAMP,'localtime'))");
                str.AppendLine(");");

                str.AppendLine("-- ------------产品排序表----------------");
                str.AppendLine("-- Table structure for productsort");
                str.AppendLine("-- ----------------------------");
                str.AppendLine("DROP TABLE IF EXISTS productsort;");
                str.AppendLine("CREATE TABLE productsort (");
                str.AppendLine("  productcode varchar(20) UNIQUE NOT NULL,");
                str.AppendLine("  sortnum int DEFAULT 0");
                str.AppendLine(");");

                bool rs = SQLiteHelper.ExecuteSqlTran(str.ToString());
                return rs;
            }
            catch (Exception)
            {
                return false;
            }
        } 
        #endregion

        #region 获取DataTable
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql)
        {
            return SQLiteHelper.Query(sql).Tables[0];
        }
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql,params SQLiteParameter [] param )
        {
            return SQLiteHelper.Query(sql, param).Tables[0];
        }
        /// <summary>
        /// 执行sql代码串的事务
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool ExecuteSqlTran(string sql)
        {
            return SQLiteHelper.ExecuteSqlTran(sql);
        }
        #endregion

        #region 执行sql语句
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool ExecuteSql(string sql)
        {
            int rs = SQLiteHelper.ExecuteSql(sql);
            return rs > 0 ? true : false;
        } 
        #endregion

        #region 获取第一行第一列
        /// <summary>
        /// 获取第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static object ExecuteScaler(string sql, params SQLiteParameter[] cmdParms)
        {
            return SQLiteHelper.GetSingle(sql, cmdParms);
        } 
        #endregion
    }
}
