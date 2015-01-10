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

using System.Windows.Input;
using DW.CodedUI.BasicElements;
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
            set { Keyboard.SendKeysDelay = value; }
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
                control.AutomationElement.SetFocus();
                Keyboard.PressModifierKeys(keys);
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
                control.AutomationElement.SetFocus();
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
                control.AutomationElement.SetFocus();
                Keyboard.SendKeys(text, modifierKeys);
            });
        }

        /// <summary>
        /// Presses the specified modifier keys without releasing them.
        /// </summary>
        /// <param name="keys">The modifier keys to get hold while the text is written.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo PressModifierKeys(ModifierKeys keys)
        {
            return Do.Action(() => Keyboard.PressModifierKeys(keys));
        }

        /// <summary>
        /// Releases the specified keys that were previously pressed by using the DW.CodedUI.KeyboardEx.PressModifierKeys method.
        /// </summary>
        /// <param name="keys">The modifier keys to release.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo ReleaseModifierKeys(ModifierKeys keys)
        {
            return Do.Action(() => Keyboard.ReleaseModifierKeys(keys));
        }

        /// <summary>
        /// Sends keystrokes to generate the specified text string.
        /// </summary>
        /// <param name="text">The text for which to generate keystrokes.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo SendKeys(string text)
        {
            return Do.Action(() => Keyboard.SendKeys(text));
        }

        /// <summary>
        /// Sends keystrokes to generate the specified text string.
        /// </summary>
        /// <param name="text">The text for which to generate keystrokes.</param>
        /// <param name="isEncoded">True if the text is encoded; otherwise, false.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo SendKeys(string text, bool isEncoded)
        {
            return Do.Action(() => Keyboard.SendKeys(text, isEncoded));
        }

        /// <summary>
        /// Sends keystrokes to generate the specified text string.
        /// </summary>
        /// <param name="text">The text for which to generate keystrokes.</param>
        /// <param name="modifierKeys">The modifier keys to get hold while the text is written.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo SendKeys(string text, ModifierKeys modifierKeys)
        {
            return Do.Action(() => Keyboard.SendKeys(text, modifierKeys));
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
            return Do.Action(() => Keyboard.SendKeys(text, modifierKeys, isEncoded));
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
            return Do.Action(() => Keyboard.SendKeys(text, modifierKeys, isEncoded, isUnicode));
        }
    }
}
