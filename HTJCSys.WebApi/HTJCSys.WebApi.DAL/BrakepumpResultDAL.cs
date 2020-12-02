using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BrakepumpResultDAL
    {
        private SqlHelper helper = new SqlHelper();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long tid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from brakepumpresult");
            strSql.Append(" where tid=@tid");
            SqlParameter[] parameters = {
					new SqlParameter("@tid",tid)
			};
            return helper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MDL.BrakepumpResultMDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into brakepumpresult(");
            strSql.Append("barcode,productcode,userid,stationid,brakepumpcode,gasketbatchno,hexagonalnutbatchno,pressuresensorbatchno,silencerbatchno,connectingpipe,boosterbrakepumpbracket,completed,createtime,completetime)");
            strSql.Append(" values (");
            strSql.Append("@barcode,@productcode,@userid,@stationid,@brakepumpcode,@gasketbatchno,@hexagonalnutbatchno,@pressuresensorbatchno,@silencerbatchno,@connectingpipe,@boosterbrakepumpbracket,@completed,@createtime,@completetime)");
            SqlParameter[] parameters = {
					new SqlParameter("@barcode",  model.barcode),
					new SqlParameter("@productcode",  model.productcode),
					new SqlParameter("@userid",  model.userid),
					new SqlParameter("@stationid",  model.stationid),
					new SqlParameter("@brakepumpcode",  model.brakepumpcode),
					new SqlParameter("@gasketbatchno",  model.gasketbatchno),
					new SqlParameter("@hexagonalnutbatchno",  model.hexagonalnutbatchno),
					new SqlParameter("@pressuresensorbatchno",  model.pressuresensorbatchno),
					new SqlParameter("@silencerbatchno",  model.silencerbatchno),
					new SqlParameter("@connectingpipe",  model.connectingpipe),
					new SqlParameter("@boosterbrakepumpbracket",  model.boosterbrakepumpbracket),
					new SqlParameter("@completed",  model.completed),
					new SqlParameter("@createtime",  model.createtime),
					new SqlParameter("@completetime",  model.completetime)};

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
        public bool Update(MDL.BrakepumpResultMDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update brakepumpresult set ");
            strSql.Append("barcode=@barcode,");
            strSql.Append("productcode=@productcode,");
            strSql.Append("userid=@userid,");
            strSql.Append("stationid=@stationid,");
            strSql.Append("brakepumpcode=@brakepumpcode,");
            strSql.Append("gasketbatchno=@gasketbatchno,");
            strSql.Append("hexagonalnutbatchno=@hexagonalnutbatchno,");
            strSql.Append("pressuresensorbatchno=@pressuresensorbatchno,");
            strSql.Append("silencerbatchno=@silencerbatchno,");
            strSql.Append("connectingpipe=@connectingpipe,");
            strSql.Append("boosterbrakepumpbracket=@boosterbrakepumpbracket,");
            strSql.Append("completed=@completed,");
            strSql.Append("createtime=@createtime,");
            strSql.Append("completetime=@completetime");
            strSql.Append(" where tid=@tid");
            SqlParameter[] parameters = {
					new SqlParameter("@barcode",  model.barcode),
					new SqlParameter("@productcode",  model.productcode),
					new SqlParameter("@userid",  model.userid),
					new SqlParameter("@stationid",  model.stationid),
					new SqlParameter("@brakepumpcode",  model.brakepumpcode),
					new SqlParameter("@gasketbatchno",  model.gasketbatchno),
					new SqlParameter("@hexagonalnutbatchno",  model.hexagonalnutbatchno),
					new SqlParameter("@pressuresensorbatchno",  model.pressuresensorbatchno),
					new SqlParameter("@silencerbatchno",  model.silencerbatchno),
					new SqlParameter("@connectingpipe",  model.connectingpipe),
					new SqlParameter("@boosterbrakepumpbracket",  model.boosterbrakepumpbracket),
					new SqlParameter("@completed",  model.completed),
					new SqlParameter("@createtime",  model.createtime),
					new SqlParameter("@completetime",  model.completetime),
					new SqlParameter("@tid",  model.tid)};
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(long tid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from brakepumpresult ");
            strSql.Append(" where tid=@tid");
            SqlParameter[] parameters = {
					new SqlParameter("@tid", tid)
			};
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string tidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from brakepumpresult ");
            strSql.Append(" where tid in (" + tidlist + ")  ");
            int rows = helper.ExecuteSql(strSql.ToString());
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
        public MDL.BrakepumpResultMDL GetModel(long tid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tid,barcode,productcode,userid,stationid,brakepumpcode,gasketbatchno,hexagonalnutbatchno,pressuresensorbatchno,silencerbatchno,connectingpipe,boosterbrakepumpbracket,completed,createtime,completetime from brakepumpresult ");
            strSql.Append(" where tid=@tid");
            SqlParameter[] parameters = {
					new SqlParameter("@tid", tid)
			};
            MDL.BrakepumpResultMDL model = new MDL.BrakepumpResultMDL();
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
        ///<summary>
        /// 得到一个对象实体
        /// </summary>
        public MDL.BrakepumpResultMDL GetModel(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tid,barcode,productcode,userid,stationid,brakepumpcode,gasketbatchno,hexagonalnutbatchno,pressuresensorbatchno,silencerbatchno,connectingpipe,boosterbrakepumpbracket,completed,createtime,completetime from brakepumpresult ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where "+where); 
            }
            MDL.BrakepumpResultMDL model = new MDL.BrakepumpResultMDL();
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
        public MDL.BrakepumpResultMDL DataRowToModel(DataRow row)
        {
            MDL.BrakepumpResultMDL model = new MDL.BrakepumpResultMDL();
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
                if (row["brakepumpcode"] != null)
                {
                    model.brakepumpcode = row["brakepumpcode"].ToString();
                }
                if (row["gasketbatchno"] != null)
                {
                    model.gasketbatchno = row["gasketbatchno"].ToString();
                }
                if (row["hexagonalnutbatchno"] != null)
                {
                    model.hexagonalnutbatchno = row["hexagonalnutbatchno"].ToString();
                }
                if (row["pressuresensorbatchno"] != null)
                {
                    model.pressuresensorbatchno = row["pressuresensorbatchno"].ToString();
                }
                if (row["silencerbatchno"] != null)
                {
                    model.silencerbatchno = row["silencerbatchno"].ToString();
                }
                if (row["connectingpipe"] != null)
                {
                    model.connectingpipe = row["connectingpipe"].ToString();
                }
                if (row["boosterbrakepumpbracket"] != null)
                {
                    model.boosterbrakepumpbracket = row["boosterbrakepumpbracket"].ToString();
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
            strSql.Append("select tid,barcode,productcode,userid,stationid,brakepumpcode,gasketbatchno,hexagonalnutbatchno,pressuresensorbatchno,silencerbatchno,connectingpipe,boosterbrakepumpbracket,completed,createtime,completetime ");
            strSql.Append(" FROM brakepumpresult ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return helper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM brakepumpresult ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            strSql.Append(")AS Row, T.*  from brakepumpresult T ");
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
