using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using System.Xml;
using System.Threading;

namespace GACNew_VCU_Writer_DAL
{
    ///**************************************************************************************************
    // * Funtion：通过ODBC对Postgres数据库进行增、删、改、查操作。
    // * Author：China-yang
    // * CreateTime：2012-02-29
    // * LastModifyTime：
    // * LastModifyAuthor:
    // **************************************************************************************************/

    public class PostgresHelper
    {
        public PostgresHelper()
        { }

        #region private Parameters
        /// 
        /// 为OdbcCommand添加参数
        /// 
        /// OdbcCommand对象
        /// OdbcParameter[]对象
        private static void AttachParameters(OdbcCommand command, OdbcParameter[] commandParameters)
        {
            foreach (OdbcParameter p in commandParameters)
            {
                if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null)) { p.Value = DBNull.Value; }
                command.Parameters.Add(p);
            }
        }
        /// 
        /// 为OdbcParameter[]添加值
        /// 
        /// OdbcParameter[]对象
        /// object[]对象
        private static void AssignParameterValues(OdbcParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null)) return;
            if (commandParameters.Length != parameterValues.Length) throw new ArgumentException("Parameter count does not match Parameter Value count.");
            for (int i = 0, j = commandParameters.Length; i < j; i++) commandParameters[i].Value = parameterValues[i];
        }
        /// 
        /// 这种方法打开,并指派一个connection, transaction, command type and parameters
        /// 
        /// OdbcCommand对象
        /// OdbcConnection对象
        /// OdbcTransaction对象
        /// CommandType对象
        /// Odbc字符串
        /// OdbcParameter[]对象
        private static void PrepareCommand(OdbcCommand command, OdbcConnection connection, OdbcTransaction transaction, CommandType commandType, string commandText, OdbcParameter[] commandParameters)
        {
            //int index = 0;
            //while (index < 3 && connection.State != ConnectionState.Open)
            //{
            //    index++;
            //    connection.Open();    
            //}

            //if (index >= 3)
            //{
            //    throw new Exception("数据库三次连接不上");
            //}

            CheckConnection(connection);
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;
            if (transaction != null) command.Transaction = transaction;
            if (commandParameters != null) AttachParameters(command, commandParameters);
            return;
        }
        #endregion

        static int index = 0;

        public static void CheckConnection(OdbcConnection connection)
        {
            try
            {
                if (connection.State != ConnectionState.Open) connection.Open();
            }
            catch (Exception ex)
            {
                if (index < 2 && connection.State != ConnectionState.Open)
                {
                    Thread.Sleep(1000);
                    index++;
                    CheckConnection(connection);
                }
                else
                {
                    throw new Exception("数据库连接失败", ex);
                    //ex.Message = "数据库连接失败";
                    //throw ex;
                }
            }

        }
        public static OdbcConnection GetOdbcConnection(string connectionString)
        {
            OdbcConnection cn = new OdbcConnection(connectionString);
            return cn;

        }
        public static void CheckCloseConneciton(OdbcConnection connection)
        {
            try
            {
                if (connection.State != ConnectionState.Closed) connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region MakeParam
        /// 
        /// object转为字符串
        /// 
        /// object对象
        /// object转为字符串
        public static string CheckNull(object obj) { return (string)obj; }
        /// 
        /// 数据库字段值是否为空
        /// 
        /// DBNull对象
        /// null字符串
        public static string CheckNull(DBNull obj) { return null; }
        /// 
        /// 判断字符串是否为空，并将字符串转为object对象
        /// 
        /// 字符串
        /// object对象也可能为DBNull
        public static object CheckForNullString(string text)
        {
            if (text == null || text.Trim().Length == 0) return System.DBNull.Value; else return text;
        }
        /// 
        /// 组成一个OdbcParameter参数
        /// 
        /// 参数名
        /// 参数值
        /// 返回一个OdbcParameter参数
        public static OdbcParameter MakeInParam(string ParamName, object Value) { return new OdbcParameter(ParamName, Value); }
        /// 
        /// 组成一个OdbcParameter参数
        /// 
        /// 参数名
        /// 参数类型
        /// 参数类型大小
        /// 参数值
        /// 返回一个OdbcParameter参数
        public static OdbcParameter MakeInParam(string ParamName, OdbcType DbType, int Size, object Value) { return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value); }
        /// 
        /// 输出一个OdbcParameter参数
        /// 
        /// 参数名
        /// 参数类型
        /// 参数类型大小
        /// 返回一个OdbcParameter参数
        public static OdbcParameter MakeOutParam(string ParamName, OdbcType DbType, int Size) { return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null); }
        /// 
        /// 构造一个OdbcParameter参数值
        /// 
        /// 参数名
        /// 参数类型
        /// 参数类型大小
        /// 输入/输出
        /// 参数值
        /// 返回一个OdbcParameter参数
        public static OdbcParameter MakeParam(string ParamName, OdbcType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            OdbcParameter param;
            if (Size > 0) param = new OdbcParameter(ParamName, DbType, Size); else param = new OdbcParameter(ParamName, DbType);
            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null)) param.Value = Value;
            return param;
        }
        #endregion

        #region ExecuteNonQuery
        /// 
        /// 执行一个Odbc，返回影响行数
        /// 
        /// 连接字符串
        /// CommandType
        /// Odbc
        /// 影响多少行
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(connectionString, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回影响行数
        /// 
        /// 连接字符串
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 影响多少行
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            using (OdbcConnection cn = new OdbcConnection(connectionString))
            {
                cn.Open();
                return ExecuteNonQuery(cn, commandType, commandText, commandParameters);
            }
        }
        /// 
        /// 执行一个存贮过程
        /// 
        /// 连接字符串
        /// 存贮过程名
        /// params object[]
        /// 影响多少行
        public static int ExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个Odbc，返回影响行数
        /// 
        /// OdbcConnection对象
        /// CommandType
        /// Odbc
        /// 影响多少行
        public static int ExecuteNonQuery(OdbcConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(connection, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回影响行数
        /// 
        /// OdbcConnection对象
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 影响多少行
        public static int ExecuteNonQuery(OdbcConnection connection, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            OdbcCommand cmd = new OdbcCommand();
            PrepareCommand(cmd, connection, (OdbcTransaction)null, commandType, commandText, commandParameters);
            int retval = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return retval;
        }
        /// 
        /// 执行一个存贮过程
        /// 
        /// OdbcConnection
        /// 存贮过程名
        /// params object[]
        /// 影响多少行
        public static int ExecuteNonQuery(OdbcConnection connection, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 事务执行一个Odbc，返回影响行数
        /// 
        /// OdbcTransaction
        /// CommandType
        /// Odbc
        /// 影响多少行
        public static int ExecuteNonQuery(OdbcTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(transaction, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 事务执行一个Odbc，返回影响行数
        /// 
        /// OdbcTransaction
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 影响多少行
        public static int ExecuteNonQuery(OdbcTransaction transaction, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            OdbcCommand cmd = new OdbcCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            int retval = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return retval;
        }
        /// 
        /// 事务执行一个存贮过程
        /// 
        /// OdbcTransaction
        /// 存贮过程名
        /// parameterValues
        /// 影响多少行
        public static int ExecuteNonQuery(OdbcTransaction transaction, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
        }
        #endregion

        #region ExecuteDataset
        /// 
        /// 执行一个Odbc，返回DataSet
        /// 
        /// 连接字符串
        /// CommandType
        /// Odbc
        /// 返回DataSet
        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteDataset(connectionString, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回DataSet
        /// 
        /// 连接字符串
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 返回DataSet
        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            using (OdbcConnection cn = new OdbcConnection(connectionString))
            {
                cn.Open();
                return ExecuteDataset(cn, commandType, commandText, commandParameters);
            }
        }
        /// 
        /// 执行一个存贮过程，返回DataSet
        /// 
        /// 连接字符串
        /// 存贮过程名
        /// parameterValues
        /// 返回DataSet
        public static DataSet ExecuteDataset(string connectionString, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个Odbc，返回DataSet
        /// 
        /// OdbcConnection
        /// CommandType
        /// Odbc
        /// 返回DataSet
        public static DataSet ExecuteDataset(OdbcConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteDataset(connection, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回DataSet
        /// 
        /// OdbcConnection
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 返回DataSet
        public static DataSet ExecuteDataset(OdbcConnection connection, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            OdbcCommand cmd = new OdbcCommand();
            PrepareCommand(cmd, connection, (OdbcTransaction)null, commandType, commandText, commandParameters);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            cmd.Parameters.Clear();
            return ds;
        }
        /// 
        /// 执行一个存贮过程，返回DataSet
        /// 
        /// OdbcConnection
        /// 存贮过程名
        /// parameterValues
        /// 返回DataSet
        public static DataSet ExecuteDataset(OdbcConnection connection, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteDataset(connection, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个Odbc，返回DataSet
        /// 
        /// OdbcTransaction
        /// CommandType
        /// Odbc
        /// 返回DataSet
        public static DataSet ExecuteDataset(OdbcTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteDataset(transaction, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回DataSet
        /// 
        /// OdbcTransaction
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 返回DataSet
        public static DataSet ExecuteDataset(OdbcTransaction transaction, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            OdbcCommand cmd = new OdbcCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            cmd.Parameters.Clear();
            return ds;
        }
        /// 
        /// 执行一个Odbc，返回DataSet
        /// 
        /// OdbcTransaction
        /// 存贮过程名
        /// parameterValues
        /// 返回DataSet
        public static DataSet ExecuteDataset(OdbcTransaction transaction, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
        }
        #endregion

        #region ExecuteDataTable
        /// 
        /// 执行一个Odbc，返回DataTable
        /// 
        /// 连接字符串
        /// CommandType
        /// Odbc
        /// 返回DataTable
        public static DataTable ExecuteDataTable(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteDataTable(connectionString, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回DataTable
        /// 
        /// 连接字符串
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 返回DataTable
        public static DataTable ExecuteDataTable(string connectionString, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            using (OdbcConnection cn = new OdbcConnection(connectionString))
            {
                //cn.Open();
                return ExecuteDataTable(cn, commandType, commandText, commandParameters);
            }
        }
        /// 
        /// 执行一个存贮过程，返回DataTable
        /// 
        /// 连接字符串
        /// 存贮过程名
        /// parameterValues
        /// 返回DataTable
        public static DataTable ExecuteDataTable(string connectionString, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataTable(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteDataTable(connectionString, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个Odbc，返回DataTable
        /// 
        /// OdbcConnection
        /// CommandType
        /// Odbc
        /// 返回DataTable
        public static DataTable ExecuteDataTable(OdbcConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteDataTable(connection, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回DataTable
        /// 
        /// OdbcConnection
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 返回DataTable
        public static DataTable ExecuteDataTable(OdbcConnection connection, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            OdbcCommand cmd = new OdbcCommand();
            PrepareCommand(cmd, connection, (OdbcTransaction)null, commandType, commandText, commandParameters);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            cmd.Parameters.Clear();
            connection.Close();
            return dt;
        }
        /// 
        /// 执行一个存贮过程，返回DataTable
        /// 
        /// OdbcConnection
        /// 存贮过程名
        /// parameterValues
        /// 返回DataTable
        public static DataTable ExecuteDataTable(OdbcConnection connection, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataTable(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteDataTable(connection, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个Odbc，返回DataTable
        /// 
        /// OdbcTransaction
        /// CommandType
        /// Odbc
        /// 返回DataTable
        public static DataTable ExecuteDataTable(OdbcTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteDataTable(transaction, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回DataTable
        /// 
        /// OdbcTransaction
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 返回DataTable
        public static DataTable ExecuteDataTable(OdbcTransaction transaction, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            OdbcCommand cmd = new OdbcCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            cmd.Parameters.Clear();
            return dt;
        }
        /// 
        /// 执行一个存贮过程，返回DataTable
        /// 
        /// OdbcTransaction
        /// 存贮过程名
        /// parameterValues
        /// 返回DataTable
        public static DataTable ExecuteDataTable(OdbcTransaction transaction, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataTable(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteDataTable(transaction, CommandType.StoredProcedure, spName);
        }
        #endregion

        #region ExecuteReader
        /// 
        /// Odbc连接身份
        /// 
        private enum OdbcConnectionOwnership
        {
            /// 
            /// 内部的
            /// 
            Internal,
            /// 
            /// 外部的
            /// 
            External
        }
        /// 
        /// 执行一个Odbc，返回OdbcDataReader
        /// 
        /// OdbcConnection
        /// OdbcTransaction
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// Odbc连接身份
        /// 返回OdbcDataReader
        private static OdbcDataReader ExecuteReader(OdbcConnection connection, OdbcTransaction transaction, CommandType commandType, string commandText, OdbcParameter[] commandParameters, OdbcConnectionOwnership connectionOwnership)
        {
            OdbcCommand cmd = new OdbcCommand();
            PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters);
            OdbcDataReader dr;
            if (connectionOwnership == OdbcConnectionOwnership.External) dr = cmd.ExecuteReader(); else dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return dr;
        }
        /// 
        /// 执行一个Odbc，返回OdbcDataReader
        /// 
        /// 连接字符串
        /// CommandType
        /// Odbc
        /// 返回OdbcDataReader
        public static OdbcDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteReader(connectionString, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回OdbcDataReader
        /// 
        /// 连接字符串
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 返回OdbcDataReader
        public static OdbcDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            OdbcConnection cn = new OdbcConnection(connectionString);
            cn.Open();

            try
            {
                return ExecuteReader(cn, null, commandType, commandText, commandParameters, OdbcConnectionOwnership.Internal);
            }
            catch
            {
                cn.Close();
                throw;
            }
        }
        /// 
        /// 执行一个存贮过程，返回OdbcDataReader
        /// 
        /// 连接字符串
        /// 存贮过程名
        /// parameterValues
        /// 返回OdbcDataReader
        public static OdbcDataReader ExecuteReader(string connectionString, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个Odbc，返回OdbcDataReader
        /// 
        /// OdbcConnection
        /// CommandType
        /// Odbc
        /// 返回OdbcDataReader
        public static OdbcDataReader ExecuteReader(OdbcConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteReader(connection, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回OdbcDataReader
        /// 
        /// OdbcConnection
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 返回OdbcDataReader
        public static OdbcDataReader ExecuteReader(OdbcConnection connection, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            return ExecuteReader(connection, (OdbcTransaction)null, commandType, commandText, commandParameters, OdbcConnectionOwnership.External);
        }
        /// 
        /// 执行一个存贮过程，返回OdbcDataReader
        /// 
        /// OdbcConnection
        /// 存贮过程名
        /// parameterValues
        /// 
        /// 
        /// OdbcDataReader dr = ExecuteReader(conn, "GetOrders", 24, 36);
        /// 
        /// 
        /// 返回OdbcDataReader
        public static OdbcDataReader ExecuteReader(OdbcConnection connection, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteReader(connection, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个Odbc，返回OdbcDataReader
        /// 
        /// OdbcTransaction
        /// CommandType
        /// Odbc
        /// 返回OdbcDataReader
        public static OdbcDataReader ExecuteReader(OdbcTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteReader(transaction, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回OdbcDataReader
        /// 
        /// OdbcTransaction
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 返回OdbcDataReader
        public static OdbcDataReader ExecuteReader(OdbcTransaction transaction, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, OdbcConnectionOwnership.External);
        }
        /// 
        /// 执行一个存贮过程，返回OdbcDataReader
        /// 
        /// OdbcTransaction
        /// 存贮过程名
        /// parameterValues
        /// 返回OdbcDataReader
        public static OdbcDataReader ExecuteReader(OdbcTransaction transaction, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteReader(transaction, CommandType.StoredProcedure, spName);
        }
        #endregion

        #region ExecuteScalar
        /// 
        /// 执行一个Odbc，返回第一行的第一列
        /// 
        /// 连接字符串
        /// CommandType
        /// Odbc
        /// 返回第一行的第一列
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteScalar(connectionString, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回第一行的第一列
        /// 
        /// 连接字符串
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 返回第一行的第一列
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            using (OdbcConnection cn = new OdbcConnection(connectionString))
            {
                cn.Open();
                return ExecuteScalar(cn, commandType, commandText, commandParameters);
            }
        }
        /// 
        /// 执行一个存贮过程，返回第一行的第一列
        /// 
        /// 连接字符串
        /// 存贮过程名
        /// parameterValues
        /// 返回第一行的第一列
        public static object ExecuteScalar(string connectionString, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个Odbc，返回第一行的第一列
        /// 
        /// OdbcConnection
        /// CommandType
        /// Odbc
        /// 返回第一行的第一列
        public static object ExecuteScalar(OdbcConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteScalar(connection, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回第一行的第一列
        /// 
        /// OdbcConnection
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 返回第一行的第一列
        public static object ExecuteScalar(OdbcConnection connection, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            OdbcCommand cmd = new OdbcCommand();
            PrepareCommand(cmd, connection, (OdbcTransaction)null, commandType, commandText, commandParameters);
            object retval = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return retval;
        }
        /// 
        /// 执行一个存贮过程，返回第一行的第一列
        /// 
        /// OdbcConnection
        /// 存贮过程名
        /// parameterValues
        /// 返回第一行的第一列
        public static object ExecuteScalar(OdbcConnection connection, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteScalar(connection, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个Odbc，返回第一行的第一列
        /// 
        /// OdbcTransaction
        /// CommandType
        /// Odbc
        /// 返回第一行的第一列
        public static object ExecuteScalar(OdbcTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteScalar(transaction, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回第一行的第一列
        /// 
        /// OdbcTransaction
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 返回第一行的第一列
        public static object ExecuteScalar(OdbcTransaction transaction, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            OdbcCommand cmd = new OdbcCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            object retval = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return retval;
        }
        /// 
        /// 执行一个存贮过程，返回第一行的第一列
        /// 
        /// OdbcTransaction
        /// 存贮过程名
        /// parameterValues
        /// 返回第一行的第一列
        public static object ExecuteScalar(OdbcTransaction transaction, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OdbcParameter[] commandParameters = OdbcHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
        }
        #endregion

        #region DataAdapter
        /// 
        /// 执行一个Odbc，返回OdbcDataAdapter
        /// 
        /// 连接字符串
        /// CommandType
        /// Odbc
        /// 返回OdbcDataAdapter
        public static OdbcDataAdapter DataAdapter(string connectionString, CommandType commandType, string commandText)
        {
            return DataAdapter(connectionString, commandType, commandText, (OdbcParameter[])null);
        }
        /// 
        /// 执行一个Odbc，返回OdbcDataAdapter
        /// 
        /// 连接字符串
        /// CommandType
        /// Odbc
        /// OdbcParameter[]参数集
        /// 返回OdbcDataAdapter
        public static OdbcDataAdapter DataAdapter(string connectionString, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            OdbcDataAdapter _da = new OdbcDataAdapter(commandText, connectionString);
            _da.SelectCommand.CommandType = commandType;
            if (commandParameters != null) AttachParameters(_da.SelectCommand, commandParameters);
            return _da;
        }
        #endregion

       
    }

    public sealed class OdbcHelperParameterCache
    {
        #region private methods, variables, and constructors
        private OdbcHelperParameterCache() { }
        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        /// 
        /// resolve at run time the appropriate set of OdbcParameters for a stored procedure
        /// 
        /// a valid connection string for a OdbcConnection
        /// the name of the stored procedure
        /// whether or not to include their return value parameter
        /// 
        private static OdbcParameter[] DiscoverSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            using (OdbcConnection cn = new OdbcConnection(connectionString))
            using (OdbcCommand cmd = new OdbcCommand(spName, cn))
            {
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                OdbcCommandBuilder.DeriveParameters(cmd);
                if (!includeReturnValueParameter)
                    cmd.Parameters.RemoveAt(0);
                OdbcParameter[] discoveredParameters = new OdbcParameter[cmd.Parameters.Count];
                cmd.Parameters.CopyTo(discoveredParameters, 0);
                return discoveredParameters;
            }
        }

        //deep copy of cached OdbcParameter array
        private static OdbcParameter[] CloneParameters(OdbcParameter[] originalParameters)
        {
            OdbcParameter[] clonedParameters = new OdbcParameter[originalParameters.Length];
            for (int i = 0, j = originalParameters.Length; i < j; i++)
                clonedParameters[i] = (OdbcParameter)((ICloneable)originalParameters[i]).Clone();
            return clonedParameters;
        }
        #endregion private methods, variables, and constructors

        #region caching functions
        /// 
        /// add parameter array to the cache
        /// 
        /// a valid connection string for a OdbcConnection
        /// the stored procedure name or T-Odbc command
        /// an array of OdbcParamters to be cached
        public static void CacheParameterSet(string connectionString, string commandText, params OdbcParameter[] commandParameters)
        {
            string hashKey = connectionString + ":" + commandText;
            paramCache[hashKey] = commandParameters;
        }

        /// 
        /// retrieve a parameter array from the cache
        /// 
        /// a valid connection string for a OdbcConnection
        /// the stored procedure name or T-Odbc command
        /// an array of OdbcParamters
        public static OdbcParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            string hashKey = connectionString + ":" + commandText;
            OdbcParameter[] cachedParameters = (OdbcParameter[])paramCache[hashKey];
            if (cachedParameters == null) return null; else return CloneParameters(cachedParameters);
        }
        #endregion caching functions

        #region Parameter Discovery Functions
        /// 
        /// Retrieves the set of OdbcParameters appropriate for the stored procedure
        /// 
        /// 
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// 
        /// a valid connection string for a OdbcConnection
        /// the name of the stored procedure
        /// an array of OdbcParameters
        public static OdbcParameter[] GetSpParameterSet(string connectionString, string spName)
        {
            return GetSpParameterSet(connectionString, spName, false);
        }

        /// 
        /// Retrieves the set of OdbcParameters appropriate for the stored procedure
        /// 
        /// 
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// 
        /// a valid connection string for a OdbcConnection
        /// the name of the stored procedure
        /// a bool value indicating whether the return value parameter should be included in the results
        /// an array of OdbcParameters
        public static OdbcParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            string hashKey = connectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
            OdbcParameter[] cachedParameters;
            cachedParameters = (OdbcParameter[])paramCache[hashKey];
            if (cachedParameters == null) cachedParameters = (OdbcParameter[])(paramCache[hashKey] = DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter));
            return CloneParameters(cachedParameters);
        }
        #endregion Parameter Discovery Functions
    }
}
