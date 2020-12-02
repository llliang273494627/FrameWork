using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace MDL
{
    /// <summary>
    /// 设备信息表
    /// </summary>
    public class DeviceInfoMDL
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
        /// 设备类型，包括扫描器、打印机、PC、伺服机、无线AP
        /// </summary>		
        private string _devicetype;
        public string DeviceType
        {
            get { return _devicetype; }
            set { _devicetype = value; }
        }
        /// <summary>
        /// 设备编号
        /// </summary>		
        private string _deviceid;
        public string DeviceID
        {
            get { return _deviceid; }
            set { _deviceid = value; }
        }
        /// <summary>
        /// 设备名称
        /// </summary>		
        private string _devicename;
        public string DeviceName
        {
            get { return _devicename; }
            set { _devicename = value; }
        }
        /// <summary>
        /// 设备IP
        /// </summary>		
        private string _deviceip;
        public string DeviceIP
        {
            get { return _deviceip; }
            set { _deviceip = value; }
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
        /// 设备状态
        /// </summary>		
        private int _devicestate;
        public int DeviceState
        {
            get { return _devicestate; }
            set { _devicestate = value; }
        }
        /// <summary>
        /// 工位号
        /// </summary>
        private string _stationid;
        public string StationID
        {
            get { return _stationid; }
            set { _stationid = value; }
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

