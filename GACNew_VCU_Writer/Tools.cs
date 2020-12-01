using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GACNew_VCU_Writer
{
    public class Tools
    {
        public static void WriteToMyLog(string sql, string message)
        {
            try
            {
                message = message.Replace("\r", "");
                message = message.Replace("\n", "");
                string value = "日志标题：" + sql + System.Environment.NewLine;
                value += "日志信息:" + message + System.Environment.NewLine;
                string dir = System.Environment.CurrentDirectory;
                dir = dir + "\\" + "DBLog";
                if (System.IO.Directory.Exists(dir) == false)
                    System.IO.Directory.CreateDirectory(dir);
                string fileName = DateTime.Now.ToString("yyyy-MM-dd") + "_log.txt";
                fileName = dir + "\\" + fileName;
                if (File.Exists(fileName) == false)
                {
                    File.Create(fileName).Close();
                }

                value += "日志时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + System.Environment.NewLine;
                value += "---------------------------------------------------------------------------" + System.Environment.NewLine;
                string info = value;

                FileInfo fileInfo = new FileInfo(fileName);
                double FileLength = fileInfo.Length;//读取文件大小（字节数）
                double FileLenKB = 0.0;
                FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.Write);
                StreamWriter sw1 = new StreamWriter(fs);
                //获取文件的大小，文件过大则删除之前的内容 
                if (FileLength > 1024)//将文件大小转换为KB
                {
                    FileLenKB = FileLength / 1024;
                    if (FileLenKB > 5000)
                    {
                        sw1.Close();
                        fs.Close();
                        fs = new FileStream(fileName, FileMode.Truncate, FileAccess.ReadWrite);//清空文件内容
                        fs.Close();
                        fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);//重新打开文件
                        sw1 = new StreamWriter(fs);
                    }
                }
                //获取文件的大小，文件过大则删除之前的内容
                sw1.Write(info + "\r\n");//开始写入值
                sw1.Close();
                fs.Close();
            }
            catch (Exception ex)
            {

            }

        }


        public static int GetQingLiValue(byte[] bin)
        {
            int index = 0;
            byte[] searchByte = new byte[4];
            searchByte[0] = 239;
            searchByte[1] = 190;
            searchByte[2] = 173;
            searchByte[3] = 222;
            for (int i = 0; i < bin.Length; i++)
            {
                if (bin[i] == searchByte[0] && bin[i + 1] == searchByte[1] && bin[i + 2] == searchByte[2] && bin[i + 3] == searchByte[3])
                {
                    index = i;
                    break;
                }
            }

            byte[] head = new byte[index];
            for (int i = 0; i < head.Length; i++)
            {
                head[i] = bin[i];
            }
            int start = 0;
            int section = 1;
            List<SW_Section> section_list = new List<SW_Section>();
            List<byte> list = new List<byte>();
            for (int i = 33; i < head.Length; i++)
            {
                if (start != 8)
                {
                    list.Add(head[i]);
                    start++;
                }
                else
                {
                    //8个字节已经满了
                    start = 0;
                    section_list.Add(new SW_Section(section, list.ToArray()));
                    section++;
                    //这一个满了，下个section
                    list.Clear();
                    list.Add(head[i]);
                    start++;
                }
                //最后一组
                if (i == head.Length - 1)
                {
                    section_list.Add(new SW_Section(section, list.ToArray()));
                }
            }
            string str = "28";
            if (section_list.Count > 1)
            {
                //【最后一个文件的地址+长度】-首地址+1;
                SW_Section first_sw = section_list[0];
                SW_Section last_sw = section_list[section_list.Count - 1];
                int value = last_sw.End_Address - first_sw.Start_Address + 1;
                //MessageBox.Show(value.ToString("X2").Substring(0, 2));
                str = value.ToString("X2").Substring(0, 2);
            }
            return int.Parse(str, System.Globalization.NumberStyles.HexNumber);
        }



    }
}
