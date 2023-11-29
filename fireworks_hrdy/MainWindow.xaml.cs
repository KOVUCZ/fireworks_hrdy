using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace fireworks_hrdy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<rocket> rockets = new List<rocket>();
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 33);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void DrawRockets()
        {
            CanvaSky.Children.Clear();
            foreach(var rocket in rockets)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Width = 10;
                ellipse.Height = 10;
                ellipse.Fill = Brushes.White;
                Canvas.SetLeft(ellipse, rocket.Location.X);
                Canvas.SetTop(ellipse, rocket.Location.Y);
                CanvaSky.Children.Add(ellipse);
            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            foreach (var rocket in rockets) 
            {
                rocket.Move();
            }
        }

        private void CanvaSky_MouseDown(object sender, MouseButtonEventArgs e)
        {
            rocket rocket = new rocket(new Point(100, 200), new Vector(2, -10), 2);
            rocket.Exploded += Rocket_Exploded;
            rockets.Add(rocket);
        }

        private void Rocket_Exploded(List<rocket> obj)
        {
            rockets.AddRange(obj);
        }
    }
}
