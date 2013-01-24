using System.Threading;
using System.Windows.Automation;
using System.Windows.Input;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Interaction;
using DW.CodedUI.UITree;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Interaction
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class KeyboardExTests
    {
        private TestableApplication _target;

        [TestInitialize]
        public void Setup()
        {
            _target = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _target.Shutdown();
        }

        [TestMethod]
        public void PressModifierKeys_Called_ElementGetsTheFocus()
        {
            var textBox = BasicElementFinder.FindChildByAutomationId<BasicEdit>(_target, "MultilineTextBoxId");

            KeyboardEx.PressModifierKeys(textBox, ModifierKeys.Shift);

            Assert.AreEqual(textBox.AutomationElement, AutomationElement.FocusedElement);
        }

        [TestMethod]
        public void PressModifierKeys_Called_ModifierKeyArePressed()
        {
            var textBox = BasicElementFinder.FindChildByAutomationId<BasicEdit>(_target, "MultilineTextBoxId");

            KeyboardEx.PressModifierKeys(textBox, ModifierKeys.Shift);

            Assert.AreEqual(ModifierKeys.Shift, System.Windows.Input.Keyboard.Modifiers);
        }

        [TestMethod]
        public void ReleaseModifierKeys_Called_ElementGetsTheFocus()
        {
            var textBox = BasicElementFinder.FindChildByAutomationId<BasicEdit>(_target, "MultilineTextBoxId");

            KeyboardEx.ReleaseModifierKeys(textBox, ModifierKeys.Shift);

            Assert.AreEqual(textBox.AutomationElement, AutomationElement.FocusedElement);
        }

        [TestMethod]
        public void ReleaseModifierKeys_Called_ModifierKeyArePressed()
        {
            var textBox = BasicElementFinder.FindChildByAutomationId<BasicEdit>(_target, "MultilineTextBoxId");
            KeyboardEx.PressModifierKeys(textBox, ModifierKeys.Shift);
            Assert.AreEqual(ModifierKeys.Shift, System.Windows.Input.Keyboard.Modifiers);

            KeyboardEx.ReleaseModifierKeys(textBox, ModifierKeys.Shift);

            Assert.AreEqual(ModifierKeys.None, System.Windows.Input.Keyboard.Modifiers);
        }

        [TestMethod]
        public void SendKeys_Called_ElementGetsTheFocus()
        {
            var textBox = BasicElementFinder.FindChildByAutomationId<BasicEdit>(_target, "MultilineTextBoxId");

            KeyboardEx.SendKeys(textBox, "Demo");

            Assert.AreEqual(textBox.AutomationElement, AutomationElement.FocusedElement);
        }

        [TestMethod]
        public void SendKeys_Called_WritesTheTextIntoTheTextBox()
        {
            var textBox = BasicElementFinder.FindChildByAutomationId<BasicEdit>(_target, "MultilineTextBoxId");

            KeyboardEx.SendKeys(textBox, "Appended");

            Assert.AreEqual("AppendedMultilineTextBoxText", textBox.Text);
        }

        [TestMethod]
        public void SendKeys_WithModifiers_RemovesPartOfTheText()
        {
            var textBox = BasicElementFinder.FindChildByAutomationId<BasicEdit>(_target, "MultilineTextBoxId");

            KeyboardEx.PressModifierKeys(textBox, ModifierKeys.Shift);
            KeyboardEx.SendKeys(textBox, KeyboardCommands.RightArrow);
            KeyboardEx.SendKeys(textBox, KeyboardCommands.RightArrow);
            KeyboardEx.SendKeys(textBox, KeyboardCommands.RightArrow);
            KeyboardEx.ReleaseModifierKeys(textBox, ModifierKeys.Shift);
            KeyboardEx.SendKeys(textBox, KeyboardCommands.Delete);

            Assert.AreEqual("tilineTextBoxText", textBox.Text);
        }
    }

    // ReSharper restore InconsistentNaming
}
