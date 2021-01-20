using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTestNet.Version
{
    /// <summary>
    /// 神龙三厂胎压设备搬迁项目
    /// </summary>
    public class VersionV1200 : AbsVersion
    {
        /// <summary>
        /// 版本配置号
        /// </summary>
        public const string VersionCode = "V.1.2.0.0";

        /// <summary>
        /// 标题
        /// </summary>
        private const string _title = "神龙汽车有限公司  胎压初始化系统";

        public override string Title { get { return $"{_title}  {VersionCode}"; } }

        public override Form FrmMain()
        {
            return new FrmV12.FrmMain { Text =Title };
        }
    }
}
