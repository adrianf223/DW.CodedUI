using System.Windows;

namespace TestApplication
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new ColorDetectorTestsWindow();
            window.Owner = this;
            window.ShowDialog();
        }
    }
}
