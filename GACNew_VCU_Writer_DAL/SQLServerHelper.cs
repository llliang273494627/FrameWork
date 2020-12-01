using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Collections;
using System.Threading;

//using Common;

namespace GACNew_VCU_Writer_DAL
{
    public class SQLServerHelper
    {
        public SQLServerHelper()
        { }

        #region private Parameters
        /// 
        /// 为SqlCommand添加参数
        /// 
        /// SqlCommand对象
        /// SqlParameter[]对象
        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            foreach (SqlParameter p in commandParameters)
            {
                if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null)) { p.Value = DBNull.Value; }
                command.Parameters.Add(p);
            }
        }
        /// 
        /// 为SqlParameter[]添加值
        /// 
        /// SqlParameter[]对象
        /// object[]对象
        private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null)) return;
            if (commandParameters.Length != parameterValues.Length) throw new ArgumentException("Parameter count does not match Parameter Value count.");
            for (int i = 0, j = commandParameters.Length; i < j; i++) commandParameters[i].Value = parameterValues[i];
        }
        /// 
        /// 这种方法打开,并指派一个connection, transaction, command type and parameters
        /// 
        /// SqlCommand对象
        /// SqlConnection对象
        /// SqlTransaction对象
        /// CommandType对象
        /// SQL字符串
        /// SqlParameter[]对象
        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            command.Connection = connection;
            command.CommandText = commandText;
            if (transaction != null) command.Transaction = transaction;
            command.CommandType = commandType;
            if (commandParameters != null) AttachParameters(command, commandParameters);
            return;
        }
        #endregion

        static int index = 0;

        public static SqlConnection GetSqlConnection(string connectionString)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            return cn;
        }

        public static bool CheckConnection(SqlConnection connection)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                //SystemModel.LogDetails.LogWriter("Err", string.Format("{0} 服务器不能连接：{1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), ex.StackTrace));
                if (index < 2 && connection.State != ConnectionState.Open)
                {
                    Thread.Sleep(1000);
                    index++;
                    return CheckConnection(connection);
                }
                else
                {
                    //new SysMonitor().SendAlert("JCXService", "slslsls", 1, "err");
                    return false;
                }
            }
        }

        public static void CheckCloseConneciton(SqlConnection connection)
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
        /// 组成一个SqlParameter参数
        /// 
        /// 参数名
        /// 参数值
        /// 返回一个SqlParameter参数
        public static SqlParameter MakeInParam(string ParamName, object Value) { return new SqlParameter(ParamName, Value); }
        /// 
        /// 组成一个SqlParameter参数
        /// 
        /// 参数名
        /// 参数类型
        /// 参数类型大小
        /// 参数值
        /// 返回一个SqlParameter参数
        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value) { return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value); }
        /// 
        /// 输出一个SqlParameter参数
        /// 
        /// 参数名
        /// 参数类型
        /// 参数类型大小
        /// 返回一个SqlParameter参数
        public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size) { return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null); }
        /// 
        /// 构造一个SqlParameter参数值
        /// 
        /// 参数名
        /// 参数类型
        /// 参数类型大小
        /// 输入/输出
        /// 参数值
        /// 返回一个SqlParameter参数
        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;
            if (Size > 0) param = new SqlParameter(ParamName, DbType, Size); else param = new SqlParameter(ParamName, DbType);
            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null)) param.Value = Value;
            return param;
        }
        #endregion

        #region ExecuteNonQuery
        /// 
        /// 执行一个SQL，返回影响行数
        /// 
        /// 连接字符串
        /// CommandType
        /// SQL
        /// 影响多少行
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(connectionString, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回影响行数
        /// 
        /// 连接字符串
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 影响多少行
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
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
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个SQL，返回影响行数
        /// 
        /// SqlConnection对象
        /// CommandType
        /// SQL
        /// 影响多少行
        public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(connection, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回影响行数
        /// 
        /// SqlConnection对象
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 影响多少行
        public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
            int retval = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connection.Close();
            return retval;
        }
        /// 
        /// 执行一个存贮过程
        /// 
        /// SqlConnection
        /// 存贮过程名
        /// params object[]
        /// 影响多少行
        public static int ExecuteNonQuery(SqlConnection connection, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 事务执行一个SQL，返回影响行数
        /// 
        /// SqlTransaction
        /// CommandType
        /// SQL
        /// 影响多少行
        public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(transaction, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 事务执行一个SQL，返回影响行数
        /// 
        /// SqlTransaction
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 影响多少行
        public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            int retval = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return retval;
        }
        /// 
        /// 事务执行一个存贮过程
        /// 
        /// SqlTransaction
        /// 存贮过程名
        /// parameterValues
        /// 影响多少行
        public static int ExecuteNonQuery(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
        }
        #endregion

        #region ExecuteDataset
        /// 
        /// 执行一个SQL，返回DataSet
        /// 
        /// 连接字符串
        /// CommandType
        /// SQL
        /// 返回DataSet
        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteDataset(connectionString, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回DataSet
        /// 
        /// 连接字符串
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 返回DataSet
        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
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
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个SQL，返回DataSet
        /// 
        /// SqlConnection
        /// CommandType
        /// SQL
        /// 返回DataSet
        public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteDataset(connection, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回DataSet
        /// 
        /// SqlConnection
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 返回DataSet
        public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            cmd.Parameters.Clear();
            connection.Close();
            return ds;
        }
        /// 
        /// 执行一个存贮过程，返回DataSet
        /// 
        /// SqlConnection
        /// 存贮过程名
        /// parameterValues
        /// 返回DataSet
        public static DataSet ExecuteDataset(SqlConnection connection, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteDataset(connection, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个SQL，返回DataSet
        /// 
        /// SqlTransaction
        /// CommandType
        /// SQL
        /// 返回DataSet
        public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteDataset(transaction, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回DataSet
        /// 
        /// SqlTransaction
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 返回DataSet
        public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            cmd.Parameters.Clear();
            return ds;
        }
        /// 
        /// 执行一个SQL，返回DataSet
        /// 
        /// SqlTransaction
        /// 存贮过程名
        /// parameterValues
        /// 返回DataSet
        public static DataSet ExecuteDataset(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
        }
        #endregion

        #region ExecuteDataTable
        /// 
        /// 执行一个SQL，返回DataTable
        /// 
        /// 连接字符串
        /// CommandType
        /// SQL
        /// 返回DataTable
        public static DataTable ExecuteDataTable(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteDataTable(connectionString, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回DataTable
        /// 
        /// 连接字符串
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 返回DataTable
        public static DataTable ExecuteDataTable(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
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
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataTable(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteDataTable(connectionString, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个SQL，返回DataTable
        /// 
        /// SqlConnection
        /// CommandType
        /// SQL
        /// 返回DataTable
        public static DataTable ExecuteDataTable(SqlConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteDataTable(connection, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回DataTable
        /// 
        /// SqlConnection
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 返回DataTable
        public static DataTable ExecuteDataTable(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
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
        /// SqlConnection
        /// 存贮过程名
        /// parameterValues
        /// 返回DataTable
        public static DataTable ExecuteDataTable(SqlConnection connection, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataTable(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteDataTable(connection, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个SQL，返回DataTable
        /// 
        /// SqlTransaction
        /// CommandType
        /// SQL
        /// 返回DataTable
        public static DataTable ExecuteDataTable(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteDataTable(transaction, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回DataTable
        /// 
        /// SqlTransaction
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 返回DataTable
        public static DataTable ExecuteDataTable(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            cmd.Parameters.Clear();
            return dt;
        }
        /// 
        /// 执行一个存贮过程，返回DataTable
        /// 
        /// SqlTransaction
        /// 存贮过程名
        /// parameterValues
        /// 返回DataTable
        public static DataTable ExecuteDataTable(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataTable(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteDataTable(transaction, CommandType.StoredProcedure, spName);
        }
        #endregion

        #region ExecuteReader
        /// 
        /// SQL连接身份
        /// 
        private enum SqlConnectionOwnership
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
        /// 执行一个SQL，返回SqlDataReader
        /// 
        /// SqlConnection
        /// SqlTransaction
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// SQL连接身份
        /// 返回SqlDataReader
        private static SqlDataReader ExecuteReader(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, SqlConnectionOwnership connectionOwnership)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters);
            SqlDataReader dr;
            if (connectionOwnership == SqlConnectionOwnership.External) dr = cmd.ExecuteReader(); else dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return dr;
        }
        /// 
        /// 执行一个SQL，返回SqlDataReader
        /// 
        /// 连接字符串
        /// CommandType
        /// SQL
        /// 返回SqlDataReader
        public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteReader(connectionString, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回SqlDataReader
        /// 
        /// 连接字符串
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 返回SqlDataReader
        public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();

            try
            {
                return ExecuteReader(cn, null, commandType, commandText, commandParameters, SqlConnectionOwnership.Internal);
            }
            catch
            {
                cn.Close();
                throw;
            }
        }
        /// 
        /// 执行一个存贮过程，返回SqlDataReader
        /// 
        /// 连接字符串
        /// 存贮过程名
        /// parameterValues
        /// 返回SqlDataReader
        public static SqlDataReader ExecuteReader(string connectionString, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个SQL，返回SqlDataReader
        /// 
        /// SqlConnection
        /// CommandType
        /// SQL
        /// 返回SqlDataReader
        public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteReader(connection, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回SqlDataReader
        /// 
        /// SqlConnection
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 返回SqlDataReader
        public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            return ExecuteReader(connection, (SqlTransaction)null, commandType, commandText, commandParameters, SqlConnectionOwnership.External);
        }
        /// 
        /// 执行一个存贮过程，返回SqlDataReader
        /// 
        /// SqlConnection
        /// 存贮过程名
        /// parameterValues
        /// 
        /// 
        /// SqlDataReader dr = ExecuteReader(conn, "GetOrders", 24, 36);
        /// 
        /// 
        /// 返回SqlDataReader
        public static SqlDataReader ExecuteReader(SqlConnection connection, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteReader(connection, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个SQL，返回SqlDataReader
        /// 
        /// SqlTransaction
        /// CommandType
        /// SQL
        /// 返回SqlDataReader
        public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteReader(transaction, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回SqlDataReader
        /// 
        /// SqlTransaction
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 返回SqlDataReader
        public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, SqlConnectionOwnership.External);
        }
        /// 
        /// 执行一个存贮过程，返回SqlDataReader
        /// 
        /// SqlTransaction
        /// 存贮过程名
        /// parameterValues
        /// 返回SqlDataReader
        public static SqlDataReader ExecuteReader(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteReader(transaction, CommandType.StoredProcedure, spName);
        }
        #endregion

        #region ExecuteScalar
        /// 
        /// 执行一个SQL，返回第一行的第一列
        /// 
        /// 连接字符串
        /// CommandType
        /// SQL
        /// 返回第一行的第一列
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteScalar(connectionString, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回第一行的第一列
        /// 
        /// 连接字符串
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 返回第一行的第一列
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
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
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个SQL，返回第一行的第一列
        /// 
        /// SqlConnection
        /// CommandType
        /// SQL
        /// 返回第一行的第一列
        public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteScalar(connection, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回第一行的第一列
        /// 
        /// SqlConnection
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 返回第一行的第一列
        public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
            object retval = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return retval;
        }
        /// 
        /// 执行一个存贮过程，返回第一行的第一列
        /// 
        /// SqlConnection
        /// 存贮过程名
        /// parameterValues
        /// 返回第一行的第一列
        public static object ExecuteScalar(SqlConnection connection, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteScalar(connection, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个SQL，返回第一行的第一列
        /// 
        /// SqlTransaction
        /// CommandType
        /// SQL
        /// 返回第一行的第一列
        public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteScalar(transaction, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回第一行的第一列
        /// 
        /// SqlTransaction
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 返回第一行的第一列
        public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            object retval = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return retval;
        }
        /// 
        /// 执行一个存贮过程，返回第一行的第一列
        /// 
        /// SqlTransaction
        /// 存贮过程名
        /// parameterValues
        /// 返回第一行的第一列
        public static object ExecuteScalar(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
        }
        #endregion

        #region DataAdapter
        /// 
        /// 执行一个SQL，返回SqlDataAdapter
        /// 
        /// 连接字符串
        /// CommandType
        /// SQL
        /// 返回SqlDataAdapter
        public static SqlDataAdapter DataAdapter(string connectionString, CommandType commandType, string commandText)
        {
            return DataAdapter(connectionString, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回SqlDataAdapter
        /// 
        /// 连接字符串
        /// CommandType
        /// SQL
        /// SqlParameter[]参数集
        /// 返回SqlDataAdapter
        public static SqlDataAdapter DataAdapter(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlDataAdapter _da = new SqlDataAdapter(commandText, connectionString);
            _da.SelectCommand.CommandType = commandType;
            if (commandParameters != null) AttachParameters(_da.SelectCommand, commandParameters);
            return _da;
        }
        #endregion

        #region ExecuteXmlReader
        /**
        /// 
        /// 执行一个SQL，返回XmlReader
        /// 
        /// SqlConnection
        /// CommandType
        /// Sql
        /// 返回XmlReader
        public static XmlReader ExecuteXmlReader(SqlConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteXmlReader(connection, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回XmlReader
        /// 
        /// SqlConnection
        /// CommandType
        /// Sql
        /// SqlParameter[]参数集
        /// 返回XmlReader
        public static XmlReader ExecuteXmlReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
            XmlReader retval = cmd.ExecuteXmlReader();
            cmd.Parameters.Clear();
            return retval;
        }
        /// 
        /// 执行一个存贮过程，返回XmlReader
        /// 
        /// SqlConnection
        /// 存贮过程名
        /// parameterValues
        /// 返回XmlReader
        public static XmlReader ExecuteXmlReader(SqlConnection connection, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteXmlReader(connection, CommandType.StoredProcedure, spName);
        }
        /// 
        /// 执行一个SQL，返回XmlReader
        /// 
        /// SqlTransaction
        /// CommandType
        /// Sql
        /// 返回XmlReader
        public static XmlReader ExecuteXmlReader(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteXmlReader(transaction, commandType, commandText, (SqlParameter[])null);
        }
        /// 
        /// 执行一个SQL，返回XmlReader
        /// 
        /// SqlTransaction
        /// CommandType
        /// Sql
        /// SqlParameter[]参数集
        /// 返回XmlReader
        public static XmlReader ExecuteXmlReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            XmlReader retval = cmd.ExecuteXmlReader();
            cmd.Parameters.Clear();
            return retval;
        }
        /// 
        /// 执行一个存贮过程，返回XmlReader
        /// 
        /// SqlTransaction
        /// 存贮过程名
        /// parameterValues
        /// 返回XmlReader
        public static XmlReader ExecuteXmlReader(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else return ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName);
        }
          **/
        #endregion

    }

    public sealed class SqlHelperParameterCache
    {
        #region private methods, variables, and constructors
        private SqlHelperParameterCache() { }
        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        /// 
        /// resolve at run time the appropriate set of SqlParameters for a stored procedure
        /// 
        /// a valid connection string for a SqlConnection
        /// the name of the stored procedure
        /// whether or not to include their return value parameter
        /// 
        private static SqlParameter[] DiscoverSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(spName, cn))
            {
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmd);
                if (!includeReturnValueParameter)
                    cmd.Parameters.RemoveAt(0);
                SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];
                cmd.Parameters.CopyTo(discoveredParameters, 0);
                return discoveredParameters;
            }
        }

        //deep copy of cached SqlParameter array
        private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];
            for (int i = 0, j = originalParameters.Length; i < j; i++)
                clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
            return clonedParameters;
        }
        #endregion private methods, variables, and constructors

        #region caching functions
        /// 
        /// add parameter array to the cache
        /// 
        /// a valid connection string for a SqlConnection
        /// the stored procedure name or T-SQL command
        /// an array of SqlParamters to be cached
        public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
        {
            string hashKey = connectionString + ":" + commandText;
            paramCache[hashKey] = commandParameters;
        }

        /// 
        /// retrieve a parameter array from the cache
        /// 
        /// a valid connection string for a SqlConnection
        /// the stored procedure name or T-SQL command
        /// an array of SqlParamters
        public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            string hashKey = connectionString + ":" + commandText;
            SqlParameter[] cachedParameters = (SqlParameter[])paramCache[hashKey];
            if (cachedParameters == null) return null; else return CloneParameters(cachedParameters);
        }
        #endregion caching functions

        #region Parameter Discovery Functions
        /// 
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// 
        /// 
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// 
        /// a valid connection string for a SqlConnection
        /// the name of the stored procedure
        /// an array of SqlParameters
        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
        {
            return GetSpParameterSet(connectionString, spName, false);
        }

        /// 
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// 
        /// 
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// 
        /// a valid connection string for a SqlConnection
        /// the name of the stored procedure
        /// a bool value indicating whether the return value parameter should be included in the results
        /// an array of SqlParameters
        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            string hashKey = connectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
            SqlParameter[] cachedParameters;
            cachedParameters = (SqlParameter[])paramCache[hashKey];
            if (cachedParameters == null) cachedParameters = (SqlParameter[])(paramCache[hashKey] = DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter));
            return CloneParameters(cachedParameters);
        }
        #endregion Parameter Discovery Functions

    }
}
