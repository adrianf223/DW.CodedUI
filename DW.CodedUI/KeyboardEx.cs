using System.Windows.Input;
using DW.CodedUI.BasicElements;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

namespace DW.CodedUI
{
    public static class KeyboardEx
    {
        public static int SendKeysDelay
        {
            get { return Keyboard.SendKeysDelay; }
            set { Keyboard.SendKeysDelay = value; }
        }

        public static CombinableDo PressModifierKeys(BasicElement control, ModifierKeys keys)
        {
            control.AutomationElement.SetFocus();
            Keyboard.PressModifierKeys(keys);
            return new CombinableDo();
        }

        public static CombinableDo ReleaseModifierKeys(BasicElement control, ModifierKeys keys)
        {
            control.AutomationElement.SetFocus();
            Keyboard.ReleaseModifierKeys(keys);
            return new CombinableDo();
        }

        public static CombinableDo SendKeys(BasicElement control, string text)
        {
            SendKeys(control, text, ModifierKeys.None);
            return new CombinableDo();
        }

        public static CombinableDo SendKeys(BasicElement control, string text, ModifierKeys modifierKeys)
        {
            control.AutomationElement.SetFocus();
            Keyboard.SendKeys(text, modifierKeys);
            return new CombinableDo();
        }

        public static CombinableDo PressModifierKeys(ModifierKeys keys)
        {
            Keyboard.PressModifierKeys(keys);
            return new CombinableDo();
        }

        public static CombinableDo ReleaseModifierKeys(ModifierKeys keys)
        {
            Keyboard.ReleaseModifierKeys(keys);
            return new CombinableDo();
        }

        public static CombinableDo SendKeys(string text)
        {
            Keyboard.SendKeys(text);
            return new CombinableDo();
        }

        public static CombinableDo SendKeys(string text, bool isEncoded)
        {
            Keyboard.SendKeys(text, isEncoded);
            return new CombinableDo();
        }

        public static CombinableDo SendKeys(string text, ModifierKeys modifierKeys)
        {
            Keyboard.SendKeys(text, modifierKeys);
            return new CombinableDo();
        }

        public static CombinableDo SendKeys(string text, ModifierKeys modifierKeys, bool isEncoded)
        {
            Keyboard.SendKeys(text, modifierKeys, isEncoded);
            return new CombinableDo();
        }

        public static CombinableDo SendKeys(string text, ModifierKeys modifierKeys, bool isEncoded, bool isUnicode)
        {
            Keyboard.SendKeys(text, modifierKeys, isEncoded, isUnicode);
            return new CombinableDo();
        }
    }
}