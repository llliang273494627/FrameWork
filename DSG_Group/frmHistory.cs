using DSG_Group.DGComm;
using DSG_Group.SqlServers;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSG_Group
{
    public partial class frmHistory : Form
    {
        public frmHistory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 页数
        /// </summary>
        private int pages = 0;

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Command3_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Command4_Click_1(object sender, EventArgs e)
        {
            pages = 1;
            string vin = txtVIN.Text.Trim();
            DateTime dateStart = dtpLow.Value.Date;
            DateTime dateEnd = dtpHigh.Value.Date;
            MSFlexGrid1.DataSource = await Service_T_Result.Queryable(vin, dateStart, dateEnd, pages, 8);

            var testSum= await Service_T_Result.Queryable(vin, dateStart, dateEnd);
            lbl_test_num.Text = testSum.ToString();
            var stateOK=await Service_T_Result.QueryableTestOK(vin, dateStart, dateEnd);
            lal_ok_num.Text = stateOK.ToString();
            var percentage = (stateOK * 100) / testSum;
            lab_rate.Text = $"{percentage}%";
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            MSFlexGrid1.AllowUserToAddRows = false;
            MSFlexGrid1.AllowUserToDeleteRows = false;
            MSFlexGrid1.AllowUserToOrderColumns = false;
            MSFlexGrid1.ReadOnly = true;
            MSFlexGrid1.RowHeadersVisible = false;

            lbl_test_num.Text = string.Empty;
            lal_ok_num.Text = string.Empty;
            lab_rate.Text = string.Empty;
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Label5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pages--;
            pages = pages < 1 ? 1 : pages;
            string vin = txtVIN.Text.Trim();
            DateTime dateStart = dtpLow.Value.Date;
            DateTime dateEnd = dtpHigh.Value.Date;
            MSFlexGrid1.DataSource = await Service_T_Result.Queryable(vin, dateStart, dateEnd, pages, 8);
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pages++;
            string vin = txtVIN.Text.Trim();
            DateTime dateStart = dtpLow.Value.Date;
            DateTime dateEnd = dtpHigh.Value.Date;
            MSFlexGrid1.DataSource = await Service_T_Result.Queryable(vin, dateStart, dateEnd, pages, 8);
        }
    }
}
