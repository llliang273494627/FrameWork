using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GACNew_VCU_Writer
{
    /// <summary>
    /// 刷写协议（规律参考，有待验证）
    /// </summary>
    public class BinFileComm
    {
        public BinFileComm(string binFilePath)
        {
            try
            {
                Log.Info("开始处理bin文件：" + binFilePath);
                using (FileStream Myfile = new FileStream(binFilePath, FileMode.Open, FileAccess.Read))
                {
                    BinaryReader binreader = new BinaryReader(Myfile);
                    int file_len = (int)Myfile.Length;//获取bin文件长度 
                    ByteAll = binreader.ReadBytes(file_len);
                    binreader.Close();
                    binreader.Dispose();
                    Log.Info("bin文件中共用字节数：" + file_len);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("处理bin文件异常", ex);
            }
        }

        /// <summary>
        /// CRC校验
        /// </summary>
        /// <param name="by">需要校验的数组</param>
        /// <param name="value">校验码</param>
        /// <returns></returns>
        public static string BinCRCStr(byte[] by, int value)
        {
            // crc校验
            CRC32Cls crc = new CRC32Cls();
            byte[] crcByte = by.Skip(value).Take(by.Length - 1).ToArray();
            string crCstr = String.Format("{0:X8}", crc.GetCRC32Str2(crcByte));
            return crCstr;
        }

        /// <summary>
        /// 刷写文件所有字节
        /// </summary>
        public byte[] ByteAll = new byte[0];

        /// <summary>
        /// 获取文件开始出索引
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, int> GetFileStartIndex()
        {
            // 文件段开始标记
            byte[] binStart = new byte[4] { 0xEF, 0xBE, 0xAD, 0xDE };
            var indexs = new Dictionary<int, int>();
            for (int i = 0; i < ByteAll.Length; i++)
            {
                if (ByteAll[i] == binStart[0]
                     && ByteAll[i + 1] == binStart[1]
                     && ByteAll[i + 2] == binStart[2]
                     && ByteAll[i + 3] == binStart[3])
                {
                    indexs.Add(indexs.Count, i);
                }
            }
            return indexs;
        }

        /// <summary>
        /// 获取文件段
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, byte[]> CreateBinBytes()
        {
            // 文件段数
            var fileCount = GetFileStartIndex();
            // 协议头
            var herder = new byte[33];
            // 获取文件标记
            var binCode = new Dictionary<int, byte[]>();
            // 获取文件内容
            var binData = new Dictionary<int, byte[]>();
            // 解析文件
            using (MemoryStream ms = new MemoryStream(ByteAll))
            {
                // 获取协议头
                ms.Read(herder, 0, herder.Length);
                int tmpBinCodeLen = (fileCount[0] - herder.Length) / fileCount.Count;
                // 文件标记
                for (int i = 0; i < fileCount.Count; i++)
                {
                    byte[] tmpBinCode = new byte[tmpBinCodeLen];
                    ms.Read(tmpBinCode, 0, tmpBinCodeLen);
                    binCode.Add(i, tmpBinCode);
                }
                // 文件内容
                for (int i = 0; i < fileCount.Count; i++)
                {
                    // 文件尾部位置
                    int tmpLen = i + 1 < fileCount.Count ? fileCount[i + 1] : ByteAll.Length;
                    byte[] tmpBinData = new byte[tmpLen - fileCount[i]];
                    ms.Read(tmpBinData, 0, tmpBinData.Length);
                    binData.Add(i, tmpBinData);
                }
                ms.Close();
                ms.Dispose();
            }
            // 拼接文件段
            Dictionary<int, byte[]> tmpDic = new Dictionary<int, byte[]>();
            for (int i = 0; i < fileCount.Count; i++)
            {
                using (MemoryStream fileMS = new MemoryStream())
                {
                    fileMS.Write(herder, 0, herder.Length);
                    fileMS.Write(binCode[i], 0, binCode[i].Length);
                    fileMS.Write(binData[i], 0, binData[i].Length);
                    tmpDic.Add(i, fileMS.ToArray());
                    fileMS.Close();
                    fileMS.Dispose();
                }
            }
            Log.Info("bin文件处理完成！共有 " + fileCount.Count + " 段数据");
            return tmpDic;
        }

    }
}
