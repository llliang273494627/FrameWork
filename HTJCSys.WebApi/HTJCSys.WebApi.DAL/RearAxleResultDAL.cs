﻿using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MDL;

namespace DAL
{
    public partial class RearAxleResultDAL
    {
        private SqlHelper helper = new SqlHelper();

        /// <summary>
        /// 判断数据是否存在
        /// </summary>
        public bool Exists(long tid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from rearaxleresult");
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
        public bool Add(RearAxleResultMDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into rearaxleresult(");
            strSql.Append("leftrearcaliperbatchno,rightrearcaliperbatchno,caliperboltbatchno,completed,createtime,completetime,repairstate,barcode,productcode,userid,stationid,rearcrossbeambatchno,g3bearingbatchno,bearingretainingboltbatchno,brakediscbatchno");
            strSql.Append(") values (");
            strSql.Append("@leftrearcaliperbatchno,@rightrearcaliperbatchno,@caliperboltbatchno,@completed,@createtime,@completetime,@repairstate,@barcode,@productcode,@userid,@stationid,@rearcrossbeambatchno,@g3bearingbatchno,@bearingretainingboltbatchno,@brakediscbatchno");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@leftrearcaliperbatchno", model.leftrearcaliperbatchno) ,            
                        new SqlParameter("@rightrearcaliperbatchno", model.rightrearcaliperbatchno) ,            
                        new SqlParameter("@caliperboltbatchno", model.caliperboltbatchno) ,            
                        new SqlParameter("@completed", model.completed) ,            
                        new SqlParameter("@createtime", model.createtime) ,            
                        new SqlParameter("@completetime", model.completetime) ,            
                        new SqlParameter("@repairstate", model.repairstate) ,            
                        new SqlParameter("@barcode", model.barcode) ,            
                        new SqlParameter("@productcode", model.productcode) ,            
                        new SqlParameter("@userid", model.userid) ,            
                        new SqlParameter("@stationid", model.stationid) ,            
                        new SqlParameter("@rearcrossbeambatchno", model.rearcrossbeambatchno) ,            
                        new SqlParameter("@g3bearingbatchno", model.g3bearingbatchno) ,            
                        new SqlParameter("@bearingretainingboltbatchno", model.bearingretainingboltbatchno) ,            
                        new SqlParameter("@brakediscbatchno", model.brakediscbatchno)             
              
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
        public bool Update(RearAxleResultMDL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update rearaxleresult set ");

            strSql.Append(" leftrearcaliperbatchno = @leftrearcaliperbatchno , ");
            strSql.Append(" rightrearcaliperbatchno = @rightrearcaliperbatchno , ");
            strSql.Append(" caliperboltbatchno = @caliperboltbatchno , ");
            strSql.Append(" completed = @completed , ");
            strSql.Append(" createtime = @createtime , ");
            strSql.Append(" completetime = @completetime , ");
            strSql.Append(" repairstate = @repairstate , ");
            strSql.Append(" barcode = @barcode , ");
            strSql.Append(" productcode = @productcode , ");
            strSql.Append(" userid = @userid , ");
            strSql.Append(" stationid = @stationid , ");
            strSql.Append(" rearcrossbeambatchno = @rearcrossbeambatchno , ");
            strSql.Append(" g3bearingbatchno = @g3bearingbatchno , ");
            strSql.Append(" bearingretainingboltbatchno = @bearingretainingboltbatchno , ");
            strSql.Append(" brakediscbatchno = @brakediscbatchno  ");
            strSql.Append(" where tid=@tid ");

            SqlParameter[] parameters = {
			            new SqlParameter("@tid", model.tid) ,            
                        new SqlParameter("@leftrearcaliperbatchno", model.leftrearcaliperbatchno) ,            
                        new SqlParameter("@rightrearcaliperbatchno", model.rightrearcaliperbatchno) ,            
                        new SqlParameter("@caliperboltbatchno", model.caliperboltbatchno) ,            
                        new SqlParameter("@completed", model.completed) ,            
                        new SqlParameter("@createtime", model.createtime) ,            
                        new SqlParameter("@completetime", model.completetime) ,            
                        new SqlParameter("@repairstate", model.repairstate) ,            
                        new SqlParameter("@barcode", model.barcode) ,            
                        new SqlParameter("@productcode", model.productcode) ,            
                        new SqlParameter("@userid", model.userid) ,            
                        new SqlParameter("@stationid", model.stationid) ,            
                        new SqlParameter("@rearcrossbeambatchno", model.rearcrossbeambatchno) ,            
                        new SqlParameter("@g3bearingbatchno", model.g3bearingbatchno) ,            
                        new SqlParameter("@bearingretainingboltbatchno", model.bearingretainingboltbatchno) ,            
                        new SqlParameter("@brakediscbatchno", model.brakediscbatchno)             
              
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
            strSql.Append("delete from rearaxleresult ");
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
            strSql.Append("delete from rearaxleresult ");
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
        public RearAxleResultMDL GetModel(long tid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tid, leftrearcaliperbatchno, rightrearcaliperbatchno, caliperboltbatchno, completed, createtime, completetime, repairstate, barcode, productcode, userid, stationid, rearcrossbeambatchno, g3bearingbatchno, bearingretainingboltbatchno, brakediscbatchno  ");
            strSql.Append("  from rearaxleresult ");
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
        public RearAxleResultMDL DataRowToModel(DataRow row)
        {
            RearAxleResultMDL model = new RearAxleResultMDL();
            if (row!=null)
            {
                if (row["tid"].ToString() != "")
                {
                    model.tid = long.Parse(row["tid"].ToString());
                }
                model.leftrearcaliperbatchno = row["leftrearcaliperbatchno"].ToString();
                model.rightrearcaliperbatchno = row["rightrearcaliperbatchno"].ToString();
                model.caliperboltbatchno = row["caliperboltbatchno"].ToString();
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
                model.rearcrossbeambatchno = row["rearcrossbeambatchno"].ToString();
                model.g3bearingbatchno = row["g3bearingbatchno"].ToString();
                model.bearingretainingboltbatchno = row["bearingretainingboltbatchno"].ToString();
                model.brakediscbatchno = row["brakediscbatchno"].ToString();

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
            strSql.Append(" FROM rearaxleresult ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return helper.Query(strSql.ToString());
        }
    }
}