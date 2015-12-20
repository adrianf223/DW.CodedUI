using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests
{
    [TestClass]
    public class KeyboardExTests
    {
        [TestInitialize]
        public void Setup()
        {
            //KeyboardEx.SendKeysDelay
            //public static CombinableDo PressModifierKeys(ModifierKeys keys)
            //public static CombinableDo PressModifierKeys(BasicElement control, ModifierKeys keys)

            //public static CombinableDo ReleaseModifierKeys(ModifierKeys keys)
            //public static CombinableDo ReleaseModifierKeys(BasicElement control, ModifierKeys keys)

            //public static CombinableDo SendKeys(string text)
            //public static CombinableDo SendKeys(string text, bool isEncoded)
            //public static CombinableDo SendKeys(string text, ModifierKeys modifierKeys)
            //public static CombinableDo SendKeys(string text, ModifierKeys modifierKeys, bool isEncoded)
            //public static CombinableDo SendKeys(string text, ModifierKeys modifierKeys, bool isEncoded, bool isUnicode)
            //public static CombinableDo SendKeys(BasicElement control, string text)
            //public static CombinableDo SendKeys(BasicElement control, string text, ModifierKeys modifierKeys)

            /*
            KeyboardEx.SendKeys(KeyboardEx.Keys.Up);
            KeyboardEx.PressKey(KeyboardEx.Keys.Up);
            KeyboardEx.ReleaseKey(KeyboardEx.Keys.Up);
            */
        }

        [TestMethod]
        public void methodname()
        {
            Do.Launch(@"C:\Windows\System32\notepad.exe").And.Wait(1000);
            var window = WindowFinder.Search(Use.Process("notepad"));

            //try
            //{
                KeyboardEx.PressKey("A"); // Hold shift
                KeyboardEx.SendKeys("demo");
                KeyboardEx.ReleaseKey("A");
            //}
            //catch (System.Exception ex)
            //{
            //    KeyboardEx.ReleaseKey("A");
            //}

        }
    }
}
