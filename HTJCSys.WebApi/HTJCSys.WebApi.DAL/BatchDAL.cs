using System;
using System.Text;
using MDL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BatchDAL
    {
        private SqlHelper helper = new SqlHelper();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long TID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BatchNo");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", TID)
			};

			return helper.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BatchMDL model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BatchNo(");
            strSql.Append("BarCode,ProductType,MaterialCode,MaterialName,BatchNo,BatchNum,StockNum,Supplier,CreateTime)");
            strSql.Append(" values (");
            strSql.Append("@BarCode,@ProductType,@MaterialCode,@MaterialName,@BatchNo,@BatchNum,@StockNum,@Supplier,@CreateTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@BarCode", model.BarCode),
                    new SqlParameter("@ProductType", model.ProductType),
                    new SqlParameter("@MaterialCode", model.MaterialCode),
					new SqlParameter("@MaterialName", model.MaterialName),
					new SqlParameter("@BatchNo", model.BatchNo),
					new SqlParameter("@BatchNum", model.BatchNum),
					new SqlParameter("@StockNum", model.StockNum),
					new SqlParameter("@Supplier", model.Supplier),
					new SqlParameter("@CreateTime", model.CreateTime)};

            int rows = helper.ExecuteSql(strSql.ToString(), parameters);
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
		public bool Update(BatchMDL model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update BatchNo set ");
            strSql.Append("BarCode=@BarCode,");
            strSql.Append("ProductType=@ProductType,");
            strSql.Append("MaterialCode=@MaterialCode,");
            strSql.Append("MaterialName=@MaterialName,");
            strSql.Append("BatchNo=@BatchNo,");
			strSql.Append("BatchNum=@BatchNum,");
            strSql.Append("StockNum=@StockNum,");
            strSql.Append("Supplier=@Supplier,");
            strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where TID=@TID");
            SqlParameter[] parameters = {
					new SqlParameter("@BarCode", model.BarCode),
                    new SqlParameter("@ProductType", model.ProductType),
                    new SqlParameter("@MaterialCode", model.MaterialCode),
					new SqlParameter("@MaterialName", model.MaterialName),
					new SqlParameter("@BatchNo", model.BatchNo),
					new SqlParameter("@BatchNum", model.BatchNum),
					new SqlParameter("@StockNum", model.StockNum),
					new SqlParameter("@Supplier", model.Supplier),
					new SqlParameter("@Supplier", model.Supplier),
					new SqlParameter("@CreateTime", model.CreateTime),
					new SqlParameter("@TID", model.TID)};

			int rows=helper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(long TID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BatchNo ");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", TID)
			};

			int rows=helper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string TIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BatchNo ");
			strSql.Append(" where TID in ("+TIDlist + ")  ");
			int rows=helper.ExecuteSql(strSql.ToString());
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
		public BatchMDL GetModel(long TID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select TID,ProductType,BarCode,MaterialCode,MaterialName,BatchNo,BatchNum,StockNum,Supplier,CreateTime from BatchNo ");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", TID)
			};

			BatchMDL model=new BatchMDL();
			DataSet ds=helper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
        public BatchMDL GetModel(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TOP 1 TID,BarCode,ProductType,MaterialCode,MaterialName,BatchNo,BatchNum,StockNum,Supplier,CreateTime from BatchNo ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where "+where);
            }

            BatchMDL model = new BatchMDL();
            DataSet ds = helper.Query(strSql.ToString());
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
		public BatchMDL DataRowToModel(DataRow row)
		{
			BatchMDL model=new BatchMDL();
			if (row != null)
			{
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=long.Parse(row["TID"].ToString());
				}
                if (row["BarCode"] != null)
				{
                    model.BarCode = row["BarCode"].ToString();
                }
                if (row["ProductType"] != null)
                {
                    model.ProductType = row["ProductType"].ToString();
                }
                if (row["MaterialCode"] != null)
                {
                    model.MaterialCode = row["MaterialCode"].ToString();
                }
                if (row["MaterialName"] != null)
				{
                    model.MaterialName = row["MaterialName"].ToString();
				}
				if(row["BatchNo"]!=null)
				{
					model.BatchNo=row["BatchNo"].ToString();
				}
				if(row["BatchNum"]!=null && row["BatchNum"].ToString()!="")
				{
					model.BatchNum=int.Parse(row["BatchNum"].ToString());
				}
				if(row["StockNum"]!=null && row["StockNum"].ToString()!="")
				{
					model.StockNum=int.Parse(row["StockNum"].ToString());
				}
                if (row["Supplier"] != null)
				{
                    model.Supplier = row["Supplier"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select TID,BarCode,ProductType,MaterialCode,MaterialName,BatchNo,BatchNum,StockNum,Supplier ");
			strSql.Append(" FROM BatchNo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return helper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM BatchNo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = helper.GetSingle(strSql.ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.TID desc");
			}
			strSql.Append(")AS Row, T.*  from BatchNo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return helper.Query(strSql.ToString());
		}
    }
}
