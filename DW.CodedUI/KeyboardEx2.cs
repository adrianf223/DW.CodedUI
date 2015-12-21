using System;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;
using Key = DW.CodedUI.Key;
using ModifierKeys = DW.CodedUI.ModifierKeys;

namespace DW.CodedUI
{
    public static class KeyboardEx2
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
                WinApi.KeyboardEvent((byte)key, WinApi.KeyboardEventFlags.KeyDown);
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
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyDown);
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
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyDown);
                LogPool.Append("Press key '{0}'.", key);
                WinApi.KeyboardEvent((byte)key, WinApi.KeyboardEventFlags.KeyDown);
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
                WinApi.KeyboardEvent((byte)key, WinApi.KeyboardEventFlags.KeyDown);
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
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyDown);
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
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyDown);
                LogPool.Append("Press key '{0}'.", key);
                WinApi.KeyboardEvent((byte)key, WinApi.KeyboardEventFlags.KeyDown);
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
                WinApi.KeyboardEvent((byte)key, WinApi.KeyboardEventFlags.KeyUp);
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
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyUp);
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
                WinApi.KeyboardEvent((byte)key, WinApi.KeyboardEventFlags.KeyUp);
                LogPool.Append("Release keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyUp);
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
        /// Gives the BasicElement the focus and holds the modifier keys while typing the given key.
        /// </summary>
        /// <param name="control">The BasicElement who should get the focus before typing the key.</param>
        /// <param name="key">The key to type.</param>
        /// <param name="modifierKeys">The modifier keys to hold while typing.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo TypeKey(BasicElement control, Key key, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Press keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyDown);

                LogPool.Append("Type key '{0}'.", key);
                Type((byte)key);

                LogPool.Append("Release keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyUp);
            },
            string.Format("Cannot type the key '{0}' and the pressed modifier keys '{1}' with the '{2}' focused.", key, modifierKeys, control));
        }


        /// <summary>
        /// Types the given text.
        /// </summary>
        /// <param name="text">The text to type.</param>
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
        public static CombinableDo TypeText(string text, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Press keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyDown);

                LogPool.Append("Type text '{0}'.", text);
                SendText(text);

                LogPool.Append("Release keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyUp);
            },
            string.Format("Cannot send the text '{0}' with the pressed modifier keys '{1}'", text, modifierKeys));
        }

        /// <summary>
        /// Types the given text while holding the modifier keys with a small delay time between each character.
        /// </summary>
        /// <param name="text">The text to type.</param>
        /// <param name="modifierKeys">The modifier keys to hold.</param>
        /// <param name="delay">The time to wait after each character in milliseconds.</param>
        public static CombinableDo TypeText(string text, ModifierKeys modifierKeys, int delay)
        {
            if (delay < 1)
                return TypeText(text, modifierKeys);

            return WrapIt(() =>
            {
                LogPool.Append("Press keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyDown);

                LogPool.Append("Type text '{0}' with a delay of {1} milliseconds.", text, delay);
                SendText(text, delay);

                LogPool.Append("Release keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyUp);
            },
            string.Format("Cannot send the text '{0}' with the pressed modifier keys '{1}'", text, modifierKeys));
        }

        /// <summary>
        /// Gives the BasicElement the focus and types the given text.
        /// </summary>
        /// <param name="control">The BasicElement who should get the focus before typing the text.</param>
        /// <param name="text">The text to type.</param>
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
        public static CombinableDo TypeText(BasicElement control, string text, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Press keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyDown);

                LogPool.Append("Type text '{0}'.", text);
                SendText(text);

                LogPool.Append("Release keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyUp);
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
        public static CombinableDo TypeText(BasicElement control, string text, ModifierKeys modifierKeys, int delay)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Set control focus for keyboard inputs on '{0}'.", control);
                control.AutomationElement.SetFocus();

                LogPool.Append("Press keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyDown);

                LogPool.Append("Type text '{0}' with a delay of {1} milliseconds.", text, delay);
                SendText(text, delay);

                LogPool.Append("Release keys '{0}'.", modifierKeys);
                WinApi.KeyboardEvent((byte)modifierKeys, WinApi.KeyboardEventFlags.KeyUp);
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
            WinApi.KeyboardEvent(key, WinApi.KeyboardEventFlags.KeyDown);
            WinApi.KeyboardEvent(key, WinApi.KeyboardEventFlags.KeyUp);
        }

        private static void SendText(string text)
        {
            SendKeys.SendWait(text);
        }

        private static void SendText(string text, int delay)
        {
            foreach (var @char in text)
            {
                SendKeys.SendWait(@char.ToString());
                Thread.Sleep(delay);
            }
        }
    }
}
