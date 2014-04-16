using System;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using DW.CodedUI.Internal;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represends windows own dialogs.
    /// </summary>
    public class BasicDialog : BasicWindowBase
    {
#if TRIAL
        static BasicDialog()
        {
            License1.LicenseChecker.Validate();
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicWindow" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control</param>
        public BasicDialog(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);
        }

        /// <summary>
        /// Gets access to unsafe methods
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

        /// <summary>
        /// Contains unsafe methods for interact with the control directly
        /// </summary>
        public class UnsafeMethods
        {
            private readonly AutomationElement _automationElement;

            internal UnsafeMethods(AutomationElement automationElement)
            {
                _automationElement = automationElement;
            }

            /// <summary>
            /// Closes the dialog.
            /// </summary>
            public void Close()
            {
                WinApi.SendMessage(new HandleRef(null, new IntPtr(_automationElement.Current.NativeWindowHandle)), WinApi.ID_Close, IntPtr.Zero, IntPtr.Zero);
            }
        }
    }
}
