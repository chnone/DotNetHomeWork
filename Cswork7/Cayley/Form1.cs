using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cayley
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics graphics;
        int N;
        double Leng, Per1, Per2, Th1, Th2;
        string Pen;

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Refresh();

            if (graphics == null) 
                this.graphics = this.splitContainer1.Panel2.CreateGraphics();
            
            N = (int)n.Value;
            Th1 = (int)th1.Value * Math.PI / 180;
            Th2 = (int)th2.Value * Math.PI / 180;
            Leng = (double)length.Value;
            Per1 = (double)per1.Value;
            Per2 = (double)per2.Value;
            Pen = pen.Text;
            drawCayleyTree(N, Leng, 290, 450, -Math.PI / 2);
        }

        void drawCayleyTree(int _n, double _leng, double x0, double y0, double _th)
        {
            if (_n == 0)
                return;

            double x1 = x0 + _leng * Math.Cos(_th);
            double y1 = y0 + _leng * Math.Sin(_th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(_n - 1, x1, y1, Per1 * _leng, _th + Th1);
            drawCayleyTree(_n - 1, x1, y1, Per2 * _leng, _th - Th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            switch (Pen)
            {
                case "红色":
                    graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "蓝色":
                    graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
            }
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
