using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace MDL
{
	public class RearAxleResultMDL
	{   		     
      	/// <summary>
		/// 自增长编号
        /// </summary>		
		private long _tid;
        public long tid
        {
            get{ return _tid; }
            set{ _tid = value; }
        }        
		/// <summary>
		/// 合件号条码
        /// </summary>		
		private string _barcode;
        public string barcode
        {
            get{ return _barcode; }
            set{ _barcode = value; }
        }        
		/// <summary>
		/// 产品编码
        /// </summary>		
		private string _productcode;
        public string productcode
        {
            get{ return _productcode; }
            set{ _productcode = value; }
        }        
		/// <summary>
		/// 用户编号
        /// </summary>		
		private string _userid;
        public string userid
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
		/// <summary>
		/// 工位号
        /// </summary>		
		private string _stationid;
        public string stationid
        {
            get{ return _stationid; }
            set{ _stationid = value; }
        }        
		/// <summary>
		/// 后横梁批次号
        /// </summary>		
		private string _rearcrossbeambatchno;
        public string rearcrossbeambatchno
        {
            get{ return _rearcrossbeambatchno; }
            set{ _rearcrossbeambatchno = value; }
        }        
		/// <summary>
		/// 3G轴承批次号
        /// </summary>		
        private string _g3bearingbatchno;
        public string g3bearingbatchno
        {
            get { return _g3bearingbatchno; }
            set { _g3bearingbatchno = value; }
        }        
		/// <summary>
		/// 轴承固定螺栓批次号
        /// </summary>		
		private string _bearingretainingboltbatchno;
        public string bearingretainingboltbatchno
        {
            get{ return _bearingretainingboltbatchno; }
            set{ _bearingretainingboltbatchno = value; }
        }        
		/// <summary>
        /// 制动盘批次号
        /// </summary>		
		private string _brakediscbatchno;
        public string brakediscbatchno
        {
            get{ return _brakediscbatchno; }
            set{ _brakediscbatchno = value; }
        }        
		/// <summary>
        /// 左后卡钳（两种型号）批次号
        /// </summary>		
		private string _leftrearcaliperbatchno;
        public string leftrearcaliperbatchno
        {
            get{ return _leftrearcaliperbatchno; }
            set{ _leftrearcaliperbatchno = value; }
        }        
		/// <summary>
        /// 右后卡钳（两种型号）批次号
        /// </summary>		
		private string _rightrearcaliperbatchno;
        public string rightrearcaliperbatchno
        {
            get{ return _rightrearcaliperbatchno; }
            set{ _rightrearcaliperbatchno = value; }
        }        
		/// <summary>
        /// 卡钳螺栓批次号
        /// </summary>		
		private string _caliperboltbatchno;
        public string caliperboltbatchno
        {
            get{ return _caliperboltbatchno; }
            set{ _caliperboltbatchno = value; }
        }        
		/// <summary>
        /// 已完成
        /// </summary>		
		private bool _completed;
        public bool completed
        {
            get{ return _completed; }
            set{ _completed = value; }
        }        
		/// <summary>
        /// 创建时间
        /// </summary>		
		private DateTime _createtime;
        public DateTime createtime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
        }        
		/// <summary>
        /// 完成时间
        /// </summary>		
		private DateTime _completetime;
        public DateTime completetime
        {
            get{ return _completetime; }
            set{ _completetime = value; }
        }        
		/// <summary>
        /// 返修状态
        /// </summary>		
		private int _repairstate;
        public int repairstate
        {
            get{ return _repairstate; }
            set{ _repairstate = value; }
        }        		   
	}
}
