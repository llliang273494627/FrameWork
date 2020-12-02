using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ProductBomInfoDAL
	/// </summary>
	public partial class ProductBomInfoDAL
	{

        private SqlHelper helper = new SqlHelper();
        public ProductBomInfoDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long TID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from productbominfo");
			strSql.Append(" where TID=@TID");
            SqlParameter[] parameters = {
					new SqlParameter("@TID", TID)
			};

			return helper.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MDL.ProductBomInfoMDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into productbominfo(");
            strSql.Append("ProductType,ProductCode,ProductName,MaterialCode,MaterialName,MaterialNum,FeatureIndex,FeatureCode,BatchNum,TraceType,[Desc] )");
			strSql.Append(" values (");
			strSql.Append("@ProductType,@ProductCode,@ProductName,@MaterialCode,@MaterialName,@MaterialNum,@FeatureIndex,@FeatureCode,@BatchNum,@TraceType,@Desc)");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductType",  model.ProductType),
					new SqlParameter("@ProductCode",  model.ProductCode),
					new SqlParameter("@ProductName",  model.ProductName),
					new SqlParameter("@MaterialCode",  model.MaterialCode),
					new SqlParameter("@MaterialName",  model.MaterialName),
					new SqlParameter("@MaterialNum",  model.MaterialNum),
					new SqlParameter("@FeatureIndex",  model.FeatureIndex),
					new SqlParameter("@FeatureCode",  model.FeatureCode),
					new SqlParameter("@BatchNum",  model.BatchNum),
					//new SqlParameter("@ScannerID",  model.ScannerID),
					new SqlParameter("@TraceType",  model.TraceType),
					new SqlParameter("@Desc",  model.Desc)};

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
		/// 更新一条数据
		/// </summary>
		public bool Update(MDL.ProductBomInfoMDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update productbominfo set ");
			strSql.Append("ProductType=@ProductType,");
			strSql.Append("ProductCode=@ProductCode,");
			strSql.Append("ProductName=@ProductName,");
			strSql.Append("MaterialCode=@MaterialCode,");
			strSql.Append("MaterialName=@MaterialName,");
			strSql.Append("MaterialNum=@MaterialNum,");
			strSql.Append("FeatureIndex=@FeatureIndex,");
            strSql.Append("FeatureCode=@FeatureCode,");
            strSql.Append("BatchNum=@BatchNum,");
            //strSql.Append("ScannerID=@ScannerID,");
            strSql.Append("TraceType=@TraceType,");
			strSql.Append("Desc=@Desc");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductType",  model.ProductType),
					new SqlParameter("@ProductCode",  model.ProductCode),
					new SqlParameter("@ProductName",  model.ProductName),
					new SqlParameter("@MaterialCode",  model.MaterialCode),
					new SqlParameter("@MaterialName",  model.MaterialName),
					new SqlParameter("@MaterialNum",  model.MaterialNum),
					new SqlParameter("@FeatureIndex",  model.FeatureIndex),
					new SqlParameter("@FeatureCode",  model.FeatureCode),
					new SqlParameter("@BatchNum",  model.BatchNum),
					//new SqlParameter("@ScannerID",  model.ScannerID),
					new SqlParameter("@TraceType",  model.TraceType),
					new SqlParameter("@Desc",  model.Desc),
					new SqlParameter("@TID",  model.TID)};

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
			strSql.Append("delete from productbominfo ");
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
		public bool DeleteList(string tidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from productbominfo ");
			strSql.Append(" where TID in ("+tidlist + ")  ");
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
        public MDL.ProductBomInfoMDL GetModel(long TID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TID,ProductType,ProductCode,ProductName,MaterialCode,MaterialName,MaterialNum,FeatureIndex,FeatureCode,BatchNum,TraceType,[Desc]  from productbominfo ");
            strSql.Append(" where TID=@TID");
            SqlParameter[] parameters = {
					new SqlParameter("@TID", TID)
			};

            MDL.ProductBomInfoMDL model = new MDL.ProductBomInfoMDL();
            DataSet ds = helper.Query(strSql.ToString(), parameters);
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
        public MDL.ProductBomInfoMDL GetModel(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TOP 1 TID,ProductType,ProductCode,ProductName,MaterialCode,MaterialName,MaterialNum,FeatureIndex,FeatureCode,BatchNum,TraceType,[Desc]  from productbominfo ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where); 
            }
            MDL.ProductBomInfoMDL model = new MDL.ProductBomInfoMDL();
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
		public MDL.ProductBomInfoMDL DataRowToModel(DataRow row)
		{
			MDL.ProductBomInfoMDL model=new MDL.ProductBomInfoMDL();
			if (row != null)
			{
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=long.Parse(row["TID"].ToString());
				}
				if(row["ProductType"]!=null)
				{
					model.ProductType=row["ProductType"].ToString();
				}
				if(row["ProductCode"]!=null)
				{
					model.ProductCode=row["ProductCode"].ToString();
				}
				if(row["ProductName"]!=null)
				{
					model.ProductName=row["ProductName"].ToString();
				}
				if(row["MaterialCode"]!=null)
				{
					model.MaterialCode=row["MaterialCode"].ToString();
				}
				if(row["MaterialName"]!=null)
				{
					model.MaterialName=row["MaterialName"].ToString();
				}
				if(row["MaterialNum"]!=null && row["MaterialNum"].ToString()!="")
				{
					model.MaterialNum=int.Parse(row["MaterialNum"].ToString());
				}
				if(row["FeatureIndex"]!=null)
				{
					model.FeatureIndex=row["FeatureIndex"].ToString();
				}
				if(row["FeatureCode"]!=null)
				{
					model.FeatureCode=row["FeatureCode"].ToString();
                }
                if (row["BatchNum"] != null && row["BatchNum"].ToString() != "")
                {
                    model.BatchNum = int.Parse(row["BatchNum"].ToString());
                }
                //if (row["ScannerID"] != null)
                //{
                //    model.ScannerID = row["ScannerID"].ToString();
                //}
                if (row["TraceType"] != null)
                {
                    model.TraceType = row["TraceType"].ToString();
                }
				if(row["Desc"]!=null)
				{
					model.Desc=row["Desc"].ToString();
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
			strSql.Append("select TID,ProductType,ProductCode,ProductName,MaterialCode,MaterialName,MaterialNum,FeatureIndex,FeatureCode,BatchNum,TraceType,[Desc]  ");
			strSql.Append(" FROM productbominfo ");
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
			strSql.Append("select count(1) FROM productbominfo ");
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
				strSql.Append("order by T.TID Desc");
			}
			strSql.Append(")AS Row, T.*  from productbominfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return helper.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize",  model.PageSize),
					new SqlParameter("@PageIndex",  model.PageIndex),
					new SqlParameter("@IsReCount",  model.IsReCount),
					new SqlParameter("@OrderType",  model.OrderType),
					new SqlParameter("@strWhere",  model.strWhere),
					};
			parameters[0].Value = "productbominfo";
			parameters[1].Value = "TID";
			parameters[6].Value = strWhere;	
			return helper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

