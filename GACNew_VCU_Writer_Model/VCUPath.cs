using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GACNew_VCU_Writer
{
    public  class VCUPath
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Baud { get; set; }

        public uint SendAddress { get; set; }

        public uint ResponseAddress { get; set; }

        public bool WriteInResult { get; set; }

        private string carType;

        public string CarType
        {
            get { return carType; }
            set { carType = value; }
        }

        private DateTime writeTime;

        public DateTime WriteTime
        {
            get { return writeTime; }
            set { writeTime = value; }
        }

        private string printCode;

        public string PrintCode
        {
            get { return printCode; }
            set { printCode = value; }
        }

        private string cRC1;

        public string CRC1
        {
            get { return cRC1; }
            set { cRC1 = value; }
        }

        private string cRC2;

        public string CRC2
        {
            get { return cRC2; }
            set { cRC2 = value; }
        }

        private string conditionCode;
        /// <summary>
        /// 硬件条码特制码
        /// </summary>
        public string ConditionCode
        {
            get { return conditionCode; }
            set { conditionCode = value; }
        }

        private string driverPath;

        public string DriverPath
        {
            get { return driverPath; }
            set { driverPath = value; }
        }

        private string binPath;

        public string BinPath
        {
            get { return binPath; }
            set { binPath = value; }
        }

        private string calPath;

        public string CalPath
        {
            get { return calPath; }
            set { calPath = value; }
        }

        private string binName;

        public string BinName
        {
            get { return binName; }
            set { binName = value; }
        }

        private string driverName;

        public string DriverName
        {
            get { return driverName; }
            set { driverName = value; }
        }

        private string calName;

        public string CalName
        {
            get { return calName; }
            set { calName = value; }
        }

        private string softWareVersion;

        public string SoftWareVersion
        {
            get { return softWareVersion; }
            set { softWareVersion = value; }
        }

        private string softWareCode;

        public string SoftWareCode
        {
            get { return softWareCode; }
            set { softWareCode = value; }
        }

        /// <summary>
        /// 车型派生
        /// </summary>
        public string OptionCode { get; set; }

        private uint canind = 0;
        /// <summary>
        /// CAN设备上的两个传输通道，0或者1
        /// </summary>
        public uint CANIND
        {
            get { return canind; }
            set { canind = value; }
        }

        /// <summary>
        /// 是否打印
        /// </summary>
        public int IsPrint { get; set; }
    }
}
