using System;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Brings possibilities to bring all windows on top.
    /// </summary>
    public static class WindowFocus
    {
#if TRIAL
        static WindowFocus()
        {
            License1.License.Display();
        }
#endif

        /// <summary>
        /// Brings the given window on top.
        /// </summary>
        /// <typeparam name="TWindow">The type of the window passed. This can be a window, messagebox or system dialog.</typeparam>
        /// <param name="window">The window to be on top. This can be a window, messagebox or system dialog.</param>
        public static void BringOnTop<TWindow>(TWindow window) where TWindow : BasicWindowBase
        {
            WinApi.SetForegroundWindow((IntPtr)window.Properties.NativeWindowHandle);
        }
    }
}