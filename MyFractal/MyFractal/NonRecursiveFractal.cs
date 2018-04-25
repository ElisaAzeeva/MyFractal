using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFractal
{
    abstract public class NonRecursiveFractal : BaseFractal
    {
        //max count of iterations
        static protected int MaxIterations;
        //constructor
        public NonRecursiveFractal(double PictureBoxWight, double PictureBoxHeight, int maxIterations) : base(PictureBoxWight, PictureBoxHeight)
        {
            // width, height form and iteration count
            pictureBoxWidth = PictureBoxWight;
            pictureBoxHeight = PictureBoxHeight;
            MaxIterations = maxIterations;
        }
    }
}
/******************   End of Tree.cs File *****************/
