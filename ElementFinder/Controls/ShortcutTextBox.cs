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

using System.Collections.Generic;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ElementFinder.Shortcuts;

namespace ElementFinder.Controls
{
    public class ShortcutTextBox : Control
    {
        static ShortcutTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ShortcutTextBox), new FrameworkPropertyMetadata(typeof(ShortcutTextBox)));
        }

        public ShortcutTextBox()
        {
            _takenKeys = new List<Key>();
            _pressedKeys = new List<Key>();

            _shortcutsCollector = new ShortcutsCollector();
            _shortcutsCollector.SetShortcuts(new GlobalShortcut(KeyPressed, KeyReleased));
        }

        private readonly ShortcutsCollector _shortcutsCollector;
        private TextBox _textBox;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var button = GetTemplateChild("PART_ClearButton") as Button;
            if (button != null)
                button.Click += (sender, args) => Text = string.Empty;

            _textBox = GetTemplateChild("Part_TextBox") as TextBox;

            if (_textBox == null)
                return;

            _textBox.GotFocus += HandleGotFocus;
            _textBox.LostFocus += HandleLostFocus;
        }

        private void HandleGotFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            _shortcutsCollector.Start();
        }

        private void HandleLostFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            _shortcutsCollector.Stop();
        }

        private readonly List<Key> _takenKeys;
        private readonly List<Key> _pressedKeys;

        private void KeyPressed(Key key)
        {
            _takenKeys.Clear();
            if (!_pressedKeys.Contains(key))
                _pressedKeys.Add(key);
        }

        private void KeyReleased(Key key)
        {
            _takenKeys.AddRange(_pressedKeys);
            _pressedKeys.Clear();

            Text = string.Join(" + ", _takenKeys);
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ShortcutTextBox), new PropertyMetadata(default(string)));

        public bool HasResetButton
        {
            get { return (bool)GetValue(HasResetButtonProperty); }
            set { SetValue(HasResetButtonProperty, value); }
        }

        public static readonly DependencyProperty HasResetButtonProperty =
            DependencyProperty.Register("HasResetButton", typeof(bool), typeof(ShortcutTextBox), new PropertyMetadata(true));
    }
}
