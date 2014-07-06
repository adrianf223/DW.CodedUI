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
