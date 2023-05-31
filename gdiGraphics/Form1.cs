using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace gdiGraphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DrawCoordinateAxes();
            comboBox1.Items.Add("y = x*x");
            comboBox1.Items.Add("y = sin(x)");
            comboBox1.Items.Add("y = cos(x)");
            comboBox1.Items.Add("y = x");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 3f);
            DrawCoordinateAxes();
            Point[] points = new Point[1000];
            if (comboBox1.SelectedIndex == 1)
            {
                g.Clear(Color.White);
                DrawCoordinateAxes();
                for (int i = 0; i < points.Length; i++)
                {
                    points[i] = new Point(i, (int)(Math.Sin((double)i / 10) * 100 + 200));
                }
                g.DrawLines(pen, points);
                g.Dispose();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                g.Clear(Color.White);
                DrawCoordinateAxes();
                for (int i = 0; i < points.Length; i++)
                {
                    points[i] = new Point(i, (int)(Math.Cos((double)i / 10) * 100 + 200));
                }
                g.DrawLines(pen, points);
                g.Dispose();
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                g.Clear(Color.White);
                DrawCoordinateAxes();
                float x;
                float y;
                for (float start = -50; start <= 50; start += 0.1F)
                {
                    y = 250 - start * start;
                    x = 460 + start * 10;
                    if (start < 0) g.DrawLine(pen, x, y, x - 5, y);
                    else g.DrawLine(pen, x, y, x + 5, y);
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                g.Clear(Color.White);
                DrawCoordinateAxes();
                float x;
                float y;
                for (float start = 0; start <= 50; start += 0.1F)
                {
                    y = 352;
                    x = 479 + start * 10;
                    g.DrawLine(pen, 0, 500, 900, 0);
                }
            }
        }
        private void DrawCoordinateAxes()
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 0.3f);
            graphics.DrawLine(pen, 0, 250, 900, 250);
            graphics.DrawLine(pen, 460, 470, 460, 0);
            pen.Dispose();
            graphics.Dispose();
        }
    }
}