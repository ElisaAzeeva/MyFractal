using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFractal
{
    class Julia4P:BaseJulia
    {
        //constructor
        public Julia4P(double PictureBoxWight, double PictureBoxHeight) : base(PictureBoxWight, PictureBoxHeight)
        {
            width = PictureBoxWight;
            height = PictureBoxHeight;
            Create();
        }//Julia4P()

        /******************************************************/
        /*                  M E T H O D S                     */
        /******************************************************/
        override protected void Polinom()
        {
            //remember prevous iteration
            oldComplex.X = newComplex.X;
            oldComplex.Y = newComplex.Y;
            // calculate real and imaginary part of z in current iteration
            // z = x^4-6 x^2 y^2 + + i(4x^3 y - 4x y^3)
            newComplex.X = Math.Pow(oldComplex.X, 4) - 6 * Math.Pow(oldComplex.X, 2) * Math.Pow(oldComplex.Y, 2) + Math.Pow(oldComplex.Y, 4) + complex.X;
            newComplex.Y = 4 * Math.Pow(oldComplex.X, 3) * oldComplex.Y - 4 * oldComplex.X  * Math.Pow(oldComplex.Y, 3) + complex.Y;
        }//Polinom()
    }
}
/******************   End of Tree.cs File *****************/
