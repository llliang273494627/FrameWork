using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTestNet.Version
{
    /// <summary>
    /// 虚拟类
    /// </summary>
    public abstract class AbsVersion : IVersion
    {
        public virtual string Title { get; set; }

        /// <summary>
        /// 获取主窗体
        /// </summary>
        /// <returns></returns>
        public virtual Form FrmMain()
        {
            return new FrmMain
            {
                Text = Title,
            };
        }

        public Form FrmInfo()
        {
            return null;
        }
    }
}
