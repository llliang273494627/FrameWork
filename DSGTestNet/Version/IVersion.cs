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
        /// 当前配置版本号
        /// </summary>
        string VersionCode { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// 获取主窗体
        /// </summary>
        Form GetFrmMain();
    }
}
