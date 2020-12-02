using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace MDL
{
    /// <summary>
    /// 产品信息表
    /// </summary>
    public class ProductInfoMDL
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
        /// 合件条码特征码索引
        /// </summary>		
        private string _featureindex;
        public string FeatureIndex
        {
            get { return _featureindex; }
            set { _featureindex = value; }
        }
        /// <summary>
        /// 合件条码特征码
        /// </summary>		
        private string _featurecode;
        public string FeatureCode
        {
            get { return _featurecode; }
            set { _featurecode = value; }
        }
        /// <summary>
        /// 合件号计数
        /// </summary>		
        private string _barcodecount;
        public string BarCodeCount
        {
            get { return _barcodecount; }
            set { _barcodecount = value; }
        }
        /// <summary>
        /// 是否有一一追溯子零件
        /// </summary>		
        private bool _haveSub;
        public bool HaveSub
        {
            get { return _haveSub; }
            set { _haveSub = value; }
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

