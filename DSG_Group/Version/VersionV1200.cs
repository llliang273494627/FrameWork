using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSG_Group.Version
{
    /// <summary>
    /// 神龙三厂胎压设备搬迁项目
    /// </summary>
    public class VersionV1200 : AbsVersion
    {
        /// <summary>
        /// 版本配置号
        /// </summary>
        private const string _versionCode = "V.1.2.0.0";

        public override Form GetFrmMain()
        {
            return new V1200.FrmMain();
        }
    }
}
