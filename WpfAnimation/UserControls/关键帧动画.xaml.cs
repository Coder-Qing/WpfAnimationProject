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
    /// 关键帧动画.xaml 的交互逻辑
    /// </summary>
    public partial class 关键帧动画 : UserControl
    {
        public 关键帧动画()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //创建两个DoubleAnimationUsingKeyFrames实例
            //一个控制TranslateTransform的X属性,另一个控制Translate Transform的Y属性
            //每个DoubleAnimationUsingKeyFrames各拥有三个关键帧用于指明X或Y在三个时间点（两个拐点和终点）应该达到什么样的值
            DoubleAnimationUsingKeyFrames dakX = new DoubleAnimationUsingKeyFrames();
            DoubleAnimationUsingKeyFrames dakY = new DoubleAnimationUsingKeyFrames();


            // 设置动画总时长
            dakX.Duration = new Duration(TimeSpan.FromMilliseconds(900));
            dakY.Duration = new Duration(TimeSpan.FromMilliseconds(900));

            //创建、添加关键帧
            LinearDoubleKeyFrame x_kf_1 = new LinearDoubleKeyFrame();
            LinearDoubleKeyFrame x_kf_2 = new LinearDoubleKeyFrame();
            LinearDoubleKeyFrame x_kf_3 = new LinearDoubleKeyFrame();

            #region 时间点 设置帧的时间方法1
            //最简单的关键帧LinearDoubleKeyFrame，这种关键帧的特点就是只需你给定时间点（KeyTime属性）和到达时间点时目标属性的值（Value属性）动画就会让目标属性值在两个关键帧之间匀速变化。
            x_kf_1.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(300));
            x_kf_1.Value = 200;
            x_kf_2.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(600));
            x_kf_2.Value = 0;
            x_kf_3.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(900));
            x_kf_3.Value = 200;
            #endregion


            #region 百分比相对时间点 设置帧的时间方法2
            //使用KeyTime.FromPercent静态方法则可以获得以百分比计算的相对时间点，程序将整个关键帧动画的时长（Duration）视为100%。
            //无论把dakX的Duration改为多少，这三个关键帧都会将整个动画分割为均等的三段
            //x_kf_1.KeyTime = KeyTime.FromPercent(0.33);
            //x_kf_1.Value = 200;
            //x_kf_2.KeyTime = KeyTime.FromPercent(0.66);
            //x_kf_2.Value = 0;
            //x_kf_3.KeyTime = KeyTime.FromPercent(1);
            //x_kf_3.Value = 200;
            #endregion

            dakX.KeyFrames.Add(x_kf_1);
            dakX.KeyFrames.Add(x_kf_2);
            dakX.KeyFrames.Add(x_kf_3);

            LinearDoubleKeyFrame y_kf_1 = new LinearDoubleKeyFrame();
            LinearDoubleKeyFrame y_kf_2 = new LinearDoubleKeyFrame();
            LinearDoubleKeyFrame y_kf_3 = new LinearDoubleKeyFrame();
            y_kf_1.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(300));
            y_kf_1.Value = 0;
            y_kf_2.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(600));
            y_kf_2.Value = 180;
            y_kf_3.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(900));
            y_kf_3.Value = 180;

            dakY.KeyFrames.Add(y_kf_1);
            dakY.KeyFrames.Add(y_kf_2);
            dakY.KeyFrames.Add(y_kf_3);

            //执行动画
            this.tt.BeginAnimation(TranslateTransform.XProperty, dakX);
            this.tt.BeginAnimation(TranslateTransform.YProperty, dakY);
        }
    }
}
