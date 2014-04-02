using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using DW.CodedUI.BasicElements;
using ElementFinder.Properties;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace ElementFinder
{
    public partial class LargeView : INotifyPropertyChanged
    {
        public LargeView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            SetPositionAndSize();
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
            var viewModel = GetMainViewModel();
            viewModel.CurrentElement = (AutomationElementInfo)e.NewValue;

            Focus();
        }

        private void HandleLoaded(object sender, RoutedEventArgs e)
        {
            var mainViewModel = GetMainViewModel();
            mainViewModel.QuickSearch = Settings.Default.QuickSearch;
            mainViewModel.ExpandAfterSearch = Settings.Default.ExpandAfterSearch;
            mainViewModel.IsEnabled = Settings.Default.IsEnabled;
            mainViewModel.HideEmptyEntries = Settings.Default.HideEmptyEntries;
            mainViewModel.AutoCopyAutomationId = Settings.Default.AutoCopyAutomationId;
        }

        private void SetPositionAndSize()
        {
            Height = Settings.Default.Size.Height;
            _oldHeight = Settings.Default.Size.Height;
            Width = Settings.Default.Size.Width;
            if (Settings.Default.IsShortView)
                ShowSmallView();
            else
                ShowLargeView();
            if (!Settings.Default.Position.IsEmpty)
            {
                Left = Settings.Default.Position.X;
                Top = Settings.Default.Position.Y;
            }
        }

        private void HandleClosing(object sender, CancelEventArgs e)
        {
            var mainViewModel = GetMainViewModel();
            Settings.Default.QuickSearch = mainViewModel.QuickSearch;
            Settings.Default.ExpandAfterSearch = mainViewModel.ExpandAfterSearch;
            Settings.Default.IsEnabled = mainViewModel.IsEnabled;
            Settings.Default.HideEmptyEntries = mainViewModel.HideEmptyEntries;
            Settings.Default.AutoCopyAutomationId = mainViewModel.AutoCopyAutomationId;
            Settings.Default.IsShortView = _isShortView;
            if (_isShortView)
                Settings.Default.Size = new Size((int)Width, (int)_oldHeight);
            else
                Settings.Default.Size = new Size((int)Width, (int)Height);
            Settings.Default.Position = new Point((int)Left, (int)Top);

            Settings.Default.Save();
        }

        private MainViewModel GetMainViewModel()
        {
            return (MainViewModel)DataContext;
        }
    }
}
