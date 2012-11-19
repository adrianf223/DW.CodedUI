#region License
/*--------------------------------------------------------------------------------
    Copyright (c) 2012 David Wendland

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
    THE SOFTWARE.
--------------------------------------------------------------------------------*/
#endregion License

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;
using System.Windows.Threading;
using DW.CodedUI.BasicElements;
using DW.CodedUI.UITree;
using DW.CodedUI.Utilities;

namespace AutomationElementFinder
{
    public partial class MainWindow
    {
        private readonly DispatcherTimer _timer;
        private readonly int _currentProcessId;
        private Highlighter _highlighter;

        public ObservableCollection<BasicElementInfo> Elements { get; set; }
        private AutomationElement _currentSelectedElement;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            _currentProcessId = Process.GetCurrentProcess().Id;

            Elements = new ObservableCollection<BasicElementInfo>();

            elementTree.SelectedItemChanged += HandleSelectedItemChanged;

            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += HandleTimerTick;

            _timer.Start();
        }

        private void HandleSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue != null)
            {
                _currentSelectedElement = ((BasicElementInfo) e.NewValue).AutomationElement;
                HighlightElement(_currentSelectedElement);
                elementTree.Focus();
            }
        }

        private void HandleTimerTick(object sender, EventArgs e)
        {
            if (!Keyboard.Modifiers.HasFlag(ModifierKeys.Control) || !Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
                return;

            var mouse = System.Windows.Forms.Cursor.Position;
            var element = AutomationElement.FromPoint(new System.Windows.Point(mouse.X, mouse.Y));
            if (element == null)
                return;

            if (element.Current.ProcessId == _currentProcessId)
                return;

            _currentSelectedElement = element;
            if (Elements.Count == 0)
            {
                var elementInfo = BasicElementFinder.GetFullUITree(element);
                Elements.Add(elementInfo);
                HighlightElement(elementInfo.AutomationElement);
                return;
            }

            if (element != Elements[0].AutomationElement)
            {
                var elementInfo = BasicElementFinder.GetFullUITree(element);
                Elements[0] = elementInfo;
                HighlightElement(elementInfo.AutomationElement);
            }
        }

        private void HighlightElement(AutomationElement element)
        {
            if (_highlighter != null)
                _highlighter.Close();
            _highlighter = new Highlighter();
            _highlighter.Highlight(element);
        }

        private void ToggleHighlight_Click(object sender, RoutedEventArgs e)
        {
            if (_highlighter != null)
            {
                _highlighter.Close();
                _highlighter = null;
            }
            else if (_currentSelectedElement != null)
                HighlightElement(_currentSelectedElement);
        }
    }
}
