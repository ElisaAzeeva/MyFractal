using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace MyFractal
{
    abstract public class BaseFractal:Control
    {
        //form width
        public static double pictureBoxWidth;
        //for heigth
        public static double pictureBoxHeight;
        //bitmap for drawing fractal
        public WriteableBitmap wbitmap;

        //constructor
        public BaseFractal(double width, double height)
        {
            pictureBoxWidth = 2 * width;
            pictureBoxHeight = 2 * height;
            wbitmap = new WriteableBitmap((int)pictureBoxWidth, (int)pictureBoxHeight, 96, 96, PixelFormats.Bgra32, null);
        }
    }
}
