using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace crossing_squares
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        string stage = "menu";
        bool mousedown = false;
        public MainWindow()
        {
            InitializeComponent();
            Menu();
        }

        private void level1_Click(object sender, RoutedEventArgs e)
        {
            stage = "level1";
            Finish.Visibility = Visibility.Visible;
            level1.Visibility = Visibility.Hidden;
            level2.Visibility = Visibility.Hidden;
            Cube.Visibility = Visibility.Visible;
            



        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Canvas.SetTop(Cube, Canvas.GetTop(Cube) - 10);
            }
            if (IsIntersects())
            {
                stage = "menu";
                Menu();
                Canvas.SetTop(Cube, Canvas.GetTop(Cube) + 620);
            }
            if (IsIntersects2())
            {
                stage = "menu";
                Menu();
                Canvas.SetTop(Cube, Canvas.GetTop(Cube) + 620);
            }
                
        }
        private bool IsIntersects()
        {
            Rect cube = new Rect();
            cube.Size = Cube.RenderSize;
            cube.Location = new Point(
                Canvas.GetLeft(Cube),
                Canvas.GetTop(Cube)
            );

            var point = Cnv.TranslatePoint(new Point(0, 0), Finish);

            Rect finish = new Rect();
            finish.Size = Finish.RenderSize;
            finish.Location = new Point(
                -point.X,
                -point.Y
            );

            return cube.IntersectsWith(finish);
        }
        private bool IsIntersects2()
        {
            Rect cube = new Rect();
            cube.Size = Cube.RenderSize;
            cube.Location = new Point(
                Canvas.GetLeft(Cube),
                Canvas.GetTop(Cube)
            );

            var point = Cnv.TranslatePoint(new Point(0, 0), Red);

            Rect red = new Rect();
            red.Size = Red.RenderSize;
            red.Location = new Point(
                -point.X,
                -point.Y
            );

            return cube.IntersectsWith(red);
        }



        private void level2_Click(object sender, RoutedEventArgs e)
        {
            stage = "level2";
            Finish.Visibility = Visibility.Visible;
            level1.Visibility = Visibility.Hidden;
            level2.Visibility = Visibility.Hidden;
            Cube.Visibility = Visibility.Visible;
            Red.Visibility = Visibility.Visible;
            

        }
        private void Menu()
        {
            if (stage == "menu")
                {
                Finish.Visibility = Visibility.Hidden;
                Cube.Visibility = Visibility.Hidden;
                level1.Visibility = Visibility.Visible;
                level2.Visibility = Visibility.Visible;
                Red.Visibility = Visibility.Hidden;
                
            }
        }
    }
}