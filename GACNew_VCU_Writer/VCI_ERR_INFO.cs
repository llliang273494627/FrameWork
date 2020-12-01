using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GACNew_VCU_Writer
{
    /// <summary>
    /// 4.定义错误信息的数据类型。
    /// </summary>
    public struct VCI_ERR_INFO
    {
        public UInt32 ErrCode;
        public byte Passive_ErrData1;
        public byte Passive_ErrData2;
        public byte Passive_ErrData3;
        public byte ArLost_ErrData;
    }
}
