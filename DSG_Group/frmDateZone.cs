using DSG_Group.DGComm;
using DSG_Group.SqlServers;
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
    public partial class frmDateZone : Form
    {
        public frmDateZone()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void cmdSaveAs_Click(object sender, EventArgs e)
        {
            var dateStart = dtpLow.Value.Date;
            var dateEnd = dtpHigh.Value.Date;
            var data = await Service_T_Result.Queryable(dateStart, dateEnd);
            if (data != null)
            {
                var bol = HelperFile.CreateExcel(data, "T_Result");
                string msg = bol ? "导出成功" : "导出失败！";
                MessageBox.Show(msg);
            }
            else { MessageBox.Show("数据库异常"); }
        }
    }
}
