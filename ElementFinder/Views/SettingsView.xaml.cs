using System.Windows;
using ElementFinder.ViewModels;

namespace ElementFinder.Views
{
    public partial class SettingsView
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private SettingsViewModel GetViewModel()
        {
            return (SettingsViewModel)DataContext;
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            Apply(sender, e);

            DialogResult = true;
        }

        private void Apply(object sender, RoutedEventArgs e)
        {
            GetViewModel().Save();
        }
    }
}
