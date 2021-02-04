using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.Comm
{
    public class CVT520 : DSG_Group.CVT520
    {
        public void SerialPortOnline(string port, string setting)
        {
            m_OpenPort = true;
            CommPort = port;
            ComSettings = setting;
            if (m_Comm == null)
                m_Comm = new System.IO.Ports.SerialPort();
            modPublic.SerialPortOnline(m_Comm, port, setting);
        }
    }
}
