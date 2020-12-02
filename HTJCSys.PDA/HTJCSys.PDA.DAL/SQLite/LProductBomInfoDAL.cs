﻿using System;
using System.Data;
using System.Text;
using System.Data.SQLite;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ProductBomInfoDAL
	/// </summary>
	public partial class LProductBomInfoDAL
	{
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long TID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from productbominfo");
			strSql.Append(" where TID=@TID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@TID", TID)
			};

			return SQLiteHelper.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MDL.ProductBomInfoMDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into productbominfo(");
            strSql.Append("TID,ProductType,ProductCode,ProductName,MaterialCode,MaterialName,MaterialNum,FeatureIndex,FeatureCode,BatchNum,ScannerID,TraceType,`Desc` )");
			strSql.Append(" values (");
			strSql.Append("@TID,@ProductType,@ProductCode,@ProductName,@MaterialCode,@MaterialName,@MaterialNum,@FeatureIndex,@FeatureCode,@BatchNum,@ScannerID,@TraceType,@Desc)");
			SQLiteParameter[] parameters = {
                    new SQLiteParameter("@TID", model.TID),
					new SQLiteParameter("@ProductType",  model.ProductType),
					new SQLiteParameter("@ProductCode",  model.ProductCode),
					new SQLiteParameter("@ProductName",  model.ProductName),
					new SQLiteParameter("@MaterialCode",  model.MaterialCode),
					new SQLiteParameter("@MaterialName",  model.MaterialName),
					new SQLiteParameter("@MaterialNum",  model.MaterialNum),
					new SQLiteParameter("@FeatureIndex",  model.FeatureIndex),
					new SQLiteParameter("@FeatureCode",  model.FeatureCode),
					new SQLiteParameter("@BatchNum",  model.BatchNum),
					new SQLiteParameter("@ScannerID",  model.ScannerID),
					new SQLiteParameter("@TraceType",  model.TraceType),
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
            strSql.Append("ScannerID=@ScannerID,");
            strSql.Append("TraceType=@TraceType,");
			strSql.Append("Desc=@Desc");
			strSql.Append(" where TID=@TID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ProductType",  model.ProductType),
					new SQLiteParameter("@ProductCode",  model.ProductCode),
					new SQLiteParameter("@ProductName",  model.ProductName),
					new SQLiteParameter("@MaterialCode",  model.MaterialCode),
					new SQLiteParameter("@MaterialName",  model.MaterialName),
					new SQLiteParameter("@MaterialNum",  model.MaterialNum),
					new SQLiteParameter("@FeatureIndex",  model.FeatureIndex),
					new SQLiteParameter("@FeatureCode",  model.FeatureCode),
					new SQLiteParameter("@BatchNum",  model.BatchNum),
					new SQLiteParameter("@ScannerID",  model.ScannerID),
					new SQLiteParameter("@TraceType",  model.TraceType),
					new SQLiteParameter("@Desc",  model.Desc),
					new SQLiteParameter("@TID",  model.TID)};

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
			strSql.Append("delete from productbominfo ");
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
		public bool DeleteList(string tidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from productbominfo ");
			strSql.Append(" where TID in ("+tidlist + ")  ");
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
		public MDL.ProductBomInfoMDL GetModel(long TID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TID,ProductType,ProductCode,ProductName,MaterialCode,MaterialName,MaterialNum,FeatureIndex,FeatureCode,BatchNum,ScannerID,TraceType,`Desc`  from productbominfo ");
			strSql.Append(" where TID=@TID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@TID", TID)
			};

			MDL.ProductBomInfoMDL model=new MDL.ProductBomInfoMDL();
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
                if (row["BatchNum"] != null && row["BatchNum"].ToString() != "")
                {
                    model.BatchNum = int.Parse(row["BatchNum"].ToString());
                }
				if(row["FeatureIndex"]!=null)
				{
					model.FeatureIndex=row["FeatureIndex"].ToString();
				}
				if(row["FeatureCode"]!=null)
				{
					model.FeatureCode=row["FeatureCode"].ToString();
                }
                if (row["ScannerID"] != null)
                {
                    model.ScannerID = row["ScannerID"].ToString();
                }
                if (row["TraceType"] != null)
                {
                    model.ScannerID = row["TraceType"].ToString();
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
			strSql.Append("select TID,ProductType,ProductCode,ProductName,MaterialCode,MaterialName,MaterialNum,FeatureIndex,FeatureCode,BatchNum,ScannerID,TraceType,`Desc`  ");
			strSql.Append(" FROM productbominfo ");
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
			strSql.Append("select count(1) FROM productbominfo ");
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
			strSql.Append(")AS Row, T.*  from productbominfo T ");
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
					new SQLiteParameter("@PageSize",  model.PageSize),
					new SQLiteParameter("@PageIndex",  model.PageIndex),
					new SQLiteParameter("@IsReCount",  model.IsReCount),
					new SQLiteParameter("@OrderType",  model.OrderType),
					new SQLiteParameter("@strWhere",  model.strWhere),
					};
			parameters[0].Value = "productbominfo";
			parameters[1].Value = "TID";
			parameters[6].Value = strWhere;	
			return SQLiteHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

