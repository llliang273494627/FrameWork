using System;
using System.Text;
using System.Data;
using System.Data.SQLite;
using MDL;

namespace DAL
{
    public partial class LAuxiliaryFasiaResultDAL
    {

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM AuxiliaryFasiaResult ");
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
        /// 判断数据是否存在
        /// </summary>
        public bool Exists(long tid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AuxiliaryFasiaResult");
            strSql.Append(" where ");
            strSql.Append(" tid = @tid  ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@tid", tid)
			};

            return SQLiteHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AuxiliaryFasiaResultMDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AuxiliaryFasiaResult(");
            strSql.Append("barcode,productcode,userid,stationid,linecode,completed,createtime,completetime,repairstate");
            strSql.Append(") values (");
            strSql.Append("@barcode,@productcode,@userid,@stationid,@linecode,@completed,@createtime,@completetime,@repairstate");
            strSql.Append(") ");
            SQLiteParameter[] parameters = {           
                        new SQLiteParameter("@completed", model.completed) ,            
                        new SQLiteParameter("@createtime", model.createtime) ,            
                        new SQLiteParameter("@completetime", model.completetime) ,            
                        new SQLiteParameter("@repairstate", model.repairstate) ,            
                        new SQLiteParameter("@barcode", model.barcode) ,            
                        new SQLiteParameter("@productcode", model.productcode) ,            
                        new SQLiteParameter("@userid", model.userid) ,            
                        new SQLiteParameter("@stationid", model.stationid) ,            
                        new SQLiteParameter("@linecode", model.linecode)           
              
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
        /// 更新一条数据
        /// </summary>
        public bool Update(AuxiliaryFasiaResultMDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AuxiliaryFasiaResult set ");
            strSql.Append(" barcode = @barcode , ");
            strSql.Append(" productcode = @productcode , ");
            strSql.Append(" userid = @userid , ");
            strSql.Append(" stationid = @stationid , ");
            strSql.Append(" linecode = @linecode , ");
            strSql.Append(" completed = @completed , ");
            strSql.Append(" createtime = @createtime , ");
            strSql.Append(" completetime = @completetime , ");
            strSql.Append(" repairstate = @repairstate ");
            strSql.Append(" where tid=@tid ");

            SQLiteParameter[] parameters = {
			            new SQLiteParameter("@tid", model.tid) ,            
                        new SQLiteParameter("@linecode", model.linecode) ,     
                        new SQLiteParameter("@completed", model.completed) ,            
                        new SQLiteParameter("@createtime", model.createtime) ,            
                        new SQLiteParameter("@completetime", model.completetime) ,            
                        new SQLiteParameter("@repairstate", model.repairstate) ,            
                        new SQLiteParameter("@barcode", model.barcode) ,            
                        new SQLiteParameter("@productcode", model.productcode) ,            
                        new SQLiteParameter("@userid", model.userid) ,            
                        new SQLiteParameter("@stationid", model.stationid)          
              
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(long tid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AuxiliaryFasiaResult ");
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string tidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AuxiliaryFasiaResult ");
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
        public AuxiliaryFasiaResultMDL GetModel(long tid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tid, barcode, productcode, userid, stationid , linecode, completed, createtime, completetime, repairstate");
            strSql.Append("  from AuxiliaryFasiaResult ");
            strSql.Append(" where tid=@tid");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@tid", tid)
			};

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
        public AuxiliaryFasiaResultMDL DataRowToModel(DataRow row)
        {
            AuxiliaryFasiaResultMDL model = new AuxiliaryFasiaResultMDL();
            if (row != null)
            {
                if (row["tid"].ToString() != "")
                {
                    model.tid = long.Parse(row["tid"].ToString());
                }
                if (row["completed"].ToString() != "")
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
                if (row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["completetime"].ToString() != "")
                {
                    model.completetime = DateTime.Parse(row["completetime"].ToString());
                }
                if (row["repairstate"].ToString() != "")
                {
                    model.repairstate = int.Parse(row["repairstate"].ToString());
                }
                model.barcode = row["barcode"].ToString();
                model.productcode = row["productcode"].ToString();
                model.userid = row["userid"].ToString();
                model.stationid = row["stationid"].ToString();
                model.linecode = row["linecode"].ToString();
            }
            return model;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM AuxiliaryFasiaResult ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SQLiteHelper.Query(strSql.ToString());
        }
    }
}