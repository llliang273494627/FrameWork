using DSGTestNet.Helper;
using DSGTestNet.SqlServers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTestNet
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            Init();
        }

        string TestCode = string.Empty;
        bool BreakFlag = false;
        bool barCodeFlag = false;

        // 鼠标点击左键的坐标
        Point mousePoint = new Point();
        frmInfo frmInfo = null;
        // 条码存储对象
        Dictionary<string, string> inputCode = null;

        /// <summary>
        /// 初始化数据
        /// </summary>
        void Init()
        {
            frmInfo = new frmInfo();
            inputCode = new Dictionary<string, string>();
        }

        /// <summary>
        /// 系统重置，即复位
        /// </summary>
        async Task resetList()
        {
            if (BreakFlag)
                return;

            await Service_vincoll.Deleteable();
            await initDictionary();
        }

        /// <summary>
        /// 初始化扫描队列信息
        /// </summary>
        async Task initDictionary()
        {
            inputCode.Clear();
            List1.Items.Clear();
            frmInfo.ListOutput.Items.Clear();
            var vins = await Service_vincoll.Queryable();
            if (vins == null || vins.Count < 1)
                return;
            foreach (var item in vins)
            {
                var subItem = item.Substring(1, 16);
                inputCode.Add(subItem, item);
                List1.Items.Add(subItem);
                frmInfo.ListOutput.Items.Add(subItem.Substring(subItem.Length - 8, 8));
            }
        }

        /// <summary>
        /// 首次加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            frmInfo.Show();

            Timer_DataSync.Start();
            Timer_PrintError.Start();
            Timer_StatusQuery.Start();
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picExit_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("是否退出胎压初始化系统？", "提示", MessageBoxButtons.YesNo);
            if (msg == DialogResult.Yes)
            {
                //oIOCard.OutputController(Lamp_Buzzer_IOPort, False) '关闭蜂鸣
                //Call closeAll()
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 窗体最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Picture1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 记录点击鼠标时的坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mousePoint = e.Location;
        }

        /// <summary>
        /// 窗体随鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X - mousePoint.X;
                int y = e.Y - mousePoint.Y;
                Location = Point.Add(Location, new Size(x, y));
            }
        }

        private void txtInputVIN_Click(object sender, EventArgs e)
        {
            txtInputVIN.Text = string.Empty;
        }

        private void txtInputVIN_Leave(object sender, EventArgs e)
        {
            txtInputVIN.Text = "手工录入VIN，回车确认";
        }

        private async void txtInputVIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (BreakFlag)
                return;
            if (e.KeyChar == 13)
            {
                TestCode = txtInputVIN.Text.Trim();
                txtInputVIN.Text = "手工录入VIN，回车确认";
                switch (TestCode.Substring(0, 17))
                {
                    case "R010000000000000C":
                        HelperLogWrete.Info("1扫描重置条码");
                        await resetList();
                        return;
                    case "R020000000000000C":
                        barCodeFlag = true;
                        return;
                }
                Debug.Print(TestCode);
                txtVin_KeyPress(txtVin, e);
            }
        }

        private void txtVin_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
