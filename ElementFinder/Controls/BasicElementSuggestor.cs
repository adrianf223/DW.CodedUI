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

using System;
using System.Collections.Generic;
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

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(BasicElementSuggestor), new PropertyMetadata(default(string)));

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

            try
            {
                Message = string.Empty;
                Properties = null;

                if (!SuggestedBasicElement.IsAvailable)
                {
                    Message = "Element is not available anymore.";
                    return;
                }

                var properties = SuggestedBasicElement.GetType().GetProperties();
                var propertyItems = new List<Property>();
                foreach (var property in properties)
                {
                    var name = property.Name;

                    if (name == "Unsafe" || name == "SupportedPatterns" || name == "Do" || name == "Properties" || name == "AutomationElement")
                        continue;

                    var value = property.GetValue(SuggestedBasicElement, null);
                    propertyItems.Add(new Property {Name = property.Name, Value = value});
                }

                Properties = propertyItems;
            }
            catch (Exception ex)
            {
                Message = string.Format("Error: {0} ({1})", ex.Message, ex.GetType());
            }
        }
    }
}
