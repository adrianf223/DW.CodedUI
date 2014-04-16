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
#if TRIAL
        static KeyboardEx()
        {
            License1.LicenseChecker.Validate();
        }
#endif

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
            control.AutomationElement.SetFocus();
            Keyboard.PressModifierKeys(keys);
            return new CombinableDo();
        }

        /// <summary>
        /// Gives the passed control the focus and releases the specified keys that were previously pressed by using the DW.CodedUI.KeyboardEx.PressModifierKeys method.
        /// </summary>
        /// <param name="control">The basic element who has to get the focus first.</param>
        /// <param name="keys">The modifier keys to release.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo ReleaseModifierKeys(BasicElement control, ModifierKeys keys)
        {
            control.AutomationElement.SetFocus();
            Keyboard.ReleaseModifierKeys(keys);
            return new CombinableDo();
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
            control.AutomationElement.SetFocus();
            Keyboard.SendKeys(text, modifierKeys);
            return new CombinableDo();
        }

        /// <summary>
        /// Presses the specified modifier keys without releasing them.
        /// </summary>
        /// <param name="keys">The modifier keys to get hold while the text is written.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo PressModifierKeys(ModifierKeys keys)
        {
            Keyboard.PressModifierKeys(keys);
            return new CombinableDo();
        }

        /// <summary>
        /// Releases the specified keys that were previously pressed by using the DW.CodedUI.KeyboardEx.PressModifierKeys method.
        /// </summary>
        /// <param name="keys">The modifier keys to release.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo ReleaseModifierKeys(ModifierKeys keys)
        {
            Keyboard.ReleaseModifierKeys(keys);
            return new CombinableDo();
        }

        /// <summary>
        /// Sends keystrokes to generate the specified text string.
        /// </summary>
        /// <param name="text">The text for which to generate keystrokes.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo SendKeys(string text)
        {
            Keyboard.SendKeys(text);
            return new CombinableDo();
        }

        /// <summary>
        /// Sends keystrokes to generate the specified text string.
        /// </summary>
        /// <param name="text">The text for which to generate keystrokes.</param>
        /// <param name="isEncoded">True if the text is encoded; otherwise, false.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo SendKeys(string text, bool isEncoded)
        {
            Keyboard.SendKeys(text, isEncoded);
            return new CombinableDo();
        }

        /// <summary>
        /// Sends keystrokes to generate the specified text string.
        /// </summary>
        /// <param name="text">The text for which to generate keystrokes.</param>
        /// <param name="modifierKeys">The modifier keys to get hold while the text is written.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo SendKeys(string text, ModifierKeys modifierKeys)
        {
            Keyboard.SendKeys(text, modifierKeys);
            return new CombinableDo();
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
            Keyboard.SendKeys(text, modifierKeys, isEncoded);
            return new CombinableDo();
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
            Keyboard.SendKeys(text, modifierKeys, isEncoded, isUnicode);
            return new CombinableDo();
        }
    }
}