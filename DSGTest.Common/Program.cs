using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTest.Common
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
            Application.ThreadException += Application_ThreadException;

            string conneString = "PORT=5432;DATABASE=DPCAWH1_DSG101;HOST=localhost;PASSWORD=123456;USER ID=postgres";
            FrameWork.Model.Comm.HelperSqlsugar.Init(4, conneString);
            Application.Run(new FrmMain());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Helper.HelperLogger.LogError("未捕获异常！", e.Exception);
        }
    }
}
