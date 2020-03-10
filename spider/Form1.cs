using System;
using System.Drawing;
using System.Windows.Forms;

namespace spider
{
    public partial class Form1 : Form
    {
        public Graphics g; //Графика
        public Bitmap map; //Битмап
        public Color Clr; //Переменная цвета
        private SolidBrush br; //Кисть
        public const int it = 50, max = 16; //Переменнные для выхода из основного цикла
        public int n;// Количество итераций
        public int xc, yc; //Координаты центра
        public PointF z, t, c, t1;  //Комплексные переменные

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Координаты центра
            xc = pictureBox1.Width / 2;
            yc = pictureBox1.Height / 2;

            map = new Bitmap(pictureBox1.Width, pictureBox1.Height);//Подключаем Битмап
            g = Graphics.FromImage(map); //Подключаем графику
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//Включаем сглаживание


            for (int y = -yc; y <= yc; y++)
            {
                for (int x = -xc; x <= xc; x++)
                {
                    //Устанавливаем начальные значения параметров
                    z.X = x * 0.01f;
                    z.Y = y * 0.01f;
                    c.X = z.X;
                    c.Y = z.Y;
                    n = 0;

                    //Основной цикл
                    while (((z.X * z.X + z.Y * z.Y) < max) && (n < it))
                    {
                        t.X = z.X;
                        t.Y = z.Y;
                        t1.X = c.X;
                        t1.Y = c.Y;
                        n++;
                        z.X = (t.X * t.X) - (t.Y * t.Y) + c.X;
                        z.Y = 2 * t.X * t.Y + c.Y;
                        c.X = t1.X / 2 + z.X;
                        c.Y = t1.Y / 2 + z.Y;
                        n++;
                    }

                    //Выбор цвета и отрисовка
                    if (n < it)
                    {
                        int colour = 30 * n % 255;
                        Clr = Color.FromArgb(colour, 0, 0);
                        br = new SolidBrush(Clr);
                        g.FillRectangle(br, xc + x, yc + y, 1, 1);
                        pictureBox1.BackgroundImage = map;
                    }
                }
            }
        }
    }
}
