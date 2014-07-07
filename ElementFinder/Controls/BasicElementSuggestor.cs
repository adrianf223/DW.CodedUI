using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using DW.CodedUI.BasicElements;

namespace ElementFinder.Controls
{
    public class BasicElementSuggestor : Control
    {
        static BasicElementSuggestor()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BasicElementSuggestor), new FrameworkPropertyMetadata(typeof(BasicElementSuggestor)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var button = GetTemplateChild("PART_TryButton") as Button;
            if (button != null)
                button.Click += ButtonOnClick;
        }

        public AutomationElement AutomationElement
        {
            get { return (AutomationElement)GetValue(AutomationElementProperty); }
            set { SetValue(AutomationElementProperty, value); }
        }

        public static readonly DependencyProperty AutomationElementProperty =
            DependencyProperty.Register("AutomationElement", typeof(AutomationElement), typeof(BasicElementSuggestor), new PropertyMetadata(OnAutomationElementChanged));

        public BasicElement SuggestedBasicElement
        {
            get { return (BasicElement)GetValue(SuggestedBasicElementProperty); }
            set { SetValue(SuggestedBasicElementProperty, value); }
        }

        public static readonly DependencyProperty SuggestedBasicElementProperty =
            DependencyProperty.Register("SuggestedBasicElement", typeof(BasicElement), typeof(BasicElementSuggestor), new PropertyMetadata(default(BasicElement)));

        public string SuggestedBasicElementTitle
        {
            get { return (string)GetValue(SuggestedBasicElementTitleProperty); }
            set { SetValue(SuggestedBasicElementTitleProperty, value); }
        }

        public static readonly DependencyProperty SuggestedBasicElementTitleProperty =
            DependencyProperty.Register("SuggestedBasicElementTitle", typeof(string), typeof(BasicElementSuggestor), new PropertyMetadata(default(string)));

        public IEnumerable<Property> Properties
        {
            get { return (IEnumerable<Property>)GetValue(PropertiesProperty); }
            set { SetValue(PropertiesProperty, value); }
        }

        public static readonly DependencyProperty PropertiesProperty =
            DependencyProperty.Register("Properties", typeof(IEnumerable<Property>), typeof(BasicElementSuggestor), new PropertyMetadata(default(IEnumerable<Property>)));

        private static void OnAutomationElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (BasicElementSuggestor)d;
            if (control.AutomationElement == null)
            {
                control.SuggestedBasicElement = null;
                return;
            }

            if (control.AutomationElement.Current.ControlType == ControlType.Button)
                control.SuggestedBasicElement = new BasicButton(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.CheckBox)
                control.SuggestedBasicElement = new BasicCheckBox(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.ComboBox)
                control.SuggestedBasicElement = new BasicComboBox(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.Edit)
                control.SuggestedBasicElement = new BasicEdit(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.List)
                control.SuggestedBasicElement = new BasicList(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.DataGrid)
                control.SuggestedBasicElement = new BasicList(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.ListItem)
                control.SuggestedBasicElement = new BasicListItem(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.DataItem)
                control.SuggestedBasicElement = new BasicListItem(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.Menu)
                control.SuggestedBasicElement = new BasicMenu(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.MenuItem)
                control.SuggestedBasicElement = new BasicMenuItem(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.RadioButton)
                control.SuggestedBasicElement = new BasicRadioButton(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.Tab)
                control.SuggestedBasicElement = new BasicTabControl(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.TabItem)
                control.SuggestedBasicElement = new BasicTabItem(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.Text)
                control.SuggestedBasicElement = new BasicText(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.Tree)
                control.SuggestedBasicElement = new BasicTreeView(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.TreeItem)
                control.SuggestedBasicElement = new BasicTreeViewItem(control.AutomationElement);
            else if (control.AutomationElement.Current.ControlType == ControlType.Window)
                control.SuggestedBasicElement = new BasicWindow(control.AutomationElement);
            else
                control.SuggestedBasicElement = new BasicElement(control.AutomationElement);

            control.SuggestedBasicElementTitle = control.SuggestedBasicElement.GetType().ToString();
            control.Properties = null;
        }

        private void ButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            if (SuggestedBasicElement == null)
                return;

            var properties = SuggestedBasicElement.GetType().GetProperties();
            var propertyItems = new List<Property>();
            foreach (var property in properties)
            {
                var name = property.Name;

                if (name == "Unsafe" || name == "SupportedPatterns" || name == "Do" || name == "Properties")
                    continue;

                var value = property.GetValue(SuggestedBasicElement, null);
                propertyItems.Add(new Property { Name = property.Name, Value = value });
            }

            Properties = propertyItems;
        }
    }
}
