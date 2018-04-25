using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MyFractal
{
    public partial class MainWindow : Window
    {
        Fern fern1;
        Tree tree1;
        BaseJulia julia1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*selected item from list
            0 -  Bernsly's fern
            1 - Pifagor's tree
            2 - Julia set
             */
            int item = ((ComboBox)sender).SelectedIndex;
            switch (item)
            {
                case 0:
                    SliderOff();
                    fern1 = new Fern(Width, Height);
                    // Create an Image to display the bitmap.
                    Image image = new Image();
                    //image.Stretch = Stretch.Uniform;
                    image.Stretch = Stretch.None;
                    image.Margin = new Thickness(0);
                    gr1.Children.Add(image);
                    image.Source = fern1.wbitmap;
                    break;
                case 1:
                    //gr1.Children.Clear();
                    SliderOff();
                    tree1 = new Tree(Width, Height);
                    gr1.Children.Add(tree1);
                    tree1.reDraw();
                    break;
                case 2:
                    //gr1.Children.Clear();
                    SliderOn();
                    julia1 = new BaseJulia(Width, Height);
                    this.DataContext = julia1;
                    // Create an Image to display the bitmap.
                    Image image1 = new Image();
                    image1.Height = form.ActualHeight;
                    image1.Width = form.ActualWidth;
                    image1.Stretch = Stretch.None;
                    image1.Margin = new Thickness(0);
                    //Set the Image source.
                    gr1.Children.Add(image1);
                    image1.Source = julia1.wbitmap;
                    //save picture
                    //TODO:OpenDialog
                    var encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)image1.Source));
                    using (FileStream stream = new FileStream("C:\\img!.png", FileMode.Create)) encoder.Save(stream);
                    break;
                case 3:
                    SliderOn();
                    julia1 = new Julia3P(Width, Height);
                    this.DataContext = julia1;
                    // Create an Image to display the bitmap.
                    Image image2 = new Image();
                    image2.Height = form.ActualHeight;
                    image2.Width = form.ActualWidth;
                    image2.Stretch = Stretch.None;
                    image2.Margin = new Thickness(0);
                    //Set the Image source.
                    gr1.Children.Add(image2);
                    image2.Source = julia1.wbitmap;
                    break;
                case 4:
                    SliderOn();
                    julia1 = new Julia4P(Width, Height);
                    this.DataContext = julia1;
                    // Create an Image to display the bitmap.
                    Image image3 = new Image();
                    image3.Height = form.ActualHeight;
                    image3.Width = form.ActualWidth;
                    image3.Stretch = Stretch.None;
                    image3.Margin = new Thickness(0);
                    //Set the Image source.
                    gr1.Children.Add(image3);
                    image3.Source = julia1.wbitmap;
                    break;
                default:
                    break;
            }

        }//ComboBox_SelectionChanged()
        private void SliderOff()
        {
            ZoomSlider.IsEnabled = false;
            MoveXSlider.IsEnabled = false;
            MoveYSlider.IsEnabled = false;
        }//SliderOff()
        private void SliderOn()
        {
            ZoomSlider.IsEnabled = true;
            MoveXSlider.IsEnabled = true;
            MoveYSlider.IsEnabled = true;
        }//SliderOff()

    }
}
/******************   End of Tree.cs File *****************/
