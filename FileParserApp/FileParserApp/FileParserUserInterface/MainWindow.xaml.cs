using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileParserUserInterface
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

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            Nullable<bool> dialogResult = ofd.ShowDialog();

            if (dialogResult == true)
            {
                txtFileName.Text = ofd.FileName;
            }
        }

        private void btnRunReports_Click(object sender, RoutedEventArgs e)
        {
            string[] args = { "-file", txtFileName.Text, "-sort", txtSortby.Text, "-search", txtSearchby.Text };

            if (!File.Exists(txtFileName.Text))
            {
                txtFileName.Text = "Enter a valid file path";
                return;
            }

            FileParseApi.FileParser.ParseArgs(args, false);

            List<FileParseApi.MedReport> reports = FileParseApi.FileParser.ProcessedReports;

            txtReport.Text = FileParseApi.ParseUtils.GenerateReport(reports);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            switch(menuItem.Name)
            {
                case "Window1":
                case "cones":
                    HostingWpfUserControlInWf.ConeControl coneControl = new HostingWpfUserControlInWf.ConeControl();
                    Window window = new Window();
                    window.Content = coneControl;
                    window.Height = 500;
                    window.Width = 600;
                    window.Show();

                    break;
            }
        }
    }
}
