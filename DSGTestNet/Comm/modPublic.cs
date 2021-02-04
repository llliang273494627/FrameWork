using DSGTestNet.SqlServers;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.Comm
{
    public class modPublic 
    {
        public async static Task<string> getConfigValue(string tableName, string group, string key)
        {
            string tmpValue = string.Empty;
            switch (tableName)
            {
                case "T_CtrlParam":
                    tmpValue = await Service_T_CtrlParam.GetValue(group, key);
                    break;
            }
            return tmpValue;
        }

        /// <summary>
        /// 串口组件连接
        /// </summary>
        public static void SerialPortOnline(SerialPort serialPort, string port, string setting)
        {
            try
            {
                if (serialPort == null || string.IsNullOrEmpty(port) || string.IsNullOrEmpty(setting))
                {
                    Helper.HelperLogWrete.Info("串口参数未设置！");
                    return;
                }
                string[] sets = setting.Split(',');
                serialPort.PortName = "COM" + port;
                serialPort.BaudRate = int.Parse(sets[0]);
                switch (sets[1])
                {
                    case "e":
                        serialPort.Parity = Parity.Even;
                        break;
                    case "m":
                        serialPort.Parity = Parity.Mark;
                        break;
                    case "n":
                        serialPort.Parity = Parity.None;
                        break;
                    case "o":
                        serialPort.Parity = Parity.Odd;
                        break;
                    case "s":
                        serialPort.Parity = Parity.Space;
                        break;
                }
                serialPort.DataBits = int.Parse(sets[2]);
                serialPort.StopBits = (StopBits)int.Parse(sets[3]);
                serialPort.Open();
            }
            catch (Exception ex)
            {
                Helper.HelperLogWrete.Info(ex.Message);
                Helper.HelperLogWrete.Error("串口打开失败！", ex);
            }
        }
    }
}
