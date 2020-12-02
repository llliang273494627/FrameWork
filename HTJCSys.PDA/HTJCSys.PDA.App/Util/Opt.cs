using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using COM;
using System.Collections;
using System.Text.RegularExpressions;
using XY.DataCollect.Intermec;
using XY.Util;
using MDL;
using System.Data;
using DAL;

namespace HTJCSys.PDA
{
    public class Opt
    {
        #region 判断全局网络状态
        /// <summary>
        /// 判断全局网络状态
        /// </summary>
        /// <returns></returns>
        public static bool GlobalNetStatus()
        {
            try
            {
                //判断wifi的信号强度是否符合要求
                bool Status = Network.GetWifiStrengthLevel() >= WiFiLevel.WIFI_SIGNAL_VERY_GOOD ? true : false;
                if (Status && BaseVariable.ServerStatus && BaseVariable.NetworkStatus)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                return false;
            }
        }
        #endregion

        #region 获取服务器的时间
        /// <summary>
        /// 获取服务器的时间
        /// </summary>
        /// <returns></returns>
        public static object GetDateTime()
        {
            try
            {
                string url = BaseVariable.RequestURL + "v2/Result.ashx";
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("do", "datetime");
                string str = Http.POST(url, dict);
                var rs = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
                ReturnInfo ReturnData = (ReturnInfo)rs;
                if (ReturnData != null && ReturnData.Code == "1")
                {
                    return ReturnData.Data;
                }
                return null;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                return null;
            }
        }
        #endregion

        #region 测试服务器数据库连接状况
        /// <summary>
        /// 测试服务器数据库连接状况
        /// </summary>
        /// <returns></returns>
        public static bool ServerConnectStatus()
        {
            try
            {
                string url = BaseVariable.RequestURL + "v2/Result.ashx";
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("do", "testdb");
                string str = Http.POST(url, dict);
                var rs = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
                ReturnInfo ReturnData = (ReturnInfo)rs;
                if (ReturnData != null && ReturnData.Code == "1")
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                return false;
            }
        } 
        #endregion

        #region 检查批次信息是否需要更新提示
        /// <summary>
        /// 检查批次信息是否需要更新提示
        /// </summary>
        /// <returns></returns>
        public static bool CheckBatchStatus(string productCode)
        {
            try
            {
                string url = BaseVariable.RequestURL + "BatchNo.ashx";
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("do", "check");
                dict.Add("ProductCode", productCode);
                string str = Http.POST(url, dict);
                var rs = JsonHelper.JsonDeSerializer<ReturnInfo>(str);
                ReturnInfo ReturnData = (ReturnInfo)rs;
                if (ReturnData != null && ReturnData.Code == "1")
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                return false;
            }
        }
        #endregion

        #region 计算检验位
        #region static Hashtable featureCol
        private static Hashtable _featureCol;
        public static Hashtable featureCol
        {
            get
            {
                if (_featureCol == null)
                {
                    Hashtable t = new Hashtable();
                    t.Add("0", "A");
                    t.Add("1", "B");
                    t.Add("2", "C");
                    t.Add("3", "D");
                    t.Add("4", "E");
                    t.Add("5", "F");
                    t.Add("6", "G");
                    t.Add("7", "H");
                    t.Add("8", "J");
                    t.Add("9", "K");
                    t.Add("10", "L");
                    t.Add("11", "M");
                    t.Add("12", "N");
                    t.Add("13", "P");
                    t.Add("14", "Q");
                    t.Add("15", "R");
                    t.Add("16", "S");
                    t.Add("17", "T");
                    t.Add("18", "U");
                    t.Add("19", "V");
                    t.Add("20", "W");
                    t.Add("21", "X");
                    t.Add("22", "Y");
                    t.Add("23", "Z");
                    _featureCol = t;
                }
                return _featureCol;
            }
            set { _featureCol = value; }
        }
        #endregion

