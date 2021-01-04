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

        public static async Task<CCar> getRunStateCar()
        {
            var rs = await Service_runstate.Queryable();
            if (rs == null)
                return null;
            var ccar = new CCar
            {
                VINCode = string.IsNullOrEmpty(rs.vin) ? string.Empty : rs.vin,
                TireRFID = string.IsNullOrEmpty(rs.dsgrf) ? string.Empty : rs.dsgrf,
                TireRFMdl = string.IsNullOrEmpty(rs.mdlrf) ? string.Empty : rs.mdlrf,
                TireRFPre = string.IsNullOrEmpty(rs.prerf) ? string.Empty : rs.prerf,
                TireRFTemp = string.IsNullOrEmpty(rs.temprf) ? string.Empty : rs.temprf,
                TireRFBattery = string.IsNullOrEmpty(rs.batteryrf) ? string.Empty : rs.batteryrf,
                TireRFAcSpeed = string.IsNullOrEmpty(rs.acspeedrf) ? string.Empty : rs.acspeedrf,
                TireLFID = string.IsNullOrEmpty(rs.dsglf) ? string.Empty : rs.dsglf,
                TireLFMdl = string.IsNullOrEmpty(rs.mdllf) ? string.Empty : rs.mdllf,
                TireLFPre = string.IsNullOrEmpty(rs.prelf) ? string.Empty : rs.prelf,
                TireLFTemp = string.IsNullOrEmpty(rs.templf) ? string.Empty : rs.templf,
                TireLFBattery = string.IsNullOrEmpty(rs.batterylf) ? string.Empty : rs.batterylf,
                TireLFAcSpeed = string.IsNullOrEmpty(rs.acspeedlf) ? string.Empty : rs.acspeedlf,
                TireRRID = string.IsNullOrEmpty(rs.dsgrr) ? string.Empty : rs.dsgrr,
                TireRRMdl = string.IsNullOrEmpty(rs.mdlrr) ? string.Empty : rs.mdlrr,
                TireRRPre = string.IsNullOrEmpty(rs.prerr) ? string.Empty : rs.prerr,
                TireRRTemp = string.IsNullOrEmpty(rs.temprr) ? string.Empty : rs.temprr,
                TireRRBattery = string.IsNullOrEmpty(rs.batteryrr) ? string.Empty : rs.batteryrr,
                TireRRAcSpeed = string.IsNullOrEmpty(rs.acspeedrr) ? string.Empty : rs.acspeedrr,
                CarType = string.Empty,
            };
            return ccar;
        }
    }
}
