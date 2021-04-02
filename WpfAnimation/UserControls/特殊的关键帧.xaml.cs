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
    /// 特殊的关键帧.xaml 的交互逻辑
    /// </summary>
    public partial class 特殊的关键帧 : UserControl
    {
        public 特殊的关键帧()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //创建动画
            DoubleAnimationUsingKeyFrames dakX = new DoubleAnimationUsingKeyFrames();
            dakX.Duration = new Duration(TimeSpan.FromMilliseconds(1000));

            //线性变化关键帧，目标属性值的变化是直线性的、均匀的，即变化速率不变。
            LinearDoubleKeyFrame lk = new LinearDoubleKeyFrame();
            lk.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200));
            lk.Value = 200;

            //不连续变化关键帧，目标属性值的变化是跳跃性的、跃迁的。
            DiscreteDoubleKeyFrame dk = new DiscreteDoubleKeyFrame();
            dk.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200));
            dk.Value = 200;

            //缓冲式变化关键帧，目标属性值以某种缓冲形式变化。
            EasingDoubleKeyFrame ek = new EasingDoubleKeyFrame();
            ek.EasingFunction = new CubicEase() {EasingMode = EasingMode.EaseIn };
            ek.EasingFunction = new BounceEase() {EasingMode = EasingMode.EaseIn,Bounces = 3,Bounciness = 5 };



            // 创建、添加关键帧
            //样条函数式变化关键帧，目标属性值的变化速率是一条贝塞尔曲线。
            //两个控制点ControlPointl和ControlPoint2，意思是贝塞尔曲线从起点出发先向ControlPoint1的方向前进、再向ControlPoint2的方向前进、最后到达终点，形成一条平滑的曲线。
            SplineDoubleKeyFrame kf = new SplineDoubleKeyFrame();
            kf.KeyTime = KeyTime.FromPercent(1);
            kf.Value = 400;
            KeySpline ks = new KeySpline();
            ks.ControlPoint1 = new Point(0, 1);
            ks.ControlPoint2 = new Point(1, 0);
            kf.KeySpline = ks;
            dakX.KeyFrames.Add(kf);

            //执行动画
            this.tt.BeginAnimation(TranslateTransform.XProperty, dakX);
        }
    }
}
