using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MyFractal
{
    class Fern: NonRecursiveFractal
    {
        // Set points interval
        private Point Max = new Point(6, 10);
        private Point Min = new Point(-6,0.1f);
        //changeable params width and height
        private int NewWidth;
        private int NewHeight;

        // probability coef array
        private float[] _probability = new float[4]
        {
            0.01f,
            0.06f,
            0.08f,
            0.85f
        };

        // Coef matrix
        private float[,] _funcCoef = new float[4, 6]
        {
            //a      b       c      d      e  f
            {0, 0, 0, 0.16f, 0, 0}, // 1 func
            {-0.15f, 0.28f, 0.26f, 0.24f, 0, 0.44f}, // 2  func
            {0.2f, -0.26f, 0.23f, 0.22f, 0, 1.6f}, // 3  func
            {0.85f, 0.04f, -0.04f, 0.85f, 0, 1.6f} // 4  func
        };
        //constructor
        public Fern(double PictureBoxWight, double PictureBoxHeight):base(PictureBoxWight, PictureBoxHeight, 200000)
        {
            pictureBoxWidth = PictureBoxWight;
            pictureBoxHeight = PictureBoxHeight;
            Create();
        }//Fern()
        //----------------------------------------------------

        /******************************************************/
        /*                  M E T H O D S                     */
        /******************************************************/
        protected override void OnRender(DrawingContext drawingContext)
        {
            Create();
        }//OnRender()
         //----------------------------------------------------

        public void Create()
        {
            Random rnd = new Random();
            Point temp = new Point(0, 0);
            // variable for current function point
            int func_num = 0;
            // coef calculation
            NewWidth = (int)(pictureBoxWidth / (Max.X - Min.X));
            NewHeight = (int)(pictureBoxHeight / (Max.Y - Min.Y));
            //Parallel.For(1, PointNumber, (i, state) =>
            for (int i = 1; i <= MaxIterations; i++)
            {
                // rand 0 to 1
                var num = rnd.NextDouble();
                // select function for next point
                for (int j = 0; j <= 3; j++)
                {
                    // if rand <= this probability coef 
                    // set  function number
                    num = num - _probability[j];
                    if (num <= 0)
                    {
                        func_num = j;
                        break;
                    }
                }
                // coordinate calculation
                Point point = new Point();
                point.X = _funcCoef[func_num, 0] * temp.X + _funcCoef[func_num, 1] * temp.Y + _funcCoef[func_num, 4];
                point.Y = _funcCoef[func_num, 2] * temp.X + _funcCoef[func_num, 3] * temp.Y + _funcCoef[func_num, 5];
                // save value for next iteration
                temp.X = point.X;
                temp.Y = point.Y;
                // caclulate pixel value
                point.X = (int)(temp.X * NewWidth + pictureBoxWidth / 2);
                point.Y = (int)(temp.Y * NewHeight);
                //RGBA - color for bitmap
                byte blue = 46;
                byte green = 255;
                byte red = 46;
                byte alpha = 255;
                byte[] colorData = { blue, green, red, alpha };
                //rectangle for set pixel
                Int32Rect rect = new Int32Rect((int)point.X, (int)point.Y, 1, 1);
                // divide on 8 because of 8 - one byte 
                int stride = wbitmap.PixelWidth * wbitmap.Format.BitsPerPixel / 8;
                // save pixel to Bitmap
                wbitmap.WritePixels(rect, colorData, stride, 0);
                //Task.Run(() => wbitmap.WritePixels(rect1, colorData, stride1, 0));
                //drawingContext.DrawRectangle(brush, p, rect);
            }//);
        }//Create()
    }
}
/******************   End of Tree.cs File *****************/
