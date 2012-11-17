using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Interop;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Interaction;
using DW.CodedUI.UITree;
using DW.CodedUI.Utilities;
using DW.CodedUI.Waiting;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    [ExecutionSpeed(Speed.MaximumSpeed)]
    public class TryOut
    {
        private WindowUnderTest _target;

        [TestInitialize]
        public void Setup()
        {
            _target = ApplicationFactory.Launch(@"Application Window Title",
                                                @"..\..\..\DW.CodedUI.Demo\bin\Debug\DW.CodedUI.Demo.exe");
        }

        [TestCleanup]
        public void TearDown()
        {
            var shutdown = new Shutdown(new ShutdownConfiguration());
            shutdown.CleanMessageBoxes();
            shutdown.CloseApplication(_target);
        }

        [TestMethod]
        public void WPFElementFinder_FindChild()
        {
            var fileMenuItem1 = WpfElementFinder.FindChildByAutomationId<WpfMenuItem>(_target, "FileMenuItem");

            var fileMenuItem2 = WpfElementFinder.FindChildByAutomationIdCondition<WpfMenuItem>(_target, i => i == "FileMenuItem");

            var fileMenuItem3 = WpfElementFinder.FindChildByType<WpfMenuItem>(_target);

            var fileMenuItem4 = WpfElementFinder.FindChildByName<WpfMenuItem>(_target, "FileMenuItem");

            var fileMenuItem5 = WpfElementFinder.FindChildByNameCondition<WpfMenuItem>(_target, i => i == "FileMenuItem");

            //fileMenuItem5.DrawHighlight();
        }

        [TestMethod]
        public void WPFElementFinder_FindChilds()
        {
            var fileMenuItems1 = WpfElementFinder.FindChildsByAutomationIdCondition<WpfMenuItem>(_target, i => i.Contains("MenuItem"));

            var fileMenuItems2 = WpfElementFinder.FindChildsByType<WpfMenuItem>(_target);

            var fileMenuItems3 = WpfElementFinder.FindChildsByNameCondition<WpfMenuItem>(_target, i => i.Contains("MenuItem"));
        }

        [TestMethod]
        public void BasicElementFinder_FindChild()
        {
            var fileMenuItem1 = BasicElementFinder.FindChildByAutomationId<BasicMenuItem>(_target, "FileMenuItem");

            var fileMenuItem2 = BasicElementFinder.FindChildByAutomationIdCondition<BasicMenuItem>(_target, i => i == "FileMenuItem");

            var fileMenuItem4 = BasicElementFinder.FindChildByName<BasicMenuItem>(_target, "FileMenuItem");

            var fileMenuItem5 = BasicElementFinder.FindChildByNameCondition<BasicMenuItem>(_target, i => i == "FileMenuItem");

            var fileMenuItem6 = BasicElementFinder.FindChildByClassName(_target, "MenuItem");

            var fileMenuItem7 = BasicElementFinder.FindChildByClassName<BasicMenuItem>(_target, "MenuItem");
        }

        [TestMethod]
        public void Method_TestCondition_ExpectedResult1()
        {
            var fileMenuItem = WpfElementFinder.FindChildByAutomationId<WpfMenuItem>(_target, "FileMenuItem");
            Mouse.Click(fileMenuItem);

            DynamicSleep.Wait();

            var openMenuItem = WpfElementFinder.FindChildByAutomationId<WpfMenuItem>(fileMenuItem, "FileOpenMenuItem");
            Mouse.Click(openMenuItem);
        }

        [TestMethod]
        [ExecutionSpeed(Speed.Slow)]
        public void Method_TestCondition_ExpectedResult2()
        {
            var fileMenuItem = BasicElementFinder.FindChildByAutomationId<BasicMenuItem>(_target, "FileMenuItem");
            fileMenuItem.BeginHighlight();
            MouseEx.Click(fileMenuItem);

            DynamicSleep.Wait();

            var openMenuItem = BasicElementFinder.FindChildByAutomationId<BasicMenuItem>(fileMenuItem, "FileOpenMenuItem");
            openMenuItem.BeginHighlight();
            MouseEx.Click(openMenuItem);

            fileMenuItem.EndHighlight();
            openMenuItem.EndHighlight();
        }
    }

    // ReSharper restore InconsistentNaming
}
