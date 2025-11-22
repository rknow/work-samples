using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HostingWpfUserControlInWf
{
    public class RectangleControl : UserControl
    {
        public RectangleControl()
        {
            Width = 400;
            Height = 400;

            var grid = new Grid();

            var rect = new Rectangle
            {
                Width = 200,
                Height = 100,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Fill = new RadialGradientBrush(Colors.LightBlue, Colors.DarkBlue),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            grid.Children.Add(rect);
            Content = grid;
        }
    }
}
     