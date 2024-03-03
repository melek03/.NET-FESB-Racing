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

namespace prvi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bgChange_click(object sender, RoutedEventArgs e)
        {
            byte red = 255;
            byte green = 187;
            byte blue = 107;

            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(red, green, blue));

            this.Background = brush;

        }
    }
}
