using DSGTestNet.Comm;
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

namespace DSGTestNet.FrmV12
{
    public partial class FrmMain : Form 
    {
        public FrmMain()
        {
            InitializeComponent();

            _modPublic = new ModPublic();
        }

        ModPublic _modPublic = null;

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
                if (serial == null )
                    return;

              
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("蓝牙扫描枪通信错误", ex);
            }
           
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
                if (serial == null )
                    return;

               
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("蓝牙扫描枪通信错误", ex);
            }
        }

        /// <summary>
        /// 首次加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmMain_Load(object sender, EventArgs e)
        {
            
            // 串口设置
            _modPublic.OpenSerialPort(MSCommBTO, "MSCommBTO");
            _modPublic.OpenSerialPort(MSComVINO, "MSComVINO");
        }

       
    }
}
