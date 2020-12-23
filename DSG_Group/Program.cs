using DSG_Group.DGComm;
using FrameWork.Model.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSG_Group
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

            // 配置数据库
            HelperSqlsugar.Init(1, HelperSetting.SqlServerCnnStr);

            Application.Run(new FrmMain());
        }
    }
}
