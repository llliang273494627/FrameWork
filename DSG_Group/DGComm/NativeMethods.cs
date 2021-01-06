using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.DGComm
{
    public class NativeMethods
    {
        [DllImport(@"dll\ADSAPI32.DLL")]
        internal static extern int DRV_GetAddress(int lpVoid);

        [DllImport(@"dll\ADSAPI32.DLL")]
        internal static extern void DRV_GetErrorMessage(long lError, string lpszszErrMsg);

        /// <summary>
        /// DOportNo通道号，关开
        /// </summary>
        /// <param name="lError"></param>
        /// <param name="lpszszErrMsg"></param>
        [DllImport(@"dll\ADSAPI32.DLL")]
        internal static extern int DRV_DioSetPortMode(long lError, PT_DioSetPortMode lpszszErrMsg);

        [DllImport(@"dll\ADSAPI32.DLL")]
        internal static extern int DRV_DioGetCurrentDOByte(long DriverHandle, PT_DioGetCurrentDOByte DioGetCurrentDOByte);

        [DllImport(@"dll\ADSAPI32.DLL")]
        internal static extern int DRV_DioWritePortByte(long DriverHandle, PT_DioWritePortByte DioWritePortByte);

        [DllImport(@"dll\kernel32.dll")]
        internal static extern int GetTickCount();

    }
}
