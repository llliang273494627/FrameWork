using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTest.Common.Helper
{
    public class HelperFunctions
    {
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="port"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static bool SerialPortOnline(System.IO.Ports.SerialPort serialPort , string  port , string  setting)
        {
            try
            {
                string[] sets = setting.Split(',');
                serialPort.PortName = "COM" + port;
                serialPort.BaudRate = int.Parse(sets[0]);
                switch (sets[1])
                {
                    case "e":
                        serialPort.Parity = System.IO.Ports.Parity.Even;
                        break;
                    case "m":
                        serialPort.Parity = System.IO.Ports.Parity.Mark;
                        break;
                    case "n":
                        serialPort.Parity = System.IO.Ports.Parity.None;
                        break;
                    case "o":
                        serialPort.Parity = System.IO.Ports.Parity.Odd;
                        break;
                    case "s":
                        serialPort.Parity = System.IO.Ports.Parity.Space;
                        break;
                }
                serialPort.DataBits = int.Parse(sets[2]);
                serialPort.StopBits = (System.IO.Ports.StopBits)int.Parse(sets[3]);
                serialPort.Open();
                return true;
            }
            catch (Exception ex)
            {
                HelperLogger.LogError($"{serialPort.PortName}：打开串口异常！", ex);
                return false;
            }
        }

        /// <summary>
        /// Ping远程IP
        /// </summary>
        /// <param name="szAddress"></param>
        /// <returns></returns>
        public static bool Ping(string szAddress)
        {
            System.Net.NetworkInformation.Ping tmpPing = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.IPStatus pr = tmpPing.Send(szAddress, 1000).Status;
            if (pr == System.Net.NetworkInformation.IPStatus.Success)
                return true;
            else
                return false;
        }
    }
}
