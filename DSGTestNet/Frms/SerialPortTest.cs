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
        }

        System.Threading.SynchronizationContext context = null;

        private void comboBox1_Click(object sender, EventArgs e)
        {
            var lst = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(lst);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text.Trim();
            serialPort1.Open();
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
            byte[] by = new byte[] 
            {
            0xFF, 0x03, 0xDC, 0x03, 0x04, 0x05, 0x06, 0x07,
            0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15,
            0x16, 0x17, 0x18, 0x19, 0x20, 0x21, 0x22, 0x23,
            0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x30, 0x31,
            0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39,
            0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47,
            0x48, 0x49, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55,
            0x56, 0x57, 0x58, 0x59, 0x60, 0x61, 0x62, 0x63,
            0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x70, 0x71,
            0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79,
            0x80, 0x81, 0x82 // 模式
            };
            serialPort1.Write(by, 0, by.Length);
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serial = sender as SerialPort;
            byte[] data = new byte[serial.BytesToRead];
            serial.Read(data, 0, data.Length);
            var strby = BitConverter.ToString(data);
            context.Send(Object => textBox1.Text = strby, null);
            switch (strby)
            {
                case "FF-03-00-10-00-6E-D0-3D":// 读值
                    button5_Click(null, null);
                    break;
            }
        }
    }
}
