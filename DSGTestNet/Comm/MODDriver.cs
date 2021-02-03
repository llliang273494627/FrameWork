using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.Comm
{
    public struct GainList
    {
        public short usGainCde;
        public Single fMaxGainVal;
        public Single fMinGainVal;
        public byte[] szGainStr;

        public void Initialize()
        {
            szGainStr = new byte[15];
        }
    }

    public struct DEVFEATURES
    {
        public byte[] szDriverVer;
        public byte[] szDriverName;
        public int dwBoardID;
        public short usMaxAIDiffChl;
        public short usMaxAISiglChl;
        public short usMaxAOChl;
        public short usMaxDOChl;
        public short usMaxDIChl;
        public short usDIOPort;
        public short usMaxTimerChl;
        public short usMaxAlarmChl;
        public short usNumADBit;
        public short usNumADByte;
        public short usNumDABit;
        public short usNumDAByte;
        public short usNumGain;
        public GainList[] glGainList;
        public int[] dwPermutation;

        public void Initialize()
        {
            szDriverVer = new byte[7];
            szDriverName = new byte[15];
            glGainList = new GainList[15];
            dwPermutation = new int[3];
        }
    }

    public struct PT_DEVLIST
    {
        public int dwDeviceNum;
        public byte[] szDeviceName;
        public short nNumOfSubdevices;

        public void Initialize()
        {
            szDeviceName = new byte[49];
        }
    }

    public struct PT_DeviceGetFeatures
    {
        public int buffer;
        public short size;
    }

    public struct PT_DioSetPortMode
    {
        public short Port;
        public short dir_Renamed;
    }

    public struct PT_DioReadPortByte
    {
        public short Port;
        public int value;
    }

    public struct PT_DioWritePortByte
    {
        public short Port;
        public short Mask;
        public int state;
    }

    public struct PT_DioGetCurrentDOByte
    {
        public short Port;
        public int value;
    }

    public class MODDriver
    {
        //Declare Function DRV_DeviceGetNumOfList Lib "adsapi32.dll" (ByRef NumOfDevices As Short) As Integer
        [DllImport("adsapi32.dll")]
        public extern static int DRV_DeviceGetNumOfList(short NumOfDevices);

        //Declare Function DRV_DeviceGetList Lib "adsapi32.dll" (ByVal devicelist As Integer, ByVal MaxEntries As Short, ByRef nOutEntries As Short) As Integer
        [DllImport("adsapi32.dll")]
        public extern static int DRV_DeviceGetList(int devicelist , short  MaxEntries , short  nOutEntries );

        //Declare Function DRV_DeviceOpen Lib "adsapi32.dll" (ByVal DeviceNum As Integer, ByRef DriverHandle As Integer) As Integer
        [DllImport("adsapi32.dll")]
        public extern static int DRV_DeviceOpen(int  DeviceNum , int DriverHandle );

        //Declare Function DRV_DeviceGetFeatures Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef lpDevFeatures As PT_DeviceGetFeatures) As Integer
        [DllImport("adsapi32.dll")]
        public extern static int DRV_DeviceGetFeatures(int DriverHandle , PT_DeviceGetFeatures lpDevFeatures);

        //Declare Sub DRV_GetErrorMessage Lib "adsapi32.dll" (ByVal lError As Integer, ByVal lpszszErrMsg As String)
        [DllImport("adsapi32.dll")]
        public extern static void  DRV_GetErrorMessage(int lError, string lpszszErrMsg);

        //Declare Function DRV_DioSetPortMode Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioSetPortMode As PT_DioSetPortMode) As Integer
        [DllImport("adsapi32.dll")]
        public extern static int DRV_DioSetPortMode(int DriverHandle, PT_DioSetPortMode DioSetPortMode);

        //Declare Function DRV_DioReadPortByte Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioReadPortByte As PT_DioReadPortByte) As Integer
        [DllImport("adsapi32.dll")]
        public extern static int DRV_DioReadPortByte(int DriverHandle, PT_DioReadPortByte DioReadPortByte);

        //Declare Function DRV_DioWritePortByte Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioWritePortByte As PT_DioWritePortByte) As Integer
        [DllImport("adsapi32.dll")]
        public extern static int DRV_DioWritePortByte(int DriverHandle, PT_DioWritePortByte DioWritePortByte);

        //Declare Function DRV_DioGetCurrentDOByte Lib "adsapi32.dll" (ByVal DriverHandle As Integer, ByRef DioGetCurrentDOByte As PT_DioGetCurrentDOByte) As Integer
        [DllImport("adsapi32.dll")]
        public extern static int DRV_DioGetCurrentDOByte(int DriverHandle, PT_DioGetCurrentDOByte DioGetCurrentDOByte);

        //Declare Function DRV_GetAddress Lib "adsapi32.dll" (ByRef lpVoid As Object) As Integer
        [DllImport("adsapi32.dll")]
        public extern static int DRV_GetAddress(object lpVoid);
    }
}
