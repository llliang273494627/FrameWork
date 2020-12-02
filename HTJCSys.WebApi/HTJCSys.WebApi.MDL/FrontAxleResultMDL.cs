using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace MDL
{
    public class FrontAxleResultMDL
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
        /// 左转向节批次号
        /// </summary>		
        private string _leftsteeringbatchno;
        public string leftsteeringbatchno
        {
            get { return _leftsteeringbatchno; }
            set { _leftsteeringbatchno = value; }
        }
        /// <summary>
        /// 右转向节批次号
        /// </summary>		
        private string _rightsteeringbatchno;
        public string rightsteeringbatchno
        {
            get { return _rightsteeringbatchno; }
            set { _rightsteeringbatchno = value; }
        }
        /// <summary>
        /// 轴承批次号
        /// </summary>		
        private string _bearingbatchno;
        public string bearingbatchno
        {
            get { return _bearingbatchno; }
            set { _bearingbatchno = value; }
        }
        /// <summary>
        /// 前制动盘（两种型号）批次号
        /// </summary>		
        private string _frontbrakediscbatchno;
        public string frontbrakediscbatchno
        {
            get { return _frontbrakediscbatchno; }
            set { _frontbrakediscbatchno = value; }
        }
        /// <summary>
        /// 左前卡钳（两种型号）批次号
        /// </summary>		
        private string _leftfrontcaliperbatchno;
        public string leftfrontcaliperbatchno
        {
            get { return _leftfrontcaliperbatchno; }
            set { _leftfrontcaliperbatchno = value; }
        }
        /// <summary>
        /// 右前卡钳（两种型号）批次号
        /// </summary>		
        private string _rightfrontcaliperbatchno;
        public string rightfrontcaliperbatchno
        {
            get { return _rightfrontcaliperbatchno; }
            set { _rightfrontcaliperbatchno = value; }
        }
        /// <summary>
        /// 卡钳螺栓批次号
        /// </summary>		
        private string _caliperboltbatchno;
        public string caliperboltbatchno
        {
            get { return _caliperboltbatchno; }
            set { _caliperboltbatchno = value; }
        }
        /// <summary>
        /// 下球销批次号
        /// </summary>		
        private string _lowerballpinbatchno;
        public string lowerballpinbatchno
        {
            get { return _lowerballpinbatchno; }
            set { _lowerballpinbatchno = value; }
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