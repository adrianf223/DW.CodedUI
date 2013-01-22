using System.Threading;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.UITree;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.BasicElements
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class BasicTextTests
    {
        private TestableApplication _application;
        private BasicText _textBlock;
        private BasicText _label;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _textBlock = BasicElementFinder.FindChildByAutomationId<BasicText>(_application, "TextBlockId");
            _label = BasicElementFinder.FindChildByAutomationId<BasicText>(_application, "LabelId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Shutdown();
        }

        [TestMethod]
        public void Text_Getted_ReturnsWrittenText()
        {
            Assert.AreEqual("TextBlockText", _textBlock.Text);
            Assert.AreEqual("LabelText", _label.Text);
        }
    }

    // ReSharper restore InconsistentNaming
}
