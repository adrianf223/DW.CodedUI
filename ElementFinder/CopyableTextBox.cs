using System.Windows;
using System.Windows.Controls;

namespace ElementFinder
{
    public class CopyableTextBox : TextBox
    {
        static CopyableTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CopyableTextBox), new FrameworkPropertyMetadata(typeof(CopyableTextBox)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var button = (Button)GetTemplateChild("PART_CopyButton");
            button.Click += HandleClick;
        }

        private void HandleClick(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Text);
        }

        public string CopyButtonToolTip
        {
            get { return (string)GetValue(CopyButtonToolTipProperty); }
            set { SetValue(CopyButtonToolTipProperty, value); }
        }

        public static readonly DependencyProperty CopyButtonToolTipProperty =
            DependencyProperty.Register("CopyButtonToolTip", typeof(string), typeof(CopyableTextBox), new PropertyMetadata(null));
    }
}
