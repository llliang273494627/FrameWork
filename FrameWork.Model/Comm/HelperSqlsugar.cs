using log4net;
using SqlSugar;
using System;

namespace FrameWork.Model.Comm
{
    public class HelperSqlsugar
    {
        // PostgreSQL：PORT=5432;DATABASE=DFPV_DSG101;HOST=localhost;PASSWORD=123456;USER ID=postgres
        // SqlServer：Server=127.0.0.1;Database=DFPV_DSG101;User Id=sa;Password=123456
        private static readonly ILog _logger = LogManager.GetLogger(typeof(HelperSqlsugar));
        private static ConnectionConfig _connection = null;
        /// <summary>
        /// 数据库操作类
        /// </summary>
        protected static SqlSugarClient sqlSugarClient = null;

        /// <summary>
        /// 是否连接
        /// </summary>
        public static bool IsOnlien { get; set; }

        /// <summary>
        /// 连接状态
        /// </summary>
        public static bool OnlineState()
        {
            try
            {
                sqlSugarClient.Open();
                sqlSugarClient.Close();
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error("连接数据库失败", ex);
                return false;
            }
        }

        /// <summary>
        /// 实例化SqlSugarClient
        /// </summary>
        /// <param name="dbType">1:SqlServer;4:PostgreSQL</param>
        /// <param name="conneStr">连接字符串</param>
        /// <returns></returns>
        public static SqlSugarClient Init(int dbType, string conneStr)
        {
            try
            {
                _connection = new ConnectionConfig()
                {
                    ConnectionString = conneStr,
                    DbType = (DbType)dbType,
                    IsAutoCloseConnection = true,
                    IsShardSameThread = false,
                    MoreSettings = new ConnMoreSettings()
                    {
                        IsAutoRemoveDataCache = true,
                        PgSqlIsAutoToLower=false,
                    },
                    // 自定义特性
                    ConfigureExternalServices = new ConfigureExternalServices()
                    {
                        EntityService = (property, column) =>
                        {
                            if (column.IsPrimarykey && property.PropertyType == typeof(int))
                            {
                                column.IsIdentity = true;
                            }
                        }
                    },
                    InitKeyType = InitKeyType.Attribute,
                };
                sqlSugarClient = new SqlSugarClient(_connection);
                IsOnlien = true;
                return sqlSugarClient;
            }
            catch (Exception ex)
            {
                IsOnlien = false;
                _logger.Error("连接数据库失败", ex);
            }
            return null;
        }
    }
}
