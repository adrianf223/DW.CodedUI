using System.Windows;
using System.Windows.Controls;

namespace AutomationElementFinder
{
    public class EnhancedTreeViewItem : TreeViewItem
    {
        static EnhancedTreeViewItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnhancedTreeViewItem), new FrameworkPropertyMetadata(typeof(EnhancedTreeViewItem)));
        }

        protected override System.Windows.DependencyObject GetContainerForItemOverride()
        {
            return new EnhancedTreeViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is EnhancedTreeViewItem;
        }

        public bool ContentStretching
        {
            get { return (bool)GetValue(ContentStretchingProperty); }
            set { SetValue(ContentStretchingProperty, value); }
        }

        public static readonly DependencyProperty ContentStretchingProperty =
            DependencyProperty.Register("ContentStretching", typeof(bool), typeof(EnhancedTreeViewItem), new UIPropertyMetadata(OnContentStretchingChanged));

        private static void OnContentStretchingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var value = (bool)e.NewValue;
            if (value)
            {
                var control = (EnhancedTreeViewItem)sender;
                if (control.IsLoaded)
                    control.AdjustChildren();
                else
                    control.Loaded += new RoutedEventHandler(control.StretchingTreeViewItem_Loaded);
            }
        }

        private void StretchingTreeViewItem_Loaded(object sender, RoutedEventArgs e)
        {
            AdjustChildren();
        }

        private void AdjustChildren()
        {
            if (this.VisualChildrenCount > 0)
            {
                var grid = this.GetVisualChild(0) as Grid;
                if (grid != null &&
                    grid.ColumnDefinitions.Count == 3)
                    grid.ColumnDefinitions.RemoveAt(1);
            }
        }

        public bool HasAutomationId
        {
            get { return (bool)GetValue(HasAutomationIdProperty); }
            set { SetValue(HasAutomationIdProperty, value); }
        }

        public static readonly DependencyProperty HasAutomationIdProperty =
            DependencyProperty.Register("HasAutomationId", typeof(bool), typeof(EnhancedTreeViewItem), new UIPropertyMetadata(false));
    }
}
