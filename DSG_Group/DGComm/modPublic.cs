using DSG_Group.BllComm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.DGComm
{
    public class modPublic
    {
        public const int OUTPORT = 1;
        public static long ErrCde;
        public static long DeviceHandle;
        public static string szErrMsg;
        public static bool[] PortDOState = new bool[15];

        // 喇叭控制参数（io信号输出端口）
        public static int rdOutput;
        public static int rdResetCommand;

        // 信号灯相关控制参数（io信号输出端口）
        private static int Lamp_GreenFlash_IOPort = 0;
        private static int Lamp_GreenLight_IOPort = 0;
        private static int Lamp_YellowLight_IOPort = 0;
        private static int Lamp_YellowFlash_IOPort = 0;
        private static int Lamp_RedLight_IOPort = 0;
        private static int Lamp_RedFlash_IOPort = 0;
        private static int Lamp_Buzzer_IOPort = 0;
        private static int Line_IOPort = 0;

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

        /// <summary>
        /// IO控制对象
        /// </summary>
        public static IOCard oIOCard;

        public static void DelayTime(long LngTime)
        {
            //long LngTick = NativeMethods.GetTickCount();

        }

        public static void insertColl(string code)
        { 
        
        }

        public static void flashLamp(int IOPort)
        {
            closeAll();
            oIOCard.OutputController(IOPort, true);
        }

       public static  void closeAll()
        {
            NoController.OutputController(Lamp_GreenLight_IOPort, false);// 关闭绿色
            NoController.OutputController(Lamp_GreenFlash_IOPort, false);// 关闭绿色闪烁
            NoController.OutputController(Lamp_YellowLight_IOPort, false);// 关闭黄色
            NoController.OutputController(Lamp_YellowFlash_IOPort, false);// 关闭黄色闪烁
            NoController.OutputController(Lamp_RedLight_IOPort, false);// 关闭红色
            NoController.OutputController(Lamp_RedFlash_IOPort, false);// 关闭红色闪烁
        }

    }
}
