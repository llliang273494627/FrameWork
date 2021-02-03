using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTestNet.Comm
{
    public class IOCard
    {
        public IOCard()
        {
            lpDevFeatures.Initialize();
            m_timer = new Timer();
            m_timer.Tick += M_timer_Tick;
            m_timer.Interval = 100;
            m_timer.Start();

            IniStallCard();
        }

        /// <summary>
        /// 用于接收输入的状态
        /// </summary>
        private bool[] DIWordState = new bool[15];
        /// <summary>
        /// 用于接收输入的状态
        /// </summary>
        private bool[] DIState = new bool[15];
        /// <summary>
        /// 用于存放IO卡地址
        /// </summary>
        private string TestMing = string.Empty;
        /// <summary>
        /// 用于存放IO卡输出状态
        /// </summary>
        private bool[] PortDOState = new bool[15];
        /// <summary>
        /// 取输入状态值
        /// </summary>
        private short DiValue = 0;
        /// <summary>
        /// 输入的中间变量
        /// </summary>
        private short iPreVal = 0;
        /// <summary>
        /// 输入的中间变量
        /// </summary>
        private short iPreVal1 = 0;

        public int ErrCde = 0;
        public int DeviceHandle = 0;
        public string szErrMsg = Convert.ToBase64String(new byte[80]);

        public DEVFEATURES lpDevFeatures = new DEVFEATURES();
        public PT_DioSetPortMode lpDioPortMode = new PT_DioSetPortMode();
        private Timer m_timer = null;

        public void OutputController(int DOportNo, bool OFFState)
        {
            if (DOportNo < 8)
            {
                var lpDioPortMode = new PT_DioSetPortMode
                {
                    Port = 0,
                    dir_Renamed = 1,
                };
                if (lpDevFeatures.usDIOPort > 0)
                {
                    ErrCde = MODDriver.DRV_DioSetPortMode(DeviceHandle, lpDioPortMode);
                    if (ErrCde != 0)
                    {
                        MODDriver.DRV_GetErrorMessage(ErrCde, szErrMsg);
                        return;
                    }
                }
                ActivateCard(0);
                DOBitPort(DOportNo, OFFState);
            }
            else
            {
                var lpDioPortMode = new PT_DioSetPortMode
                {
                    Port = 1,
                    dir_Renamed = 1,
                };
                if (lpDevFeatures.usDIOPort > 0)
                {
                    ErrCde = MODDriver.DRV_DioSetPortMode(DeviceHandle, lpDioPortMode);
                    if (ErrCde != 0)
                    {
                        MODDriver.DRV_GetErrorMessage(ErrCde, szErrMsg);
                        return;
                    }
                }
                ActivateCard(1);
                DOBitPort(DOportNo - 8, OFFState);
            }
        }

        private void ActivateCard(short AddressNO)
        {
            var lpDioGetCurrentDoByte = new PT_DioGetCurrentDOByte
            {
                Port = AddressNO,
                value = MODDriver.DRV_GetAddress(0),
            };
            ErrCde = MODDriver.DRV_DioGetCurrentDOByte(DeviceHandle, lpDioGetCurrentDoByte);
            if (ErrCde != 0)
            {
                MODDriver.DRV_GetErrorMessage(ErrCde, szErrMsg);
            }
        }

        private void DOBitPort(int DOPort, bool OFFState)
        {
            PortDOState[DOPort] = OFFState;
            int DoValue = 0;
            for (int i = 0; i < 7; i++)
            {
                if (PortDOState[i])
                {
                    int DOBit = 1;
                    if (i >= 1)
                    {
                        for (int j = 1; j < i; j++)
                        {
                            DOBit = DOBit * 2;
                        }
                    }
                    DoValue = DoValue + DOBit;
                }
            }
            var lpDioWritePort = new PT_DioWritePortByte
            {
                Port = lpDioPortMode.Port,
                Mask = 255,
                state = DoValue,
            };
            ErrCde = MODDriver.DRV_DioWritePortByte(DeviceHandle, lpDioWritePort);
            if (ErrCde != 0)
            {
                MODDriver.DRV_GetErrorMessage(ErrCde, szErrMsg);
            }
        }

        private void IniStallCard()
        {
            // 扫描设备
            int tt = MODDriver.DRV_GetAddress(0);
            ErrCde = MODDriver.DRV_DeviceGetList(tt, 255, 0);
            if (ErrCde != 0)
            {
                MODDriver.DRV_GetErrorMessage(ErrCde, szErrMsg);
                return;
            }
            // 扫描设备号
            ErrCde = MODDriver.DRV_DeviceGetNumOfList(0);
            if (ErrCde != 0)
            {
                MODDriver.DRV_GetErrorMessage(ErrCde, szErrMsg);
                return;
            }
            GetDevice();
        }

        private void GetDevice()
        { 
        
        }

        private void M_timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
