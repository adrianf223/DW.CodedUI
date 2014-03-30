using System;
using System.ComponentModel;
using System.Windows;

namespace ElementFinder
{
    public partial class App : Application
    {
        private LargeView _largeView;
        private ShortView _shortView;
        private bool _isClosing;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ShowShortView();
        }

        private void ShowLargeView()
        {
            if (_largeView == null)
            {
                _largeView = new LargeView();

                _largeView.Closing += HandleClosing;
                _largeView.SwitchView += SwitchToShortView;
            }

            if (_shortView != null)
            {
                _largeView.Left = _shortView.Left;
                _largeView.Top = _shortView.Top;
                // take over found element
                _shortView.Hide();
            }

            _largeView.ShowDialog();
        }

        private void ShowShortView()
        {
            if (_shortView == null)
            {
                _shortView = new ShortView();
                
                _shortView.Closing += HandleClosing;
                _shortView.SwitchView += SwitchToLargeView;
            }

            if (_largeView != null)
            {
                _shortView.Left = _largeView.Left;
                _shortView.Top = _largeView.Top;
                // take over found element
                _largeView.Hide();
            }

            _shortView.ShowDialog();
        }

        private void SwitchToLargeView(object sender, EventArgs e)
        {
            ShowLargeView();
        }

        private void SwitchToShortView(object sender, EventArgs e)
        {
            ShowShortView();
        }

        private void HandleClosing(object sender, CancelEventArgs e)
        {
            if (_isClosing)
                return;

            _isClosing = true;
            if (_largeView != sender && _largeView != null)
                _largeView.Close();

            if (_shortView != sender && _shortView != null)
                _shortView.Close();

            Shutdown();
        }
    }
}
