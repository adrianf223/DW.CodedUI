using System.Windows.Input;

namespace TestApplication
{
    public partial class MouseExTestsWindow
    {
        public MouseExTestsWindow()
        {
            InitializeComponent();
        }

        private void InputTextBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            InputTextBox.Text = "TextBox got doubleclicked";
        }
    }
}
