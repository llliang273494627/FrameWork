using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace DAL
{
    public class LRadiatorResultDAL
    {
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int tid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from radiatorresult");
			strSql.Append(" where tid=@tid");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tid",  tid)
			};
			
			return SQLiteHelper.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MDL.RadiatorResultMDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into radiatorresult(");
			strSql.Append("barcode,productcode,userid,stationid,radiatorcode,condensercode,fanassemblycode,intercoolercode,torque1,angle1,torque2,angle2,torque3,angle3,torque4,angle4,torque5,angle5,torque6,angle6,completed,createtime,completetime)");
			strSql.Append(" values (");
			strSql.Append("@barcode,@productcode,@userid,@stationid,@radiatorcode,@condensercode,@fanassemblycode,@intercoolercode,@torque1,@angle1,@torque2,@angle2,@torque3,@angle3,@torque4,@angle4,@torque5,@angle5,@torque6,@angle6,@completed,@createtime,@completetime)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@barcode",  model.barcode),
					new SQLiteParameter("@productcode",  model.productcode),
					new SQLiteParameter("@userid",  model.userid),
					new SQLiteParameter("@stationid",  model.stationid),
					new SQLiteParameter("@radiatorcode",  model.radiatorcode),
					new SQLiteParameter("@condensercode",  model.condensercode),
					new SQLiteParameter("@fanassemblycode",  model.fanassemblycode),
					new SQLiteParameter("@intercoolercode",  model.intercoolercode),
					new SQLiteParameter("@torque1",  model.torque1),
					new SQLiteParameter("@angle1",  model.angle1),
					new SQLiteParameter("@torque2",  model.torque2),
					new SQLiteParameter("@angle2",  model.angle2),
					new SQLiteParameter("@torque3",  model.torque3),
					new SQLiteParameter("@angle3",  model.angle3),
					new SQLiteParameter("@torque4",  model.torque4),
					new SQLiteParameter("@angle4",  model.angle4),
					new SQLiteParameter("@torque5",  model.torque5),
					new SQLiteParameter("@angle5",  model.angle5),
					new SQLiteParameter("@torque6",  model.torque6),
					new SQLiteParameter("@angle6",  model.angle6),
					new SQLiteParameter("@completed",  model.completed),
					new SQLiteParameter("@createtime",  model.createtime),
					new SQLiteParameter("@completetime",  model.completetime)};
																													
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
		public bool Update(MDL.RadiatorResultMDL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update radiatorresult set ");
			strSql.Append("barcode=@barcode,");
			strSql.Append("productcode=@productcode,");
			strSql.Append("userid=@userid,");
			strSql.Append("stationid=@stationid,");
			strSql.Append("radiatorcode=@radiatorcode,");
			strSql.Append("condensercode=@condensercode,");
			strSql.Append("fanassemblycode=@fanassemblycode,");
			strSql.Append("intercoolercode=@intercoolercode,");
			strSql.Append("torque1=@torque1,");
			strSql.Append("angle1=@angle1,");
			strSql.Append("torque2=@torque2,");
			strSql.Append("angle2=@angle2,");
			strSql.Append("torque3=@torque3,");
			strSql.Append("angle3=@angle3,");
			strSql.Append("torque4=@torque4,");
			strSql.Append("angle4=@angle4,");
			strSql.Append("torque5=@torque5,");
			strSql.Append("angle5=@angle5,");
			strSql.Append("torque6=@torque6,");
			strSql.Append("angle6=@angle6,");
			strSql.Append("completed=@completed,");
			strSql.Append("createtime=@createtime,");
			strSql.Append("completetime=@completetime");
			strSql.Append(" where tid=@tid");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@barcode",  model.barcode),
					new SQLiteParameter("@productcode",  model.productcode),
					new SQLiteParameter("@userid",  model.userid),
					new SQLiteParameter("@stationid",  model.stationid),
					new SQLiteParameter("@radiatorcode",  model.radiatorcode),
					new SQLiteParameter("@condensercode",  model.condensercode),
					new SQLiteParameter("@fanassemblycode",  model.fanassemblycode),
					new SQLiteParameter("@intercoolercode",  model.intercoolercode),
					new SQLiteParameter("@torque1",  model.torque1),
					new SQLiteParameter("@angle1",  model.angle1),
					new SQLiteParameter("@torque2",  model.torque2),
					new SQLiteParameter("@angle2",  model.angle2),
					new SQLiteParameter("@torque3",  model.torque3),
					new SQLiteParameter("@angle3",  model.angle3),
					new SQLiteParameter("@torque4",  model.torque4),
					new SQLiteParameter("@angle4",  model.angle4),
					new SQLiteParameter("@torque5",  model.torque5),
					new SQLiteParameter("@angle5",  model.angle5),
					new SQLiteParameter("@torque6",  model.torque6),
					new SQLiteParameter("@angle6",  model.angle6),
					new SQLiteParameter("@completed",  model.completed),
					new SQLiteParameter("@createtime",  model.createtime),
					new SQLiteParameter("@completetime",  model.completetime),
					new SQLiteParameter("@tid",  model.tid)};
						
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
		public bool Delete(int tid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from radiatorresult ");
			strSql.Append(" where tid=@tid");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tid",  tid)
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
			strSql.Append("delete from radiatorresult ");
			strSql.Append(" where tid in ("+tidlist + ")  ");
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
        public MDL.RadiatorResultMDL GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tid,barcode,productcode,userid,stationid,radiatorcode,condensercode,fanassemblycode,intercoolercode,torque1,angle1,torque2,angle2,torque3,angle3,torque4,angle4,torque5,angle5,torque6,angle6,completed,createtime,completetime from radiatorresult ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }
            strSql.Append(" limit 1");
            MDL.RadiatorResultMDL model = new MDL.RadiatorResultMDL();
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
		public MDL.RadiatorResultMDL GetModel(int tid)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select tid,barcode,productcode,userid,stationid,radiatorcode,condensercode,fanassemblycode,intercoolercode,torque1,angle1,torque2,angle2,torque3,angle3,torque4,angle4,torque5,angle5,torque6,angle6,completed,createtime,completetime from radiatorresult ");
			strSql.Append(" where tid=@tid");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tid",  tid)
			};
			
			MDL.RadiatorResultMDL model=new MDL.RadiatorResultMDL();
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
		public MDL.RadiatorResultMDL DataRowToModel(DataRow row)
		{
			MDL.RadiatorResultMDL model=new MDL.RadiatorResultMDL();
			if (row != null)
			{
				if(row["tid"]!=null && row["tid"].ToString()!="")
				{
					model.tid=int.Parse(row["tid"].ToString());
				}
				if(row["barcode"]!=null)
				{
					model.barcode=row["barcode"].ToString();
				}
				if(row["productcode"]!=null)
				{
					model.productcode=row["productcode"].ToString();
				}
				if(row["userid"]!=null)
				{
					model.userid=row["userid"].ToString();
				}
				if(row["stationid"]!=null)
				{
					model.stationid=row["stationid"].ToString();
				}
				if(row["radiatorcode"]!=null)
				{
					model.radiatorcode=row["radiatorcode"].ToString();
				}
				if(row["condensercode"]!=null)
				{
					model.condensercode=row["condensercode"].ToString();
				}
				if(row["fanassemblycode"]!=null)
				{
					model.fanassemblycode=row["fanassemblycode"].ToString();
				}
				if(row["intercoolercode"]!=null)
				{
					model.intercoolercode=row["intercoolercode"].ToString();
				}
				if(row["torque1"]!=null && row["torque1"].ToString()!="")
				{
					model.torque1=decimal.Parse(row["torque1"].ToString());
				}
				if(row["angle1"]!=null && row["angle1"].ToString()!="")
				{
					model.angle1=decimal.Parse(row["angle1"].ToString());
				}
				if(row["torque2"]!=null && row["torque2"].ToString()!="")
				{
					model.torque2=decimal.Parse(row["torque2"].ToString());
				}
				if(row["angle2"]!=null && row["angle2"].ToString()!="")
				{
					model.angle2=decimal.Parse(row["angle2"].ToString());
				}
				if(row["torque3"]!=null && row["torque3"].ToString()!="")
				{
					model.torque3=decimal.Parse(row["torque3"].ToString());
				}
				if(row["angle3"]!=null && row["angle3"].ToString()!="")
				{
					model.angle3=decimal.Parse(row["angle3"].ToString());
				}
				if(row["torque4"]!=null && row["torque4"].ToString()!="")
				{
					model.torque4=decimal.Parse(row["torque4"].ToString());
				}
				if(row["angle4"]!=null && row["angle4"].ToString()!="")
				{
					model.angle4=decimal.Parse(row["angle4"].ToString());
				}
				if(row["torque5"]!=null && row["torque5"].ToString()!="")
				{
					model.torque5=decimal.Parse(row["torque5"].ToString());
				}
				if(row["angle5"]!=null && row["angle5"].ToString()!="")
				{
					model.angle5=decimal.Parse(row["angle5"].ToString());
				}
				if(row["torque6"]!=null && row["torque6"].ToString()!="")
				{
					model.torque6=decimal.Parse(row["torque6"].ToString());
				}
				if(row["angle6"]!=null && row["angle6"].ToString()!="")
				{
					model.angle6=decimal.Parse(row["angle6"].ToString());
				}
				if(row["completed"]!=null && row["completed"].ToString()!="")
				{
					if((row["completed"].ToString()=="1")||(row["completed"].ToString().ToLower()=="true"))
					{
						model.completed=true;
					}
					else
					{
						model.completed=false;
					}
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
				}
				if(row["completetime"]!=null && row["completetime"].ToString()!="")
				{
					model.completetime=DateTime.Parse(row["completetime"].ToString());
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
			strSql.Append("select tid,barcode,productcode,userid,stationid,radiatorcode,condensercode,fanassemblycode,intercoolercode,torque1,angle1,torque2,angle2,torque3,angle3,torque4,angle4,torque5,angle5,torque6,angle6,completed,createtime,completetime ");
			strSql.Append(" FROM radiatorresult ");
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
			strSql.Append("select count(1) FROM radiatorresult ");
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
				strSql.Append("order by T.tid desc");
			}
			strSql.Append(")AS Row, T.*  from radiatorresult T ");
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
