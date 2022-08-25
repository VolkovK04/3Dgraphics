using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3Dgraphics
{
    public partial class Form1 : Form
    {
        Bitmap img;
        Graphics g;
        Scene scene;
        Point2 CursorCenter;
        public Form1()
        {
            InitializeComponent();

            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            this.MouseWheel += Form1_MouseWheel;

            Timer timer = new Timer()
            {
                Interval = 100,
                Enabled = true
            };
            timer.Tick += Timer_Tick;
            Camera.SetScreenSize(pictureBox1.Size);
            scene = new Scene();
            int cubeSize = 10;
            for (int i=0; i<10; i++)
            {
                for (int j=0; j<1; j++)
                {
                    for (int k=0; k<10; k++)
                    {
                        Cube cube = new Cube(new Point3(cubeSize*i, cubeSize * j, 50+ cubeSize * k), cubeSize);
                        scene.Objects.Add(cube);
                    }
                }
            }


            img = (Bitmap)Camera.ScreenSize;
            g = Graphics.FromImage(img);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawScene(scene);
            pictureBox1.Image = img;
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            Camera.SetFov(Camera.FOV * Math.Exp(e.Delta / 120.0 / 100));

        }

        bool Esc=false;
        private void Timer_Tick(object sender, EventArgs e)
        {
            double speed = 5;
            Vec3 velosity = new Vec3();
            if (keys.Contains(Keys.W))
                velosity += new Vec3(0, 0, 1);
            if (keys.Contains(Keys.A))
                velosity += new Vec3(-1, 0, 0);
            if (keys.Contains(Keys.S))
                velosity += new Vec3(0, 0, -1);
            if (keys.Contains(Keys.D))
                velosity += new Vec3(1, 0, 0);
            if (keys.Contains(Keys.Up))
                velosity += new Vec3(0, 1, 0);
            if (keys.Contains(Keys.Down))
                velosity += new Vec3(0, -1, 0);
            Camera.Move(velosity.Norm()*speed);

            if (!Esc)
            {
                CursorCenter = new Point2(pictureBox1.Width / 2 + Location.X + 8, pictureBox1.Height / 2 + Location.Y + 32);
                Cursor.Hide();
                Camera.Rotate(Cursor.Position - CursorCenter);
                Cursor.Position = CursorCenter;
            }

            g.DrawScene(scene);
            pictureBox1.Image = img;

        }
        List<Keys> keys = new List<Keys>();
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!keys.Contains(e.KeyCode))
                keys.Add(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keys.Remove(e.KeyCode);

            if (e.KeyCode == Keys.Escape)
                Esc = !Esc;
        }
    }
}
