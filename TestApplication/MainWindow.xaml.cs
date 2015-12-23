using System.Windows;
using System.Windows.Automation;

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

        private void MouseExTests_Button_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new MouseExTestsWindow();
            window.Owner = this;
            window.ShowDialog();
        }

        private void WindowFocusTests_Button_OnClick(object sender, RoutedEventArgs e)
        {
            var window1 = new WindowFocusTestsWindow();
            AutomationProperties.SetAutomationId(window1, "CUI_WindowFocusTestsWindow_1");
            window1.Owner = this;
            window1.Show();

            var window2 = new WindowFocusTestsWindow();
            AutomationProperties.SetAutomationId(window2, "CUI_WindowFocusTestsWindow_2");
            window2.Owner = this;
            window2.Show();
        }

        private void ShowMessageBox_Button_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, "MessageBoxText", "MessageBoxTitle");
        }

        private void UITests_Button_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new UITestsWindow();
            window.Owner = this;
            window.ShowDialog();
        }
    }
}
