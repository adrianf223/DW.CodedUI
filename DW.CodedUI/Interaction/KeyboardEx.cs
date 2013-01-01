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
using Microsoft.VisualStudio.TestTools.UITesting;

namespace DW.CodedUI.Interaction
{
    public static class KeyboardEx
    {
        public static int SendKeysDelay
        {
            get { return Keyboard.SendKeysDelay; }
            set { Keyboard.SendKeysDelay = value; }
        }

        public static void PressModifierKeys(ModifierKeys keys)
        {
            Keyboard.PressModifierKeys(keys);
        }

        public static void PressModifierKeys(UITestControl testControl, ModifierKeys keys)
        {
            Keyboard.PressModifierKeys(testControl, keys);
        }

        public static void ReleaseModifierKeys(ModifierKeys keys)
        {
            Keyboard.ReleaseModifierKeys(keys);
        }

        public static void ReleaseModifierKeys(UITestControl testControl, ModifierKeys keys)
        {
            Keyboard.ReleaseModifierKeys(testControl, keys);
        }

        public static void SendKeys(string text)
        {
            SendKeys(text, ModifierKeys.None);
        }

        public static void SendKeys(string text, ModifierKeys modifierKeys)
        {
            Keyboard.SendKeys(text, modifierKeys);
        }

        public static void SendKeys(UITestControl control, string text)
        {
            SendKeys(control, text, ModifierKeys.None);
        }

        public static void SendKeys(UITestControl control, string text, ModifierKeys modifierKeys)
        {
            Keyboard.SendKeys(control, text, modifierKeys);
        }
    }
}