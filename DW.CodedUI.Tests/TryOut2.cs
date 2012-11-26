using System.Windows;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Interaction;
using DW.CodedUI.UITree;
using DW.CodedUI.Utilities;
using DW.CodedUI.Waiting;
using Microsoft.VisualStudio.TestTools.UITest.Common.UIMap;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class TryOut2 : CodedUIBase<UIMap>
    {
        private WindowUnderTest _target;

        [TestInitialize]
        public void Setup()
        {
            _target = ApplicationFactory.Launch(@"Application Window Title",
                                                @"..\..\..\DW.CodedUI.Demo\bin\Debug\DW.CodedUI.Demo.exe");
        }

        [TestCleanup]
        [ExecutionSpeed(Speed.Fast)]
        public void TearDown()
        {
            var shutdownConfiguration = new ShutdownConfiguration();
            shutdownConfiguration.SetSetMessageBoxInfo(new MessageBoxInfo("Wurst1", MessageBoxResult.OK),
                                                       new MessageBoxInfo("Wurst2", MessageBoxResult.OK),
                                                       new MessageBoxInfo("Wurst3", MessageBoxResult.OK));
            var shutdown = new Shutdown(shutdownConfiguration);

            shutdown.CloseApplication(_target);
            DynamicSleep.Wait();
            shutdown.CleanMessageBoxes();
            DynamicSleep.Wait();
            shutdown.CloseApplication(_target);
        }

        [TestMethod]
        public void Method_TestCondition_ExpectedResult()
        {
            var map = UIMap;

            RefreshUIMap();
        }

        [TestMethod]
        [ExecutionSpeed(Speed.Slow)]
        public void Method_TestCondition_ExpectedResult1()
        {
            DynamicSleep.Wait();

            var comboBox = BasicElementFinder.FindChildByAutomationId<BasicComboBox>(_target, "DemoComboBox");
            MouseEx.Click(comboBox);

            DynamicSleep.Wait();

            var secondItem = BasicElementFinder.FindChildByAutomationId<BasicElement>(comboBox, "SecondItem");
            MouseEx.Click(secondItem);

            DynamicSleep.Wait();
        }

        [TestMethod]
        public void Method_TestCondition_ExpectedResult2()
        {
            var fileMenuItem = BasicElementFinder.FindChildByAutomationId<BasicMenuItem>(_target, "FileMenuItem");
            MouseEx.Click(fileMenuItem);

            var messageBoxMenuItem = BasicElementFinder.FindChildByAutomationId<BasicMenuItem>(fileMenuItem, "FileMessageBoxMenuItem");
            MouseEx.Click(messageBoxMenuItem);
        }
    }

    // ReSharper restore InconsistentNaming
}
