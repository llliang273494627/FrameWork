using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace DAL
{
    public class LPedalResultDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long tid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from pedalresult");
            strSql.Append(" where tid=@tid");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@tid", tid)
			};

            return SQLiteHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MDL.PedalResultMDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pedalresult(");
            strSql.Append("barcode,productcode,userid,stationid,pedalassycode,accelpedalcode,cluthhandlebatchno,boltbatchno,nutbatchno,torque1,torque2,torque3,completed,createtime,completetime)");
            strSql.Append(" values (");
            strSql.Append("@barcode,@productcode,@userid,@stationid,@pedalassycode,@accelpedalcode,@cluthhandlebatchno,@boltbatchno,@nutbatchno,@torque1,@torque2,@torque3,@completed,@createtime,@completetime)");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@barcode",  model.barcode),
					new SQLiteParameter("@productcode",  model.productcode),
					new SQLiteParameter("@userid",  model.userid),
					new SQLiteParameter("@stationid",  model.stationid),
					new SQLiteParameter("@pedalassycode",  model.pedalassycode),
					new SQLiteParameter("@accelpedalcode",  model.accelpedalcode),
					new SQLiteParameter("@cluthhandlebatchno",  model.cluthhandlebatchno),
					new SQLiteParameter("@boltbatchno",  model.boltbatchno),
					new SQLiteParameter("@nutbatchno",  model.nutbatchno),
					new SQLiteParameter("@torque1",  model.torque1),
					new SQLiteParameter("@torque2",  model.torque2),
					new SQLiteParameter("@torque3",  model.torque3),
					new SQLiteParameter("@completed",  model.completed),
					new SQLiteParameter("@createtime",  model.createtime),
					new SQLiteParameter("@completetime",  model.completetime)};
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
        public bool Update(MDL.PedalResultMDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pedalresult set ");
            strSql.Append("barcode=@barcode,");
            strSql.Append("productcode=@productcode,");
            strSql.Append("userid=@userid,");
            strSql.Append("stationid=@stationid,");
            strSql.Append("pedalassycode=@pedalassycode,");
            strSql.Append("accelpedalcode=@accelpedalcode,");
            strSql.Append("cluthhandlebatchno=@cluthhandlebatchno,");
            strSql.Append("boltbatchno=@boltbatchno,");
            strSql.Append("nutbatchno=@nutbatchno,");
            strSql.Append("torque1=@torque1,");
            strSql.Append("torque2=@torque2,");
            strSql.Append("torque3=@torque3,");
            strSql.Append("completed=@completed,");
            strSql.Append("createtime=@createtime,");
            strSql.Append("completetime=@completetime");
            strSql.Append(" where tid=@tid");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@barcode",  model.barcode),
					new SQLiteParameter("@productcode",  model.productcode),
					new SQLiteParameter("@userid",  model.userid),
					new SQLiteParameter("@stationid",  model.stationid),
					new SQLiteParameter("@pedalassycode",  model.pedalassycode),
					new SQLiteParameter("@accelpedalcode",  model.accelpedalcode),
					new SQLiteParameter("@cluthhandlebatchno",  model.cluthhandlebatchno),
					new SQLiteParameter("@boltbatchno",  model.boltbatchno),
					new SQLiteParameter("@nutbatchno",  model.nutbatchno),
					new SQLiteParameter("@torque1",  model.torque1),
					new SQLiteParameter("@torque2",  model.torque2),
					new SQLiteParameter("@torque3",  model.torque3),
					new SQLiteParameter("@completed",  model.completed),
					new SQLiteParameter("@createtime",  model.createtime),
					new SQLiteParameter("@completetime",  model.completetime),
					new SQLiteParameter("@tid",  model.tid)};

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
        public bool Delete(long tid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pedalresult ");
            strSql.Append(" where tid=@tid");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@tid", tid)
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
        public bool DeleteList(string tidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pedalresult ");
            strSql.Append(" where tid in (" + tidlist + ")  ");
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
        public MDL.PedalResultMDL GetModel(long tid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tid,barcode,productcode,userid,stationid,pedalassycode,accelpedalcode,cluthhandlebatchno,boltbatchno,nutbatchno,torque1,torque2,torque3,completed,createtime,completetime from pedalresult ");
            strSql.Append(" where tid=@tid");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@tid", tid)
			};
            MDL.PedalResultMDL model = new MDL.PedalResultMDL();
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
        public MDL.PedalResultMDL GetModel(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tid,barcode,productcode,userid,stationid,pedalassycode,accelpedalcode,cluthhandlebatchno,boltbatchno,nutbatchno,torque1,torque2,torque3,completed,createtime,completetime from pedalresult ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where "+where);
            }
            MDL.PedalResultMDL model = new MDL.PedalResultMDL();
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
        public MDL.PedalResultMDL DataRowToModel(DataRow row)
        {
            MDL.PedalResultMDL model = new MDL.PedalResultMDL();
            if (row != null)
            {
                if (row["tid"] != null && row["tid"].ToString() != "")
                {
                    model.tid = long.Parse(row["tid"].ToString());
                }
                if (row["barcode"] != null)
                {
                    model.barcode = row["barcode"].ToString();
                }
                if (row["productcode"] != null)
                {
                    model.productcode = row["productcode"].ToString();
                }
                if (row["userid"] != null)
                {
                    model.userid = row["userid"].ToString();
                }
                if (row["stationid"] != null)
                {
                    model.stationid = row["stationid"].ToString();
                }
                if (row["pedalassycode"] != null)
                {
                    model.pedalassycode = row["pedalassycode"].ToString();
                }
                if (row["accelpedalcode"] != null)
                {
                    model.accelpedalcode = row["accelpedalcode"].ToString();
                }
                if (row["cluthhandlebatchno"] != null)
                {
                    model.cluthhandlebatchno = row["cluthhandlebatchno"].ToString();
                }
                if (row["boltbatchno"] != null)
                {
                    model.boltbatchno = row["boltbatchno"].ToString();
                }
                if (row["nutbatchno"] != null)
                {
                    model.nutbatchno = row["nutbatchno"].ToString();
                }
                if (row["torque1"] != null && row["torque1"].ToString() != "")
                {
                    model.torque1 = decimal.Parse(row["torque1"].ToString());
                }
                if (row["torque2"] != null && row["torque2"].ToString() != "")
                {
                    model.torque2 = decimal.Parse(row["torque2"].ToString());
                }
                if (row["torque3"] != null && row["torque3"].ToString() != "")
                {
                    model.torque3 = decimal.Parse(row["torque3"].ToString());
                }
                if (row["completed"] != null && row["completed"].ToString() != "")
                {
                    if ((row["completed"].ToString() == "1") || (row["completed"].ToString().ToLower() == "true"))
                    {
                        model.completed = true;
                    }
                    else
                    {
                        model.completed = false;
                    }
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["completetime"] != null && row["completetime"].ToString() != "")
                {
                    model.completetime = DateTime.Parse(row["completetime"].ToString());
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
            strSql.Append("select tid,barcode,productcode,userid,stationid,pedalassycode,accelpedalcode,cluthhandlebatchno,boltbatchno,nutbatchno,torque1,torque2,torque3,completed,createtime,completetime ");
            strSql.Append(" FROM pedalresult ");
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
            strSql.Append("select count(1) FROM pedalresult ");
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
                strSql.Append("order by T.tid desc");
            }
            strSql.Append(")AS Row, T.*  from pedalresult T ");
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
