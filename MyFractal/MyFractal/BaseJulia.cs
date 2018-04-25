using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyFractal
{
    class BaseJulia : NonRecursiveFractal//, INotifyPropertyChanged
    {
        /******************************************************/
        /*              C O N S T A N T S                     */
        /******************************************************/
        //circle radius for way out from loop
        protected const double radius = 2;
        //variable for width, height
        public static double width;
        public static double height;
        //select number defining the form of a Julia set
        protected Point complex = new Point(-0.70176, -0.3842);
        //private Point complex = new Point(-0.74543, 0.11301);
        //select zoom and move variable
        protected double zoom = 1;
        protected Point move = new Point(0, 0);
        protected Point newComplex = new Point();
        protected Point oldComplex = new Point();
        //#region INotifyPropertyChanged implementation
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void Notify(string propertyName)
        //{
        //    if (this.PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName+"Changed"));

        //        //DependencyProperty.Register("Transforms", typeof(ObservableCollection<FigureTransform>),
        //        //typeof(CrystalControl), new PropertyMetadata(null, TransformsPropertyChanged))
        //    }
        //}
        //#endregion INotifyPropertyChanged implementation
        //zoom property
        public double Zoom
        {
            get { return zoom; }
            set
            {
                // Do nothing unless the new value is different..
                if (value != zoom)
                {
                    // Set the value
                    zoom = value;
                    Create();
                    // This next line is the only change within this property.
                    // Notify anyone who cares about this.
                    //Notify("Zoom");
                }
            }
        }//Zoom
         //----------------------------------------------------

        //moveX property
        public double MoveX
        {
            get { return move.X; }
            set
            {
                if (value != move.X)
                {
                    // Set the value
                    move.X = value;
                    Create();
                }
            }
        }
        //----------------------------------------------------

        //moveY property
        public double MoveY
        {
            get { return move.Y; }
            set
            {
                if (value != move.Y)
                {
                    // Set the value
                    move.Y = value;
                    Create();
                }
            }
        }
        //----------------------------------------------------
        // TODO:need slider change complex constant
        //constructor
        public BaseJulia(double PictureBoxWight, double PictureBoxHeight) : base(PictureBoxWight, PictureBoxHeight, 300)
        {
            width = PictureBoxWight;
            height = PictureBoxHeight;
            Create();
        }//Julia()
         //----------------------------------------------------

        /******************************************************/
        /*                  M E T H O D S                     */
        /******************************************************/
        public void Create()//DrawingContext drawingContext)
        {
            // every iteration, calculate znew = zold² + С
            //every pixel
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    //calculate real and imaginary part of z
                    //combined with zoom, move, width and height
                    newComplex.X = 1.5 * (x - width / 2) / (0.5 * zoom * width) + move.X;
                    newComplex.Y = (y - height / 2) / (0.5 * zoom * height) + move.Y;
                    //i - count of iteration 
                    int i;
                    for (i = 0; i < MaxIterations; i++)
                    {
                        // virtual method z^2 
                        Polinom();
                        // if point isn't belong to the circle wiyh radius = 2 - break
                        if ((newComplex.X * newComplex.X + newComplex.Y * newComplex.Y) > 2 * radius)
                            break;
                    }//for i
                     //RGBA - color for bitmap
                     //byte blue = (byte)((i * 9) % 255);
                     //byte green = 0;
                     //byte red = (byte)((i * 9) % 255);
                     //byte alpha = 255;
                    byte blue = 0;
                    byte green = 0;
                    byte red = (byte)((i * 9) % 255);
                    byte alpha = 255;
                    byte[] colorData = { blue, green, red, alpha };
                    //rectangle for set pixel
                    Int32Rect rect = new Int32Rect(x, y, 1, 1);
                    // divide on 8 because of 8 - one byte 
                    int stride = wbitmap.PixelWidth * wbitmap.Format.BitsPerPixel / 8;
                    // save pixel to Bitmap
                    wbitmap.WritePixels(rect, colorData, stride, 0);
                }//for y
        }//Create()
        virtual protected void Polinom()
        {
            //remember prevous iteration
            oldComplex.X = newComplex.X;
            oldComplex.Y = newComplex.Y;
            // calculate real and imaginary part of z in current iteration
            newComplex.X = oldComplex.X * oldComplex.X - oldComplex.Y * oldComplex.Y + complex.X;
            newComplex.Y = 2 * oldComplex.X * oldComplex.Y + complex.Y;
        }//Polinom()
    }
}
/******************   End of Tree.cs File *****************/
