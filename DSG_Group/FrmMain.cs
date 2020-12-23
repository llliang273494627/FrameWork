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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 系统配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbntSystemSetting_Click(object sender, EventArgs e)
        {
            var frm = new frmPSW();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var frmoption = new frmOption();
                frmoption.ShowDialog();
            }
        }
    }
}
