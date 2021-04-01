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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAnimation.UserControls
{
    /// <summary>
    /// 简单线性动画.xaml 的交互逻辑
    /// </summary>
    public partial class 简单线性动画 : UserControl
    {
        public 简单线性动画()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TranslateTransform的X、Y属性均为Double类型，选用DoubleAnimation来使之产生变化
            //声明dax和daY两个DoubleAnimation变量并分别为之创建引用实例
            DoubleAnimation daX = new DoubleAnimation();
            DoubleAnimation daY = new DoubleAnimation();

            //指定起点
            daX.From = 0D;
            daY.From = 0D;

            //指定终点
            Random r = new Random();
            daX.To = r.NextDouble() * 300;
            daY.To = r.NextDouble() * 300;

            //指定时长
            Duration duration = new Duration(TimeSpan.FromMilliseconds(300));
            daX.Duration = duration;
            daY.Duration = duration;

            // 动画的主体是TranslateTransform 变形，而非Button 
            //调用BeginAnimation方法，让daX、daY分别作用在TranslateTransform的XProperty、YProperty依赖属性上
            this.tt.BeginAnimation(TranslateTransform.XProperty, daX);
            this.tt.BeginAnimation(TranslateTransform.YProperty, daY);
        }
    }
}
