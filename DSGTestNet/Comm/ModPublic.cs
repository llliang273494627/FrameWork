using DSGTestNet.Helper;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.Comm
{
    public class ModPublic
    {
        /// <summary>
        /// 打开串口
        /// </summary>
        public void OpenSerialPort(SerialPort serialPort, string name = "")
        {
            try
            {
                string tmp = serialPort.IsOpen ? $"串口号：{serialPort.PortName} 已经打开" : $"打开串口号：{serialPort.PortName}";
                if (!serialPort.IsOpen)
                    serialPort.Open();
                HelperLogWrete.Info(name + tmp);
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error($"{name}打开串口失败：{serialPort.PortName}", ex);
            }
        }
    }
}
