using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace COM
{
    /// <summary>
    /// 快捷方式操作类
    /// </summary>
    public class Shortcut
    {
        /// <summary>
        /// 可执行程序路径
        /// </summary>
        public string ExecPath { get; set; }

        /// <summary>
        /// 可执行程序快捷方式名称
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// 可执行程序快捷方式路径
        /// </summary>
        public string ShortcutPath { get; set; }

        public Shortcut(Assembly assembly,string name)
        {
            this.ExecPath = assembly.GetModules()[0].FullyQualifiedName;
            this.AppName = name;
            this.ShortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs), this.AppName + ".lnk");
        }

        /// <summary>
        /// 创建快捷方式，指定快捷方式名称
        /// </summary>
        /// <param name="name"></param>
        public void Create()
        {
            Create(this.ExecPath, this.AppName);
        }

        /// <summary>
        /// 创建快捷方式，指定快捷方式名称
        /// </summary>
        /// <param name="name"></param>
        public bool IsExist()
        {
            return System.IO.File.Exists(this.ShortcutPath);
        }

        /// <summary>
        /// 移除创建快捷方式
        /// </summary>
        /// <param name="name"></param>
        public void Remove()
        {
            Remove(this.ShortcutPath);
        }

        #region //静态方法
        ///<summary>
        ///创建快捷方式
        ///</summary>
        ///<param name="ExePath">程序所在路径</param>
        ///<param name="where">快捷方式的名称</param>
        ///<example>
        /// string name = "My App";
        /// string exePath = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
        /// Shortcut.Create(exePath, name);
        ///</example>
        public static void Create(string exePath, string name)
        {
            StreamWriter objWriter = null;
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs), name + ".lnk");
                if (System.IO.File.Exists(path))
                {
                    File.Delete(path);
                }
                objWriter = File.CreateText(path);
                objWriter.WriteLine(string.Format("24#\"{0}\" 1", exePath));
                objWriter.Close();
            }
            finally
            {
                objWriter = null;
            }
        }

        ///<summary>
        /// 移除快捷方式
        ///</summary>
        ///<param name="where">快捷方式的名称</param>
        public static void Remove(string name)
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs), name + ".lnk");
                if (System.IO.File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
    }
}
