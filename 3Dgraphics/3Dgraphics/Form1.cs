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
        private const int CUBE_SIZE = 10;

        private bool escapePressed = false;
        private List<Keys> pressedKeys = new List<Keys>();

        private Bitmap image;
        private Graphics graphics;
        private Scene scene = new Scene();
        private Point2 cursorCenter;

        public Form1()
        {
            InitializeComponent();

            Camera.SetScreenSize(pictureBox1.Size);

            for (int i=0; i<10; i++)
            {
                for (int j=0; j<1; j++)
                {
                    for (int k=0; k<10; k++)
                    {
                        Cube cube = new Cube(new Point3(CUBE_SIZE * i, CUBE_SIZE * j, 50+ CUBE_SIZE * k), CUBE_SIZE);
                        scene.Objects.Add(cube);
                    }
                }
            }


            image = (Bitmap)Camera.ScreenSize;
            graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            graphics.DrawScene(scene);
            pictureBox1.Image = image;
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            Camera.SetFov(Camera.FieldOfView * Math.Exp(e.Delta / 120.0 / 100)); //magic numbers
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            double speed = 5;
            Vector3 velosity = new Vector3();
            if (pressedKeys.Contains(Keys.W))
                velosity += new Vector3(0, 0, 1);
            if (pressedKeys.Contains(Keys.A))
                velosity += new Vector3(-1, 0, 0);
            if (pressedKeys.Contains(Keys.S))
                velosity += new Vector3(0, 0, -1);
            if (pressedKeys.Contains(Keys.D))
                velosity += new Vector3(1, 0, 0);
            if (pressedKeys.Contains(Keys.Up))
                velosity += new Vector3(0, 1, 0);
            if (pressedKeys.Contains(Keys.Down))
                velosity += new Vector3(0, -1, 0);
            Camera.Move(velosity.Normalized()*speed);

            if (!escapePressed)
            {
                cursorCenter = new Point2(pictureBox1.Width / 2 + Location.X + 8, pictureBox1.Height / 2 + Location.Y + 32);
                Cursor.Hide();
                Camera.Rotate(Cursor.Position - cursorCenter);
                Cursor.Position = cursorCenter;
            }

            graphics.DrawScene(scene);
            pictureBox1.Image = image;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pressedKeys.Contains(e.KeyCode))
                pressedKeys.Add(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(e.KeyCode);

            if (e.KeyCode == Keys.Escape)
                escapePressed = !escapePressed;
        }
    }
}
