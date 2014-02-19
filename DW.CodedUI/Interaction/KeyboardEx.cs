using System.Windows.Input;
using DW.CodedUI.BasicElements;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

namespace DW.CodedUI.Interaction
{
    public static class KeyboardEx
    {
        public static int SendKeysDelay
        {
            get { return Keyboard.SendKeysDelay; }
            set { Keyboard.SendKeysDelay = value; }
        }

        public static void PressModifierKeys(BasicElement control, ModifierKeys keys)
        {
            control.AutomationElement.SetFocus();
            Keyboard.PressModifierKeys(keys);
        }

        public static void ReleaseModifierKeys(BasicElement control, ModifierKeys keys)
        {
            control.AutomationElement.SetFocus();
            Keyboard.ReleaseModifierKeys(keys);
        }

        public static void SendKeys(BasicElement control, string text)
        {
            SendKeys(control, text, ModifierKeys.None);
        }

        public static void SendKeys(BasicElement control, string text, ModifierKeys modifierKeys)
        {
            control.AutomationElement.SetFocus();
            Keyboard.SendKeys(text, modifierKeys);
        }
    }
}