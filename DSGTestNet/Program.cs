using DSGTestNet.Helper;
using DSGTestNet.Version;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTestNet
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

            FrameWork.Model.Comm.HelperSqlsugar.Init(4, HelperSetting.ConnString);
            var frm = VersionCont.Init.GetFrmMain();
            Application.Run(frm);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HelperLogWrete.Error($"未捕获异常\r\n{e.Exception.Message}", e.Exception);
        }
    }
}
