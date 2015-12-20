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

using System.Runtime.InteropServices;
using System.Windows.Input;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

namespace DW.CodedUI
{
    /// <summary>
    /// Provides static methods for performing automated keyboard actions.
    /// </summary>
    public static class KeyboardEx
    {
        /// <summary>
        /// Gets or sets the time to wait between sending keystrokes to the application.
        /// </summary>
        public static int SendKeysDelay
        {
            get { return Keyboard.SendKeysDelay; }
            set
            {
                LogPool.Append("Set the keyboard delay to '{0}'.", value);
                Keyboard.SendKeysDelay = value;
            }
        }

        /// <summary>
        /// Gives the passed control the focus and presses the specified modifier keys without releasing them.
        /// </summary>
        /// <param name="control">The basic element who has to get the focus first.</param>
        /// <param name="keys">The modifier keys to press.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo PressModifierKeys(BasicElement control, ModifierKeys keys)
        {
            return Do.Action(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Press keys '{0}'.", keys);
                Keyboard.PressModifierKeys(keys);

                WinApi.keybd_event(WinApi.KeyboardKey.UP, 0, WinApi.KeyboardEventFlags.KEY_DOWN_EVENT, 0);
            });
        }

        /// <summary>
        /// Gives the passed control the focus and releases the specified keys that were previously pressed by using the DW.CodedUI.KeyboardEx.PressModifierKeys method.
        /// </summary>
        /// <param name="control">The basic element who has to get the focus first.</param>
        /// <param name="keys">The modifier keys to release.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo ReleaseModifierKeys(BasicElement control, ModifierKeys keys)
        {
            return Do.Action(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Press keys '{0}'.", keys);
                Keyboard.ReleaseModifierKeys(keys);
            });
        }

        /// <summary>
        /// Gives the passed control the focus and send key commands to it.
        /// </summary>
        /// <param name="control">The basic element who has to get the focus first.</param>
        /// <param name="text">The text to be written into the focused element.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo SendKeys(BasicElement control, string text)
        {
            SendKeys(control, text, ModifierKeys.None);
            return new CombinableDo();
        }

        /// <summary>
        /// Gives the passed control the focus and send key commands with pressed modifier keys to it.
        /// </summary>
        /// <param name="control">The basic element who has to get the focus first.</param>
        /// <param name="text">The text to be written into the focused element.</param>
        /// <param name="modifierKeys">The modifier keys to get hold while the text is written.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo SendKeys(BasicElement control, string text, ModifierKeys modifierKeys)
        {
            return Do.Action(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                if (modifierKeys == ModifierKeys.None)
                    LogPool.Append("Send text '{0}'.", text);
                else
                    LogPool.Append("Send text '{0}' with the modifier keys '{1}'.", text, modifierKeys);
                System.Windows.Forms.SendKeys.SendWait(text);
                //TODO: Keyboard.SendKeys(text, modifierKeys);
            });
        }

        /// <summary>
        /// Presses the specified modifier keys without releasing them.
        /// </summary>
        /// <param name="keys">The modifier keys to get hold while the text is written.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo PressModifierKeys(ModifierKeys keys)
        {
            return Do.Action(() =>
            {
                LogPool.Append("Press keys '{0}'.", keys);
                Keyboard.PressModifierKeys(keys);
            });
        }

        /// <summary>
        /// Releases the specified keys that were previously pressed by using the DW.CodedUI.KeyboardEx.PressModifierKeys method.
        /// </summary>
        /// <param name="keys">The modifier keys to release.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo ReleaseModifierKeys(ModifierKeys keys)
        {
            return Do.Action(() =>
            {
                LogPool.Append("Release keys '{0}'.", keys);
                Keyboard.ReleaseModifierKeys(keys);
            });
        }

        /// <summary>
        /// Sends keystrokes to generate the specified text string.
        /// </summary>
        /// <param name="text">The text for which to generate keystrokes.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo SendKeys(string text)
        {
            return Do.Action(() =>
            {
                LogPool.Append("Send text '{0}'.", text);
                System.Windows.Forms.SendKeys.SendWait(text);
            });
        }

        /// <summary>
        /// Sends keystrokes to generate the specified text string.
        /// </summary>
        /// <param name="text">The text for which to generate keystrokes.</param>
        /// <param name="isEncoded">True if the text is encoded; otherwise, false.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo SendKeys(string text, bool isEncoded)
        {
            return Do.Action(() =>
            {
                LogPool.Append("Send text '{0}' (encoded '{1}').", text, isEncoded);
                Keyboard.SendKeys(text, isEncoded);
            });
        }

        /// <summary>
        /// Sends keystrokes to generate the specified text string.
        /// </summary>
        /// <param name="text">The text for which to generate keystrokes.</param>
        /// <param name="modifierKeys">The modifier keys to get hold while the text is written.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo SendKeys(string text, ModifierKeys modifierKeys)
        {
            return Do.Action(() =>
            {
                if (modifierKeys == ModifierKeys.None)
                    LogPool.Append("Send text '{0}'.", text);
                else
                    LogPool.Append("Send text '{0}' with the modifier keys '{1}'.", text, modifierKeys);
                Keyboard.SendKeys(text, modifierKeys);
            });
        }

        /// <summary>
        /// Sends keystrokes to generate the specified text string.
        /// </summary>
        /// <param name="text">The text for which to generate keystrokes.</param>
        /// <param name="modifierKeys">The modifier keys to get hold while the text is written.</param>
        /// <param name="isEncoded">True if the text is encoded; otherwise, false.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo SendKeys(string text, ModifierKeys modifierKeys, bool isEncoded)
        {
            return Do.Action(() =>
            {
                if (modifierKeys == ModifierKeys.None)
                    LogPool.Append("Send text '{0}' (encoded '{1}').", text, isEncoded);
                else
                    LogPool.Append("Send text '{0}' with the keys '{1}' (encoded '{2}').", text, modifierKeys, isEncoded);

                Keyboard.SendKeys(text, modifierKeys, isEncoded);
            });
        }

        /// <summary>
        /// Sends keystrokes to the provided control to generate the specified text string using the provided modifier keys and indicators for encoding and unicode.
        /// </summary>
        /// <param name="text">The text for which to generate keystrokes.</param>
        /// <param name="modifierKeys">The modifier keys to get hold while the text is written.</param>
        /// <param name="isEncoded">True if the text is encoded; otherwise, false.</param>
        /// <param name="isUnicode">True if the text is Unicode text; otherwise, false.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo SendKeys(string text, ModifierKeys modifierKeys, bool isEncoded, bool isUnicode)
        {
            return Do.Action(() =>
            {
                if (modifierKeys == ModifierKeys.None)
                    LogPool.Append("Send text '{0}' (encoded '{1}'; unicode '{2}').", text, isEncoded, isUnicode);
                else
                    LogPool.Append("Send text '{0}' with the keys '{1}' (encoded '{2}'; unicode '{3}').", text, modifierKeys, isEncoded, isUnicode);

                Keyboard.SendKeys(text, modifierKeys, isEncoded, isUnicode);
            });
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public const uint KEYEVENTF_KEYUP = 0x02;
        public const uint VK_SHIFT = 0x10;
        public const uint VK_CONTROL = 0x11;

        public static void PressKey(string key)
        {
            WinApi.keybd_event((byte)VK_SHIFT, 0, 0, 0);
        }

        public static void ReleaseKey(string key)
        {
            WinApi.keybd_event((byte)VK_SHIFT, 0, (int)KEYEVENTF_KEYUP, 0);
        }
    }
}
