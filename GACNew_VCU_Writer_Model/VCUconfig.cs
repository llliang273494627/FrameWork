using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GACNew_VCU_Writer
{
    public class VCUconfig
    {
        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string mtoc;
        /// <summary>
        /// 车辆类型
        /// </summary>
        public string MTOC
        {
            get { return mtoc; }
            set { mtoc = value; }
        }

        private string conditionCode;
        /// <summary>
        /// 特制码
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

        private string cRC3;

        public string CRC3
        {
            get { return cRC3; }
            set { cRC3 = value; }
        }

        private string softWareVersion;
        /// <summary>
        /// 软件版本号
        /// </summary>
        public string SoftWareVersion
        {
            get { return softWareVersion; }
            set { softWareVersion = value; }
        }

        private string softWareCode;
        /// <summary>
        /// 软件简码
        /// </summary>
        public string SoftWareCode
        {
            get { return softWareCode; }
            set { softWareCode = value; }
        }

        private string hardWareCode;
        /// <summary>
        /// 硬件型号
        /// </summary>
        public string HardWareCode
        {
            get { return hardWareCode; }
            set { hardWareCode = value; }
        }

        private string hw;
        /// <summary>
        /// HW
        /// </summary>
        public string HW
        {
            get { return hw; }
            set { hw = value; }
        }

        private string sw;
        /// <summary>
        /// SW
        /// </summary>
        public string SW
        {
            get { return sw; }
            set { sw = value; }
        }

        private string elementNum;

        /// <summary>
        /// 零件号
        /// </summary>
        public string ElementNum
        {
            get { return elementNum; }
            set { elementNum = value; }
        }

        private string sign;
        /// <summary>
        /// 记号
        /// </summary>
        public string Sign
        {
            get { return sign; }
            set { sign = value; }
        }
    }
}
