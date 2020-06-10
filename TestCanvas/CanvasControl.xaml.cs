using System;
using System.Collections.Generic;
using System.Linq;
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

namespace TestCanvas
{
    /// <summary>
    /// Interaction logic for CanvasControl.xaml
    /// </summary>
    public partial class CanvasControl : UserControl
    {



        public double MinX
        {
            get { return (double)GetValue(MinXProperty); }
            set { SetValue(MinXProperty, value); }
        }
        public static readonly DependencyProperty MinXProperty =
            DependencyProperty.Register("MinX", typeof(double), typeof(CanvasControl), new FrameworkPropertyMetadata(OnPropertyChanged));

        public double MinY
        {
            get { return (double)GetValue(MinYProperty); }
            set { SetValue(MinYProperty, value); }
        }
        public static readonly DependencyProperty MinYProperty =
            DependencyProperty.Register("MinY", typeof(double), typeof(CanvasControl), new FrameworkPropertyMetadata(OnPropertyChanged));

        public double MaxX
        {
            get { return (double)GetValue(MaxXProperty); }
            set { SetValue(MaxXProperty, value); }
        }
        public static readonly DependencyProperty MaxXProperty =
            DependencyProperty.Register("MaxX", typeof(double), typeof(CanvasControl), new FrameworkPropertyMetadata(OnPropertyChanged));

        public double MaxY
        {
            get { return (double)GetValue(MaxYProperty); }
            set { SetValue(MaxYProperty, value); }
        }
        public static readonly DependencyProperty MaxYProperty =
            DependencyProperty.Register("MaxY", typeof(double), typeof(CanvasControl), new FrameworkPropertyMetadata(OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is CanvasControl canvasControl))
                return;
            canvasControl.Draw();
        }

        public  void Draw()
        {
            double desiredWidth = MaxX - MinX;
            double desiredHeight = MaxY - MinY;
            Canvas.Width = desiredWidth;
            Canvas.Height = desiredHeight;

            Canvas.Children.Clear();
            Line newLine;
            newLine = new Line() { X1 = MinX, Y1 = MinY, X2 = MaxX, Y2 = MinY, Stroke = Brushes.Black, StrokeThickness = 1 }; //bottom
            Canvas.Children.Add(newLine);
            newLine = new Line() { X1 = MaxX, Y1 = MinY, X2 = MaxX, Y2 = MaxY, Stroke = Brushes.Black, StrokeThickness = 1 }; //right
            Canvas.Children.Add(newLine);
            newLine = new Line() { X1 = MaxX, Y1 = MaxY, X2 = MinX, Y2 = MaxY, Stroke = Brushes.Black, StrokeThickness = 1 }; //top
            Canvas.Children.Add(newLine);
            newLine = new Line() { X1 = MinX, Y1 = MaxY, X2 = MinX, Y2 = MinY, Stroke = Brushes.Black, StrokeThickness = 1 }; //left
            Canvas.Children.Add(newLine);
            newLine = new Line() { X1 = MinX, Y1 = MinY, X2 = MaxX, Y2 = MaxY, Stroke = Brushes.Black, StrokeThickness = 1 }; //diagonal Min-Max
            //Canvas.Children.Add(newLine);
            //newLine = new Line() { X1 = MinX, Y1 = MaxY, X2 = MaxX, Y2 = MinY, Stroke = Brushes.Black, StrokeThickness = 1 }; //diagonal TL-BR
            Canvas.Children.Add(newLine);

            
            ///matrix.Scale(desiredWidth, -desiredHeight);
            //matrix.Scale(1, -1);
            //            matrix.Translate(offsetX, offsetY);
            //var transformGroup = new TransformGroup();
            //var scaleTransform = new ScaleTransform(2, -5);
            //transformGroup.Children.Add(scaleTransform);
            //Canvas.RenderTransform = transformGroup;
            scaleTransform.ScaleY = -1;
            translateTransform.X = -MinX;
            translateTransform.Y = desiredHeight+MinY;
           // scaleTransform.ScaleX = 1;
            //scaleTransform.CenterX = 10;
            //scaleTransform.CenterY = 40;
        }

        public CanvasControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Draw();
        }
    }
}
