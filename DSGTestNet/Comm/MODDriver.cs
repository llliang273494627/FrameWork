using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.Comm
{
    public class MODDriver
    {
        [DllImport("adsapi32.dll")]
        public static extern short DRV_GetAddress(object lpVoid);

        [DllImport("adsapi32.dll")]
        public static extern int DRV_DioReadPortByte(int DriverHandle , PT_DioReadPortByte DioReadPortByte);

        [DllImport("adsapi32.dll")]
        public static extern void DRV_GetErrorMessage(int lError, string lpszszErrMsg);
    }

    public struct PT_DioSetPortMode
    {
        public short Port;
        public short dir_Renamed;
    }

    public struct PT_DioReadPortByte
    {
        public short Port;
        public short value;
    }


}
