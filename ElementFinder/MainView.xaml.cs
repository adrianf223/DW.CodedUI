using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using DW.CodedUI.BasicElements;

namespace ElementFinder
{
    public partial class LargeView : INotifyPropertyChanged
    {
        public LargeView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            _oldHeight = 600;
            ShowLargeView();
        }

        private double _oldHeight;
        private bool _isShortView;

        public bool IsShortView
        {
            get { return _isShortView; }
            private set
            {
                _isShortView = value;
                OnPropertyChanged("IsShortView");
            }
        }

        private void DoSwitchView(object sender, RoutedEventArgs e)
        {
            if (WindowStyle == WindowStyle.None)
                ShowLargeView();
            else
                ShowSmallView();
        }

        private void ShowSmallView()
        {
            IsShortView = true;
            WindowStyle = WindowStyle.None;
            _oldHeight = Height;
            Height = 30;
            ResizeMode = ResizeMode.NoResize;
        }

        private void ShowLargeView()
        {
            IsShortView = false;
            WindowStyle = WindowStyle.SingleBorderWindow;
            Height = _oldHeight;
            ResizeMode = ResizeMode.CanResize;
        }

        private void CloseView(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void HandleMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsShortView)
                return;

            DragMove();
        }

        private void OnSizeDragDelta(object sender, DragDeltaEventArgs e)
        {
            if (!IsShortView)
                return;

            var newWidth = Width + e.HorizontalChange;
            if (newWidth >= MinWidth && newWidth <= MaxWidth)
                Width = newWidth;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void HandleSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var viewModel = (MainViewModel)DataContext;
            viewModel.CurrentElement = (AutomationElementInfo)e.NewValue;
            
            Focus();
        }
    }
}
