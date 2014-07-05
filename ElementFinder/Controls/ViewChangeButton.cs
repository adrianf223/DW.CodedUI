using System.Windows;
using System.Windows.Controls;

namespace ElementFinder.Controls
{
    public class ViewChangeButton : Button
    {
        static ViewChangeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ViewChangeButton), new FrameworkPropertyMetadata(typeof(ViewChangeButton)));
        }

        public bool IsMinimized
        {
            get { return (bool)GetValue(IsMinimizedProperty); }
            set { SetValue(IsMinimizedProperty, value); }
        }

        public static readonly DependencyProperty IsMinimizedProperty =
            DependencyProperty.Register("IsMinimized", typeof(bool), typeof(ViewChangeButton), new PropertyMetadata(default(bool)));
    }
}
