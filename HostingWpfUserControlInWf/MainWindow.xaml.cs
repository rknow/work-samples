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

namespace HostingWpfUserControlInWf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int coneCount = 0;
    private int rectangleCount = 0;
    private int circleCount = 0;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnGenerateConeShape_Click(object sender, RoutedEventArgs e)
    {
        ConeControl coneControl = new ConeControl();
        this.wrapPanel1.Children.Add(coneControl);
        coneCount++;
        ((Label)this.wrapPanel1.Children[1]).Content = $"Total Cones on screen: {coneCount}";
    }

    private void btnRemoveConeShape_Click(object sender, RoutedEventArgs e)
    {
        if (this.wrapPanel1.Children.Count > 0)
        {
            this.wrapPanel1.Children.RemoveAt(this.wrapPanel1.Children.Count - 1);
            coneCount--;
            ((Label)this.wrapPanel1.Children[1]).Content = $"Total Cones on screen: {coneCount}";
        }
    }

    private void btnGenerateRectangleShape_Click(object sender, RoutedEventArgs e)
    {
        RectangleControl rectangleControl = new RectangleControl();
        this.wrapPanel2.Children.Add(rectangleControl);
        rectangleCount++;
        ((Label)this.wrapPanel2.Children[1]).Content = $"Total Rectangles on screen: {rectangleCount}";
    }

    private void btnRemoveRectangleShape_Click(object sender, RoutedEventArgs e)
    {
        if (this.wrapPanel2.Children.Count > 0)
        {
            this.wrapPanel2.Children.RemoveAt(this.wrapPanel2.Children.Count - 1);
            rectangleCount--;
            ((Label)this.wrapPanel2.Children[1]).Content = $"Total Rectangles on screen: {rectangleCount}";
        }
    }

    private void btnGenerateCircleShape_Click(object sender, RoutedEventArgs e)
    {
        CircleControl circleControl = new CircleControl();
        this.wrapPanel3.Children.Add(circleControl);
        circleCount++;
        ((Label)this.wrapPanel3.Children[1]).Content = $"Total Circles on screen: {circleCount}";
    }

    private void btnRemoveCircleShape_Click(object sender, RoutedEventArgs e)
    {
        if (this.wrapPanel3.Children.Count > 0)
        {
            this.wrapPanel3.Children.RemoveAt(this.wrapPanel3.Children.Count - 1);
            circleCount--;
            ((Label)this.wrapPanel3.Children[1]).Content = $"Total Circles on screen: {circleCount}";
        }
    }
}
