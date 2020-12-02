using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace COM
{
    /// <summary>
    /// 验证类
    /// </summary>
    public static class Validate
    {
        #region 验证类
        //搜索输入字符串并返回所有 href=“...”值 
        public static string DumpHrefs(String inputString)
        {
            Regex r;
            Match m;
            r = new Regex("href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))",
             RegexOptions.IgnoreCase | RegexOptions.Compiled);
            string str = "";
            for (m = r.Match(inputString); m.Success; m.NextMatch())
            {
                str = ("Found href " + m.Groups[1]);
            }
            return str;
        }

        /// <summary>
        /// 验证Email地址
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format. 
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// dd-mm-yy 的日期形式代替 mm/dd/yy 的日期形式。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns> 
        public static string MDYToDMY(String input)
        {
            return Regex.Replace(input, "\\b(?\\d{1,2})/(?\\d{1,2})/(?\\d{2,4})\\b", "${day}-${month}-${year}");
        }

        /// <summary>
        /// 验证是否为小数 
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidDecimal(string strIn)
        {
            return Regex.IsMatch(strIn, @"[0].\d{1,2}|[1]");
        }

        /// <summary>
        /// 验证是否为电话号码
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns> 
        public static bool IsValidTel(string strIn)
        {
            return Regex.IsMatch(strIn, @"(\d+-)?(\d{4}-?\d{7}|\d{3}-?\d{8}|^\d{7,8})(-\d+)?");
        }

        /// <summary>
        /// 验证年月日 
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidDate(string strIn)
        {
            return Regex.IsMatch(strIn, @"^2\d{3}-(?:0?[1-9]|1[0-2])-(?:0?[1-9]|[1-2]\d|3[0-1])(?:0?[1-9]|1\d|2[0-3]):(?:0?[1-9]|[1-5]\d):(?:0?[1-9]|[1-5]\d)$");
        }

        /// <summary>
        /// 验证后缀名
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidPostfix(string strIn)
        {
            return Regex.IsMatch(strIn, @"\.(?i:gif|jpg)$");
        }

        /// <summary>
        /// 验证字符是否在4至12之间
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns> 
        public static bool IsValidByte(string strIn)
        {
            return Regex.IsMatch(strIn, @"^[a-z]{4,12}$");
        }

        /// <summary>
        /// 验证IP
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns> 
        public static bool IsValidIp(string strIn)
        {
            return Regex.IsMatch(strIn, @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");
        } 
        /// <summary>
        /// 验证正整数
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns> 
        public static bool IsValidUInt(string strIn)
        {
            return Regex.IsMatch(strIn, @"^\d+$");
        }
        /// <summary>
        /// 验证整数 
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidInt(string strIn)
        {
            return Regex.IsMatch(strIn, @"^-?\d+$");
        }
        /// <summary>
        /// //匹配由数字和26个英文字母组成的字符串
        /// </summary>
        /// <returns></returns>
        public static bool IsMatchNumberAlphabet(string strIn)
        {
            return Regex.IsMatch(strIn, @"^[A-Za-z0-9]+$");
        }
        /// <summary>
        /// 匹配正浮点数
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsMatchUFloat(string strIn)
        {
            return Regex.IsMatch(strIn, @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$");
        }
        /// <summary>
        /// 匹配汉字
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsMatchChinese(string strIn)
        {
            return Regex.IsMatch(strIn, @"^[\u4e00-\u9fa5]{0,}$");
        }
        /// <summary>
        /// 匹配xx位到xx位小数的正实数
        /// </summary>
        /// <param name="strIn">匹配的字符</param>
        /// <param name="pointNumStart">小数点位数，不填为不限</param>
        /// <param name="pointNumEnd">小数点位数，不填为不限</param>
        /// <returns></returns>
        public static bool IsMatchNumber(string strIn, int? pointNumStart, int? pointNumEnd)
        {
            return pointNumStart == null || pointNumEnd == null ? Regex.IsMatch(strIn, @"^[0-9]+(.[0-9]+)?$") : Regex.IsMatch(strIn, @"^[0-9]+(.[0-9]{" + pointNumStart + "," + pointNumEnd + @"})?$");
        }
        /// <summary>
        /// 匹配英文字符
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsMatchAlphabet(string strIn)
        {
            return Regex.IsMatch(strIn, @"^[A-Za-z]+$");
        }
        #endregion

        #region 验证与模式字符串匹配
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>        
        public static bool IsMatch(string input, string pattern)
        {
            return IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 验证字符串是否匹配，匹配返回true
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="options">筛选条件</param>
        public static bool IsMatch(string input, string pattern, RegexOptions options)
        {
            return Regex.IsMatch(input, pattern, options);
        }
        #endregion
    }
}