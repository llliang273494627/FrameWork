using DSGTestNet.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.Version
{
    public class VersionCont
    {
        public static IVersion _init = null;
        /// <summary>
        /// 单例
        /// </summary>
        public static IVersion Init
        {
            get
            {
                if (_init == null)
                    _init = GetVersion();
                return _init;
            }
        }

        /// <summary>
        /// 获取版本
        /// </summary>
        /// <returns></returns>
        public static IVersion GetVersion()
        {
            string tmpVersionConde = HelperSetting.Version;
            IVersion version ;
            switch (tmpVersionConde)
            {
                case VersionV1100.VersionCode:// 东风乘用车G29胎压检测项目
                    version = new VersionV1100();
                    break;
                case VersionV1200.VersionCode: // 神龙三厂胎压设备搬迁项目
                    version = new VersionV1200();
                    break;
                default:
                    // 默认版本
                    version = new VersionDef();
                    HelperLogWrete.Info($"没有匹配的版本号 使用默认版本 {tmpVersionConde}");
                    break;
            }
            return version;
        }
    }
}
