using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.Comm
{
    public class CVT520:SerialPort
    {
        public string Text { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
       public int Status { get; set; }
    }
}
