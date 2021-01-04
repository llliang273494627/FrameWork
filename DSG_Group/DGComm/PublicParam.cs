using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.DGComm
{
    public class PublicParam
    {
        public const int OUTPORT = 1;
        public static long ErrCde;
        public static long DeviceHandle;
        public static string szErrMsg;
        public static bool[] PortDOState = new bool[15];

        // 传感器参数设置
        public static string mdlValue;
        public static string preMinValue;
        public static string preMaxValue;
        public static string tempMinValue;
        public static string tempMaxValue;
        public static string acSpeedMinValue;
        public static string acSpeedMaxValue;
        public static string mTOCStartIndex;
        public static string tPMSCodeLen;

        public static PT_DioSetPortMode lpDioPortMode;
        public static DEVFEATURES lpDevFeatures;
        public static PT_DioGetCurrentDOByte lpDioGetCurrentDoByte;
        public static PT_DioWritePortByte lpDioWritePort;

    }
}
