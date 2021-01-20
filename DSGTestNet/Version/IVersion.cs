using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTestNet.Version
{
    /// <summary>
    /// 版本接口
    /// </summary>
    public interface IVersion
    {
        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// 获取主窗体
        /// </summary>
        Form FrmMain();

        /// <summary>
        /// 内页信息
        /// </summary>
        /// <returns></returns>
        Form FrmInfo();
    }
}
