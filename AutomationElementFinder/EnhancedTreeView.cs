using System.Windows;
using System.Windows.Controls;

namespace AutomationElementFinder
{
    public class EnhancedTreeView : TreeView
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new EnhancedTreeViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is EnhancedTreeViewItem;
        }
    }
}
