#region License

/*--------------------------------------------------------------------------------
    Copyright (c) 2012 David Wendland

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
    THE SOFTWARE.
--------------------------------------------------------------------------------*/

#endregion License

using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;

namespace AutomationElementFinder
{
    public class PropertiesControl : ItemsControl
    {
        static PropertiesControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertiesControl), new FrameworkPropertyMetadata(typeof(PropertiesControl)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new Property();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is Property;
        }

        public bool HideEmptyEntries
        {
            get { return (bool)GetValue(HideEmptyEntriesProperty); }
            set { SetValue(HideEmptyEntriesProperty, value); }
        }

        public static readonly DependencyProperty HideEmptyEntriesProperty =
            DependencyProperty.Register("HideEmptyEntries", typeof(bool), typeof(PropertiesControl), new UIPropertyMetadata(OnElementChanged));

        public AutomationElement Element
        {
            get { return (AutomationElement)GetValue(ElementProperty); }
            set { SetValue(ElementProperty, value); }
        }

        public static readonly DependencyProperty ElementProperty =
            DependencyProperty.Register("Element", typeof(AutomationElement), typeof(PropertiesControl), new UIPropertyMetadata(OnElementChanged));

        private static void OnElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (PropertiesControl)d;
            control.ReadProperties();
        }

        private void ReadProperties()
        {
            Items.Clear();
            if (Element == null || !Helper.IsAvailable(Element))
                return;

            TakeProperty("AcceleratorKey", Element.Current.AcceleratorKey);
            TakeProperty("AccessKey", Element.Current.AccessKey);
            TakeProperty("AutomationId", Element.Current.AutomationId, true);
            TakeProperty("BoundingRectangle", Element.Current.BoundingRectangle);
            TakeProperty("ClassName", Element.Current.ClassName);
            TakeProperty("ControlType", Element.Current.ControlType);
            TakeProperty("FrameworkId", Element.Current.FrameworkId);
            TakeProperty("HasKeyboardFocus", Element.Current.HasKeyboardFocus);
            TakeProperty("HelpText", Element.Current.HelpText);
            TakeProperty("IsContentElement", Element.Current.IsContentElement);
            TakeProperty("IsControlElement", Element.Current.IsControlElement);
            TakeProperty("IsEnabled", Element.Current.IsEnabled);
            TakeProperty("IsKeyboardFocusable", Element.Current.IsKeyboardFocusable);
            TakeProperty("IsOffscreen", Element.Current.IsOffscreen);
            TakeProperty("IsPassword", Element.Current.IsPassword);
            TakeProperty("IsRequiredForForm", Element.Current.IsRequiredForForm);
            TakeProperty("ItemStatus", Element.Current.ItemStatus);
            TakeProperty("ItemType", Element.Current.ItemType);
            TakeProperty("LabeledBy", Element.Current.LabeledBy);
            TakeProperty("LocalizedControlType", Element.Current.LocalizedControlType);
            TakeProperty("Name", Element.Current.Name);
            TakeProperty("NativeWindowHandle", Element.Current.NativeWindowHandle);
            TakeProperty("Orientation", Element.Current.Orientation);
            TakeProperty("ProcessId", Element.Current.ProcessId);
        }

        private void TakeProperty(string key, object value, bool highlight = false)
        {
            if (value == null)
            {
                if (HideEmptyEntries)
                    Items.Add(new Property { Title = key, Value = value });
                return;
            }

            var valueAsString = value.ToString();
            if (HideEmptyEntries && string.IsNullOrEmpty(valueAsString))
                return;

            Items.Add(new Property { Title = key, Value = value, Highlight = highlight });
        }
    }

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

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var button = GetTemplateChild("PART_Copy") as Button;
            if (button != null)
            {
                button.Click += HandleCopyClick;
            }
        }

        private void HandleCopyClick(object sender, RoutedEventArgs e)
        {
            if (Value == null)
                return;

            Clipboard.SetText(Value.ToString());
        }
    }
}
