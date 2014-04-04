using System;
using System.Text;
using System.Windows;

namespace ElementFinder
{
    public partial class ExceptionWindow
    {
        private readonly Exception _exception;
        private readonly bool _showContinue;

        public ExceptionWindow(Exception exception, bool canContinue = true)
        {
            _exception = exception;
            _showContinue = canContinue;
            InitializeComponent();

            Loaded += HandleLoaded;
        }

        private void HandleLoaded(object sender, RoutedEventArgs e)
        {
            if (_showContinue)
                _canContinue.Visibility = Visibility.Visible;

            if (_exception == null)
            {
                _errorMessage.Text = "Unknown Message";
            }
            else
            {
                _errorMessage.Text = _exception.Message;
                if (_exception.InnerException != null)
                    _showInner.Visibility = Visibility.Visible;
                _title.Text = _exception.GetType().ToString();
                _detailsText.Text = CreateExceptionDetails();
            }
        }

        private void ContinueClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ShowInnerExceptionClick(object sender, RoutedEventArgs e)
        {
            new ExceptionWindow(_exception.InnerException, false).Show();
        }

        private void ShowDetailsClick(object sender, RoutedEventArgs e)
        {
            if (_showDetails.IsChecked == true)
            {
                Height = 500;
                Width = 500;
                ResizeMode = ResizeMode.CanResize;
            }
            else
            {
                Height = 250;
                Width = 400;
                ResizeMode = ResizeMode.NoResize;
            }
        }

        private string CreateExceptionDetails()
        {
            var message = new StringBuilder();
            message.AppendLine("================================================");
            message.AppendLine(_exception.Message);
            message.AppendLine("================================================");
            message.AppendLine("Date: " + DateTime.Now.Date.ToLongDateString());
            message.AppendLine("Time: " + DateTime.Now.ToLongTimeString());
            message.AppendLine("Type: " + _exception.GetType());
            message.AppendLine("Message: " + _exception.Message);
            message.AppendLine("Help Link: " + _exception.HelpLink);
            message.AppendLine("Source: " + _exception.Source);
            message.AppendLine("Target Site: " + (_exception.TargetSite != null ? _exception.TargetSite.ToString() : "<Null>"));
            message.AppendLine("\nStack Trace");
            message.AppendLine("================================================");
            message.AppendLine(_exception.StackTrace);
            message.AppendLine("================================================");
            return message.ToString();
        }

        private void CopyClick(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(_detailsText.Text);
            MessageBox.Show("Der Text wurde in die Zwischenablage kopiert.");
        }
    }
}
