using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace DAL
{
    public class LMaterialFieldDAL
    {
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long TID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from materialfield");
			strSql.Append(" where TID=@TID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@TID",TID)
			};
			return SQLiteHelper.Exists(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MDL.MaterialFieldMDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into materialfield(");
			strSql.Append("TID,MaterialCode,MaterialName,TableName,FieldName,`Desc` )");
			strSql.Append(" values (");
			strSql.Append("@TID,@MaterialCode,@MaterialName,@TableName,@FieldName,@Desc)");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@TID", model.TID),
					new SQLiteParameter("@MaterialCode",  model.MaterialCode),
					new SQLiteParameter("@MaterialName",  model.MaterialName),
					new SQLiteParameter("@TableName",  model.TableName),
					new SQLiteParameter("@FieldName",  model.FieldName),
					new SQLiteParameter("@Desc",  model.Desc)};
			int rows=SQLiteHelper.ExecuteSql(strSql.ToString(),parameters);
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
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@MaterialCode", model.MaterialCode),
					new SQLiteParameter("@MaterialName", model.MaterialName),
					new SQLiteParameter("@TableName", model.TableName),
					new SQLiteParameter("@FieldName", model.FieldName),
					new SQLiteParameter("@Desc", model.Desc),
					new SQLiteParameter("@TID", model.TID)};
			int rows=SQLiteHelper.ExecuteSql(strSql.ToString(),parameters);
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
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@TID", TID)
			};
			int rows=SQLiteHelper.ExecuteSql(strSql.ToString(),parameters);
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
			int rows=SQLiteHelper.ExecuteSql(strSql.ToString());
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
			strSql.Append("select TID,MaterialCode,MaterialName,TableName,FieldName,`Desc`  from materialfield ");
			strSql.Append(" where TID=@TID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@TID",TID)
			};
			MDL.MaterialFieldMDL model=new MDL.MaterialFieldMDL();
			DataSet ds=SQLiteHelper.Query(strSql.ToString(),parameters);
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
            strSql.Append("select TID,MaterialCode,MaterialName,TableName,FieldName,`Desc`  from materialfield ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }
            strSql.Append(" LIMIT 1");
            MDL.MaterialFieldMDL model = new MDL.MaterialFieldMDL();
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
			strSql.Append("select TID,MaterialCode,MaterialName,TableName,FieldName,`Desc`  ");
			strSql.Append(" FROM materialfield ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return SQLiteHelper.Query(strSql.ToString());
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
			return SQLiteHelper.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", MySqlDbType.VarChar, 255),
					new SQLiteParameter("@fldName", MySqlDbType.VarChar, 255),
					new SQLiteParameter("@PageSize", MySqlDbType.Int32),
					new SQLiteParameter("@PageIndex", MySqlDbType.Int32),
					new SQLiteParameter("@IsReCount", MySqlDbType.Bit),
					new SQLiteParameter("@OrderType", MySqlDbType.Bit),
					new SQLiteParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "materialfield";
			parameters[1].Value = "TID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return SQLiteHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
