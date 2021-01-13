using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.DSGComm
{
    /// <summary>
    /// IO控制对象
    /// </summary>
    public class IOCard
    {
        public int ErrCde { get; set; }
        public string szErrMsg { get { return Convert.ToBase64String(new byte[80]); } }

        public bool[] PortDOState = new bool[15];

        public void ActivateCard(int AddressNO)
        {
            var lpDioGetCurrentDoByte = new PT_DioGetCurrentDOByte
            {
                Port = AddressNO,
                value = MODDriver.DRV_GetAddress(0),
            };
             ErrCde = MODDriver.DRV_DioGetCurrentDOByte(0, lpDioGetCurrentDoByte);
            if (ErrCde != 0)
                MODDriver.DRV_GetErrorMessage(ErrCde, szErrMsg);
        }

        public void DOBitPort(int dOPort, bool oFFState)
        {
            PortDOState[dOPort] = oFFState;
            int DoValue = 0;
            for (int i = 0; i < 7; i++)
            {
                if (PortDOState[i])
                    DoValue += DOBit(i);
            }
            //modPublic.lpDioWritePort.Port = modPublic.lpDioPortMode.Port;
            //modPublic.lpDioWritePort.Mask = 255;
            //modPublic.lpDioWritePort.state = DoValue;
            //int ErrCde = NativeMethods.DRV_DioWritePortByte(0, modPublic.lpDioWritePort);
            //if (ErrCde != 0)
            //    NativeMethods.DRV_GetErrorMessage(ErrCde, modPublic.szErrMsg);
        }

        public int DOBit(int bit)
        {
            int DOBit = 1;
            if (bit >= 1)
            {
                for (int i = 1; i < bit; i++)
                    DOBit = DOBit * 2;
            }
            return DOBit;
        }

        /// <summary>
        /// DOportNo通道号，关开
        /// 供外部调用输出模块
        /// </summary>
        /// <param name="DOportNo"></param>
        /// <param name="OFFState"></param>
        public void OutputController(int DOportNo, bool OFFState)
        {
            //modPublic.lpDioPortMode.Port = DOportNo < 8 ? 0 : 1;
            //modPublic.lpDioPortMode.dir = 1;
            //if (modPublic.lpDevFeatures.usDIOPort > 0)
            //{
            //    int ErrCde = NativeMethods.DRV_DioSetPortMode(0, modPublic.lpDioPortMode);
            //    if (ErrCde != 0)
            //    {
            //        NativeMethods.DRV_GetErrorMessage(ErrCde, modPublic.szErrMsg);
            //        return;
            //    }
            //}
            //if (DOportNo < 8)
            //{
            //    ActivateCard(0);
            //    DOBitPort(DOportNo, OFFState);
            //}
            //else
            //{
            //    ActivateCard(1);
            //    DOBitPort(DOportNo - 8, OFFState);
            //}
        }
    }
}
