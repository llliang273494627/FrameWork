using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MDL
{
    public class BrakepumpResultMDL
    {
		/// <summary>
		/// 自增编号
        /// </summary>
        private long _tid;
		public long tid
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 总成号条码
        /// </summary>
        private string _barcode;
		public string barcode
		{
			set{ _barcode=value;}
			get{return _barcode;}
		}
		/// <summary>
		/// 产品编码
        /// </summary>
        private string _productcode;
		public string productcode
		{
			set{ _productcode=value;}
			get{return _productcode;}
		}
		/// <summary>
		/// 用户ID
        /// </summary>
        private string _userid;
		public string userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 工位ID
        /// </summary>
        private string _stationid;
		public string stationid
		{
			set{ _stationid=value;}
			get{return _stationid;}
		}
		/// <summary>
		/// 制动泵编码
        /// </summary>
        private string _brakepumpcode;
		public string brakepumpcode
		{
			set{ _brakepumpcode=value;}
			get{return _brakepumpcode;}
		}
		/// <summary>
        /// 密封垫批次号
        /// </summary>
        private string _gasketbatchno;
		public string gasketbatchno
		{
			set{ _gasketbatchno=value;}
			get{return _gasketbatchno;}
		}
		/// <summary>
        /// 六角(法兰面)螺母
        /// </summary>
        private string _hexagonalnutbatchno;
		public string hexagonalnutbatchno
		{
			set{ _hexagonalnutbatchno=value;}
			get{return _hexagonalnutbatchno;}
		}
		/// <summary>
        /// 压力传感器批次号
        /// </summary>
        private string _pressuresensorbatchno;
		public string pressuresensorbatchno
		{
			set{ _pressuresensorbatchno=value;}
			get{return _pressuresensorbatchno;}
		}
		/// <summary>
        /// 消音器(制动泵隔音垫)
        /// </summary>
        private string _silencerbatchno;
		public string silencerbatchno
		{
			set{ _silencerbatchno=value;}
			get{return _silencerbatchno;}
		}
		/// <summary>
        /// 结合管(制动连接管)
        /// </summary>
        private string _connectingpipe;
		public string connectingpipe
		{
			set{ _connectingpipe=value;}
			get{return _connectingpipe;}
		}
		/// <summary>
        /// 助力器制动泵支架
        /// </summary>
        private string _boosterbrakepumpbracket;
		public string boosterbrakepumpbracket
		{
			set{ _boosterbrakepumpbracket=value;}
			get{return _boosterbrakepumpbracket;}
		}
		/// <summary>
		/// bool：是否完成
        /// </summary>
        private bool? _completed;
		public bool? completed
		{
			set{ _completed=value;}
			get{return _completed;}
		}
		/// <summary>
		/// DateTime：创建时间
        /// </summary>
        private DateTime _createtime;
		public DateTime createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// DateTime：完成时间
        /// </summary>
        private DateTime? _completetime;
		public DateTime? completetime
		{
			set{ _completetime=value;}
			get{return _completetime;}
		}
    }
}
