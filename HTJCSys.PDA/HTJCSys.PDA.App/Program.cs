using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using COM;
using System.Reflection;
using System.Runtime.InteropServices;
using XY.Util;
using System.IO;

namespace HTJCSys.PDA
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            try
            {
                BaseVariable.InitXmlVar();//初始化基础变量
                if (!File.Exists(BaseVariable.XmlFilePath))
                {
                    throw new Exception("Config.xml配置文件不存在,请检查");
                }
                XmlHelper xml = new XmlHelper();
                BaseVariable.RequestURL = xml.SelectValue("/Root/Server/APIURL");
                string modelVaild = xml.SelectValue("/Root/Sys/ModelVaild");
                if (modelVaild.Trim().Equals("1"))
                {
                    string c = BaseVariable.APPRootPath + "config.dat";
                    if (!File.Exists(BaseVariable.XmlFilePath))
                    {
                        throw new Exception("config.dat系统文件不存在,请检查");
                    }
                    
                    SystemIdentity info = SystemIdentity.GetFromFile(c);
                    
                    if (info.GetDeviceModel() != "CK3X")
                    {
                        throw new Exception("设备版本不兼容!!!");
                    }
                }

                string appName = Assembly.GetExecutingAssembly().GetName().Name;
                if (!MutexHelper.IsApplicationOnRun(appName))
                {
                    #region 创建快捷方式
                    Shortcut sc = new Shortcut(Assembly.GetExecutingAssembly(), "鸿泰集成防错系统");
                    if (!sc.IsExist())
                    {
                        sc.Create();
                    } 
                    #endregion

                    TaskBarHelper.ShowTaskBar(false);
                    Application.Run(new FrmLogin());
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("系统正在运行!");//如果该程序已经运行则返回，避免程序重复运行
                    Application.Exit();
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                TaskBarHelper.ShowTaskBar(true);
            }
        }
    }
}