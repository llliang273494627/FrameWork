using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
	/// <summary>
    /// 数据访问类:UserInfoDAL
	/// </summary>
	public partial class UserInfoDAL
    {
        private SqlHelper helper = new SqlHelper();
        public UserInfoDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long TID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from userinfo");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", TID)
			};

			return helper.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MDL.UserInfoMDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into userinfo(");
			strSql.Append("UserID,UserName,UserSex,UserPwd,PhoneNum,Department,RoleName,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@UserName,@UserSex,@UserPwd,@PhoneNum,@Department,@RoleName,@CreateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID",  model.UserID),
					new SqlParameter("@UserName",  model.UserName),
					new SqlParameter("@UserSex",  model.UserSex),
					new SqlParameter("@UserPwd",  model.UserPwd),
					new SqlParameter("@PhoneNum",  model.PhoneNum),
					new SqlParameter("@Department",  model.Department),
					new SqlParameter("@RoleName",  model.RoleName),
					new SqlParameter("@CreateTime",  model.CreateTime)};

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
		public bool Update(MDL.UserInfoMDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update userinfo set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserSex=@UserSex,");
			strSql.Append("UserPwd=@UserPwd,");
			strSql.Append("PhoneNum=@PhoneNum,");
			strSql.Append("Department=@Department,");
			strSql.Append("RoleName=@RoleName,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID",  model.UserID),
					new SqlParameter("@UserName",  model.UserName),
					new SqlParameter("@UserSex",  model.UserSex),
					new SqlParameter("@UserPwd",  model.UserPwd),
					new SqlParameter("@PhoneNum",  model.PhoneNum),
					new SqlParameter("@Department",  model.Department),
					new SqlParameter("@RoleName",  model.RoleName),
					new SqlParameter("@CreateTime",  model.CreateTime),
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
			strSql.Append("delete from userinfo ");
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
			strSql.Append("delete from userinfo ");
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
		public MDL.UserInfoMDL GetModel(long TID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TID,UserID,UserName,UserSex,UserPwd,PhoneNum,Department,RoleName,CreateTime from userinfo ");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", TID)
			};

			MDL.UserInfoMDL model=new MDL.UserInfoMDL();
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
        public MDL.UserInfoMDL GetModel(string UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TID,UserID,UserName,UserSex,UserPwd,PhoneNum,Department,RoleName,CreateTime from userinfo ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", UserID)
			};

            MDL.UserInfoMDL model = new MDL.UserInfoMDL();
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
		public MDL.UserInfoMDL DataRowToModel(DataRow row)
		{
			MDL.UserInfoMDL model=new MDL.UserInfoMDL();
			if (row != null)
			{
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=long.Parse(row["TID"].ToString());
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserSex"]!=null)
				{
					model.UserSex=row["UserSex"].ToString();
				}
				if(row["UserPwd"]!=null)
				{
					model.UserPwd=row["UserPwd"].ToString();
				}
				if(row["PhoneNum"]!=null)
				{
					model.PhoneNum=row["PhoneNum"].ToString();
				}
				if(row["Department"]!=null)
				{
					model.Department=row["Department"].ToString();
				}
				if(row["RoleName"]!=null)
				{
					model.RoleName=row["RoleName"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
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
			strSql.Append("select TID,UserID,UserName,UserSex,UserPwd,PhoneNum,Department,RoleName,CreateTime ");
			strSql.Append(" FROM userinfo ");
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
			strSql.Append("select count(1) FROM userinfo ");
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
			strSql.Append(")AS Row, T.*  from userinfo T ");
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
			parameters[0].Value = "userinfo";
			parameters[1].Value = "TID";
			parameters[6].Value = strWhere;	
			return helper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

