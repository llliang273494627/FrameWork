using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MDL;
using System.Data.SQLite;
using System.Data;

namespace DAL
{
    public class LProductSortDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from productsort");
            strSql.Append(" where productcode=@productcode");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@productcode", code)
			};

            return SQLiteHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ProductSortMDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into productsort(");
            strSql.Append("productcode,sortnum)");
            strSql.Append(" values (");
            strSql.Append("@productcode,@sortnum)");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@productcode", model.ProductCode),
					new SQLiteParameter("@sortnum", model.SortNum)};

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
        /// 更新一条数据
        /// </summary>
        public bool Update(ProductSortMDL model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update productsort set ");
                strSql.Append("sortnum=@sortnum");
                strSql.Append(" where productcode='@productcode'");
                SQLiteParameter[] parameters = {
					new SQLiteParameter("@sortnum", model.SortNum),                                           
					new SQLiteParameter("@productcode", model.ProductCode)};

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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from productsort ");
            strSql.Append(" where productcode=@productcode");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@productcode", code)
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
            strSql.Append("delete from productsort ");
            strSql.Append(" where productcode in (" + TIDlist + ")  ");
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
        public ProductSortMDL GetModel(string code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select productcode,sortnum from productsort ");
            strSql.Append(" where productcode=@productcode");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@productcode", code)
			};

            ProductSortMDL model = new ProductSortMDL();
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
        public ProductSortMDL DataRowToModel(DataRow row)
        {
            ProductSortMDL model = new ProductSortMDL();
            if (row != null)
            {
                if (row["productcode"] != null)
                {
                    model.ProductCode = row["productcode"].ToString();
                }
                if (row["sortnum"] != null && row["sortnum"].ToString() != "")
                {
                    model.SortNum = int.Parse(row["sortnum"].ToString());
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
            strSql.Append("select productcode,sortnum ");
            strSql.Append(" FROM productsort ");
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
            strSql.Append("select count(1) FROM productsort ");
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
            strSql.Append(")AS Row, T.*  from productsort T ");
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