        #region static Hashtable lettersCol
        private static Hashtable _lettersCol;
        public static Hashtable lettersCol
        {
            get
            {
                if (_lettersCol == null)
                {
                    Hashtable t = new Hashtable();
                    t.Add("0", "0");
                    t.Add("1", "1");
                    t.Add("2", "2");
                    t.Add("3", "3");
                    t.Add("4", "4");
                    t.Add("5", "5");
                    t.Add("6", "6");
                    t.Add("7", "7");
                    t.Add("8", "8");
                    t.Add("9", "9");
                    t.Add("A", "10");
                    t.Add("B", "11");
                    t.Add("C", "12");
                    t.Add("D", "13");
                    t.Add("E", "14");
                    t.Add("F", "15");
                    t.Add("G", "16");
                    t.Add("H", "17");
                    t.Add("J", "18");
                    t.Add("K", "19");
                    t.Add("L", "20");
                    t.Add("M", "21");
                    t.Add("N", "22");
                    t.Add("P", "23");
                    t.Add("Q", "24");
                    t.Add("R", "25");
                    t.Add("S", "26");
                    t.Add("T", "27");
                    t.Add("U", "28");
                    t.Add("V", "29");
                    t.Add("W", "30");
                    t.Add("X", "31");
                    t.Add("Y", "32");
                    t.Add("Z", "33");
                    _lettersCol = t;
                }
                return _lettersCol;
            }
            set { _lettersCol = value; }
        }
        #endregion

        /// <summary>
        /// 计算检验位
        /// </summary>
        /// <param name="barCode">合件条码,不包含校验位</param>
        /// <returns></returns>
        public static string CheckBit(string barCode)
        {
            string checkSum = String.Empty;
            string tmpStr = String.Empty;
            int remainder = 0;

            try
            {
                for (int index = 0; index < barCode.Length; index++)
                {
                    tmpStr += lettersCol[barCode.Substring(index, 1)];
                }

                #region 用Math.IEEERemainder求余时，如果tmpStr过大，如167101812210143200011，会有问题，余数一直是16
                //remainder = Convert.ToInt32(Math.IEEERemainder(Convert.ToDouble(tmpStr), 24));
                //if (remainder < 0)
                //{
                //    remainder += 24;
                //}
                //tmpStr = remainder.ToString();
                #endregion

                remainder = LongIntMod2(tmpStr, 24);

                checkSum = featureCol[remainder.ToString()].ToString();
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(String.Format("在计算检验位时出错：{0}", ex.Message));
            }

            return checkSum;
        }


        /// <summary>
        /// 求余数
        /// </summary>
        /// <param name="p_strNum"></param>
        /// <param name="p_intMod"></param>
        /// <returns></returns>
        public static int LongIntMod2(string p_strNum, int p_intMod)
        {
            int n = p_strNum.Length;
            int jieguo = 0;

            for (int i = 0; i < n; i++)
            {
                int temp = p_strNum[i] - '0';
                jieguo = (jieguo * 10 + temp) % p_intMod;
            }

            return jieguo;
        } 
        #endregion

        #region 判断合件条码是否合格
        /// <summary>
        /// 判断合件条码是否合格
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool HJValidate(string code)
        {
            Regex regex = new Regex("^([0-9|A-Z|a-z]{14})$");
            bool rst = regex.IsMatch(code);
            return rst;
        } 
        #endregion

        #region 获取特征码
        /// <获取特征码>
        /// 比较特征码
        /// </summary>
        /// <param name="str">含有特征码的字符串</param>
        /// <param name="index">特征码的校验位</param>
        /// <returns>string</returns>
        public static string GetFeatureCode(string str, string index)
        {
            //获取特征码
            string rst = "";
            string[] code = index.Split(',');
            if (int.Parse(code[code.Length - 1].ToString()) > str.Length)
            {
                return null;
            }
            for (int i = 0; i < code.Length; i++)
            {
                int start = int.Parse(code[i].ToString()) - 1;
                rst += str.Substring(start, 1);
            }
            return rst;
        }
        #endregion

