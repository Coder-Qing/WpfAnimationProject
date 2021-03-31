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

namespace WpfButtonBrush
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        double o = 1.0;//不透明度计数器

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloneVisual(object sender, RoutedEventArgs e)
        {
            VisualBrush vBrush = new VisualBrush(this.realButton);
            Rectangle rect = new Rectangle();
            rect.Width = realButton.ActualWidth;
            rect.Height = realButton.ActualHeight;
            rect.Fill = vBrush;
            rect.Opacity = o;
            o -= 0.2;

            this.stackPanelRight.Children.Add(rect);
        }
    }
}
