using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MDL
{
    /// <summary>
    /// 批次号信息历史表
    /// </summary>
    [Serializable]
    public partial class BatchNoHisMDL
    {
        /// <summary>
        ///自增长编号
        /// </summary>
        private long _tid;
        public long TID
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 子零件编码
        /// </summary>
        private string _materialcode;
        public string MaterialCode
        {
            set { _materialcode = value; }
            get { return _materialcode; }
        }
        /// <summary>
        /// 批次号
        /// </summary>
        private string _batchno;
        public string BatchNo
        {
            set { _batchno = value; }
            get { return _batchno; }
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
        /// 创建时间
        /// </summary>
        private DateTime _createtime;
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
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