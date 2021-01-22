using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTestNet.Frms
{
    public partial class SerialPortTest : Form
    {
        public SerialPortTest()
        {
            InitializeComponent();
            context = System.Threading.SynchronizationContext.Current;
            modPublic = new Comm.ModPublic();
        }

        System.Threading.SynchronizationContext context = null;
        Comm.ModPublic modPublic = null;

        private void comboBox1_Click(object sender, EventArgs e)
        {
            var lst = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(lst);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = comboBox1.Text.Trim().Replace("COM", string.Empty);
            modPublic.OpenSerialPort(serialPort1, name, textBox3.Text.Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] by = new byte[] { 0xFF, 0x05, 0x00, 0x01, 0xFF, 0x00, 0xC8, 0x24 };
            serialPort1.Write(by, 0, by.Length);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] by = new byte[] { 0xFF, 0x05, 0x00, 0x02, 0xFF, 0x00, 0x38, 0x24 };
            serialPort1.Write(by, 0, by.Length);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] start = new byte[11] { 0xFF, 0x03, 0xDC, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10 };
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            System.IO.BinaryWriter write = new System.IO.BinaryWriter(stream);
            write.Write(start, 0, 11);
            write.Write(230000); // 15 压力值
            write.Write((short)0);
            write.Write((short)1000); // 19 温度
            write.Write((short)0);
            write.Write((short)10); // 23 加速度
            write.Write(101010);  // 27 id
            write.Write(0);  // 31 
            write.Write(new byte[] { 0x4F, 0x4B }); // 32 电池
            write.Write(new byte[52]); // 83
            byte[] by = stream.ToArray();
            serialPort1.Write(by, 0, by.Length);
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serial = sender as SerialPort;
            byte[] data = new byte[serial.BytesToRead];
            serial.Read(data, 0, data.Length);
            var strby = BitConverter.ToString(data);
            switch (strby)
            {
                case "FF-05-00-02-FF-00-38-24":
                    strby = "重置开始测试：" + strby;
                    context.Send(Object => listBox1.Items.Clear(), null);
                    button4_Click(null, null);
                    break;
                case "FF-05-00-01-FF-00-C8-24":
                    strby = "开始测试：" + strby;
                    button3_Click(null, null);
                    break;
                case "FF-03-00-10-00-6E-D0-3D":// 读值
                    strby = "读取值：" + strby;
                    button5_Click(null, null);
                    break;
            }
            context.Send(Object => listBox1.Items.Add(strby), null);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var con = sender as ListBox;
            if (con != null)
            {
                textBox1.Text = con.Text;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine(textBox2.Text.Trim());
        }
    }
}
