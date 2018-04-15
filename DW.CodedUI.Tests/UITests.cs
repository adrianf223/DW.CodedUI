#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2018 David Wendland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE
*/
#endregion License

using System.Diagnostics;
using System.Linq;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests
{
    [TestClass]
    public class UITests
    {
        private static BasicWindow _mainWindow;
        private static BasicWindow _testWindow;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Do.Launch(TestData.ApplicationPath).And.Wait(1000);
            _mainWindow = WindowFinder.Search(Use.AutomationId(TestData.MainWindowAutomationId));
            var currentButton = UI.GetChild<BasicButton>(By.AutomationId("CUI_UITests_Button"), From.Element(_mainWindow));
            currentButton.Unsafe.Click();
            DynamicSleep.Wait(1000);
            _testWindow = WindowFinder.Search(Use.AutomationId("CUI_UITestsWindow"), And.NoAssert());
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            _testWindow.CloseButton.Unsafe.Click();
            DynamicSleep.Wait(1000);
            _mainWindow.CloseButton.Unsafe.Click();
            DynamicSleep.Wait(1000);
        }

        [TestMethod]
        public void GetChild_ByAutomationId_ReturnsFirstResult()
        {
            var panel = UI.GetChild(By.AutomationId("CUI_AutomationIdsPanel"), From.Element(_testWindow));

            var foundChild = UI.GetChild(By.AutomationId("CUI_Button", CompareKind.Contains), From.Element(panel), With.NoAssert());

            Assert.IsNotNull(foundChild);
            Assert.AreEqual("CUI_Button1", foundChild.AutomationId);
        }

        [TestMethod]
        public void GetChildren_ByAutomationId_ReturnsAllThreeButtons()
        {
            var panel = UI.GetChild(By.AutomationId("CUI_AutomationIdsPanel"), From.Element(_testWindow));

            var foundChild = UI.GetChildren(By.AutomationId("CUI_Button", CompareKind.Contains), From.Element(panel), With.NoAssert()).ToList();

            Assert.AreEqual(3, foundChild.Count);
            Assert.AreEqual("CUI_Button1", foundChild[0].AutomationId);
            Assert.AreEqual("CUI_Button2", foundChild[1].AutomationId);
            Assert.AreEqual("CUI_Button3", foundChild[2].AutomationId);
        }

        [TestMethod]
        public void GetChild_ByClassName_ReturnsFirstResult()
        {
            var panel = UI.GetChild(By.AutomationId("CUI_ClassNamesPanel"), From.Element(_testWindow));

            var foundChild = UI.GetChild<BasicButton>(By.ClassName("Button"), From.Element(panel), With.NoAssert());

            Assert.IsNotNull(foundChild);
            Assert.AreEqual("First", foundChild.Text);
        }

        [TestMethod]
        public void GetChildren_ByClassName_ReturnsAllThreeButtons()
        {
            var panel = UI.GetChild(By.AutomationId("CUI_ClassNamesPanel"), From.Element(_testWindow));

            var foundChild = UI.GetChildren<BasicButton>(By.ClassName("Button"), From.Element(panel), With.NoAssert()).ToList();

            Assert.AreEqual(3, foundChild.Count);
            Assert.AreEqual("First", foundChild[0].Text);
            Assert.AreEqual("Second", foundChild[1].Text);
            Assert.AreEqual("Third", foundChild[2].Text);
        }

        [TestMethod]
        public void GetChild_ByName_ReturnsFirstResult()
        {
            var panel = UI.GetChild(By.AutomationId("CUI_NamesPanel"), From.Element(_testWindow));

            var foundChild = UI.GetChild(By.Name("B-", CompareKind.StartsWith), From.Element(panel), With.NoAssert());

            Assert.IsNotNull(foundChild);
            
            Assert.AreEqual("B-First", foundChild.Name);
        }

        [TestMethod]
        public void GetChildren_ByName_ReturnsAllThreeButtons()
        {
            var panel = UI.GetChild(By.AutomationId("CUI_NamesPanel"), From.Element(_testWindow));

            var foundChild = UI.GetChildren(By.Name("B-", CompareKind.StartsWith), From.Element(panel), With.NoAssert()).ToList();

            Assert.AreEqual(6, foundChild.Count); // Duplicated because the button and its content both has the name start with "B-"
            Assert.AreEqual("B-First", foundChild[0].Name);
            Assert.AreEqual("B-First", foundChild[1].Name);
            Assert.AreEqual("B-Second", foundChild[2].Name);
            Assert.AreEqual("B-Second", foundChild[3].Name);
            Assert.AreEqual("B-Third", foundChild[4].Name);
            Assert.AreEqual("B-Third", foundChild[5].Name);
        }

        [TestMethod, ExpectedException(typeof(UIElementNotFoundException))]
        public void GetChild_SearchForNotExisting_RaisesElementNotFoundException()
        {
            UI.GetChild(By.AutomationId("CUI_GoHomeYouAreDrunk"), From.Element(_testWindow), With.Timeout(100));
        }

        [TestMethod]
        public void GetChild_SearchForNotExistingButExceptionsDeactivated_ReturnsNullInstead()
        {
            var basicElement = UI.GetChild(By.AutomationId("CUI_GoHomeYouAreDrunk"), From.Element(_testWindow), With.NoAssert().And.Timeout(100));

            Assert.IsNull(basicElement);
        }

        [TestMethod]
        public void GetChild_SearchForNotExistingAndDefinedTimeot_SearchesOnlyTheTimeoutTime()
        {
            var watch = new Stopwatch();
            watch.Start();

            UI.GetChild(By.AutomationId("CUI_GoHomeYouAreDrunk"), From.Element(_testWindow), With.Timeout(1000).And.NoAssert());

            watch.Stop();
            var elapsed = watch.Elapsed;
            Assert.IsTrue(elapsed.TotalMilliseconds > 900 && elapsed.TotalMilliseconds < 1100, elapsed.ToString());
        }
        
        [TestMethod]
        public void GetParent_FromAutomationIdButton_ReturnsTheRightPanel()
        {
            var button = UI.GetChild(By.AutomationId("CUI_Button", CompareKind.Contains), From.Element(_testWindow), With.NoAssert());

            var parentPanel = UI.GetParent(By.ClassName("Button"), From.Element(button));

            Assert.AreEqual("CUI_AutomationIdsPanel", parentPanel.AutomationId);
        }

        [TestMethod]
        public void GetFullUITree_CalledWithWindow_Returns12Buttons()
        {
            var tree = UI.GetFullUITreeData(_testWindow);

            var rootItems = tree.Children.ToList();

            Assert.AreEqual("TitleBar", rootItems[0].AutomationId);
            Assert.AreEqual("CUI_AutomationIdsPanel", rootItems[1].AutomationId);
            Assert.AreEqual("CUI_ClassNamesPanel", rootItems[2].AutomationId);
            Assert.AreEqual("CUI_NamesPanel", rootItems[3].AutomationId);

            var automationIdsElements = rootItems[1].Children.ToList();
            Assert.AreEqual("CUI_Button1", automationIdsElements[0].AutomationId);
            Assert.AreEqual("CUI_Button2", automationIdsElements[1].AutomationId);
            Assert.AreEqual("CUI_Button3", automationIdsElements[2].AutomationId);

            var classNameElements = rootItems[2].Children.ToList();
            Assert.AreEqual("Button", classNameElements[0].ClassName);
            Assert.AreEqual("First", classNameElements[0].Name);
            Assert.AreEqual("Button", classNameElements[1].ClassName);
            Assert.AreEqual("Second", classNameElements[1].Name);
            Assert.AreEqual("Button", classNameElements[2].ClassName);
            Assert.AreEqual("Third", classNameElements[2].Name);

            var nameElements = rootItems[3].Children.ToList();
            Assert.AreEqual("B-First", nameElements[0].Name);
            Assert.AreEqual("B-Second", nameElements[1].Name);
            Assert.AreEqual("B-Third", nameElements[2].Name);
        }
    }
}
