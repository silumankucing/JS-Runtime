using System.Windows;
using HelixToolkit.Wpf;
using System.Windows.Media.Media3D;

namespace STLViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var importer = new StLReader();
            var model = importer.Read("test.stl");

            ModelView.Content = model;
        }
    }
}