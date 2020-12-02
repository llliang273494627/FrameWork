using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using MDL;

namespace DAL
{
    public class MaterialBomDAL
    {
        private SqlHelper helper = new SqlHelper();

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static MaterialBomMDL GetModel(DataRow row)
        {
            MaterialBomMDL model = new MaterialBomMDL();
            if (row != null)
            {
                if (row["tid"] != null && row["tid"].ToString() != "")
                {
                    model.TID = long.Parse(row["tid"].ToString());
                }
                if (row["productcode"] != null)
                {
                    model.ProductCode = row["productcode"].ToString();
                }
                if (row["productname"] != null)
                {
                    model.ProductName = row["productname"].ToString();
                }
                if (row["producttype"] != null)
                {
                    model.ProductType = row["producttype"].ToString();
                }
                if (row["materialcode"] != null)
                {
                    model.MaterialCode = row["materialcode"].ToString();
                }
                if (row["materialname"] != null)
                {
                    model.MaterialName = row["materialname"].ToString();
                }
                if (row["materialnum"] != null && row["materialnum"].ToString() != "")
                {
                    model.MaterialNum = int.Parse(row["materialnum"].ToString());
                }
                if (row["batchnum"] != null && row["batchnum"].ToString() != "")
                {
                    model.BatchNum = int.Parse(row["batchnum"].ToString());
                }
                if (row["fieldname"] != null)
                {
                    model.FieldName = row["fieldname"].ToString();
                }
                if (row["tablename"] != null)
                {
                    model.TableName = row["tablename"].ToString();
                }
                if (row["featureindex"] != null)
                {
                    model.FeatureIndex = row["featureindex"].ToString();
                }
                if (row["featurecode"] != null)
                {
                    model.FeatureCode = row["featurecode"].ToString();
                }
                if (row["tracetype"] != null)
                {
                    model.TraceType = row["tracetype"].ToString();
                }
                //if (row["scannerid"] != null)
                //{
                //    model.StationID = row["scannerid"].ToString();
                //}
            }
            return model;
        } 
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体（带扩展的）
        /// </summary>
        /// <param name="row"></param>
        /// <param name="ExtCount">最大5</param>
        /// <returns></returns>
        public static MaterialBomMDL GetModel(DataRow row,int ExtCount)
        {
            MaterialBomMDL model = new MaterialBomMDL();
            if (row != null)
            {
                if (row["tid"] != null && row["tid"].ToString() != "")
                {
                    model.TID = long.Parse(row["tid"].ToString());
                }
                if (row["productcode"] != null)
                {
                    model.ProductCode = row["productcode"].ToString();
                }
                if (row["productname"] != null)
                {
                    model.ProductName = row["productname"].ToString();
                }
                if (row["producttype"] != null)
                {
                    model.ProductType = row["producttype"].ToString();
                }
                if (row["materialcode"] != null)
                {
                    model.MaterialCode = row["materialcode"].ToString();
                }
                if (row["materialname"] != null)
                {
                    model.MaterialName = row["materialname"].ToString();
                }
                if (row["materialnum"] != null && row["materialnum"].ToString() != "")
                {
                    model.MaterialNum = int.Parse(row["materialnum"].ToString());
                }
                if (row["batchnum"] != null && row["batchnum"].ToString() != "")
                {
                    model.BatchNum = int.Parse(row["batchnum"].ToString());
                }
                if (row["fieldname"] != null)
                {
                    model.FieldName = row["fieldname"].ToString();
                }
                if (row["tablename"] != null)
                {
                    model.TableName = row["tablename"].ToString();
                }
                if (row["featureindex"] != null)
                {
                    model.FeatureIndex = row["featureindex"].ToString();
                }
                if (row["featurecode"] != null)
                {
                    model.FeatureCode = row["featurecode"].ToString();
                }
                if (row["tracetype"] != null)
                {
                    model.TraceType = row["tracetype"].ToString();
                }
                //if (row["scannerid"] != null)
                //{
                //    model.StationID = row["scannerid"].ToString();
                //}
                if (ExtCount>0 && row["ext1"] != null)
                {
                    model.Ext1 = row["ext1"].ToString();
                }
                if (ExtCount > 1 && row["ext2"] != null)
                {
                    model.Ext2 = row["ext2"].ToString();
                }
                if (ExtCount > 2 && row["ext3"] != null)
                {
                    model.Ext3 = row["ext3"].ToString();
                }
                if (ExtCount > 3 && row["ext4"] != null)
                {
                    model.Ext4 = row["ext4"].ToString();
                }
                if (ExtCount > 4 && row["ext5"] != null)
                {
                    model.Ext5 = row["ext5"].ToString();
                }
            }
            return model;
        } 
        #endregion

        #region 获取集合
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static Dictionary<string, MaterialBomMDL> GetList(DataTable table)
        {
            Dictionary<string, MaterialBomMDL> HT = new Dictionary<string, MaterialBomMDL>();
            MaterialBomMDL model = null;
            foreach (DataRow row in table.Rows)
            {
                string MaterialCode = row["materialcode"].ToString();
                model = GetModel(row);
                HT.Add(MaterialCode, model);
            }
            return HT;
        } 
        #endregion

        #region 获取集合
        /// <summary>
        /// 获取集合（带扩展的）
        /// </summary>
        /// <param name="table"></param>
        /// <param name="ExtCount">扩展的数量</param>
        /// <returns></returns>
        public static Dictionary<string, MaterialBomMDL> GetList(DataTable table, int ExtCount)
        {
            Dictionary<string, MaterialBomMDL> HT = new Dictionary<string, MaterialBomMDL>();
            MaterialBomMDL model = null;
            foreach (DataRow row in table.Rows)
            {
                string MaterialCode = row["materialcode"].ToString();
                model = GetModel(row,ExtCount);
                HT.Add(MaterialCode, model);
            }
            return HT;
        }
        #endregion
    }
}
