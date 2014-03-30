using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ElementFinder
{
    public partial class ShortView
    {
        public ShortView()
        {
            InitializeComponent();

            DataContext = new ShortViewModel();
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

        private void CloseView(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void HandleMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void OnSizeDragDelta(object sender, DragDeltaEventArgs e)
        {
            var newWidth = Width + e.HorizontalChange;

            if (newWidth > MaxWidth ||
                newWidth < MinWidth)
                return;

            Width = newWidth;
        }

        private void OnDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Width = 600;
        }

        private void CopyAutomationId(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(AutomationIdTextBox.Text);
        }

        private void CopyName(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(NameTextBox.Text);
        }
    }
}
