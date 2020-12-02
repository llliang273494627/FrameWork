using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MDL
{
    // <summary>
    /// RadiatorResultMDL:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class RadiatorResultMDL
    {
        private int _tid;
        private string _barcode;
        private string _productcode;
        private string _userid;
        private string _stationid;
        private string _radiatorcode;
        private string _condensercode;
        private string _fanassemblycode;
        private string _intercoolercode;
        private decimal? _torque1;
        private decimal? _angle1;
        private decimal? _torque2;
        private decimal? _angle2;
        private decimal? _torque3;
        private decimal? _angle3;
        private decimal? _torque4;
        private decimal? _angle4;
        private decimal? _torque5;
        private decimal? _angle5;
        private decimal? _torque6;
        private decimal? _angle6;
        private bool? _completed;
        private DateTime? _createtime;
        private DateTime? _completetime;

        /// <summary>
        /// auto_increment
        /// </summary>
        public int tid
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 条码
        /// </summary>
        public string barcode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string productcode
        {
            set { _productcode = value; }
            get { return _productcode; }
        }
        /// <summary>
        /// 用户id
        /// </summary>
        public string userid
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 工位号
        /// </summary>
        public string stationid
        {
            set { _stationid = value; }
            get { return _stationid; }
        }
        /// <summary>
        /// 散热器条码
        /// </summary>
        public string radiatorcode
        {
            set { _radiatorcode = value; }
            get { return _radiatorcode; }
        }
        /// <summary>
        /// 冷凝器
        /// </summary>
        public string condensercode
        {
            set { _condensercode = value; }
            get { return _condensercode; }
        }
        /// <summary>
        /// 风扇总成
        /// </summary>
        public string fanassemblycode
        {
            set { _fanassemblycode = value; }
            get { return _fanassemblycode; }
        }
        /// <summary>
        /// 中冷器
        /// </summary>
        public string intercoolercode
        {
            set { _intercoolercode = value; }
            get { return _intercoolercode; }
        }
        /// <summary>
        /// 力矩1
        /// </summary>
        public decimal? torque1
        {
            set { _torque1 = value; }
            get { return _torque1; }
        }
        /// <summary>
        /// 角度1
        /// </summary>
        public decimal? angle1
        {
            set { _angle1 = value; }
            get { return _angle1; }
        }
        /// <summary>
        /// 力矩2
        /// </summary>
        public decimal? torque2
        {
            set { _torque2 = value; }
            get { return _torque2; }
        }
        /// <summary>
        /// 角度2
        /// </summary>
        public decimal? angle2
        {
            set { _angle2 = value; }
            get { return _angle2; }
        }
        /// <summary>
        /// 力矩3
        /// </summary>
        public decimal? torque3
        {
            set { _torque3 = value; }
            get { return _torque3; }
        }
        /// <summary>
        /// 角度3
        /// </summary>
        public decimal? angle3
        {
            set { _angle3 = value; }
            get { return _angle3; }
        }
        /// <summary>
        /// 力矩4
        /// </summary>
        public decimal? torque4
        {
            set { _torque4 = value; }
            get { return _torque4; }
        }
        /// <summary>
        /// 角度4
        /// </summary>
        public decimal? angle4
        {
            set { _angle4 = value; }
            get { return _angle4; }
        }
        /// <summary>
        /// 力矩5
        /// </summary>
        public decimal? torque5
        {
            set { _torque5 = value; }
            get { return _torque5; }
        }
        /// <summary>
        /// 角度5
        /// </summary>
        public decimal? angle5
        {
            set { _angle5 = value; }
            get { return _angle5; }
        }
        /// <summary>
        /// 力矩6
        /// </summary>
        public decimal? torque6
        {
            set { _torque6 = value; }
            get { return _torque6; }
        }
        /// <summary>
        /// 角度6
        /// </summary>
        public decimal? angle6
        {
            set { _angle6 = value; }
            get { return _angle6; }
        }
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool? completed
        {
            set { _completed = value; }
            get { return _completed; }
        }
        /// <summary>
        /// 生成时间
        /// </summary>
        public DateTime? createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? completetime
        {
            set { _completetime = value; }
            get { return _completetime; }
        }
    }
}
