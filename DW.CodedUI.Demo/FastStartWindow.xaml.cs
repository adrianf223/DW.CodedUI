using System.Windows;

namespace DW.CodedUI.Demo
{
    public partial class FastStartWindow
    {
        public FastStartWindow()
        {
            InitializeComponent();
        }

        private void ShowChildWindowModal(object sender, RoutedEventArgs e)
        {
            var childWindow = new ChildWindow();
            childWindow.Owner = this;
            childWindow.ShowDialog();
        }

        private void ShowChildWindowNonModal(object sender, RoutedEventArgs e)
        {
            var childWindow = new ChildWindow();
            childWindow.Owner = this;
            childWindow.Show();
        }
    }
}
