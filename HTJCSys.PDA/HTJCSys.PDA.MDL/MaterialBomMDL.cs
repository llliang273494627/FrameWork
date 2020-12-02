using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MDL
{
    public class MaterialBomMDL
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long TID { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>
        public string ProductType { get; set; }
        /// <summary>
        /// 材料编码
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 材料数量
        /// </summary>
        public int? MaterialNum { get; set; }
        /// <summary>
        /// 材料批次数量
        /// </summary>
        public int? BatchNum { get; set; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 批次条码
        /// </summary>
        public string BatchBarCode { get; set; }
        /// <summary>
        /// 特征码位置
        /// </summary>
        public string FeatureIndex { get; set; }
        /// <summary>
        /// 特征码
        /// </summary>
        public string FeatureCode { get; set; }
        /// <summary>
        /// 追溯类型
        /// </summary>
        public string TraceType { get; set; }
        /// <summary>
        /// 工位ID
        /// </summary>
        public string StationID { get; set; }
        /// <summary>
        /// 扩展1
        /// </summary>
        public string Ext1 { get; set; }
        /// <summary>
        /// 扩展2
        /// </summary>
        public string Ext2 { get; set; }
        /// <summary>
        /// 扩展3
        /// </summary>
        public string Ext3 { get; set; }
        /// <summary>
        /// 扩展4
        /// </summary>
        public string Ext4 { get; set; }
        /// <summary>
        /// 扩展5
        /// </summary>
        public string Ext5 { get; set; }
    }
}
