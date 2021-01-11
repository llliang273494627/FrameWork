using DSG_Group.DGComm;
using DSG_Group.SqlServers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.BllComm
{
    public class CCar
    {
        public string VINCode { get; set; }
        public string TireRFID { get; set; }
        public string TireRFMdl { get; set; }
        public string TireRFPre { get; set; }
        public string TireRFTemp { get; set; }
        public string TireRFBattery { get; set; }
        public string TireRFAcSpeed { get; set; }
        public string TireLFID { get; set; }
        public string TireLFMdl { get; set; }
        public string TireLFPre { get; set; }
        public string TireLFTemp { get; set; }
        public string TireLFBattery { get; set; }
        public string TireLFAcSpeed { get; set; }
        public string TireRRID { get; set; }
        public string TireLRID { get; set; }
        public string TireLRMdl { get; set; }
        public string TireLRPre { get; set; }
        public string TireLRTemp { get; set; }
        public string TireLRBattery { get; set; }
        public string TireLRAcSpeed { get; set; }
        public string TireRRMdl { get; set; }
        public string TireRRPre { get; set; }
        public string TireRRTemp { get; set; }
        public string TireRRBattery { get; set; }
        public string TireRRAcSpeed { get; set; }
        public string CarType { get; set; }

        public int GetTestState { get; set; }

        public bool Save(long SpaceAvailable)
        {
            HelperLogWrete.Info($"校验上台车开始时间:[{DateTime.Now}]");
            // 待开发
            return true;
        }

    }
}
