using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace MDL
{
    /// <summary>
    /// 产品Bom信息表
    /// </summary>
    public class ProductBomInfoMDL
    {
        /// <summary>
        /// 自增长编号
        /// </summary>		
        private long _tid;
        public long TID
        {
            get { return _tid; }
            set { _tid = value; }
        }
        /// <summary>
        /// 产品类型
        /// </summary>		
        private string _producttype;
        public string ProductType
        {
            get { return _producttype; }
            set { _producttype = value; }
        }
        /// <summary>
        /// 产品编码
        /// </summary>		
        private string _productcode;
        public string ProductCode
        {
            get { return _productcode; }
            set { _productcode = value; }
        }
        /// <summary>
        /// 产品名称
        /// </summary>		
        private string _productname;
        public string ProductName
        {
            get { return _productname; }
            set { _productname = value; }
        }
        /// <summary>
        /// 子零件编码
        /// </summary>		
        private string _materialcode;
        public string MaterialCode
        {
            get { return _materialcode; }
            set { _materialcode = value; }
        }
        /// <summary>
        /// 子零件名称
        /// </summary>		
        private string _materialname;
        public string MaterialName
        {
            get { return _materialname; }
            set { _materialname = value; }
        }
        /// <summary>
        /// 子项数量
        /// </summary>		
        private int _materialnum;
        public int MaterialNum
        {
            get { return _materialnum; }
            set { _materialnum = value; }
        }
        /// <summary>
        /// 特征码索引
        /// </summary>		
        private string _featureindex;
        public string FeatureIndex
        {
            get { return _featureindex; }
            set { _featureindex = value; }
        }
        /// <summary>
        /// 特征码
        /// </summary>		
        private string _featurecode;
        public string FeatureCode
        {
            get { return _featurecode; }
            set { _featurecode = value; }
        }
        /// <summary>
        /// 批次数量
        /// </summary>		
        private int _batchnum;
        public int BatchNum
        {
            get { return _batchnum; }
            set { _batchnum = value; }
        }
        /// <summary>
        /// 扫描器编号
        /// </summary>		
        private string _scannerid;
        public string ScannerID
        {
            get { return _scannerid; }
            set { _scannerid = value; }
        }
        /// <summary>
        /// 追溯方式
        /// </summary>
        private string _tracetype;
        public string TraceType
        {
            get { return _tracetype; }
            set { _tracetype = value; }
        }
        /// <summary>
        /// 描述
        /// </summary>		
        private string _desc;
        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

    }
}

