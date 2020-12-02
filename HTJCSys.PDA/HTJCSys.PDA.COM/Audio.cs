using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace COM
{
    public class Audio
    {
        #region 提示音
        /// <summary>
        /// 提示音
        /// </summary>
        /// <param name="flag">0:错误,1:扫描正确,2:OK</param>
        /// <returns></returns>
        public static bool SoundTip(int flag)
        {
            Sound sp = null;
            try
            {
                string filePath = "";
                uint[] blight = new uint[2];
                switch (flag)
                {
                    case 0:
                        filePath = BaseVariable.ErrorSound;
                        break;
                    case 1:
                        filePath = BaseVariable.ScanSound;
                        break;
                    case 2:
                        filePath = BaseVariable.OkSound;
                        break;
                }
                //using (SoundPlayer sp = new SoundPlayer(filePath))
                //{
                //    sp.Play();
                //}
                sp = new Sound(filePath);
                sp.Play();
                return true;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                return false;
            }
            finally
            {
                sp = null;
            }
        }
        #endregion
    }
}
