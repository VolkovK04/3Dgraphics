using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
namespace _3Dgraphics
{
    public partial class Form1 : Form
    {
        private const int CUBE_SIZE = 10;

        private float cameraSpeed = 5;
        private bool cursorVisible = true;
        private List<Keys> pressedKeys = new List<Keys>();
        private double mouseSensitive = 1;
        private double wheelSensitive = 1;

        private bool antiAliasing = false;
        private Bitmap image;
        private Graphics graphics;
        private Scene scene = new Scene();
        private Point2 cursorCenter;

        public Form1()
        {
            InitializeComponent();

            for (int i=0; i<10; i++)
            {
                for (int j=0; j<10; j++)
                {
                    for (int k=0; k<10; k++)
                    {
                        Cube cube = new Cube(new Point3(CUBE_SIZE * i, CUBE_SIZE * j, 50+ CUBE_SIZE * k), CUBE_SIZE*5/10);
                        scene.Objects.Add(cube);
                    }
                }
            }

            SetImageSize(pictureBox.Size);

            graphics.DrawScene(scene);
            pictureBox.Image = image;

            cursorVisible = false;
            Cursor.Hide();
        }
        private void SetImageSize(Size size)
        {
            Camera.SetScreenSize(size);
            image = (Bitmap)size;
            graphics = Graphics.FromImage(image);
            if (antiAliasing)
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            Camera.SetFov(Camera.FieldOfView * Math.Exp(e.Delta / 120.0 * wheelSensitive / 100)); 
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

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
            Camera.Move(velosity.Normalized()*cameraSpeed);

            if (!cursorVisible)
            {
                cursorCenter = new Point2(pictureBox.Width / 2 + Location.X + 8, pictureBox.Height / 2 + Location.Y + 32);
                Camera.Rotate((Cursor.Position - cursorCenter) * mouseSensitive);
                Cursor.Position = cursorCenter;
            }

            graphics.DrawScene(scene);
            pictureBox.Image = image;

            stopwatch.Stop();
            label1.Text = $"FPS: {Math.Round(1000.0/stopwatch.ElapsedMilliseconds, 2).ToString()}";

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
            {
                cursorVisible = !cursorVisible;
                if (cursorVisible)
                    Cursor.Show();
                else
                    Cursor.Hide();
            }
        }
        private void PictureBox1_SizeChanged(object sender, EventArgs e)
        {
            SetImageSize(pictureBox.Size);
        }
    }
}
