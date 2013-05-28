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
            new ChildWindow().ShowDialog();
        }

        private void ShowChildWindowNonModal(object sender, RoutedEventArgs e)
        {
            new ChildWindow().Show();
        }
    }
}
