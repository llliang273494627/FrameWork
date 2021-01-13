using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.DSGComm
{
    /// <summary>
    /// VT520控制对象
    /// </summary>
    public class CVT520
    {
        public int CommPort { get; set; }
        public string ComSettings { get; set; }
        public bool OpenPort { get; set; }
    }
}
