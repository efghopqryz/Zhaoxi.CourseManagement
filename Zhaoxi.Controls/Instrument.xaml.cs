using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Zhaoxi.Controls
{
    /// <summary>
    /// Instrument.xaml 的互動邏輯
    /// </summary>
    public partial class Instrument : UserControl
    {
        //依賴屬性、依賴對象
        public int Value
        {
            get { return (int)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }
        //PropertyChangedCallback：是委託
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(Instrument), new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("MyProperty", typeof(int), typeof(Instrument), new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(Instrument), new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        public int Interval
        {
            get { return (int)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
        }

        public static readonly DependencyProperty IntervalProperty = DependencyProperty.Register("Interval", typeof(int), typeof(Instrument), new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        public Brush PlateBackground
        {
            get { return (Brush)GetValue(PlateBackgroundProperty); }
            set { SetValue(PlateBackgroundProperty, value); }
        }

        public static readonly DependencyProperty PlateBackgroundProperty =
            DependencyProperty.Register("PlateBackground", typeof(Brush), typeof(Instrument), new PropertyMetadata(default(Brush)));

        public int ScaleTextSize
        {
            get { return (int)GetValue(ScaleTextSizeProperty); }
            set { SetValue(ScaleTextSizeProperty, value); }
        }

        public Brush ScaleBrush
        {
            get { return (Brush)GetValue(ScaleBrushProperty); }
            set { SetValue(ScaleBrushProperty, value); }
        }

        public static readonly DependencyProperty ScaleBrushProperty =
            DependencyProperty.Register("ScaleBrush", typeof(Brush), typeof(Instrument), new PropertyMetadata(default(Brush),new PropertyChangedCallback(OnPropertyChanged)));

        public static readonly DependencyProperty ScaleTextSizeProperty =
            DependencyProperty.Register("ScaleTextSize", typeof(int), typeof(Instrument), new PropertyMetadata(default(int),new PropertyChangedCallback(OnPropertyChanged)));

        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Instrument).Refresh();
        }

        public Instrument()
        {
            InitializeComponent();

            this.SizeChanged += Instrument_SizeChanged1;
        }

        private void Instrument_SizeChanged1(object sender, SizeChangedEventArgs e)
        {
            double minSize = Math.Min(this.RenderSize.Width, this.RenderSize.Height);
            this.backEllipse.Width = minSize;
            this.backEllipse.Height = minSize;
        }

        private void Refresh()
        {
            double radius = this.backEllipse.Width / 2;
            if (double.IsNaN(radius)) return;

            this.mainCanvas.Children.Clear();

            //double min = 0, max = 100;
            double step = 270 / (this.Maximum - this.Minimum);
            //int scaleAreaCount = 10;
            for (int i = 0; i < this.Maximum - this.Minimum; i++)
            {
                Line lineScale = new Line();
                //Math.PI：角度、180：弧度
                //radius - 20：從最外圓邊向內20
                //- 45：逆時鐘45度
                lineScale.X1 = radius - (radius - 13) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y1 = radius - (radius - 13) * Math.Sin((i * step - 45) * Math.PI / 180);
                lineScale.X2 = radius - (radius - 8) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y2 = radius - (radius - 8) * Math.Sin((i * step - 45) * Math.PI / 180);
                lineScale.Stroke = this.ScaleBrush;
                lineScale.StrokeThickness = 2;

                mainCanvas.Children.Add(lineScale);
            }

            step = 270.0 / Interval;
            int scaleText = (int)this.Minimum;
            for (int i = 0; i <= Interval; i++)
            {
                Line lineScale = new Line();
                lineScale.X1 = radius - (radius - 20) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y1 = radius - (radius - 20) * Math.Sin((i * step - 45) * Math.PI / 180);
                lineScale.X2 = radius - (radius - 8) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y2 = radius - (radius - 8) * Math.Sin((i * step - 45) * Math.PI / 180);

                lineScale.Stroke = ScaleBrush;
                lineScale.StrokeThickness = 1;

                mainCanvas.Children.Add(lineScale);

                TextBlock textScale = new TextBlock();
                textScale.Width = 34;
                textScale.TextAlignment = TextAlignment.Center;
                textScale.FontSize = this.ScaleTextSize;
                textScale.Text = (scaleText + (this.Maximum - this.Minimum) / Interval * i).ToString();

                textScale.Foreground = this.ScaleBrush;
                Canvas.SetLeft(textScale, radius - (radius - 36) * Math.Cos((i * step - 45) * Math.PI / 180) - 17);
                Canvas.SetTop(textScale, radius - (radius - 36) * Math.Sin((i * step - 45) * Math.PI / 180) - 10);

                this.mainCanvas.Children.Add(textScale);
            }

            //M：兩個數據為一個點、A：畫圓弧
            string sData = "M{0} {1} A{0} {0} 0 1 1 {1} {2}";
            sData = string.Format(sData, radius / 2, radius, radius * 1.5);
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            this.circle.Data = (Geometry)converter.ConvertFrom(sData);

            //將指針指向正確的數值
            step = 270.0 / (this.Maximum - this.Minimum);
            //this.rtPointer.Angle = this.Value * step - 45;

            //將指針動作動畫化
            DoubleAnimation da = new DoubleAnimation((int)((this.Value - this.Minimum) * step) - 45, new Duration(TimeSpan.FromMilliseconds(200)));
            this.rtPointer.BeginAnimation(RotateTransform.AngleProperty, da);

            //畫指針
            sData = "M{0} {1},{1} {2},{1} {3}";
            sData = string.Format(sData, radius * 0.3, radius, radius - 5, radius + 5);
            this.pointer.Data = (Geometry)converter.ConvertFrom(sData);
        }
    }
}