        #region 比较特征码
        /// <summary>
        /// 比较特征码
        /// </summary>
        /// <param name="Str">待比较的字符串</param>
        /// <param name="featureIndex">校验位</param>
        /// <param name="featureCode">目标特征码</param>
        /// <returns></returns>
        public static bool ValidateFeatureCode(string Str, string featureIndex, string featureCode)
        {
            //获取特征码
            string FCode = "";
            string[] code = featureIndex.Split(',');
            for (int i = 0; i < code.Length; i++)
            {
                int start = int.Parse(code[i].ToString()) - 1;
                FCode += Str.Substring(start, 1);
            }
            if (featureCode == FCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


        /****************** 20160825 @Seay ******************/

        /// <summary>
        /// 产品特征码对应产品信息集合
        /// </summary>
        public static Dictionary<string, ProductInfoMDL> FeatureCodeList = null;

        #region 加载产品信息
        /// <summary>
        /// 加载产品信息
        /// </summary>
        public static void LoadProductInfo()
        {
            Opt.FeatureCodeList = null;

            LProductInfoDAL lProductDAL = new LProductInfoDAL();

            DataSet ds = lProductDAL.GetList("");

            if (ds == null || ds.Tables.Count < 1)
            {
                return;
            }

            DataTable table = ds.Tables[0];

            if (table == null || table.Rows.Count < 1)
            {
                return;
            }

            FeatureCodeList = new Dictionary<string, ProductInfoMDL>();
            ProductInfoMDL model;

            foreach (DataRow row in table.Rows)
            {
                model = lProductDAL.DataRowToModel(row);

                FeatureCodeList.Add(model.FeatureCode, model);
                model = null;
            }
        }
        #endregion

        #region 根据零件判断合件是否匹配

        #region //0.定义集合
        /// <summary>
        /// 零件对应特征码字典
        /// </summary>
        public static Dictionary<string, List<string>> FeatureCodeDict = null;
        /// <summary>
        /// 特征码对应的索引集合
        /// </summary>
        public static Hashtable FeatureIndexSet = null; 
        #endregion

        #region //1.初始化集合
        /// <summary>
        /// 初始化特征码集合
        /// </summary>
        /// <returns></returns>
        public static bool InitFeatureCode()
        {
                string sql = string.Format("SELECT DISTINCT(b.materialcode),b.materialname,p.productcode,p.producttype,p.featurecode,p.featureindex FROM productbominfo  b LEFT JOIN productinfo p ON b.productcode=p.productcode WHERE p.producttype='{0}'", BaseVariable.DeviceEntity.ProductType);
                DataTable table = LocalDbDAL.GetDataTable(sql);
                if (table != null && table.Rows.Count > 0)
                {
                    FeatureCodeDict = new Dictionary<string, List<string>>();
                    FeatureIndexSet = new Hashtable();
                    foreach (DataRow row in table.Rows)
                    {
                        string c = row["materialcode"].ToString();
                        string f = row["featurecode"].ToString();
                        string i = row["featureindex"].ToString();
                        List<string> list = new List<string>();

                        if (FeatureCodeDict.ContainsKey(c))
                        {
                            list = FeatureCodeDict[c];
                            FeatureCodeDict.Remove(c);
                        }

                        // 将特征码添加特征码的列表
                        list.Add(f);
                        // 添加零件对应特征码的列表
                        FeatureCodeDict.Add(c, list);

                        // 添加特征码对应的索引
                        //if (!FeatureIndexSet.ContainsKey(f))
                        //{
                        //    FeatureIndexSet.Add(f + "_" + c, i);
                        //}
                    }
                    return true;
                }
            return false;
        } 
        #endregion

        #region //2.根据子零件判断合件是否匹配
        /// <summary>
        /// 根据子零件判断合件是否匹配
        /// </summary>
        /// <param name="materialCode">子零件条码</param>
        /// <param name="barcode">合件条码</param>
        /// <returns></returns>
        public static bool ValidatePartCode(string materialCode, string barcode)
        {
            if (FeatureCodeDict.ContainsKey(materialCode))
            {
                List<string> list = FeatureCodeDict[materialCode];
                string f = GetFeatureCode(barcode,"1,2,3,4,5,6");
                if (list != null && f != null && list.Contains(f))
                {
                    return ValidateFeatureCode(barcode, "1,2,3,4,5,6", f);
                }
            }
            return false;
        } 
        #endregion
        #endregion
    }
}
