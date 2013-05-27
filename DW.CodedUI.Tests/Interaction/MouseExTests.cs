using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Interaction;
using DW.CodedUI.UITree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Interaction
{
    // ReSharper disable InconsistentNaming

    [TestClass]
    public class MouseExTests
    {
        private BasicWindow _window;

        [TestInitialize]
        public void Setup()
        {
            _window = ApplicationFactory.Launch(ApplicationInfo.ExecutablePath);
        }

        [TestMethod]
        public void Method_TestCondition_ExpectedResult()
        {
            var button = BasicElementFinder.FindChildByAutomationId<BasicButton>(_window, "ButtonId");

            MouseEx.Click(button, At.BottomRight(20, 10));
        }
    }

    // ReSharper restore InconsistentNaming
}
