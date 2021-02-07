using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace DSGTest.Common.Frms
{
    public partial class frmShowLog : Form
    {
        public frmShowLog()
        {
            InitializeComponent();
        }

        private void bntLockLog_Click(object sender, EventArgs e)
        {
            try
            {
                string name = monthCalendar1.SelectionStart.ToString("yyyyMMdd") + "_Log.txt";
                string fileName = Path.Combine(Directory.GetCurrentDirectory(), "Log", name);
                if (File.Exists(fileName))
                {
                    ProcessStartInfo process = new ProcessStartInfo();
                    process.FileName = fileName;
                    Process.Start(process);
                }
                else
                {
                    MessageBox.Show($"选择日志文件为空！{name}");
                }
            }
            catch (Exception ex)
            {
                Helper.HelperLogger.LogError("打开日志文件异常！", ex);
            }
        }
    }
}
