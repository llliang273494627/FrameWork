using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace COM
{
    public class MD5
    {
        #region MD5加密方法
        /// <summary>
        /// MD5加密方法
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <param name="bit">加密的位数</param>
        /// <returns>加密后的字符串</returns>
        public static string Encode(string str, int bit)
        {
            if (bit == 16)
                return Md516(str);
            else if (bit == 32)
                return Md532(str);
            else
                return null;
        }

        #region MD5 16位加密
        /// <summary>
        /// MD5 16位加密
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        private static string Md516(string str)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(str)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }
        #endregion

        #region MD5 32位加密
        /// <summary>
        /// MD5 32位加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string Md532(string str)
        {
            string result = "";
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符
                //result = s[i].ToString("X").Length<2 ? result + "0" +s[i].ToString("X"):result + s[i].ToString("X");0:X2
                result = result + s[i].ToString("X2");
            }
            return result;
        }
        #endregion 
        #endregion
    }
}
