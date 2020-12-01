using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GACNew_VCU_Writer
{
    public class PrintInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Int32 ID { get; set; }
        
        /// <summary>
        /// 软件版本号
        /// </summary>
        public string SoftWareVersion { get; set; }

        /// <summary>
        /// 车型派生
        /// </summary>
        public string OptionCode { get; set; }

        /// <summary>
        /// 条形码
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// 零件名称
        /// </summary>
        public string PartsName { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Number { get; set; }
    }
}
