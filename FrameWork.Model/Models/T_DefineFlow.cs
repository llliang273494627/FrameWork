using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace FrameWork.Model.Models
{
    /// <summary>
    /// 流程表
    /// </summary>
    [SugarTable("T_DefineFlow")]
    public class T_DefineFlow
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }

        public string flowname { get; set; }

        public string sendcmd { get; set; }

        public int waittime { get; set; }

        public string receivecmd { get; set; }

        public bool enabled { get; set; }

        public string sendaddress { get; set; }

        public int sleeptime { get; set; }

        public int receivenum { get; set; }

        public int? canind { get; set; }
    }
}
