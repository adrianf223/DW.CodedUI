using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;

namespace AutomationElementFinder
{
    public class AutomationElementVisualization : Control
    {
        static AutomationElementVisualization()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AutomationElementVisualization), new FrameworkPropertyMetadata(typeof(AutomationElementVisualization)));
        }

        public AutomationElement Element
        {
            get { return (AutomationElement)GetValue(ElementProperty); }
            set { SetValue(ElementProperty, value); }
        }

        public static readonly DependencyProperty ElementProperty =
            DependencyProperty.Register("Element", typeof(AutomationElement), typeof(AutomationElementVisualization), new UIPropertyMetadata(null));
    }
}
