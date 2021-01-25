using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.Comm
{
    /// <summary>
    /// IO控制对象
    /// </summary>
    public class IOCard
    {
        public int ErrCde = 0;
        public string szErrMsg { get { return Convert.ToBase64String(new byte[80]); } }

        public void OutputController(short DOportNo, bool OFFState)
        {

        }

        public void GetPortValue(short PortAddress)
        {
            var lpDioReadPort = new PT_DioReadPortByte
            {
                Port = PortAddress,
                value = MODDriver.DRV_GetAddress(0),
            };
            ErrCde = MODDriver.DRV_DioReadPortByte(0, lpDioReadPort);
            if (ErrCde != 0)
            {
                MODDriver.DRV_GetErrorMessage(ErrCde, szErrMsg);
                return;
            }
            for (int i = 0; i < 7; i++)
            { 
            
            }
        }
    }
}
