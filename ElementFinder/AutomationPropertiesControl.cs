using System.Reflection;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using DW.CodedUI.BasicElements;

namespace ElementFinder
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
            // TODO: Put to separate thread

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

    public class BasicPropertiesControl : ItemsControl
    {
        static BasicPropertiesControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BasicPropertiesControl), new FrameworkPropertyMetadata(typeof(BasicPropertiesControl)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new Property();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is Property;
        }

        public AutomationElement Element
        {
            get { return (AutomationElement)GetValue(ElementProperty); }
            set { SetValue(ElementProperty, value); }
        }

        public static readonly DependencyProperty ElementProperty =
            DependencyProperty.Register("Element", typeof(AutomationElement), typeof(BasicPropertiesControl), new UIPropertyMetadata(OnElementChanged));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(BasicPropertiesControl), new PropertyMetadata(null));

        private static void OnElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (BasicPropertiesControl)d;
            control.ReadProperties();
        }

        private void ReadProperties()
        {
            // TODO: Put to separate thread

            Items.Clear();

            if (Element == null)
                return;

            var element = FindBasicElementByType(Element);
            if (element == null || !element.IsAvailable)
                return;

            var type = element.GetType();
            Title = type.ToString();
            var props = type.GetProperties();
            foreach (var prop in props)
                TakeProperty(prop.Name, GetPropertyValue(prop, element));
        }

        private static object GetPropertyValue(PropertyInfo prop, BasicElement element)
        {
            try
            {
                return prop.GetValue(element, null);
            }
            catch
            {
                return "<error>";
            }
        }

        private BasicElement FindBasicElementByType(AutomationElement element)
        {
            return null; // TODO: What about elements which does not exist? Like the maximize button on a window which is maximized already.

            // TODO: Get by supported patterns
            // TODO: Make it requestable by a button

            var controlType = element.Current.ControlType;
            if (controlType == ControlType.Button) return new BasicButton(element);
            //if (controlType == ControlType.Calendar) return new (element);
            if (controlType == ControlType.CheckBox) return new BasicCheckBox(element);
            if (controlType == ControlType.ComboBox) return new BasicComboBox(element);
            //if (controlType == ControlType.Custom) return new (element);
            //if (controlType == ControlType.DataGrid) return new (element);
            //if (controlType == ControlType.DataItem) return new (element);
            //if (controlType == ControlType.Document) return new (element);
            if (controlType == ControlType.Edit) return new BasicEdit(element);
            //if (controlType == ControlType.Group) return new (element);
            //if (controlType == ControlType.Header) return new (element);
            //if (controlType == ControlType.HeaderItem) return new (element);
            //if (controlType == ControlType.Hyperlink) return new (element);
            //if (controlType == ControlType.Image) return new (element);
            if (controlType == ControlType.List) return new BasicList(element);
            if (controlType == ControlType.ListItem) return new BasicListItem(element);
            if (controlType == ControlType.Menu) return new BasicMenu(element);
            //if (controlType == ControlType.MenuBar) return new (element);
            if (controlType == ControlType.MenuItem) return new BasicMenuItem(element);
            //if (controlType == ControlType.Pane) return new (element);
            //if (controlType == ControlType.ProgressBar) return new (element);
            if (controlType == ControlType.RadioButton) return new BasicRadioButton(element);
            //if (controlType == ControlType.ScrollBar) return new (element);
            //if (controlType == ControlType.SemanticZoom) return new (element);
            //if (controlType == ControlType.Separator) return new (element);
            //if (controlType == ControlType.Slider) return new (element);
            //if (controlType == ControlType.Spinner) return new (element);
            //if (controlType == ControlType.SplitButton) return new (element);
            //if (controlType == ControlType.StatusBar) return new (element);
            if (controlType == ControlType.Tab) return new BasicTabControl(element);
            if (controlType == ControlType.TabItem) return new BasicTabItem(element);
            //if (controlType == ControlType.Table) return new (element);
            if (controlType == ControlType.Text) return new BasicText(element);
            //if (controlType == ControlType.Thumb) return new (element);
            //if (controlType == ControlType.TitleBar) return new (element);
            //if (controlType == ControlType.ToolBar) return new (element);
            //if (controlType == ControlType.ToolTip) return new (element);
            if (controlType == ControlType.Tree) return new BasicTreeView(element);
            if (controlType == ControlType.TreeItem) return new BasicTreeViewItem(element);
            if (controlType == ControlType.Window) return new BasicWindow(element);
            return new BasicElement(element);
        }

        private void TakeProperty(string key, object value, bool highlight = false)
        {
            if (value == null)
                return;

            if (key == "Unsafe") return;
            if (key == "AutomationElement") return;
            if (key == "SupportedPatterns") return;
            if (key == "Properties") return;
            if (key == "Do") return;

            Items.Add(new Property { Title = key, Value = value.ToString(), Highlight = highlight });
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
