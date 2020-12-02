using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using COM;

namespace HTJCSys.PDA
{
    public partial class FrmLoginWait : Form
    {
        FrmLogin frmLogin = null;
        FrmMain frmMain = null;
        int frmType = 0;
        public FrmLoginWait()
        {
            InitializeComponent();
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);//居中显示
        }

        public FrmLoginWait(Form frm, int type, string msg)
            : this()
        {
            frmType = type;
            if (type==1)
            {
                this.frmMain = frm as FrmMain;
            }
            else
            {
                this.frmLogin = frm as FrmLogin;
            }
            this.label1.Text = msg;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.timer.Enabled = false;
            if (frmType==1)
            {
                int count = 0;
                while (FrmMain.ThreadUploadDataState != ThreadState.Stop && count < 10)
                {
                    Thread.Sleep(1000);
                    count++;
                }
                //CLog.WriteStationLog("login", "[FrmLoginWait.count:]" + count + ",ThreadState:" + FrmMain.ThreadUploadDataState.ToString());

                this.Close();
            }
            else
            {
                HTJCSys.PDA.FrmLogin.delegateInit init = new FrmLogin.delegateInit(this.frmLogin.Init);
                init.Invoke();
                this.Close();
            }
        }

        private void FrmLoginWait_Click(object sender, EventArgs e)
        {

        }
    }
}