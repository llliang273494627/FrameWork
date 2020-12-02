using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using MDL;
using COM;
using XY.Util;

namespace DAL
{
    public class MaterialBomDAL
    {
        static string requestUrl = BaseVariable.RequestURL + "MaterialBom.ashx";
        /// <summary>
        /// 得到一个Hashtable
        /// </summary>
        /// <param name="ProductType">产品类型</param>
        /// <param name="ProductCode">产品编码</param>
        /// <param name="TableName">结果表名称</param>
        /// <param name="TraceType">追溯类型:0:扫描和批次追溯,1:扫描追溯,2:批次追溯</param>
        /// <returns></returns>
        public static Hashtable GetBomJoinInfo(string ProductType, string ProductCode, string TableName, int TraceType)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("do", "get");
            dict.Add("ProductType", ProductType);
            dict.Add("ProductCode", ProductCode);
            dict.Add("TableName", TableName);
            dict.Add("TraceType", TraceType);
            string str = Http.POST(requestUrl, dict);
            var obj = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
            ReturnInfo ReturnData = (ReturnInfo)obj;
            if (ReturnData != null && ReturnData.Code == "1")
            {
                var data = JsonHelper.JsonDeSerializer<Hashtable>(ReturnData.Data.ToString());
                Hashtable table = (Hashtable)data;
                return table;
            }
            else
            {
                return null;
            }
        }

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
                if (row["scannerid"] != null)
                {
                    model.StationID = row["scannerid"].ToString();
                }
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
                if (row["scannerid"] != null)
                {
                    model.StationID = row["scannerid"].ToString();
                }
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
        public static Hashtable GetList(DataTable table)
        {
            Hashtable HT = new Hashtable();
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
        public static Hashtable GetList(DataTable table, int ExtCount)
        {
            Hashtable HT = new Hashtable();
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
