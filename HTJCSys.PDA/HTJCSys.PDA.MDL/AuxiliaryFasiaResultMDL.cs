using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace MDL
{
    public class AuxiliaryFasiaResultMDL
    {
        /// <summary>
        /// 自增长编号
        /// </summary>		
        private long _tid;
        public long tid
        {
            get { return _tid; }
            set { _tid = value; }
        }
        /// <summary>
        /// 合件号条码
        /// </summary>		
        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }
        /// <summary>
        /// 产品编码
        /// </summary>		
        private string _productcode;
        public string productcode
        {
            get { return _productcode; }
            set { _productcode = value; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>		
        private string _userid;
        public string userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 工位号
        /// </summary>		
        private string _stationid;
        public string stationid
        {
            get { return _stationid; }
            set { _stationid = value; }
        }
        /// <summary>
        /// 线束
        /// </summary>		
        private string _linecode;
        public string linecode
        {
            get { return _linecode; }
            set { _linecode = value; }
        }
        /// <summary>
        /// 已完成
        /// </summary>		
        private bool _completed;
        public bool completed
        {
            get { return _completed; }
            set { _completed = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        private DateTime _createtime;
        public DateTime createtime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// 完成时间
        /// </summary>		
        private DateTime _completetime;
        public DateTime completetime
        {
            get { return _completetime; }
            set { _completetime = value; }
        }
        /// <summary>
        /// 返修状态
        /// </summary>		
        private int _repairstate;
        public int repairstate
        {
            get { return _repairstate; }
            set { _repairstate = value; }
        }
    }
}