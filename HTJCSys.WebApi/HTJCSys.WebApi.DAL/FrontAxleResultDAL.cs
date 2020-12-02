using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MDL;

namespace DAL
{
    public partial class FrontAxleResultDAL
    {
        private SqlHelper helper = new SqlHelper();

        /// <summary>
        /// 判断数据是否存在
        /// </summary>
        public bool Exists(long tid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from frontaxleresult");
            strSql.Append(" where ");
            strSql.Append(" tid = @tid  ");
            SqlParameter[] parameters = {
					new SqlParameter("@tid", tid)
			};

            return helper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(FrontAxleResultMDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into frontaxleresult(");
            strSql.Append("leftfrontcaliperbatchno,rightfrontcaliperbatchno,caliperboltbatchno,lowerballpinbatchno,completed,createtime,completetime,repairstate,barcode,productcode,userid,stationid,leftsteeringbatchno,rightsteeringbatchno,bearingbatchno,frontbrakediscbatchno");
            strSql.Append(") values (");
            strSql.Append("@leftfrontcaliperbatchno,@rightfrontcaliperbatchno,@caliperboltbatchno,@lowerballpinbatchno,@completed,@createtime,@completetime,@repairstate,@barcode,@productcode,@userid,@stationid,@leftsteeringbatchno,@rightsteeringbatchno,@bearingbatchno,@frontbrakediscbatchno");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@leftfrontcaliperbatchno", model.leftfrontcaliperbatchno) ,            
                        new SqlParameter("@rightfrontcaliperbatchno", model.rightfrontcaliperbatchno) ,            
                        new SqlParameter("@caliperboltbatchno", model.caliperboltbatchno) ,            
                        new SqlParameter("@lowerballpinbatchno", model.lowerballpinbatchno) ,            
                        new SqlParameter("@completed", model.completed) ,            
                        new SqlParameter("@createtime", model.createtime) ,            
                        new SqlParameter("@completetime", model.completetime) ,            
                        new SqlParameter("@repairstate", model.repairstate) ,            
                        new SqlParameter("@barcode", model.barcode) ,            
                        new SqlParameter("@productcode", model.productcode) ,            
                        new SqlParameter("@userid", model.userid) ,            
                        new SqlParameter("@stationid", model.stationid) ,            
                        new SqlParameter("@leftsteeringbatchno", model.leftsteeringbatchno) ,            
                        new SqlParameter("@rightsteeringbatchno", model.rightsteeringbatchno) ,            
                        new SqlParameter("@bearingbatchno", model.bearingbatchno) ,            
                        new SqlParameter("@frontbrakediscbatchno", model.frontbrakediscbatchno)             
              
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
        /// 更新一条数据
        /// </summary>
        public bool Update(FrontAxleResultMDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update frontaxleresult set ");

            strSql.Append(" leftfrontcaliperbatchno = @leftfrontcaliperbatchno , ");
            strSql.Append(" rightfrontcaliperbatchno = @rightfrontcaliperbatchno , ");
            strSql.Append(" caliperboltbatchno = @caliperboltbatchno , ");
            strSql.Append(" lowerballpinbatchno = @lowerballpinbatchno , ");
            strSql.Append(" completed = @completed , ");
            strSql.Append(" createtime = @createtime , ");
            strSql.Append(" completetime = @completetime , ");
            strSql.Append(" repairstate = @repairstate , ");
            strSql.Append(" barcode = @barcode , ");
            strSql.Append(" productcode = @productcode , ");
            strSql.Append(" userid = @userid , ");
            strSql.Append(" stationid = @stationid , ");
            strSql.Append(" leftsteeringbatchno = @leftsteeringbatchno , ");
            strSql.Append(" rightsteeringbatchno = @rightsteeringbatchno , ");
            strSql.Append(" bearingbatchno = @bearingbatchno , ");
            strSql.Append(" frontbrakediscbatchno = @frontbrakediscbatchno  ");
            strSql.Append(" where tid=@tid ");

            SqlParameter[] parameters = {
			            new SqlParameter("@tid", model.tid) ,            
                        new SqlParameter("@leftfrontcaliperbatchno", model.leftfrontcaliperbatchno) ,            
                        new SqlParameter("@rightfrontcaliperbatchno", model.rightfrontcaliperbatchno) ,            
                        new SqlParameter("@caliperboltbatchno", model.caliperboltbatchno) ,            
                        new SqlParameter("@lowerballpinbatchno", model.lowerballpinbatchno) ,            
                        new SqlParameter("@completed", model.completed) ,            
                        new SqlParameter("@createtime", model.createtime) ,            
                        new SqlParameter("@completetime", model.completetime) ,            
                        new SqlParameter("@repairstate", model.repairstate) ,            
                        new SqlParameter("@barcode", model.barcode) ,            
                        new SqlParameter("@productcode", model.productcode) ,            
                        new SqlParameter("@userid", model.userid) ,            
                        new SqlParameter("@stationid", model.stationid) ,            
                        new SqlParameter("@leftsteeringbatchno", model.leftsteeringbatchno) ,            
                        new SqlParameter("@rightsteeringbatchno", model.rightsteeringbatchno) ,            
                        new SqlParameter("@bearingbatchno", model.bearingbatchno) ,            
                        new SqlParameter("@frontbrakediscbatchno", model.frontbrakediscbatchno)             
              
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(long tid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from frontaxleresult ");
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string tidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from frontaxleresult ");
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
        public FrontAxleResultMDL GetModel(long tid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tid, leftfrontcaliperbatchno, rightfrontcaliperbatchno, caliperboltbatchno, lowerballpinbatchno, completed, createtime, completetime, repairstate, barcode, productcode, userid, stationid, leftsteeringbatchno, rightsteeringbatchno, bearingbatchno, frontbrakediscbatchno  ");
            strSql.Append("  from frontaxleresult ");
            strSql.Append(" where tid=@tid");
            SqlParameter[] parameters = {
					new SqlParameter("@tid", tid)
			};

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
        public FrontAxleResultMDL DataRowToModel(DataRow row)
        {
            FrontAxleResultMDL model = new FrontAxleResultMDL();
            if (row != null)
            {
                if (row["tid"].ToString() != "")
                {
                    model.tid = long.Parse(row["tid"].ToString());
                }
                model.leftfrontcaliperbatchno = row["leftfrontcaliperbatchno"].ToString();
                model.rightfrontcaliperbatchno = row["rightfrontcaliperbatchno"].ToString();
                model.caliperboltbatchno = row["caliperboltbatchno"].ToString();
                model.lowerballpinbatchno = row["lowerballpinbatchno"].ToString();
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
                model.leftsteeringbatchno = row["leftsteeringbatchno"].ToString();
                model.rightsteeringbatchno = row["rightsteeringbatchno"].ToString();
                model.bearingbatchno = row["bearingbatchno"].ToString();
                model.frontbrakediscbatchno = row["frontbrakediscbatchno"].ToString();
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
            strSql.Append(" FROM frontaxleresult ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return helper.Query(strSql.ToString());
        }
    }
}