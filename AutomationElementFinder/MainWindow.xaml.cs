using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using DW.CodedUI.BasicElements;
using DW.CodedUI.UITree;
using DW.CodedUI.Utilities;
using Point = System.Drawing.Point;

namespace AutomationElementFinder
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        private readonly DispatcherTimer _timer;
        private readonly int _currentProcessId;
        private BasicElementInfo _currentSelectedElement;
        public BasicElementInfo CurrentSelectedElement
        {
            get { return _currentSelectedElement; }
            set { _currentSelectedElement = value; NotifyPropertyChanged(() => CurrentSelectedElement); }
        }

        private Highlighter _highlighter;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            _currentProcessId = Process.GetCurrentProcess().Id;

            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += HandleSearchTimerTick;

            elementTree.SelectedItemChanged += HandleSelectedItemChanged;
            siblingsTree.SelectedItemChanged += HandleSelectedItemChanged;

            DirectElements = new ObservableCollection<BasicElementInfo>();
            TreeElements = new ObservableCollection<BasicElementInfo>();
            IsActivated = true;
            ShowHighlight = true;
            ReadFullTree = true;
        }

        #region FindElements

        private void EnableSearch()
        {
            _timer.Start();
        }

        private void DisableSearch()
        {
            _timer.Stop();
        }

        private void HandleSearchTimerTick(object sender, EventArgs e)
        {
            if (!Keyboard.Modifiers.HasFlag(ModifierKeys.Control) || !Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
                return;

            var mouse = System.Windows.Forms.Cursor.Position;
            var elements = GetAllElementsByPosition(mouse);
            if (elements == null)
                return;

            DirectElements.Clear();
            foreach (var element in elements)
                DirectElements.Add(element);
            if (DirectElements.Any())
            {
                CurrentSelectedElement = DirectElements.First();
                CurrentSelectedElement.IsSelected = true;
            }
            if (ShowHighlight)
                HighlightElement(CurrentSelectedElement);
        }

        private IEnumerable<BasicElementInfo> GetAllElementsByPosition(Point position)
        {
            var items = new List<BasicElementInfo>();

            try
            {
                var element = AutomationElement.FromPoint(position);
                if (element == null || !Helper.IsAvailable(element))
                    return null;

                if (element.Current.ProcessId == _currentProcessId)
                    return null;

                items.Add(BasicElementFinder.GetFullUITree(element));
                if (!ReadFullTree)
                    return items;

                TreeElements.Clear();
                var toppestParent = GetParent(element);
                var tree = BasicElementFinder.GetFullUITree(toppestParent);
                foreach (var treeItem in GetAllElementsByPosition(tree, position))
                    TreeElements.Add(treeItem);
            }
            catch
            {
                return items;
            }
            return items;
        }

        private IEnumerable<BasicElementInfo> GetAllElementsByPosition(BasicElementInfo tree, Point position)
        {
            var items = new List<BasicElementInfo>();
            foreach (var child in tree.Children)
            {
                if (!Helper.IsAvailable(child.AutomationElement))
                    continue;
                if (child.AutomationElement.Current.BoundingRectangle.Contains(position))
                    items.Add(child);
                items.AddRange(GetAllElementsByPosition(child, position));
            }
            return items;
        }

        private AutomationElement GetParent(AutomationElement element)
        {
            var parent = TreeWalker.ControlViewWalker.GetParent(element);
            if (parent == null || parent.Current.FrameworkId != "WPF" || !Helper.IsAvailable(parent))
                return element;

            while (parent.Current.ClassName != "Window")
            {
                parent = TreeWalker.ControlViewWalker.GetParent(parent);
                if (!Helper.IsAvailable(parent))
                    return null;
            }
            return parent;
        }

        #endregion FindElements

        #region Highlight
        
        private void HandleSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var view = (TreeView) sender;
            CurrentSelectedElement = null;
            if (e.NewValue != null && e.NewValue is BasicElementInfo)
            {
                CurrentSelectedElement = (BasicElementInfo)e.NewValue;
                if (ShowHighlight)
                {
                    HighlightElement(CurrentSelectedElement);
                    view.Focus();
                }
            }
        }

        private void HighlightElement(BasicElementInfo element)
        {
            if (_highlighter != null)
                _highlighter.Close();

            if (element == null)
                return;

            if (!Helper.IsAvailable(element.AutomationElement))
                return;

            if (element.AutomationElement.Current.IsOffscreen)
                return;

            _highlighter = new Highlighter();
            _highlighter.Highlight(element.AutomationElement);
        }

        private void EnableHighlight()
        {
            if (CurrentSelectedElement != null)
                HighlightElement(CurrentSelectedElement);
        }

        private void DisableHighlight()
        {
            _highlighter.Close();
        }

        #endregion Highlight

        #region Properties

        public ObservableCollection<BasicElementInfo> DirectElements { get; set; }
        public ObservableCollection<BasicElementInfo> TreeElements { get; set; }

        public bool IsActivated
        {
            get { return _isActivated; }
            set
            {
                _isActivated = value;
                NotifyPropertyChanged(() => IsActivated);

                if (value)
                    EnableSearch();
                else
                    DisableSearch();
            }
        }
        private bool _isActivated;

        public bool ShowHighlight
        {
            get { return _showHighlight; }
            set
            {
                _showHighlight = value;
                NotifyPropertyChanged(() => ShowHighlight);

                if (value)
                    EnableHighlight();
                else
                    DisableHighlight();
            }
        }
        private bool _showHighlight;

        public bool ReadFullTree
        {
            get { return _readFullTree; }
            set
            {
                _readFullTree = value;
                NotifyPropertyChanged(() => ReadFullTree);
            }
        }
        private bool _readFullTree;

        #endregion Properties

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged<T>(Expression<Func<T>> property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var memberExpression = property.Body as MemberExpression;
                handler(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
            }
        }

        #endregion NotifyPropertyChanged
    }
}
