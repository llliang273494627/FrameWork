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
            _frmInfo = new Frms.FrmInfo();
        }

        ModPublic _modPublic = null;
        Frms.FrmInfo _frmInfo = null;

        /// <summary>
        /// 鼠标按下左键是的坐标点
        /// </summary>
        Point _mousePoint = new Point();

        private void FrmInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _mousePoint = e.Location;
        }

        private void FrmInfo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X - _mousePoint.X;
                int y = e.Y - _mousePoint.Y;
                Location = Point.Add(Location, new Size(x, y));
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
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _frmInfo.Show();
            // 串口设置
            _modPublic.OpenSerialPort(MSCommBTO, "MSCommBTO");
            _modPublic.OpenSerialPort(MSComVINO, "MSComVINO");
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }
    }
}
