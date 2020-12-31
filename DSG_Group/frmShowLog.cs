using DSG_Group.DGComm;
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
    public partial class frmShowLog : Form
    {
        public frmShowLog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查看日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntShowLog_Click(object sender, EventArgs e)
        {
            try
            {
                var showtime = dateTime.Value.Date;
                string dir = Path.Combine(Directory.GetCurrentDirectory(), "Log");
                var dirInfo = new DirectoryInfo(dir);
                var fileName = dirInfo.GetFiles("*_Info.txt").Where(t => t.CreationTime.Date == showtime).OrderBy(t => t.CreationTime).Last();
                if (fileName != null)
                {
                    System.Diagnostics.Process.Start("notepad.exe", fileName.FullName);
                }
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("查看日志失败！", ex);
            }
           
        }
    }
}
