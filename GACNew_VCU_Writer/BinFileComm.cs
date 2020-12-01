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
                    // 获取文件头位置
                    BinLen = new Dictionary<int, int>();
                    for (int i = 0; i < ByteAll.Length; i++)
                    {
                        if (ByteAll[i] == BinStart[0]
                             && ByteAll[i + 1] == BinStart[1]
                             && ByteAll[i + 2] == BinStart[2]
                             && ByteAll[i + 3] == BinStart[3])
                        {
                            BinLen.Add(BinLen.Count, i);
                        }
                    }
                    binreader.Close();
                    binreader.Dispose();
                    Log.Info("bin文件中共用字节数：" + file_len);
                    if (BinLen[0] - Herder.Length < 1)
                    {
                        Log.Info("不适合多段数据处理规律：" + file_len);
                        return;
                    }

                    CommdByte(file_len);
                    ByteAlls = CreateBinByte();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("处理bin文件异常", ex);
            }
        }

        /// <summary>
        /// 文件头
        /// </summary>
        private byte[] BinStart = new byte[4] { 0xEF, 0xBE, 0xAD, 0xDE };

        /// <summary>
        /// 协议头
        /// </summary>
        private byte[] Herder = new byte[33];

        /// <summary>
        /// 文件标记
        /// </summary>
        private Dictionary<int, byte[]> BinCode = new Dictionary<int, byte[]>();

        /// <summary>
        /// 文件内容
        /// </summary>
        private Dictionary<int, byte[]> BinData = new Dictionary<int, byte[]>();

        /// <summary>
        /// 文件头位置集合
        /// </summary>
        public Dictionary<int, int> BinLen = new Dictionary<int, int>();

        /// <summary>
        /// 刷写文件所有字节
        /// </summary>
        public byte[] ByteAll = new byte[0];

        /// <summary>
        /// 多段文件
        /// </summary>
        public Dictionary<int, byte[]> ByteAlls = new Dictionary<int, byte[]>();

        /// <summary>
        /// CRC校验
        /// </summary>
        /// <param name="by">需要校验的数组</param>
        /// <param name="value">校验码</param>
        /// <returns></returns>
        public static string BinCRCStr(byte [] by, int value)
        {
            // crc校验
            CRC32Cls crc = new CRC32Cls();
            byte[] crcByte = by.Skip(value).Take(by.Length - 1).ToArray();
            string crCstr = String.Format("{0:X8}", crc.GetCRC32Str2(crcByte));
            return crCstr;
        }

        /// <summary>
        /// 处理数组
        /// </summary>
        private void CommdByte(int file_len)
        {
            MemoryStream ms = new MemoryStream(ByteAll);
            // 获取协议头
            if (file_len > Herder.Length)
                ms.Read(Herder, 0, Herder.Length);
            // 获取文件标记
            BinCode = new Dictionary<int, byte[]>();
            int tmpBinCodeLen = (BinLen[0] - Herder.Length) / BinLen.Count;
            for (int i = 0; i < BinLen.Count; i++)
            {
                // 文件标记
                byte[] tmpBinCode = new byte[tmpBinCodeLen];
                ms.Read(tmpBinCode, 0, tmpBinCodeLen);
                BinCode.Add(i, tmpBinCode);
            }
            // 获取文件内容
            BinData = new Dictionary<int, byte[]>();
            for (int i = 0; i < BinLen.Count; i++)
            {
                // 文件尾部位置
                int tmpLen = i + 1 < BinLen.Count ? BinLen[i + 1] : file_len;
                byte[] tmpBinData = new byte[tmpLen - BinLen[i]];
                ms.Read(tmpBinData, 0, tmpBinData.Length);
                BinData.Add(i, tmpBinData);
            }
            ms.Close();
            ms.Dispose();
            Log.Info("bin文件处理完成！共用 " + BinLen.Count + " 段数据");
        }

        /// <summary>
        /// 拼接bin数组
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, byte[]> CreateBinByte()
        {
            Dictionary<int, byte[]> tmpDic = new Dictionary<int, byte[]>();
            if (BinLen.Count < 2)
                tmpDic.Add(0, ByteAll);
            else
            {
                for (int i = 0; i < BinLen.Count; i++)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(Herder, 0, Herder.Length);
                    ms.Write(BinCode[i], 0, BinCode[i].Length);
                    ms.Write(BinData[i], 0, BinData[i].Length);
                    tmpDic.Add(i, ms.ToArray());
                }
            }
            return tmpDic;
        }

    }
}
