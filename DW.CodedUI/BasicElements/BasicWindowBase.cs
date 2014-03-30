using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.Internal;

namespace DW.CodedUI.BasicElements
{
    public abstract class BasicWindowBase : BasicElement
    {
        protected BasicWindowBase(AutomationElement element)
            : base(element)
        {
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

        public Process OwningProcess
        {
            get
            {
                uint processId = 0;
                WinApi.GetWindowThreadProcessId((IntPtr)AutomationElement.Current.NativeWindowHandle, out processId);
                return Process.GetProcessById((int)processId);
            }
        }

        public bool CanClicked
        {
            get
            {
                int result = (int)WinApi.GetWindowLongPtr((IntPtr)AutomationElement.Current.NativeWindowHandle, (int)WinApi.WindowLongFlags.GWL_STYLE);
                var isDisabled = (result & WinApi.WS_DISABLED) == WinApi.WS_DISABLED;
                return !isDisabled;
            }
        }
    }
}
