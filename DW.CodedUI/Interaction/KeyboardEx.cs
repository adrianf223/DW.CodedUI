#region License
/*--------------------------------------------------------------------------------
    Copyright (c) 2012-2013 David Wendland

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
    THE SOFTWARE.
--------------------------------------------------------------------------------*/
#endregion License

using System.Windows.Input;
using DW.CodedUI.BasicElements;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace DW.CodedUI.Interaction
{
    // ReSharper disable UnusedMember.Global
    // ReSharper disable IntroduceOptionalParameters.Global
    // ReSharper disable MemberCanBePrivate.Global

    /// <summary>
    /// Enhances the static Keyboard class to send keys to basic elements
    /// </summary>
    public static class KeyboardEx
    {
        /// <summary>
        /// Gets or sets the delay between each key
        /// </summary>
        public static int SendKeysDelay
        {
            get { return Keyboard.SendKeysDelay; }
            set { Keyboard.SendKeysDelay = value; }
        }

        /// <summary>
        /// Focuses the given control and sends modifier keys
        /// </summary>
        /// <param name="control">The control which should receive the keys</param>
        /// <param name="keys">The modifier keys to press</param>
        public static void PressModifierKeys(BasicElement control, ModifierKeys keys)
        {
            control.AutomationElement.SetFocus();
            Keyboard.PressModifierKeys(keys);
        }

        /// <summary>
        /// Focuses the given control and sends release of modifier keys
        /// </summary>
        /// <param name="control">The control which should receive release</param>
        /// <param name="keys">The modifier keys to release</param>
        public static void ReleaseModifierKeys(BasicElement control, ModifierKeys keys)
        {
            control.AutomationElement.SetFocus();
            Keyboard.ReleaseModifierKeys(keys);
        }

        /// <summary>
        /// Focuses the given control and sends key commands to it
        /// </summary>
        /// <param name="control">The control which should receive the keys</param>
        /// <param name="text">The keys to send</param>
        public static void SendKeys(BasicElement control, string text)
        {
            SendKeys(control, text, ModifierKeys.None);
        }

        /// <summary>
        /// Focuses the given control and sends key commands to it
        /// </summary>
        /// <param name="control">The control which should receive the keys</param>
        /// <param name="text">The keys to send</param>
        /// <param name="modifierKeys">The pressed modifier keys until keys will be send</param>
        public static void SendKeys(BasicElement control, string text, ModifierKeys modifierKeys)
        {
            control.AutomationElement.SetFocus();
            Keyboard.SendKeys(text, modifierKeys);
        }
    }

    // ReSharper restore UnusedMember.Global
    // ReSharper restore IntroduceOptionalParameters.Global
    // ReSharper restore MemberCanBePrivate.Global
}