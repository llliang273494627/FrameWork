using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.DSGComm
{
    public class MODDriver
    {
        [DllImport("adsapi32.dll")]
        internal static extern int DRV_DioSetPortMode(int DriverHandle, PT_DioSetPortMode DioSetPortMode);

        [DllImport("adsapi32.dll")]
        internal static extern void DRV_GetErrorMessage(int lError, string lpszszErrMsg);

        //Declare Function DRV_GetAddress Lib "adsapi32.dll" (ByRef lpVoid As Object) As Integer
        [DllImport("adsapi32.dll")]
        internal static extern int DRV_GetAddress(object lpVoid);

        //Declare Function DRV_DioGetCurrentDOByte Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioGetCurrentDOByte As PT_DioGetCurrentDOByte) As Integer
        [DllImport("adsapi32.dll")]
        internal static extern int DRV_DioGetCurrentDOByte(int DriverHandle, PT_DioGetCurrentDOByte DioGetCurrentDOByte);

        //Declare Function DRV_DioWritePortByte Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioWritePortByte As PT_DioWritePortByte) As Integer
        [DllImport("adsapi32.dll")]
        internal static extern int DRV_DioWritePortByte(int DriverHandle, PT_DioWritePortByte DioWritePortByte);
    }

    public struct PT_DioSetPortMode
    {
        public short Port;
        public short dir_Renamed;
    }

    public struct DEVFEATURES
    {
        public short usMaxDOChl;
        public short usDIOPort;
    }

    public struct PT_DioGetCurrentDOByte
    {
        public int Port;
        public int value;
    }

    public struct PT_DioWritePortByte
    {
        public short Port;
        public short Mask;
        public int state;
    }

}
