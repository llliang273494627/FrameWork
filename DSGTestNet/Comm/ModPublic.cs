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
                HelperLogWrete.Info($"{name}打开串口失败：{serialPort.PortName}");
                HelperLogWrete.Error($"{name}打开串口失败：{serialPort.PortName}", ex);
            }
        }
        public void OpenSerialPort(SerialPort serialPort,string portName,string setting, string name = "")
        {
            try
            {
                if (string.IsNullOrEmpty(portName) || string.IsNullOrEmpty(setting))
                    return;

                serialPort.PortName = "COM" + portName;
                var set = setting.Split(',');
                if (set.Length == 4)
                {
                    int.TryParse(set[0], out int BaudRate);
                    serialPort.BaudRate = BaudRate;
                    switch (set[1])
                    {
                        case "n":
                            serialPort.Parity = Parity.None;
                            break;
                        case "o":
                            serialPort.Parity = Parity.Odd;
                            break;
                        case "e":
                            serialPort.Parity = Parity.Even;
                            break;
                        case "m":
                            serialPort.Parity = Parity.Mark;
                            break;
                        case "s":
                            serialPort.Parity = Parity.Space;
                            break;
                        default:
                            int.TryParse(set[1], out int parity);
                            serialPort.Parity = (Parity)parity;
                            break;
                    }
                    int.TryParse(set[2], out int DataBits);
                    serialPort.DataBits = DataBits;
                    int.TryParse(set[3], out int StopBits);
                    serialPort.StopBits = (StopBits)StopBits;
                }
                string tmp = serialPort.IsOpen ? $"串口号：{serialPort.PortName} 已经打开" : $"打开串口号：{serialPort.PortName}";
                if (!serialPort.IsOpen)
                    serialPort.Open();
                HelperLogWrete.Info(name + tmp);
            }
            catch (Exception ex)
            {
                HelperLogWrete.Info($"{name}打开串口失败：{serialPort.PortName}");
                HelperLogWrete.Error($"{name}打开串口失败：{serialPort.PortName}", ex);
            }
        }
    }
}
