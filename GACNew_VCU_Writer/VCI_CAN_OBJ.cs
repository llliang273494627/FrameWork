using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GACNew_VCU_Writer
{
    /// <summary>
    /// 2.定义CAN信息帧的数据类型。
    /// </summary>
    unsafe public struct VCI_CAN_OBJ
    {
        public uint ID;
        public uint TimeStamp;
        public byte TimeFlag;
        public byte SendType;
        public byte RemoteFlag;//是否是远程帧
        public byte ExternFlag;//是否是扩展帧
        public byte DataLen;
        public fixed byte Data[8];
        public fixed byte Reserved[3];
    }
}
