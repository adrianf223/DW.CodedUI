#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2014 David Wendland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE
*/
#endregion License

using System;
using System.Text;
using System.Windows;

namespace ElementFinder.Views
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
