using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTestNet.Frms
{
    public partial class FrmInfo : Form
    {
        public FrmInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 鼠标按下左键是的坐标点
        /// </summary>
        Point _mousePoint = new Point();

        private void FrmInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _mousePoint = e.Location;
        }

        private void FrmInfo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X - _mousePoint.X;
                int y = e.Y - _mousePoint.Y;
                Location = Point.Add(Location, new Size(x, y));
            }
        }
    }
}
