using System.Windows;

namespace DW.CodedUI.Demo
{
    public partial class ControlsWindow
    {
        public ControlsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show(this, "Button Clicked", "Button Clicked");
        }
    }
}
