using System;
using System.Windows;
using System.Windows.Media;

namespace MyFractal
{
    class Tree : BaseFractal
    {
        /******************************************************/
        /*              C O N S T A N T S                     */
        /******************************************************/
        //variable for out of recursion  
        private const double a1 = 200;
        //variable for reduce options a  
        private const double a2 = 0.7;
        //start point
        private Point point1 = new Point(300, 450);

        // todo: comments, theory, refactoring
        //pen for writing tree
        public Pen p = new Pen(Brushes.Green, 1);
        //variable for rotation angle
        public double angle = Math.PI / 2; 
        // variable for change rotation angle
        public double ang1 = Math.PI / 4;  
        public double ang2 = Math.PI / 6;
        //----------------------------------------------------

        //tree constructor:
        //wight and height form
        public Tree(double PictureBoxWight, double PictureBoxHeight) : base(PictureBoxWight, PictureBoxHeight)
        {
            pictureBoxWidth = PictureBoxWight;
            pictureBoxHeight = PictureBoxHeight;

        }//Tree()
         //----------------------------------------------------

         /******************************************************/
         /*                  M E T H O D S                     */
         /******************************************************/
         //draw tree
        protected override void OnRender(DrawingContext drawingContext)
        {
            Draw(drawingContext,a1,point1, angle);
        }//OnRender()
        //----------------------------------------------------

        //reDraw tree
        public void reDraw()
        {
            InvalidateVisual();
        }//reDraw()
        //----------------------------------------------------

        //Draw - drawing 
        // a - variable for out of ecursion 
        // point - point for draw line
        // angle - variable for rotation angle
        public void Draw(DrawingContext drawingContext,double a,Point point,double angle)
        {
            if (a > 2)
            {
                //out of ecursion
                a *= a2; 

                //Calculated coordinate for child-vertex
                Point pointNew = new Point
                {
                    X = (float)Math.Round(point.X + a * Math.Cos(angle)),
                    Y = (float)Math.Round(point.Y - a * Math.Sin(angle))
                };

                //draw line between vertex
                drawingContext.DrawLine(p,point,pointNew);
                //InvalidateVisual();
                //get new coordinate
                point.X = pointNew.X;
                point.Y = pointNew.Y;

                //call recursive function for left and rigth children
                Draw(drawingContext,a, point, angle + ang1);
                Draw(drawingContext,a,point, angle - ang2);
            }
        }//Draw()
    }
}
/******************   End of Tree.cs File *****************/
