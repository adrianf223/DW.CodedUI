using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Automation;
using DW.CodedUI.Internal;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents the base for the <see cref="DW.CodedUI.BasicElements.BasicWindow" /> and <see cref="DW.CodedUI.BasicElements.BasicMessageBox" />.
    /// </summary>
    public abstract class BasicWindowBase : BasicElement
    {
#if TRIAL
        static BasicWindowBase()
        {
            License1.License.Display();
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicWindow" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        protected BasicWindowBase(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the close button in the title bar of the normalized window.
        /// </summary>
        /// <remarks>Currently the button can be found only on English or German systems and if the <see cref="DW.CodedUI.BasicElements.BasicWindow.WindowState" /> is <see cref="DW.CodedUI.WindowState.Normal" />. If the system is another language consider using the <see cref="DW.CodedUI.UI" /> object with searching with <see cref="DW.CodedUI.By.Name(string)" />.</remarks>
        public BasicButton CloseButton
        {
            get
            {
                var closeButtonName = SystemStrings.GetString(SystemStrings.CloseButton);
                return UI.GetChild<BasicButton>(By.Name(closeButtonName), From.Element(this), With.NoTimeout());
            }
        }

        /// <summary>
        /// Gets the title bar of the window.
        /// </summary>
        public BasicElement TitleBar
        {
            get
            {
                return UI.GetChild(By.Condition(e => e.Properties.ControlType.Equals(ControlType.TitleBar)), From.Element(this), With.NoTimeout());
            }
        }

        /// <summary>
        /// Gets the title of the window.
        /// </summary>
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

        /// <summary>
        /// Gets the process the current window belongs to.
        /// </summary>
        public Process OwningProcess
        {
            get
            {
                uint processId = 0;
                WinApi.GetWindowThreadProcessId((IntPtr)AutomationElement.Current.NativeWindowHandle, out processId);
                return Process.GetProcessById((int)processId);
            }
        }

        /// <summary>
        /// Gets a value that indicates if the window can be clicked or not. This is false if the window is disabled e.g. if a modal window is opened.
        /// </summary>
        public bool CanClicked
        {
            get
            {
                var result = (int)WinApi.GetWindowLongPtr((IntPtr)AutomationElement.Current.NativeWindowHandle, (int)WinApi.WindowLongFlags.GWL_STYLE);
                var isDisabled = (result & WinApi.WS_DISABLED) == WinApi.WS_DISABLED;
                return !isDisabled;
            }
        }
    }
}
