using System.Threading;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.UITree;
using DW.CodedUI.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Utilities
{
    [TestClass]
    public class HighlighterTests
    {
        private BasicWindow _application;
        private BasicButton _button;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _button = BasicElementFinder.FindChildByAutomationId<BasicButton>(_application, "ButtonId");
        }

        [TestMethod]
        public void Method_TestCondition_ExpectedResult()
        {
            _button.BeginHighlight();

            // Do anything else, the highlight is shown

            _button.EndHighlight();
        }

        [TestMethod]
        public void Method_TestCondition_ExpectedResult2()
        {
            var highlighter = new Highlighter();
            highlighter.Highlight(_button.AutomationElement);

            // Do anything else, the highlight is shown

            highlighter.Close();
        }
    }
}
