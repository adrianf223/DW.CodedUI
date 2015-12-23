using System.Windows;

namespace TestApplication
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ColorDetectorTests_Button_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new ColorDetectorTestsWindow();
            window.Owner = this;
            window.ShowDialog();
        }

        private void KeyboardExTests_Button_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new KeyboardExTestsWindow();
            window.Owner = this;
            window.ShowDialog();
        }
    }
}
