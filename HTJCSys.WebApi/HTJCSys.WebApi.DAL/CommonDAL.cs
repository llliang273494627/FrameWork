using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 公共DAL操作类
    /// </summary>
    public class CommonDAL
    {
        private static SqlHelper helper = new SqlHelper();

        #region 获取DataTable
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql)
        {
            DataSet set = helper.Query(sql);
            if (set!=null || set.Tables.Count>0)
            {
                return set.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, params SqlParameter[] Parameters)
        {
            DataSet set = helper.Query(sql, Parameters);
            if (set != null || set.Tables.Count > 0)
            {
                return set.Tables[0];
            }
            else
            {
                return null;
            }
        } 
        #endregion

        public static bool ExecuteSql(string sql, params SqlParameter[] Parameters)
        {
            int rs = helper.ExecuteSql(sql, Parameters);
            return rs > 0 ? true : false;
        } 

        #region 测试数据库连接状态
        /// <summary>
        /// 测试数据库连接状态
        /// </summary>
        /// <returns></returns>
        public static bool TestConnection()
        {
            return helper.TestConnection();
        } 
        #endregion

        #region 获取第一行第一列
        /// <summary>
        /// 获取第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExecuteScaler(string sql, params SqlParameter[] parameters)
        {
            return helper.GetSingle(sql, parameters);
        } 
        #endregion
    }
}
