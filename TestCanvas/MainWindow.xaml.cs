using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TestCanvas
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

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            //Line newLine= new Line();
            //newLine.X1 = double.Parse(tbX1.Text);
            //newLine.Y1 = double.Parse(tbY1.Text);
            //newLine.X2 = double.Parse(tbX2.Text);
            //newLine.Y2 = double.Parse(tbY2.Text);
            //newLine.StrokeThickness = 3;
            //newLine.Stroke= new SolidColorBrush((Color)ColorConverter.ConvertFromString(txColor.Text));
            //canvas.Children.Add(newLine);
            //lbLines.Items.Add($"X1:{newLine.X1} Y1:{newLine.Y1} X2:{newLine.X2} Y2:{newLine.Y2} Color:{txColor.Text}");
            CanvasControl.Draw();
        }
    }
}
