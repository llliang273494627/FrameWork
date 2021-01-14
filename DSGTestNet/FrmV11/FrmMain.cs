using DSGTestNet.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTestNet.FrmV11
{
    public partial class FrmMain : DSGTestVB.FrmMain
    {
        public FrmMain()
        {
            InitializeComponent();
            //MSComVINO.Open();
            //MSCommBTO.Open();
        }

        /// <summary>
        /// 处理有线扫描枪的扫描信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MSComVINO_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var serial = sender as SerialPort;
                if (serial == null || base.BreakFlag)
                    return;

                Thread.Sleep(100);
                base.TestCode = serial.ReadExisting();
                if (string.IsNullOrEmpty(base.TestCode))
                    return;

                if (base.TestCode.Length >= 17)
                {
                    var subCode = base.TestCode.Substring(0, 17);
                    switch (subCode)
                    {
                        case "R010000000000000C"://重置条码
                            HelperLogWrete.Info("1扫描重置条码");
                            base.resetList();
                            return;
                        case "R020000000000000C"://强制输入条码
                            base.barCodeFlag = true;
                            return;
                    }
                }
                Debug.Print(base.TestCode);
                base.txtVIN_KeyPress(base.txtVin, new KeyPressEventArgs(Convert.ToChar(13)));
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("蓝牙扫描枪通信错误", ex);
            }
            
        }

        /// <summary>
        /// 无线条码枪通信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MSCommBTO_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var serial = sender as SerialPort;
                if (serial == null || base.BreakFlag)
                    return;

                Thread.Sleep(100);
                base.TestCode = serial.ReadExisting();
                if (string.IsNullOrEmpty(base.TestCode))
                    return;

                if (base.TestCode.Length >= 17)
                {
                    var subCode = base.TestCode.Substring(0, 17);
                    switch (subCode)
                    {
                        case "R010000000000000C"://重置条码
                            HelperLogWrete.Info("0扫描重置条码");
                            base.resetList();
                            return;
                        case "R020000000000000C"://强制输入条码
                            HelperLogWrete.Info("扫描强制输入条码");
                            base.barCodeFlag = true;
                            base.resetList();
                            return;
                    }
                }
                Debug.Print(base.TestCode);
                base.txtVIN_KeyPress(base.txtVin, new KeyPressEventArgs(Convert.ToChar(13)));
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("蓝牙扫描枪通信错误", ex);
            }
        }
    }
}
