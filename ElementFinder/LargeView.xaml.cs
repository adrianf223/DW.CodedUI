using System;
using System.Windows;

namespace ElementFinder
{
    public partial class LargeView
    {
        public LargeView()
        {
            InitializeComponent();
            DataContext = new LargeViewModel();
        }

        public event EventHandler SwitchView;

        private void OnSwitchView()
        {
            var handler = SwitchView;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void DoSwitchView(object sender, RoutedEventArgs e)
        {
            OnSwitchView();
        }
    }
}
