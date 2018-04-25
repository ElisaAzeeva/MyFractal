using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace MyFractal
{
    class Julia3P : BaseJulia
    {
        //constructor
        public Julia3P(double PictureBoxWight, double PictureBoxHeight) : base(PictureBoxWight, PictureBoxHeight)
        {
            width = PictureBoxWight;
            height = PictureBoxHeight;
            Create();
        }//Julia3P()

        /******************************************************/
        /*                  M E T H O D S                     */
        /******************************************************/
        override protected void Polinom()
        {
            //remember prevous iteration
            oldComplex.X = newComplex.X;
            oldComplex.Y = newComplex.Y;
            // calculate real and imaginary part of z in current iteration
            // z = x^3-3xy^2 + i(3x^2y-y^3)
            newComplex.X = Math.Pow(oldComplex.X, 3) - 3 * oldComplex.X * Math.Pow(oldComplex.Y, 2) + complex.X;
            newComplex.Y = 3 * Math.Pow(oldComplex.X, 2) * oldComplex.Y - Math.Pow(oldComplex.Y,3) + complex.Y;
        }//Polinom()

    }
}
/******************   End of Tree.cs File *****************/
