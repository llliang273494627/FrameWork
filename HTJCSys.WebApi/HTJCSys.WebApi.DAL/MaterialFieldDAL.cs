using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MaterialFieldDAL
    {
        private SqlHelper helper = new SqlHelper();
        public MaterialFieldDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long TID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from materialfield");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", SqlDbType.Int)
			};
			parameters[0].Value = TID;

			return helper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MDL.MaterialFieldMDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into materialfield(");
			strSql.Append("MaterialCode,MaterialName,TableName,FieldName,[Desc] )");
			strSql.Append(" values (");
			strSql.Append("@MaterialCode,@MaterialName,@TableName,@FieldName,@Desc)");
			SqlParameter[] parameters = {
					new SqlParameter("@MaterialCode", SqlDbType.VarChar,20),
					new SqlParameter("@MaterialName", SqlDbType.VarChar,45),
					new SqlParameter("@TableName", SqlDbType.VarChar,45),
					new SqlParameter("@FieldName", SqlDbType.VarChar,45),
					new SqlParameter("@Desc", SqlDbType.VarChar,128)};
			parameters[0].Value = model.MaterialCode;
			parameters[1].Value = model.MaterialName;
			parameters[2].Value = model.TableName;
			parameters[3].Value = model.FieldName;
			parameters[4].Value = model.Desc;

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
		public bool Update(MDL.MaterialFieldMDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update materialfield set ");
			strSql.Append("MaterialCode=@MaterialCode,");
			strSql.Append("MaterialName=@MaterialName,");
			strSql.Append("TableName=@TableName,");
			strSql.Append("FieldName=@FieldName,");
			strSql.Append("Desc=@Desc");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@MaterialCode", model.MaterialCode),
					new SqlParameter("@MaterialName", model.MaterialName),
					new SqlParameter("@TableName", model.TableName),
					new SqlParameter("@FieldName", model.FieldName),
					new SqlParameter("@Desc", model.Desc),
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
			strSql.Append("delete from materialfield ");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", SqlDbType.Int)
			};
			parameters[0].Value = TID;

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
			strSql.Append("delete from materialfield ");
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
		public MDL.MaterialFieldMDL GetModel(long TID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TID,MaterialCode,MaterialName,TableName,FieldName,[Desc]  from materialfield ");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", SqlDbType.Int)
			};
			parameters[0].Value = TID;

			MDL.MaterialFieldMDL model=new MDL.MaterialFieldMDL();
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
        public MDL.MaterialFieldMDL GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TOP 1 TID,MaterialCode,MaterialName,TableName,FieldName,[Desc]  from materialfield ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where "+where);
            }
            MDL.MaterialFieldMDL model = new MDL.MaterialFieldMDL();
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
		public MDL.MaterialFieldMDL DataRowToModel(DataRow row)
		{
			MDL.MaterialFieldMDL model=new MDL.MaterialFieldMDL();
			if (row != null)
			{
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=long.Parse(row["TID"].ToString());
				}
				if(row["MaterialCode"]!=null)
				{
					model.MaterialCode=row["MaterialCode"].ToString();
				}
				if(row["MaterialName"]!=null)
				{
					model.MaterialName=row["MaterialName"].ToString();
				}
				if(row["TableName"]!=null)
				{
					model.TableName=row["TableName"].ToString();
				}
				if(row["FieldName"]!=null)
				{
					model.FieldName=row["FieldName"].ToString();
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
			strSql.Append("select TID,MaterialCode,MaterialName,TableName,FieldName,[Desc]  ");
			strSql.Append(" FROM materialfield ");
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
			strSql.Append("select count(1) FROM materialfield ");
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
			strSql.Append(")AS Row, T.*  from materialfield T ");
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
					new SqlParameter("@PageSize", SqlDbType.Int32),
					new SqlParameter("@PageIndex", SqlDbType.Int32),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "materialfield";
			parameters[1].Value = "TID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return helper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
