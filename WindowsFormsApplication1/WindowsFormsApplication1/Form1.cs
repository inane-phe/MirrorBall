using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Graphics g;
        int size = 20;
        int number = 1;//幾個點
        double xx, yy;
        double deg;
        Color color = Color.Red;
        bool line = false;

        public Form1()//建構子
        { 
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 600;
            MessageBox.Show("formWidth=" + this.Width + "\nformHeight=" + this.Height).ToString();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            /*int xBias = 42;
            g = this.CreateGraphics();
            g.Clear(Color.White);
            g.FillEllipse(Brushes.Black, e.X, e.Y, size, size);
            //g.FillEllipse(Brushes.Black, e.X - size / 2, e.Y - size / 2, size, size);//調整座標位置使鼠標指到圓心
            //g.FillEllipse(Brushes.Black, this.ClientSize.Width/2-size/2, this.ClientSize.Height/2-size/2, size, size); Form1中心點
            //g.FillEllipse(Brushes.Black, 0, 0, size, size); Form1原點
            //控制的球
            g.FillEllipse(new SolidBrush(Color.Red), e.X - size / 2, e.Y - size / 2, size, size);
            //對稱Y的球
            g.FillEllipse(new SolidBrush(Color.Green), this.Width/2-xBias+(this.Width/2-(e.X -size/2)), e.Y -size/2, size, size);
            g.FillEllipse(new SolidBrush(Color.Yellow), e.X -size/2,this.Height/2-xBias+(this.Height/2-(e.Y -size/2)) , size, size);
            g.FillEllipse(new SolidBrush(Color.Orange), this.Width / 2 - xBias + (this.Width / 2 - (e.X - size / 2)), this.Height / 2 - xBias + (this.Height / 2 - (e.Y - size / 2)), size, size);
            */
            Point center = new Point(this.Width / 2, this.Height / 2);
            g = this.CreateGraphics();
            g.Clear(Color.White);
            //g.FillEllipse(Brushes.Black, e.X, e.Y, size, size);
            for (int i = 0; i < number ; i++)
            {
                int x = e.X - center.X;
                int y = e.Y - center.Y;
                double temp = (2 * Math.PI / 360) * i * (360 / number);
                int new_x = (int)(Math.Cos(temp) * x - Math.Sin(temp) * y);
                int new_y = (int)(Math.Sin(temp) * x + Math.Cos(temp) * y);
                new_x += center.X;
                new_y += center.Y;
                g.FillEllipse(new SolidBrush(color), new_x - size / 2, new_y - size / 2, size, size);
            }
            if (line == false)
            {
                for (int i=1 ; i<=number ; i++)
                {

                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Add)
            {
                number *= 2;
                if (number == 16)
                {
                    number = 18;
                }//7缺口 9壞掉
            }
            if (e.KeyData == Keys.Subtract && number >1)
            {
                number /= 2;
            }
            if (e.KeyData == Keys.Up)
            {
                size *= 2;
            }
            if (e.KeyData == Keys.Down && size > 1)
            {
                size /= 2;
            }
            if (e.KeyData == Keys.C)
            {
                colorDialog1.ShowDialog();
                color = colorDialog1.Color;
            }
            if (e.KeyData == Keys.C)
            {
                line = !line;
            }
        }
    }
}
