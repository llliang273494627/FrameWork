using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.DGComm
{
    public struct PT_DioSetPortMode
    {
        public int Port;
        public int dir;
    }

    public struct PT_DioGetCurrentDOByte
    {
        public int Port;
        public long value;
    }

    public struct DEVFEATURES
    {
        public int usDIOPort;
    }

    public struct PT_DioWritePortByte
    {
        public int Port;
        public int Mask;
        public int state;
    }


}
