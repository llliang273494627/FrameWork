using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTestNet.FrmDef
{
    public partial class FrmInfo : Form
    {
        public FrmInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 鼠标位置
        /// </summary>
        Point _lastPoint = new Point();

        private void FrmInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _lastPoint = e.Location;
            }
        }

        private void FrmInfo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.Location.X - _lastPoint.X;
                int y = e.Location.Y - _lastPoint.Y;
                Location = Point.Add(new Point(x, y), new Size(Location));
            }
        }
    }
}
