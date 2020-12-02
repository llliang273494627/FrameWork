using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MDL
{
    public class StockInfoMDL
    {       
        /// <summary>
        /// 自增ID
        /// </summary>
        private int _tid;
        public int TID
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 材料流水号条码
        /// </summary>
        private string _barcode;
        public string BarCode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 材料编码
        /// </summary>
        private string _materialcode;
        public string MaterialCode
        {
            set { _materialcode = value; }
            get { return _materialcode; }
        }
        /// <summary>
        /// 材料名称
        /// </summary>
        private string _materialName;
        public string MaterialName
        {
            set { _materialName = value; }
            get { return _materialName; }
        }
        /// <summary>
        /// 扫描设备号
        /// </summary>
        private string _scannerid;
        public string ScannerID
        {
            set { _scannerid = value; }
            get { return _scannerid; }
        }
    }
}
