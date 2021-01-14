using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTestNet.Version
{
    /// <summary>
    /// 默认版本
    /// </summary>
    public class VersionDef : AbsVersion
    {
        /// <summary>
        /// 版本配置号
        /// 默认版本
        /// </summary>
        private const string _versionCode = "V.1.0.0.0";

        /// <summary>
        /// 标题
        /// </summary>
        private const string _title = "选择版本";

        public override string Title { get { return $"{_title}  {_versionCode}"; } }
    }
}
