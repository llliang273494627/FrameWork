using DSGTest.Common.SqlServive.Sql_DPCAWH1_DSG101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTest.Common.Comm
{
    public class CCar
    {
        #region 属性
        protected string m_VINCode = string.Empty;
        public string VINCode { get => m_VINCode; set => m_VINCode = value; }

        protected string m_TireRFID = string.Empty;
        public string TireRFID { get => m_TireRFID; set => m_TireRFID = value; }

        protected string m_TireRFMdl = string.Empty;
        public string TireRFMdl { get => m_TireRFMdl; set => m_TireRFMdl = value; }

        protected string m_TireRFPre = string.Empty;
        public string TireRFPre { get => m_TireRFPre; set => m_TireRFPre = value; }

        protected string m_TireRFTemp = string.Empty;
        public string TireRFTemp { get => m_TireRFTemp; set => m_TireRFTemp = value; }

        protected string m_TireRFBattery = string.Empty;
        public string TireRFBattery { get => m_TireRFBattery; set => m_TireRFBattery = value; }

        protected string m_TireRFAcSpeed = string.Empty;
        public string TireRFAcSpeed { get => m_TireRFAcSpeed; set => m_TireRFAcSpeed = value; }

        protected string m_TireRRID = string.Empty;
        public string TireRRID { get => m_TireRRID; set => m_TireRRID = value; }

        protected string m_TireRRMdl = string.Empty;
        public string TireRRMdl { get => m_TireRRMdl; set => m_TireRRMdl = value; }

        protected string m_TireRRPre = string.Empty;
        public string TireRRPre { get => m_TireRRPre; set => m_TireRRPre = value; }

        protected string m_TireRRTemp = string.Empty;
        public string TireRRTemp { get => m_TireRRTemp; set => m_TireRRTemp = value; }

        protected string m_TireRRBattery = string.Empty;
        public string TireRRBattery { get => m_TireRRBattery; set => m_TireRRBattery = value; }

        protected string m_TireRRAcSpeed = string.Empty;
        public string TireRRAcSpeed { get => m_TireRRAcSpeed; set => m_TireRRAcSpeed = value; }

        protected string m_TireLFID = string.Empty;
        public string TireLFID { get => m_TireLFID; set => m_TireLFID = value; }

        protected string m_TireLFMdl = string.Empty;
        public string TireLFMdl { get => m_TireLFMdl; set => m_TireLFMdl = value; }

        protected string m_TireLFPre = string.Empty;
        public string TireLFPre { get => m_TireLFPre; set => m_TireLFPre = value; }

        protected string m_TireLFTemp = string.Empty;
        public string TireLFTemp { get => m_TireLFTemp; set => m_TireLFTemp = value; }

        protected string m_TireLFBattery = string.Empty;
        public string TireLFBattery { get => m_TireLFBattery; set => m_TireLFBattery = value; }

        protected string m_TireLFAcSpeed = string.Empty;
        public string TireLFAcSpeed { get => m_TireLFAcSpeed; set => m_TireLFAcSpeed = value; }

        protected string m_TireLRID = string.Empty;
        public string TireLRID { get => m_TireLRID; set => m_TireLRID = value; }

        protected string m_TireLRMdl = string.Empty;
        public string TireLRMdl { get => m_TireLRMdl; set => m_TireLRMdl = value; }

        protected string m_TireLRPre = string.Empty;
        public string TireLRPre { get => m_TireLRPre; set => m_TireLRPre = value; }

        protected string m_TireLRTemp = string.Empty;
        public string TireLRTemp { get => m_TireLRTemp; set => m_TireLRTemp = value; }

        protected string m_TireLRBattery = string.Empty;
        public string TireLRBattery { get => m_TireLRBattery; set => m_TireLRBattery = value; }

        protected string m_TireLRAcSpeed = string.Empty;
        public string TireLRAcSpeed { get => m_TireLRAcSpeed; set => m_TireLRAcSpeed = value; }
        #endregion

        protected short testState;

        public string GetTestState()
        {
            return testState.ToString();
        }

        public void SetCarInfByVIN(string vin)
        {
            var result = ServiceT_Result.Queryable(vin);
            if (result == null)
                return;
            m_VINCode = result.VIN;
            m_TireRFID = result.ID020;
            m_TireLFID = result.ID022;
            m_TireRRID = result.ID021;
            m_TireLRID = result.ID023;
            m_TireRFMdl = result.Mdl020;
            m_TireLFMdl = result.Mdl022;
            m_TireRRMdl = result.Mdl021;
            m_TireLRMdl = result.Mdl023;
            m_TireRFPre = result.Pre020;
            m_TireLFPre = result.Pre022;
            m_TireRRPre = result.Pre021;
            m_TireLRPre = result.Pre023;
            m_TireRFTemp = result.Temp020;
            m_TireLFTemp = result.Temp022;
            m_TireRRTemp = result.Temp021;
            m_TireLRTemp = result.Temp023;
            m_TireRFBattery = result.Battery020;
            m_TireLFBattery = result.Battery022;
            m_TireRRBattery = result.Battery021;
            m_TireLRBattery = result.Battery023;
            m_TireRFAcSpeed = result.AcSpeed020;
            m_TireLFAcSpeed = result.AcSpeed022;
            m_TireRRAcSpeed = result.AcSpeed021;
            m_TireLRAcSpeed = result.AcSpeed023;
            short.TryParse(result.TestState, out testState);
        }
    }
}
