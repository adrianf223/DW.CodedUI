using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.Internal;

namespace DW.CodedUI.BasicElements
{
    public class BasicDialog : BasicElement
    {
        public BasicDialog(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);
        }

        public UnsafeMethods Unsafe { get; private set; }

        public class UnsafeMethods
        {
            private readonly AutomationElement _automationElement;

            internal UnsafeMethods(AutomationElement automationElement)
            {
                _automationElement = automationElement;
            }

            public void Close()
            {
                WinApi.SendMessage(new HandleRef(null, new IntPtr(_automationElement.Current.NativeWindowHandle)), WinApi.ID_Close, IntPtr.Zero, IntPtr.Zero);
            }
        }

        public BasicButton CloseButton
        {
            get
            {
                var currentCulture = Thread.CurrentThread.CurrentCulture;
                if (currentCulture.Name == "de-DE")
                    return UI.GetChild<BasicButton>(By.Name("Schließen"), From.Element(this));
                return UI.GetChild<BasicButton>(By.Name("Close"), From.Element(this));
            }
        }

        public BasicElement TitleBar
        {
            get
            {
                return UI.GetChild(By.Condition(e => e.Properties.ControlType.Equals(ControlType.TitleBar)), From.Element(this));
            }
        }

        public string Title
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Name))
                    return Name;

                var strbTitle = new StringBuilder(255);
                WinApi.GetWindowText((IntPtr)AutomationElement.Current.NativeWindowHandle, strbTitle, strbTitle.Capacity + 1);
                return strbTitle.ToString();
            }
        }
    }
}
