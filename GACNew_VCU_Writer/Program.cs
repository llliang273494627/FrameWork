using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GACNew_VCU_Writer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
            //Application.Run(new Form1("整车控制器", "SW1.01", "HW1.01", "SW", "HW", "2020-10-10", "+CT87SE102AL9250359", "11054", "LNAA2AA34K5S10224","A8"));
        }
    }
}
