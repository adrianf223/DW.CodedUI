using System;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    // TODO: Support XButton1 and XButton2, see WinApi.MouseEventDataXButtons
    /// <summary>
    /// Represents mouse buttons.
    /// </summary>
    [Flags]
    public enum MouseButtons : long
    {
        /// <summary>
        /// The left mouse button.
        /// </summary>
        Left = WinApi.MouseEventFlags.LEFTDOWN | WinApi.MouseEventFlags.LEFTUP,

        /// <summary>
        /// The middle mouse button.
        /// </summary>
        Middle = WinApi.MouseEventFlags.MIDDLEDOWN | WinApi.MouseEventFlags.MIDDLEUP,

        /// <summary>
        /// The right mouse button.
        /// </summary>
        Right = WinApi.MouseEventFlags.RIGHTDOWN | WinApi.MouseEventFlags.RIGHTUP,

        /// <summary>
        /// The additional mouse button 1.
        /// </summary>
        X1 = WinApi.MouseEventFlags.XDOWN | WinApi.MouseEventFlags.XUP,

        /// <summary>
        /// The additional mouse button 2.
        /// </summary>
        X2 = X1
    }
}