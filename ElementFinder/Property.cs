using System.Windows;
using System.Windows.Controls;

namespace ElementFinder
{
    public class Property : Control
    {
        static Property()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Property), new FrameworkPropertyMetadata(typeof(Property)));
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(Property), new UIPropertyMetadata(null));

        public object Value
        {
            get { return (object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(Property), new UIPropertyMetadata(null));

        public bool Highlight
        {
            get { return (bool)GetValue(HighlightProperty); }
            set { SetValue(HighlightProperty, value); }
        }

        public static readonly DependencyProperty HighlightProperty =
            DependencyProperty.Register("Highlight", typeof(bool), typeof(Property), new UIPropertyMetadata(false));
    }
}