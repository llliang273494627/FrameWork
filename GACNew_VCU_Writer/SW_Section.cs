using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GACNew_VCU_Writer
{
    public class SW_Section
    {
        public int Index { set; get; }
        public int Start_Address { set; get; }
        public int Length { set; get; }
        public int End_Address { set; get; }
        public byte[] InFileInfo { set; get; }

        public SW_Section(int index, byte[] head)
        {
            Index = index;
            InFileInfo = head;

            byte[] address = new byte[4];
            address[0] = head[0];
            address[1] = head[1];
            address[2] = head[2];
            address[3] = head[3];

            byte[] len = new byte[4];
            len[0] = head[4];
            len[1] = head[5];
            len[2] = head[6];
            len[3] = head[7];

            Start_Address = IntToBitConverter(address);
            Length = IntToBitConverter(len);
            End_Address = Start_Address + Length - 1;
        }

        public byte[] IntToBitConverter(int num)
        {
            byte[] bytes = BitConverter.GetBytes(num);
            return bytes;
        }

        public int IntToBitConverter(byte[] bytes)
        {
            int temp = BitConverter.ToInt32(bytes, 0);
            return temp;
        }

    }


}
