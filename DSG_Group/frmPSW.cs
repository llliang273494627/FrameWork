using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSG_Group
{
    public partial class frmPSW : Form
    {
        public frmPSW()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void bntSignIn_Click(object sender, EventArgs e)
        {
            var pwd = txtPwd.Text.Trim();
            if (string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("请输入密码");
                return;
            }

            var usePwd =await SqlServers.ServiceT_Psw.GetPSW();
            if (usePwd.Equals(pwd))
            {
                DialogResult= DialogResult.OK;
            }
            else
            {
                MessageBox.Show("密码不正确");
            }
        }
    }
}
