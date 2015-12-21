using System;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    /// TODO: Support XButton1 and XButton2, see WinApi.MouseEventDataXButtons
    [Flags]
    public enum MouseButtons : long
    {
        Left = WinApi.MouseEventFlags.LEFTDOWN | WinApi.MouseEventFlags.LEFTUP,
        Middle = WinApi.MouseEventFlags.MIDDLEDOWN | WinApi.MouseEventFlags.MIDDLEUP,
        Right = WinApi.MouseEventFlags.RIGHTDOWN | WinApi.MouseEventFlags.RIGHTUP,
        X1 = WinApi.MouseEventFlags.XDOWN | WinApi.MouseEventFlags.XUP,
        X2 = X1
    }
}