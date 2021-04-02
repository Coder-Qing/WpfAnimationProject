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
    /// 路径动画.xaml 的交互逻辑
    /// </summary>
    public partial class 路径动画 : UserControl
    {
        public 路径动画()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //从XAML代码中获取移动路径数据
            PathGeometry pg = this.LayoutRoot.FindResource("movingPath") as PathGeometry;
            Duration duration = new Duration(TimeSpan.FromMilliseconds(600));

            //创建动画
            DoubleAnimationUsingPath dapX = new DoubleAnimationUsingPath();
            dapX.PathGeometry = pg;
            dapX.Source = PathAnimationSource.X;
            dapX.Duration = duration;
            DoubleAnimationUsingPath dapY = new DoubleAnimationUsingPath();
            dapY.PathGeometry = pg;
            dapY.Source = PathAnimationSource.Y;
            dapY.Duration = duration;

            //自动返回、永远循环
            dapX.AutoReverse = true;
            dapX.RepeatBehavior = RepeatBehavior.Forever;
            dapY.AutoReverse = true;
            dapY.RepeatBehavior = RepeatBehavior.Forever;

            // 执行动画
            this.tt.BeginAnimation(TranslateTransform.XProperty, dapX);
            this.tt.BeginAnimation(TranslateTransform.YProperty, dapY);
        }
    }
}
