using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MDL
{
    public class PedalResultMDL
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        private long _tid;
        public long tid
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 产品条码
        /// </summary>
        private string _barcode;
        public string barcode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 产品编码
        /// </summary>
        private string _productcode;
        public string productcode
        {
            set { _productcode = value; }
            get { return _productcode; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        private string _userid;
        public string userid
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 工位ID
        /// </summary>
        private string _stationid;
        public string stationid
        {
            set { _stationid = value; }
            get { return _stationid; }
        }
        /// <summary>
        /// 踏板总成
        /// </summary>
        private string _pedalassycode;
        public string pedalassycode
        {
            set { _pedalassycode = value; }
            get { return _pedalassycode; }
        }
        /// <summary>
        /// 油门踏板
        /// </summary>
        private string _accelpedalcode;
        public string accelpedalcode
        {
            set { _accelpedalcode = value; }
            get { return _accelpedalcode; }
        }
        /// <summary>
        /// 离合器把手批次号
        /// </summary>
        private string _cluthhandlebatchno;
        public string cluthhandlebatchno
        {
            set { _cluthhandlebatchno = value; }
            get { return _cluthhandlebatchno; }
        }
        /// <summary>
        /// 螺栓批次号
        /// </summary>
        private string _boltbatchno;
        public string boltbatchno
        {
            set { _boltbatchno = value; }
            get { return _boltbatchno; }
        }
        /// <summary>
        /// 螺母批次号
        /// </summary>
        private string _nutbatchno;
        public string nutbatchno
        {
            set { _nutbatchno = value; }
            get { return _nutbatchno; }
        }
        /// <summary>
        /// 力矩1
        /// </summary>
        private decimal? _torque1;
        public decimal? torque1
        {
            set { _torque1 = value; }
            get { return _torque1; }
        }
        /// <summary>
        /// 力矩2
        /// </summary>
        private decimal? _torque2;
        public decimal? torque2
        {
            set { _torque2 = value; }
            get { return _torque2; }
        }
        /// <summary>
        /// 力矩3
        /// </summary>
        private decimal? _torque3;
        public decimal? torque3
        {
            set { _torque3 = value; }
            get { return _torque3; }
        }
        /// <summary>
        /// bool：是否完成
        /// </summary>
        private bool? _completed;
        public bool? completed
        {
            set { _completed = value; }
            get { return _completed; }
        }
        /// <summary>
        /// DateTime：生成时间
        /// </summary>
        private DateTime _createtime;
        public DateTime createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// DateTime：完成时间
        /// </summary>
        private DateTime? _completetime;
        public DateTime? completetime
        {
            set { _completetime = value; }
            get { return _completetime; }
        }
    }
}
