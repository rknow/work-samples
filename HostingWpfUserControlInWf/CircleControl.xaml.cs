using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HostingWpfUserControlInWf
{
    public class CircleControl : UserControl
    {
        public CircleControl()
        {
            Width = 400;
            Height = 400;

            var grid = new Grid();

            var ellipse = new Ellipse
            {
                Width = 200,
                Height = 200,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Fill = new RadialGradientBrush(Colors.LightCoral, Colors.DarkRed),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            grid.Children.Add(ellipse);
            Content = grid;
        }
    }
}
     