using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Common.Logging;

namespace GACNew_VCU_Writer
{
    public partial class FrmLog : Form
    {
        #region 私有变量

        /// <summary>
        /// 日志对象
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(FrmLog));

        #endregion

        public FrmLog()
        {
            InitializeComponent();
        }

        private void FrmLog_Load(object sender, EventArgs e)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                DirectoryInfo logFolder = new DirectoryInfo(path + "Logs");
                DirectoryInfo errorFolder = new DirectoryInfo(path + "Error");

                this.cboLog.Text = string.Empty;
                this.cboLog.Items.Clear();
                this.cboError.Text = string.Empty;
                this.cboError.Items.Clear();

                foreach (FileInfo file in logFolder.GetFiles())
                {
                    this.cboLog.Items.Add(file.Name);
                    if (this.cboLog.Text == string.Empty) this.cboLog.Text = file.Name;
                }

                foreach (FileInfo file in errorFolder.GetFiles())
                {
                    this.cboError.Items.Add(file.Name);
                    if (this.cboError.Text == string.Empty) this.cboError.Text = file.Name;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cboLog.Text != string.Empty)
                {
                    //System.Diagnostics.Process.Start("notepad.exe", AppDomain.CurrentDomain.BaseDirectory + @"Log\" + this.cboLog.Text);
                    DateTime selectDate = dateTimePicker1.Value;
                    System.Diagnostics.Process.Start("notepad.exe", AppDomain.CurrentDomain.BaseDirectory + @"Logs\" + this.cboLog.Text);
                    
                }
                else
                {
                    MessageBox.Show("请选择正常日志文件！");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cboError.Text != string.Empty)
                {
                    System.Diagnostics.Process.Start("notepad.exe", AppDomain.CurrentDomain.BaseDirectory + @"Error\" + this.cboError.Text);
                }
                else
                {
                    MessageBox.Show("请选择错误日志文件！");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }
    }
}
