using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace DAL
{
    /// <summary>
    /// 数据访问类:LStockInfoDAL
    /// </summary>
    public class LStockInfoDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from stockinfo");
            strSql.Append(" where TID=@TID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@TID", TID)
			};

            return SQLiteHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.StockInfoMDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into stockinfo(");
            strSql.Append("BarCode,MaterialCode,MaterialName,ScannerID)");
            strSql.Append(" values (");
            strSql.Append("@BarCode,@MaterialCode,@MaterialName,@ScannerID)");
            strSql.Append(";select LAST_INSERT_ROWID()");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@BarCode", model.BarCode),
					new SQLiteParameter("@MaterialCode", model.MaterialCode),
					new SQLiteParameter("@MaterialName", model.MaterialName),
					new SQLiteParameter("@ScannerID", model.ScannerID)};

            object obj = SQLiteHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MDL.StockInfoMDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update stockinfo set ");
            strSql.Append("BarCode=@BarCode,");
            strSql.Append("MaterialCode=@MaterialCode,");
            strSql.Append("MaterialName=@MaterialName,");
            strSql.Append("ScannerID=@ScannerID");
            strSql.Append(" where TID=@TID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@BarCode", model.BarCode),
					new SQLiteParameter("@MaterialCode", model.MaterialCode),
					new SQLiteParameter("@MaterialName", model.MaterialName),
					new SQLiteParameter("@ScannerID", model.ScannerID),
					new SQLiteParameter("@TID", model.TID)};

            int rows = SQLiteHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int TID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from stockinfo ");
            strSql.Append(" where TID=@TID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@TID", TID)
			};

            int rows = SQLiteHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string TIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from stockinfo ");
            strSql.Append(" where TID in (" + TIDlist + ")  ");
            int rows = SQLiteHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MDL.StockInfoMDL GetModel(int TID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TID,BarCode,MaterialCode,MaterialName,ScannerID from stockinfo ");
            strSql.Append(" where TID=@TID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@TID",TID)
			};

            MDL.StockInfoMDL model = new MDL.StockInfoMDL();
            DataSet ds = SQLiteHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MDL.StockInfoMDL GetModel(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TID,BarCode,MaterialCode,MaterialName,ScannerID from stockinfo ");
            
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where "+where);
            }
            MDL.StockInfoMDL model = new MDL.StockInfoMDL();
            DataSet ds = SQLiteHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MDL.StockInfoMDL DataRowToModel(DataRow row)
        {
            MDL.StockInfoMDL model = new MDL.StockInfoMDL();
            if (row != null)
            {
                if (row["TID"] != null && row["TID"].ToString() != "")
                {
                    model.TID = int.Parse(row["TID"].ToString());
                }
                if (row["BarCode"] != null)
                {
                    model.BarCode = row["BarCode"].ToString();
                }
                if (row["MaterialCode"] != null)
                {
                    model.MaterialCode = row["MaterialCode"].ToString();
                }
                if (row["MaterialName"] != null)
                {
                    model.MaterialName = row["MaterialName"].ToString();
                }
                if (row["ScannerID"] != null)
                {
                    model.ScannerID = row["ScannerID"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TID,BarCode,MaterialCode,MaterialName,ScannerID ");
            strSql.Append(" FROM stockinfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SQLiteHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM stockinfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = SQLiteHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.TID desc");
            }
            strSql.Append(")AS Row, T.*  from stockinfo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return SQLiteHelper.Query(strSql.ToString());
        }
    }
}
