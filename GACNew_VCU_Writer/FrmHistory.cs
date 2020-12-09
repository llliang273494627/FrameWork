using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Logging;
using GACNew_VCU_Writer_BLL;
using System.IO;

namespace GACNew_VCU_Writer
{
    public partial class FrmHistory : Form
    {
        #region 私有变量

        /// <summary>
        /// 日志对象
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(FrmHistory));

        private static Configer configer = new Configer();

        #endregion

        #region 属性

        private string localConnectionString = string.Empty;

        public string LocalConnectionString
        {
            get { return localConnectionString; }
            set { localConnectionString = value; }
        }

        #endregion

        public FrmHistory()
        {
            InitializeComponent();
        }

        public FrmHistory(string localConnectionString)
        {
            this.localConnectionString = localConnectionString;
            configer = new Configer(this.localConnectionString);
            InitializeComponent();  
        }

        private void FrmHistory_Load(object sender, EventArgs e)
        {
            //dgvSelectedValue.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSelectedValue.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           
        }

        private async void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                //DataTable dtSelectValue = configer.GetHistoryResult(this.dtpStartTime.Value, this.dtpEndTime.Value, this.txtVIN.Text);
                DataTable dtSelectValue =await Comm.SqlComm.GetHistoryResult(this.dtpStartTime.Value, this.dtpEndTime.Value, this.txtVIN.Text);
                this.dgvSelectedValue.DataSource = dtSelectValue;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtSource = this.dgvSelectedValue.DataSource as DataTable;
                if (dtSource == null || dtSource.Rows.Count == 0)
                {
                    MessageBox.Show("没有数据导出！");
                    return;
                }
                    
                ExcelHelper excelHelper = new ExcelHelper();
                byte[] data = excelHelper.DataTable2Excel(dtSource, "写入数据");

                string directoryPath = AppDomain.CurrentDomain.BaseDirectory + @"导出";
                string filePath = directoryPath + @"\TCU写入数据" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";

                if (Directory.Exists(directoryPath) == false)
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (!File.Exists(filePath))
                {
                    FileStream fs = new FileStream(filePath, FileMode.CreateNew);
                    fs.Write(data, 0, data.Length);
                    fs.Close();
                }

                MessageBox.Show("导出成功！");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
                MessageBox.Show("导出失败，请查看Error日志!");
            }
        }
    }
}
