using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
	/// <summary>
    /// 数据访问类:DeviceInfoDAL
	/// </summary>
	public partial class DeviceInfoDAL
    {
        private SqlHelper helper = new SqlHelper();

        public DeviceInfoDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long TID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from deviceinfo");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", TID)
			};

			return helper.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MDL.DeviceInfoMDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into deviceinfo(");
			strSql.Append("DeviceType,DeviceID,DeviceName,DeviceIP,ProductType,DeviceState,StationID,[Desc] )");
			strSql.Append(" values (");
			strSql.Append("@DeviceType,@DeviceID,@DeviceName,@DeviceIP,@ProductType,@DeviceState,@StationID,@Desc)");
			SqlParameter[] parameters = {
					new SqlParameter("@DeviceType",  model.DeviceType),
					new SqlParameter("@DeviceID",  model.DeviceID),
					new SqlParameter("@DeviceName",  model.DeviceName),
					new SqlParameter("@DeviceIP",  model.DeviceIP),
					new SqlParameter("@ProductType",  model.ProductType),
					new SqlParameter("@DeviceState",  model.DeviceState),
					new SqlParameter("@StationID",  model.StationID),
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
		public bool Update(MDL.DeviceInfoMDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update deviceinfo set ");
			strSql.Append("DeviceType=@DeviceType,");
			strSql.Append("DeviceID=@DeviceID,");
			strSql.Append("DeviceName=@DeviceName,");
			strSql.Append("DeviceIP=@DeviceIP,");
            strSql.Append("ProductType=@ProductType,");
            strSql.Append("DeviceState=@DeviceState,");
            strSql.Append("StationID=@StationID,");
			strSql.Append("Desc=@Desc");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@DeviceType",  model.DeviceType),
					new SqlParameter("@DeviceID",  model.DeviceID),
					new SqlParameter("@DeviceName",  model.DeviceName),
					new SqlParameter("@DeviceIP",  model.DeviceIP),
					new SqlParameter("@ProductType",  model.ProductType),
					new SqlParameter("@DeviceState",  model.DeviceState),
					new SqlParameter("@StationID",  model.StationID),
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
			strSql.Append("delete from deviceinfo ");
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
			strSql.Append("delete from deviceinfo ");
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
		public MDL.DeviceInfoMDL GetModel(long TID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TID,DeviceType,DeviceID,DeviceName,DeviceIP,ProductType,DeviceState,StationID,[Desc] from deviceinfo ");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", TID)
			};

			MDL.DeviceInfoMDL model=new MDL.DeviceInfoMDL();
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
        public MDL.DeviceInfoMDL GetModel(string str)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TID,DeviceType,DeviceID,DeviceName,DeviceIP,ProductType,DeviceState,StationID,[Desc] from deviceinfo ");
            if (!string.IsNullOrEmpty(str))
            {
                strSql.Append(" where "+str);
            }

            MDL.DeviceInfoMDL model = new MDL.DeviceInfoMDL();
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
		public MDL.DeviceInfoMDL DataRowToModel(DataRow row)
		{
			MDL.DeviceInfoMDL model=new MDL.DeviceInfoMDL();
			if (row != null)
			{
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=long.Parse(row["TID"].ToString());
				}
				if(row["DeviceType"]!=null)
				{
					model.DeviceType=row["DeviceType"].ToString();
				}
				if(row["DeviceID"]!=null)
				{
					model.DeviceID=row["DeviceID"].ToString();
				}
				if(row["DeviceName"]!=null)
				{
					model.DeviceName=row["DeviceName"].ToString();
				}
				if(row["DeviceIP"]!=null)
				{
					model.DeviceIP=row["DeviceIP"].ToString();
				}
				if(row["ProductType"]!=null)
				{
					model.ProductType=row["ProductType"].ToString();
                }
                if (row["DeviceState"] != null && row["DeviceState"].ToString() != "")
                {
                    model.DeviceState = int.Parse(row["DeviceState"].ToString());
                }
                if (row["StationID"] != null)
                {
                    model.StationID = row["StationID"].ToString();
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
			strSql.Append("select TID,DeviceType,DeviceID,DeviceName,DeviceIP,ProductType,DeviceState,StationID,[Desc]  ");
			strSql.Append(" FROM deviceinfo ");
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
			strSql.Append("select count(1) FROM deviceinfo ");
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
			strSql.Append(")AS Row, T.*  from deviceinfo T ");
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
			parameters[0].Value = "deviceinfo";
			parameters[1].Value = "TID";
			parameters[6].Value = strWhere;	
			return helper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

