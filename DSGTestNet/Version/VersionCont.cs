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
        /// <summary>
        /// 单例
        /// </summary>
        public static IVersion Init { get { return GetVersion(); } }

        /// <summary>
        /// 获取版本
        /// </summary>
        /// <returns></returns>
        public static IVersion GetVersion()
        {
            string tmpVersionConde = HelperSetting.Version;
            IVersion version;
            switch (tmpVersionConde)
            {
                case "V.1.1.0.0":
                    // 东风乘用车G29胎压检测项目
                    version = new VersionV1100();
                    break;
                case "V.1.2.0.0":
                    // 神龙三厂胎压设备搬迁项目
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
