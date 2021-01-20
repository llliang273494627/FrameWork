using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTestNet.Version
{
    /// <summary>
    /// 东风乘用车G29胎压检测项目
    /// </summary>
    public class VersionV1100 : AbsVersion
    {
        /// <summary>
        /// 版本配置号
        /// </summary>
        private const string _versionCode = "V.1.1.0.0";

        /// <summary>
        /// 标题
        /// </summary>
        private const string _title = "东风乘用车公司  胎压初始化系统";

        public override string Title { get { return $"{_title}  {_versionCode}"; } }

        public override Form FrmMain()
        {
            return new FrmV11.FrmMain { Text = Title };
        }

    }
}
