using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.DGComm
{
    public class NoController
    {
        internal static void ActivateCard(int AddressNO)
        {
            PublicParam.lpDioGetCurrentDoByte.Port = AddressNO;
            PublicParam.lpDioGetCurrentDoByte.value = NativeMethods.DRV_GetAddress(0);
            PublicParam.ErrCde = NativeMethods.DRV_DioGetCurrentDOByte(PublicParam.DeviceHandle, PublicParam.lpDioGetCurrentDoByte);
            if (PublicParam.ErrCde != 0)
                NativeMethods.DRV_GetErrorMessage(PublicParam.ErrCde, PublicParam.szErrMsg);
        }

        internal static void DOBitPort(int dOPort,bool oFFState)
        {
            PublicParam.PortDOState[dOPort] = oFFState;
            int DoValue = 0;
            for (int i = 0; i < 7; i++)
            {
                if (PublicParam.PortDOState[i])
                    DoValue += DOBit(i);
            }
            PublicParam.lpDioWritePort.Port = PublicParam.lpDioPortMode.Port;
            PublicParam.lpDioWritePort.Mask = 255;
            PublicParam.lpDioWritePort.state = DoValue;
            PublicParam.ErrCde = NativeMethods.DRV_DioWritePortByte(PublicParam.DeviceHandle, PublicParam.lpDioWritePort);
            if (PublicParam.ErrCde != 0)
                NativeMethods.DRV_GetErrorMessage(PublicParam.ErrCde, PublicParam.szErrMsg);
        }

        internal static int DOBit(int bit)
        {
            int DOBit = 1;
            if (bit >= 1)
            {
                for (int i = 1; i < bit; i++)
                    DOBit = DOBit*2;
            }
            return DOBit;
        }

        /// <summary>
        /// DOportNo通道号，关开
        /// </summary>
        internal static void OutputController(int dOportNo, bool oFFState)
        {
            PublicParam.lpDioPortMode.Port = dOportNo < 8 ? 0 : 1;
            PublicParam.lpDioPortMode.dir = PublicParam.OUTPORT;
            if (PublicParam.lpDevFeatures.usDIOPort > 0)
            {
                PublicParam.ErrCde = NativeMethods.DRV_DioSetPortMode(PublicParam.DeviceHandle, PublicParam.lpDioPortMode);
                if (PublicParam.ErrCde != 0)
                {
                    NativeMethods.DRV_GetErrorMessage(PublicParam.ErrCde, PublicParam.szErrMsg);
                    return;
                }
            }
            if (dOportNo < 8)
            {
                ActivateCard(0);
                DOBitPort(dOportNo, oFFState);
            }
            else
            {
                ActivateCard(1);
                DOBitPort(dOportNo - 8, oFFState);
            }
        }
    }
}
