#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2015 David Wendland

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

using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;

namespace ElementFinder.Controls
{
    public class AutomationPropertiesControl : ItemsControl
    {
        static AutomationPropertiesControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AutomationPropertiesControl), new FrameworkPropertyMetadata(typeof(AutomationPropertiesControl)));
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
            DependencyProperty.Register("HideEmptyEntries", typeof(bool), typeof(AutomationPropertiesControl), new UIPropertyMetadata(OnElementChanged));

        public AutomationElement Element
        {
            get { return (AutomationElement)GetValue(ElementProperty); }
            set { SetValue(ElementProperty, value); }
        }

        public static readonly DependencyProperty ElementProperty =
            DependencyProperty.Register("Element", typeof(AutomationElement), typeof(AutomationPropertiesControl), new UIPropertyMetadata(OnElementChanged));

        private static void OnElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (AutomationPropertiesControl)d;
            control.ReadProperties();
        }

        private void ReadProperties()
        {
            Items.Clear();
            if (Element == null || !IsAvailable(Element))
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
            TakeProperty("Name", Element.Current.Name, true);
            TakeProperty("NativeWindowHandle", Element.Current.NativeWindowHandle);
            TakeProperty("Orientation", Element.Current.Orientation);
            TakeProperty("ProcessId", Element.Current.ProcessId);
            int i = 0;
            foreach (var pattern in Element.GetSupportedPatterns())
            {
                string title = string.Empty;
                if (i++ == 0)
                    title = "Supported Patterns";
                TakeProperty(title, pattern.ProgrammaticName);
            }
        }

        private void TakeProperty(string key, object value, bool highlight = false)
        {
            if (value == null)
            {
                if (!HideEmptyEntries)
                    Items.Add(new Property { Title = key, Value = value });
                return;
            }

            var valueAsString = value.ToString();
            if (HideEmptyEntries && string.IsNullOrWhiteSpace(valueAsString))
                return;

            Items.Add(new Property { Title = key, Value = value, Highlight = highlight });
        }

        private static bool IsAvailable(AutomationElement element)
        {
            try
            {
                var checkitemAvailbility = element.Current.FrameworkId;
            }
            catch (ElementNotAvailableException)
            {
                return false;
            }
            return true;
        }
    }
}
