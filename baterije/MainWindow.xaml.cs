using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace baterije
{
    public partial class MainWindow : Window
    {
        private readonly Random random = new Random();
        private DispatcherTimer timer;

        private readonly SolidColorBrush[] temp_colors = {
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006400")),    //20 degrees
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#228B22")),    //25 degrees
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF00")),    //30 degrees
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD700")),    //35 degrees
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA500")),    //40 degrees
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0000")),    //45 degrees
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8B0000"))     //50 degrees
        };

        public MainWindow()
        {
            InitializeComponent();

            //setting each battery cell to the base temperature of 20°C
            foreach (var grid in new[] {first, second, third, fourth, fifth, sixth })
            {
                foreach(Rectangle rectangle in grid.Children)
                {
                    rectangle.Fill = temp_colors[0];
                }
            }

            //description of what each color represents
            twenty.Fill = temp_colors[0];
            twfive.Fill = temp_colors[1];
            thirty.Fill = temp_colors[2];
            thfive.Fill = temp_colors[3];
            forty.Fill = temp_colors[4];
            fofive.Fill = temp_colors[5];
            fifty.Fill = temp_colors[6];

        }

        private void changeTemp()
        {
            foreach (var grid in new[] { first, second, third, fourth, fifth, sixth })
            {
                foreach (Rectangle rectangle in grid.Children)
                {
                    rectangle.Fill = temp_colors[random.Next(temp_colors.Length)];
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            changeTemp();
        }

        private void start_click(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(0.5); //color change each half a second 
            timer.Start();

        }

        private void stop_click(object sender, RoutedEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
            }
        }

        
    }
}
