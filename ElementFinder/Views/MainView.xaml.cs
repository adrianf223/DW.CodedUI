#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2015 David Wendland

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
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using DW.CodedUI.BasicElements;
using ElementFinder.Properties;
using ElementFinder.ViewModels;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace ElementFinder.Views
{
    public partial class MainView : INotifyPropertyChanged
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            GetViewModel().ToggleView += OnToggleView;

            SetPositionAndSize();
        }

        private void OnToggleView(object sender, EventArgs eventArgs)
        {
            if (IsShortView)
                ShowLargeView();
            else
                ShowSmallView();
        }

        private double _oldHeight;

        public bool IsShortView
        {
            get { return _isShortView; }
            set
            {
                _isShortView = value;
                OnPropertyChanged("IsShortView");
            }
        }
        private bool _isShortView;


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

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void HandleSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var viewModel = GetViewModel();
            viewModel.CurrentElement = (AutomationElementInfo)e.NewValue;

            Focus();
        }

        private void HandleLoaded(object sender, RoutedEventArgs e)
        {
            var mainViewModel = GetViewModel();
            mainViewModel.QuickSearch = Settings.Default.QuickSearch;
            mainViewModel.ExpandAfterSearch = Settings.Default.ExpandAfterSearch;
            mainViewModel.IsEnabled = Settings.Default.IsEnabled;
            mainViewModel.HideEmptyEntries = Settings.Default.HideEmptyEntries;
            mainViewModel.AutoCopyAutomationId = Settings.Default.AutoCopyAutomationId;
            mainViewModel.TopMost = Settings.Default.TopMost;
            mainViewModel.TopMostHighlighter = Settings.Default.TopMostHighlighter;
            mainViewModel.LeftColumnWidth = new GridLength(Settings.Default.LeftColumnWidth);
            mainViewModel.NoticeHighlightPosition = Settings.Default.NoticeHighlightPosition;
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
            var mainViewModel = GetViewModel();
            Settings.Default.QuickSearch = mainViewModel.QuickSearch;
            Settings.Default.ExpandAfterSearch = mainViewModel.ExpandAfterSearch;
            Settings.Default.IsEnabled = mainViewModel.IsEnabled;
            Settings.Default.HideEmptyEntries = mainViewModel.HideEmptyEntries;
            Settings.Default.AutoCopyAutomationId = mainViewModel.AutoCopyAutomationId;
            Settings.Default.TopMost = mainViewModel.TopMost;
            Settings.Default.TopMostHighlighter = mainViewModel.TopMostHighlighter;
            Settings.Default.LeftColumnWidth = mainViewModel.LeftColumnWidth.Value;
            Settings.Default.IsShortView = IsShortView;
            Settings.Default.NoticeHighlightPosition = mainViewModel.NoticeHighlightPosition;
            if (IsShortView)
                Settings.Default.Size = new Size((int)Width, (int)_oldHeight);
            else
                Settings.Default.Size = new Size((int)Width, (int)Height);
            Settings.Default.Position = new Point((int)Left, (int)Top);

            Settings.Default.Save();
        }

        private MainViewModel GetViewModel()
        {
            return (MainViewModel)DataContext;
        }

        private void ClearPane(object sender, RoutedEventArgs e)
        {
            GetViewModel().CurrentElement = null;
            GetViewModel().Elements.Clear();
        }

        private void ShowSettings(object sender, RoutedEventArgs e)
        {
            var mainViewModel = GetViewModel();
            mainViewModel.StopShortcuts();

            var viewModel = new SettingsViewModel();
            var window = new SettingsView();
            window.Owner = this;
            window.DataContext = viewModel;
            viewModel.Load();

            if (window.ShowDialog() == true)
            {
                mainViewModel.QuickSearch = Settings.Default.QuickSearch;
                mainViewModel.ExpandAfterSearch = Settings.Default.ExpandAfterSearch;
                mainViewModel.HideEmptyEntries = Settings.Default.HideEmptyEntries;
                mainViewModel.AutoCopyAutomationId = Settings.Default.AutoCopyAutomationId;
                mainViewModel.TopMost = Settings.Default.TopMost;
                mainViewModel.TopMostHighlighter = Settings.Default.TopMostHighlighter;
                mainViewModel.NoticeHighlightPosition = Settings.Default.NoticeHighlightPosition;
                mainViewModel.UpdateInteractionObserver();
                mainViewModel.UpdateElementsCatcher();
            }

            mainViewModel.StartShortcuts();
        }
    }
}
