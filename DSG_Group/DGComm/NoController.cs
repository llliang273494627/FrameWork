﻿using System;
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
            modPublic.lpDioGetCurrentDoByte.Port = AddressNO;
            modPublic.lpDioGetCurrentDoByte.value = NativeMethods.DRV_GetAddress(0);
            modPublic.ErrCde = NativeMethods.DRV_DioGetCurrentDOByte(modPublic.DeviceHandle, modPublic.lpDioGetCurrentDoByte);
            if (modPublic.ErrCde != 0)
                NativeMethods.DRV_GetErrorMessage(modPublic.ErrCde, modPublic.szErrMsg);
        }

        internal static void DOBitPort(int dOPort,bool oFFState)
        {
            modPublic.PortDOState[dOPort] = oFFState;
            int DoValue = 0;
            for (int i = 0; i < 7; i++)
            {
                if (modPublic.PortDOState[i])
                    DoValue += DOBit(i);
            }
            modPublic.lpDioWritePort.Port = modPublic.lpDioPortMode.Port;
            modPublic.lpDioWritePort.Mask = 255;
            modPublic.lpDioWritePort.state = DoValue;
            modPublic.ErrCde = NativeMethods.DRV_DioWritePortByte(modPublic.DeviceHandle, modPublic.lpDioWritePort);
            if (modPublic.ErrCde != 0)
                NativeMethods.DRV_GetErrorMessage(modPublic.ErrCde, modPublic.szErrMsg);
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
            modPublic.lpDioPortMode.Port = dOportNo < 8 ? 0 : 1;
            modPublic.lpDioPortMode.dir = modPublic.OUTPORT;
            if (modPublic.lpDevFeatures.usDIOPort > 0)
            {
                modPublic.ErrCde = NativeMethods.DRV_DioSetPortMode(modPublic.DeviceHandle, modPublic.lpDioPortMode);
                if (modPublic.ErrCde != 0)
                {
                    NativeMethods.DRV_GetErrorMessage(modPublic.ErrCde, modPublic.szErrMsg);
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
