#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2018 David Wendland

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

using System;
using System.Threading;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;
using WinModifierKeys = System.Windows.Input.ModifierKeys;

namespace DW.CodedUI
{
    /// <summary>
    /// Provides static methods for performing automated keyboard actions.
    /// </summary>
    /// <remarks>
    /// If typetext does not work as expected, check if System.Windows.Forms.SendKeys.SendWait is working. This is used internally.<br />
    /// In some cases an App.config file needs to be created for the test project to force the new implementation of that. See <a href="https://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.sendwait(v=vs.110).aspx">MSDN</a>.
    /// </remarks>
    public static class KeyboardEx
    {
        /// <summary>
        /// Presses and holds the given key down. Use <see cref="ReleaseKey(Key)" /> to release the key back again.
        /// </summary>
        /// <param name="key">The key to press and hold.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo PressKey(Key key)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Press key '{0}'.", key);
                WinApi.KeyboardEvent((byte)key, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);
            },
            string.Format("Cannot press down the key '{0}'.", key));
        }

        /// <summary>
        /// Presses and holds the given modifier keys down. Use <see cref="ReleaseKey(ModifierKeys)" /> to release the key back again.
        /// </summary>
        /// <param name="modifierKeys">The modifier keys to press and hold.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo PressKey(ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Press key '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);
            },
            string.Format("Cannot press down the modifier key '{0}'.", modifierKeys));
        }

        /// <summary>
        /// Presses and holds the given key and modifier keys down. Use <see cref="ReleaseKey(Key, ModifierKeys)" /> to release the key back again.
        /// </summary>
        /// <param name="key">The key to press and hold.</param>
        /// <param name="modifierKeys">The modifier keys to press and hold.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo PressKey(Key key, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Press keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);
                LogPool.Append("Press key '{0}'.", key);
                WinApi.KeyboardEvent((byte)key, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);
            },
            string.Format("Cannot press down the key '{0}' with the modifier keys '{1}'.", key, modifierKeys));
        }

        /// <summary>
        /// Gives the BasicElement the focus and presses and holds the given key down. Use <see cref="ReleaseKey(Key)" /> to release the key back again.
        /// </summary>
        /// <param name="control">The BasicElement who should get the focus before pressing the key.</param>
        /// <param name="key">The key to press and hold.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo PressKey(BasicElement control, Key key)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Press key '{0}'.", key);
                WinApi.KeyboardEvent((byte)key, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);
            },
            string.Format("Cannot press down the key '{0}' with the '{1}' focused.", key, control));
        }

        /// <summary>
        /// Gives the BasicElement the focus and presses and holds the given modifier keys down. Use <see cref="ReleaseKey(ModifierKeys)" /> to release the key back again.
        /// </summary>
        /// <param name="control">The BasicElement who should get the focus before pressing the key.</param>
        /// <param name="modifierKeys">The modifier keys to press and hold.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo PressKey(BasicElement control, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Press keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);
            },
            string.Format("Cannot press down the modifier keys '{0}' with the '{1}' focused.", modifierKeys, control));
        }

        /// <summary>
        /// Gives the BasicElement the focus and presses and holds the given key and modifier keys down. Use <see cref="ReleaseKey(Key, ModifierKeys)" /> to release the key back again.
        /// </summary>
        /// <param name="control">The BasicElement who should get the focus before pressing the key.</param>
        /// <param name="key">The key to press and hold.</param>
        /// <param name="modifierKeys">The modifier keys to press and hold.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo PressKey(BasicElement control, Key key, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Press keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);
                LogPool.Append("Press key '{0}'.", key);
                WinApi.KeyboardEvent((byte)key, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);
            },
            string.Format("Cannot press down the key '{0}' and the modifier keys '{1}' with the '{2}' focused.", key, modifierKeys, control));
        }

        /// <summary>
        /// Releases the key which got pressed before.
        /// </summary>
        /// <param name="key">The key to release.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo ReleaseKey(Key key)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Release key '{0}'.", key);
                WinApi.KeyboardEvent((byte)key, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY | WinApi.KeyboardEventFlags.KEYEVENTF_KEYUP);
            },
            string.Format("Cannot release the key '{0}'", key));
        }

        /// <summary>
        /// Releases the modifier key which got pressed before.
        /// </summary>
        /// <param name="modifierKeys">The modifier keys to release.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo ReleaseKey(ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Release keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY | WinApi.KeyboardEventFlags.KEYEVENTF_KEYUP);
            },
            string.Format("Cannot release the modifier key '{0}'", modifierKeys));
        }

        /// <summary>
        /// Releases the key and modifier keys which got pressed before.
        /// </summary>
        /// <param name="key">The key to release.</param>
        /// <param name="modifierKeys">The modifier keys to release.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo ReleaseKey(Key key, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Release key '{0}'.", key);
                WinApi.KeyboardEvent((byte)key, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY | WinApi.KeyboardEventFlags.KEYEVENTF_KEYUP);
                LogPool.Append("Release keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY | WinApi.KeyboardEventFlags.KEYEVENTF_KEYUP);
            },
            string.Format("Cannot release the key '{0}' and the modifier keys '{1}'", key, modifierKeys));
        }

        /// <summary>
        /// Types the given key.
        /// </summary>
        /// <param name="key">The key to type.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo TypeKey(Key key)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Type key '{0}'.", key);
                Type((byte)key);
            },
            string.Format("Cannot type the key '{0}'", key));
        }

        /// <summary>
        /// Types the given modifier keys.
        /// </summary>
        /// <param name="modifierKeys">The modifier keys to type.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo TypeKey(ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Type modifier keys '{0}'.", modifierKeys);
                Type((byte)modifierKeys);
            },
            string.Format("Cannot type the modifier keys '{0}'", modifierKeys));
        }

        /// <summary>
        /// Types the given key while holding the modifier keys.
        /// </summary>
        /// <param name="key">The key to type.</param>
        /// <param name="modifierKeys">The modifier keys to hold while typing.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        /// <remarks>Some combinations might not work because of a WinApi problem.<br />
        /// E.g. Shift+Arrow to select text, consider using KeyboardEx.TypeText("{LEFT}", ModifierKeys.Shift) instead.<br />
        /// See the possible parameter of the Windows Forms SendWait.</remarks>
        public static CombinableDo TypeKey(Key key, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Press keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);

                LogPool.Append("Type key '{0}'.", key);
                Type((byte)key);

                LogPool.Append("Release keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY | WinApi.KeyboardEventFlags.KEYEVENTF_KEYUP);
            },
            string.Format("Cannot type the key '{0}' and the pressed modifier keys '{1}'.", key, modifierKeys));
        }


        /// <summary>
        /// Gives the BasicElement the focus and types the given key.
        /// </summary>
        /// <param name="control">The BasicElement who should get the focus before typing the key.</param>
        /// <param name="key">The key to type.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo TypeKey(BasicElement control, Key key)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Type key '{0}'.", key);
                Type((byte)key);
            },
            string.Format("Cannot press down the key '{0}' with the '{1}' focused.", key, control));
        }

        /// <summary>
        /// Gives the BasicElement the focus and types the given modifier keys.
        /// </summary>
        /// <param name="control">The BasicElement who should get the focus before typing the key.</param>
        /// <param name="modifierKeys">The modifier keys to type.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo TypeKey(BasicElement control, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Type modifier keys '{0}'.", modifierKeys);
                Type((byte)modifierKeys);
            },
            string.Format("Cannot press down the modifier keys '{0}' with the '{1}' focused.", modifierKeys, control));
        }

        /// <summary>
        /// Gives the BasicElement the focus and holds the modifier keys while typing the given key.
        /// </summary>
        /// <param name="control">The BasicElement who should get the focus before typing the key.</param>
        /// <param name="key">The key to type.</param>
        /// <param name="modifierKeys">The modifier keys to hold while typing.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        /// <remarks>Some combinations might not work because of a WinApi problem.<br />
        /// E.g. Shift+Arrow to select text, consider using KeyboardEx.TypeText("{LEFT}", ModifierKeys.Shift) instead.<br />
        /// See the possible parameter of the Windows Forms SendWait.</remarks>
        public static CombinableDo TypeKey(BasicElement control, Key key, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Press keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);

                LogPool.Append("Type key '{0}'.", key);
                Type((byte)key);

                LogPool.Append("Release keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY | WinApi.KeyboardEventFlags.KEYEVENTF_KEYUP);
            },
            string.Format("Cannot type the key '{0}' and the pressed modifier keys '{1}' with the '{2}' focused.", key, modifierKeys, control));
        }

        /// <summary>
        /// Types the given text.
        /// </summary>
        /// <param name="text">The text to type.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo TypeText(string text)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Type text '{0}'.", text);
                SendText(text);
            },
            string.Format("Cannot send the text '{0}'", text));
        }

        /// <summary>
        /// Types the given text with a small delay time between each character.
        /// </summary>
        /// <param name="text">The text to type.</param>
        /// <param name="delay">The time to wait after each character in milliseconds.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo TypeText(string text, int delay)
        {
            if (delay < 1)
                return TypeText(text);

            return WrapIt(() =>
            {
                LogPool.Append("Type text '{0}' with a delay of {1} milliseconds.", text, delay);
                SendText(text, delay);
            },
            string.Format("Cannot send the text '{0}'", text));
        }

        /// <summary>
        /// Types the given text while holding the modifier keys.
        /// </summary>
        /// <param name="text">The text to type.</param>
        /// <param name="modifierKeys">The modifier keys to hold.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo TypeText(string text, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Press keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);

                LogPool.Append("Type text '{0}'.", text);
                SendText(text);

                LogPool.Append("Release keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY | WinApi.KeyboardEventFlags.KEYEVENTF_KEYUP);
            },
            string.Format("Cannot send the text '{0}' with the pressed modifier keys '{1}'", text, modifierKeys));
        }

        /// <summary>
        /// Types the given text while holding the modifier keys with a small delay time between each character.
        /// </summary>
        /// <param name="text">The text to type.</param>
        /// <param name="modifierKeys">The modifier keys to hold.</param>
        /// <param name="delay">The time to wait after each character in milliseconds.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo TypeText(string text, ModifierKeys modifierKeys, int delay)
        {
            if (delay < 1)
                return TypeText(text, modifierKeys);

            return WrapIt(() =>
            {
                LogPool.Append("Press keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);

                LogPool.Append("Type text '{0}' with a delay of {1} milliseconds.", text, delay);
                SendText(text, delay);

                LogPool.Append("Release keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY | WinApi.KeyboardEventFlags.KEYEVENTF_KEYUP);
            },
            string.Format("Cannot send the text '{0}' with the pressed modifier keys '{1}'", text, modifierKeys));
        }

        /// <summary>
        /// Gives the BasicElement the focus and types the given text.
        /// </summary>
        /// <param name="control">The BasicElement who should get the focus before typing the text.</param>
        /// <param name="text">The text to type.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo TypeText(BasicElement control, string text)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Type text '{0}'.", text);
                SendText(text);
            },
            string.Format("Cannot send the text '{0}' with the '{1} focused.'", text, control));
        }

        /// <summary>
        /// Gives the BasicElement the focus and types the given text with a small delay time between each character.
        /// </summary>
        /// <param name="control">The BasicElement who should get the focus before typing the text.</param>
        /// <param name="text">The text to type.</param>
        /// <param name="delay">The time to wait after each character in milliseconds.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo TypeText(BasicElement control, string text, int delay)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Type text '{0}' with a delay of {1} milliseconds.", text, delay);
                SendText(text, delay);
            },
            string.Format("Cannot send the text '{0}' with the '{1} focused.'", text, control));
        }

        /// <summary>
        /// Gives the BasicElement the focus and types the given text while holding the modifier keys.
        /// </summary>
        /// <param name="control">The BasicElement who should get the focus before typing the text.</param>
        /// <param name="text">The text to type.</param>
        /// <param name="modifierKeys">The modifier keys to hold.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo TypeText(BasicElement control, string text, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Press keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);

                LogPool.Append("Type text '{0}'.", text);
                SendText(text);

                LogPool.Append("Release keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY | WinApi.KeyboardEventFlags.KEYEVENTF_KEYUP);
            },
            string.Format("Cannot send the text '{0}' and the pressed modifier keys '{1}' with the '{2}' focused.", text, modifierKeys, control));
        }

        /// <summary>
        /// Gives the BasicElement the focus and types the given text while holding the modifier keys with a small delay time between each character.
        /// </summary>
        /// <param name="control">The BasicElement who should get the focus before typing the text.</param>
        /// <param name="text">The text to type.</param>
        /// <param name="modifierKeys">The modifier keys to hold.</param>
        /// <param name="delay">The time to wait after each character in milliseconds.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo TypeText(BasicElement control, string text, ModifierKeys modifierKeys, int delay)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Press keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);

                LogPool.Append("Type text '{0}' with a delay of {1} milliseconds.", text, delay);
                SendText(text, delay);

                LogPool.Append("Release keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY | WinApi.KeyboardEventFlags.KEYEVENTF_KEYUP);
            },
            string.Format("Cannot send the text '{0}' and the pressed modifier keys '{1}' with the '{2}' focused.", text, modifierKeys, control));
        }

        private static CombinableDo WrapIt(Action action, string errorText)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                throw new LoggedException(string.Format("{0} See inner exception for details.", errorText), ex);
            }

            return new CombinableDo();
        }

        private static void Type(byte key)
        {
            WinApi.KeyboardEvent(key, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY);
            WinApi.KeyboardEvent(key, WinApi.KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY | WinApi.KeyboardEventFlags.KEYEVENTF_KEYUP);
        }

        private static void SendText(string text)
        {
            System.Windows.Forms.SendKeys.SendWait(text);
        }

        private static void SendText(string text, int delay)
        {
            foreach (var @char in text)
            {
                System.Windows.Forms.SendKeys.SendWait(@char.ToString());
                Thread.Sleep(delay);
            }
        }

        #region Downward compatibility
        /// <summary>
        /// Not supported anymore (it does nothing). Consider using the overloads with the delay parameter.
        /// </summary>
        [Obsolete("Not supported anymore (it does nothing). Consider using the overloads with the delay parameter.")]
        public static int SendKeysDelay { get; set; }

        /// <summary>
        ///"Not supported anymore (PressKey will be called).
        /// </summary>
        /// <param name="control">Forwarded to the PressKey method.</param>
        /// <param name="modifierKeys">Converted and forwarded to the ReleaseKey method.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        [Obsolete("Not supported anymore (PressKey will be called).")]
        public static CombinableDo PressModifierKeys(BasicElement control, WinModifierKeys modifierKeys)
        {
            if (modifierKeys == WinModifierKeys.None)
                return new CombinableDo();

            return PressKey(control, Convert(modifierKeys));
        }

        /// <summary>
        /// Not supported anymore (ReleaseKey will be called).
        /// </summary>
        /// <param name="control">Not used.</param>
        /// <param name="modifierKeys">Converted and forwarded to the ReleaseKey method.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        [Obsolete("Not supported anymore (ReleaseKey will be called).")]
        public static CombinableDo ReleaseModifierKeys(BasicElement control, WinModifierKeys modifierKeys)
        {
            if (modifierKeys == WinModifierKeys.None)
                return new CombinableDo();

            return ReleaseKey(Convert(modifierKeys));
        }

        /// <summary>
        /// Not supported anymore (TypeText will be called).
        /// </summary>
        /// <param name="control">Forwarded to the TypeText method.</param>
        /// <param name="text">Forwarded to the TypeText method.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        [Obsolete("Not supported anymore (TypeText will be called).")]
        public static CombinableDo SendKeys(BasicElement control, string text)
        {
            return TypeText(control, text);
        }

        /// <summary>
        /// Not supported anymore (TypeText will be called).
        /// </summary>
        /// <param name="control">Forwarded to the TypeText method.</param>
        /// <param name="text">Forwarded to the TypeText method.</param>
        /// <param name="modifierKeys">Converted and forwarded to the TypeText method.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        [Obsolete("Not supported anymore (TypeText will be called).")]
        public static CombinableDo SendKeys(BasicElement control, string text, WinModifierKeys modifierKeys)
        {
            if (modifierKeys == WinModifierKeys.None)
                return new CombinableDo();

            return TypeText(control, text, Convert(modifierKeys));
        }

        /// <summary>
        /// Not supported anymore (PressKey will be called).
        /// </summary>
        /// <param name="modifierKeys">Converted and forwarded to the PressKey method.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        [Obsolete("Not supported anymore (PressKey will be called).")]
        public static CombinableDo PressModifierKeys(WinModifierKeys modifierKeys)
        {
            if (modifierKeys == WinModifierKeys.None)
                return new CombinableDo();

            return PressKey(Convert(modifierKeys));
        }

        /// <summary>
        /// Not supported anymore (ReleaseKey will be called).
        /// </summary>
        /// <param name="modifierKeys">Converted and forwarded to the ReleaseKey method.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        [Obsolete("Not supported anymore (ReleaseKey will be called).")]
        public static CombinableDo ReleaseModifierKeys(WinModifierKeys modifierKeys)
        {
            if (modifierKeys == WinModifierKeys.None)
                return new CombinableDo();

            return ReleaseKey(Convert(modifierKeys));
        }

        /// <summary>
        /// Not supported anymore (TypeText will be called).
        /// </summary>
        /// <param name="text">Forwarded to the TypeText method.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        [Obsolete("Not supported anymore (TypeText will be called).")]
        public static CombinableDo SendKeys(string text)
        {
            return TypeText(text);
        }

        /// <summary>
        /// Not supported anymore (TypeText will be called).
        /// </summary>
        /// <param name="text">Forwarded to the TypeText method.</param>
        /// <param name="isEncoded">Not used.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        [Obsolete("Not supported anymore (TypeText will be called).")]
        public static CombinableDo SendKeys(string text, bool isEncoded)
        {
            return TypeText(text);
        }

        /// <summary>
        /// Not supported anymore (TypeText will be called).
        /// </summary>
        /// <param name="text">Forwarded to the TypeText method.</param>
        /// <param name="modifierKeys">Converted and forwarded to the TypeText method.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        [Obsolete("Not supported anymore (TypeText will be called).")]
        public static CombinableDo SendKeys(string text, WinModifierKeys modifierKeys)
        {
            if (modifierKeys == WinModifierKeys.None)
                return new CombinableDo();

            return TypeText(text, Convert(modifierKeys));
        }

        /// <summary>
        /// Not supported anymore (TypeText will be called).
        /// </summary>
        /// <param name="text">Forwarded to the TypeText method.</param>
        /// <param name="modifierKeys">Converted and forwarded to the TypeText method.</param>
        /// <param name="isEncoded">Not used.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        [Obsolete("Not supported anymore (TypeText will be called).")]
        public static CombinableDo SendKeys(string text, WinModifierKeys modifierKeys, bool isEncoded)
        {
            if (modifierKeys == WinModifierKeys.None)
                return new CombinableDo();

            return TypeText(text, Convert(modifierKeys));
        }

        /// <summary>
        /// Not supported anymore (TypeText will be called).
        /// </summary>
        /// <param name="text">Forwarded to the TypeText method.</param>
        /// <param name="modifierKeys">Converted and forwarded to the TypeText method.</param>
        /// <param name="isEncoded">Not used.</param>
        /// <param name="isUnicode">Not used.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        [Obsolete("Not supported anymore (TypeText will be called).")]
        public static CombinableDo SendKeys(string text, WinModifierKeys modifierKeys, bool isEncoded, bool isUnicode)
        {
            if (modifierKeys == WinModifierKeys.None)
                return new CombinableDo();

            return TypeText(text, Convert(modifierKeys));
        }

        private static ModifierKeys Convert(WinModifierKeys modifierKeys)
        {
            ModifierKeys converted = 0;
            if (modifierKeys.HasFlag(WinModifierKeys.Shift))
                converted |= ModifierKeys.Shift;
            if (modifierKeys.HasFlag(WinModifierKeys.Control))
                converted |= ModifierKeys.Control;
            if (modifierKeys.HasFlag(WinModifierKeys.Alt))
                converted |= ModifierKeys.Alt;
            if (modifierKeys.HasFlag(WinModifierKeys.Windows))
                converted |= ModifierKeys.Windows;
            return converted;
        }
        #endregion Downward compatibility
    }
}
