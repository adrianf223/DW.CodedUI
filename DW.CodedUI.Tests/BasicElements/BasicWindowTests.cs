﻿using System.Linq;
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
    public class BasicWindowTests
    {
        private BasicWindow _target;

        [TestInitialize]
        public void Setup()
        {
            _target = ApplicationFactory.Launch(ApplicationInfo.ExecutablePath, ApplicationInfo.FastStartArguments, timeout: 10000);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_target.IsAvailable)
                _target.Unsafe.Close();
        }

        [TestMethod]
        public void Maximize_Called_MaximizesWindow()
        {
            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Normal, _target.WindowState);

            _target.Maximize();

            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Maximized, _target.WindowState);
        }

        [TestMethod]
        public void Minimize_Called_MinimizesWindow()
        {
            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Normal, _target.WindowState);

            _target.Minimize();

            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Minimized, _target.WindowState);
        }

        [TestMethod]
        public void Normalize_WindowIsMinimizes_NormalizesWindow()
        {
            Thread.Sleep(200);
            _target.Minimize();
            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Minimized, _target.WindowState);

            _target.Normalize();

            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Normal, _target.WindowState);
        }

        [TestMethod]
        public void Normalize_WindowIsMaximized_NormaizesWindow()
        {
            Thread.Sleep(200);
            _target.Maximize();
            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Maximized, _target.WindowState);

            _target.Normalize();

            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Normal, _target.WindowState);
        }

        [TestMethod]
        public void Title_Get_ReturnsWindowTitle()
        {
            Assert.AreEqual(_target.Title, ApplicationInfo.WindowTitle);
        }

        [TestMethod]
        public void WindowState_Get_ReturnsActualState()
        {
            Thread.Sleep(200);
            _target.Maximize();
            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Maximized, _target.WindowState);
            Thread.Sleep(200);
            _target.Minimize();
            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Minimized, _target.WindowState);
            Thread.Sleep(200);
            _target.Normalize();
            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Normal, _target.WindowState);
        }

        [TestMethod]
        public void UnsafeMaximize_Called_MaximizesWindow()
        {
            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Normal, _target.WindowState);

            _target.Unsafe.Maximize();

            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Maximized, _target.WindowState);
        }

        [TestMethod]
        public void UnsafeMinimize_Called_MinimizesWindow()
        {
            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Normal, _target.WindowState);

            _target.Unsafe.Minimize();

            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Minimized, _target.WindowState);
        }

        [TestMethod]
        public void UnsafeNormalize_WindowIsMinimizes_NormalizesWindow()
        {
            Thread.Sleep(200);
            _target.Unsafe.Minimize();
            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Minimized, _target.WindowState);

            _target.Unsafe.Normalize();

            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Normal, _target.WindowState);
        }

        [TestMethod]
        public void UnsafeNormalize_WindowIsMaximized_NormaizesWindow()
        {
            Thread.Sleep(200);
            _target.Unsafe.Maximize();
            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Maximized, _target.WindowState);

            _target.Unsafe.Normalize();

            Thread.Sleep(200);
            Assert.AreEqual(WindowState.Normal, _target.WindowState);
        }

        [TestMethod]
        public void UnsafeClose_Called_ClosesWindow()
        {
            _target.Unsafe.Close();

            Assert.IsFalse(_target.IsAvailable);
        }

        [TestMethod]
        public void CanClicked_ModalChildWindowIsOpen_ReturnsFalse()
        {
            var button = BasicElementFinder.FindChildByAutomationId<BasicButton>(_target, "ShowModalChild");
            button.Unsafe.Click();

            var clickable = _target.CanClicked;

            Assert.IsFalse(clickable);
        }

        [TestMethod]
        public void CanClicked_NonModalChildWindowIsOpen_ReturnsTrue()
        {
            var button = BasicElementFinder.FindChildByAutomationId<BasicButton>(_target, "ShowNonModalChild");
            button.Unsafe.Click();

            var clickable = _target.CanClicked;

            Assert.IsTrue(clickable);
        }

        [TestMethod]
        public void CanClicked_NoChildWindowIsOpen_ReturnsTrue()
        {
            var clickable = _target.CanClicked;

            Assert.IsTrue(clickable);
        }

        [TestMethod]
        public void GetChildWindows_NoChildWindowIsOpen_ReturnsEmptyList()
        {
            var childWindows = _target.GetChildWindows();

            Assert.IsFalse(childWindows.Any());
        }

        [TestMethod]
        public void GetChildWindows_TwoChildWindowsAreOpen_ReturnsListOfTwoBasicWindow()
        {
            var button = BasicElementFinder.FindChildByAutomationId<BasicButton>(_target, "ShowNonModalChild");
            button.Unsafe.Click();
            button.Unsafe.Click();

            var childWindows = _target.GetChildWindows();

            Assert.AreEqual(2, childWindows.Count());
        }
    }

    // ReSharper restore InconsistentNaming
}