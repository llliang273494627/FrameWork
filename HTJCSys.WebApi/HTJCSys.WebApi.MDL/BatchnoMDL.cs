using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MDL
{
    /// <summary>
    /// 批次号信息
    /// </summary>
    public class BatchNoMDL
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        private long _tid;
        public long TID
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 材料编号
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
        private string _materialname;
        public string MaterialName
        {
            set { _materialname = value; }
            get { return _materialname; }
        }
        /// <summary>
        /// 批次号
        /// </summary>
        private string _BatchNo;
        public string BatchNo
        {
            set { _BatchNo = value; }
            get { return _BatchNo; }
        }
        /// <summary>
        /// 批次包装数量
        /// </summary>
        private int _BatchNum;
        public int BatchNum
        {
            set { _BatchNum = value; }
            get { return _BatchNum; }
        }
        /// <summary>
        /// 批次剩余数量
        /// </summary>
        private int _StockNum = 0;
        public int StockNum
        {
            set { _StockNum = value; }
            get { return _StockNum; }
        }
        /// <summary>
        /// 供应商
        /// </summary>
        private string _supplier;
        public string Supplier
        {
            set { _supplier = value; }
            get { return _supplier; }
        }
    }
}
