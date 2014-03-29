using System.Diagnostics;
using System.Threading;
using DW.CodedUI.BasicElements;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tryouts
{
    [CodedUITest]
    public class Tryout
    {
        [TestMethod]
        public void ApplicationFactory_StartMinimizeMaximizeAndClose()
        {
            Process.Start(@"D:\Public Sources\DW.CodedUI\bin\AutomationElementFinder.exe");
            Thread.Sleep(3000);

            var window = WindowFinder.Search(Using.Title("AutomationEle"));
            Thread.Sleep(3000);

            Assert.AreEqual("AutomationElementFinder", window.Title);

            var minimizeButton = UI.GetChild<BasicButton>(By.Name("blobb").And.AutomationId("Minimieren"), From.Element(window));
            minimizeButton = UI.GetChild<BasicButton>(By.Name("Minimieren"), From.Element(window), With.NoAssert().And.NoTimeout());
            minimizeButton = UI.GetChild<BasicButton>(By.Name("Minimieren"), From.Element(window), With.Timeout(3000).And.NoAssert());
            minimizeButton = UI.GetChild<BasicButton>(By.Name("Minimieren"), From.Element(window), With.Timeout(3000));
            minimizeButton = UI.GetChild<BasicButton>(By.Name("Minimieren"), From.Element(window), With.Assert().Timeout(1000));

            MouseEx.Click(minimizeButton);

            //MouseEx.Click(window.TitleBar);
            //Thread.Sleep(3000);

            //MouseEx.Click(window.MaximizeButton);
            //Thread.Sleep(3000);

            //MouseEx.Click(window.RestoreButton);
            //Thread.Sleep(3000);

            //MouseEx.Click(window.MinimizeButton);
            //Thread.Sleep(3000);

            //window.Unsafe.Normalize();
            //Thread.Sleep(3000);

            //MouseEx.Click(window.CloseButton);
        }

        [TestMethod]
        public void WindowFinder_StartMinimizeMaximizeAndClose()
        {
            Process.Start(@"D:\Public Sources\DW.CodedUI\bin\AutomationElementFinder.exe");
            Thread.Sleep(3000);

            var window = WindowFinder.Search(Using.Title("AutomationEle"), And.NoAssert());
            Thread.Sleep(3000);

            Assert.AreEqual("AutomationElementFinder", window.Title);

            MouseEx.Click(window.TitleBar);
            Thread.Sleep(3000);

            MouseEx.Click(window.MaximizeButton);
            Thread.Sleep(3000);
            MouseEx.Click(window.RestoreButton);
            Thread.Sleep(3000);
            MouseEx.Click(window.MinimizeButton);
            Thread.Sleep(3000);

            window.Unsafe.Normalize();
            Thread.Sleep(3000);

            MouseEx.Click(window.CloseButton);
        }

        [TestMethod]
        public void UIElementFinder_FindChild_FindsChild()
        {
            var window = WindowFinder.Search(Using.Title("AutomationEle"), And.Assert());
            Thread.Sleep(3000);

            var basicElement = UI.GetChild(By.Name("Read Siblings"), From.Element(window));

            MouseEx.Click(basicElement);
        }

        [TestMethod]
        public void UIElementFinder_FindParent_FindsParent()
        {
            var window = WindowFinder.Search(Using.Title("AutomationEle"), And.Assert());
            Thread.Sleep(3000);

            var basicElement = UI.GetChild(By.Name("Read Siblings"), From.Element(window));
            var parent = UI.GetParent<BasicWindow>(By.Name("AutomationElementFinder"), From.Element(basicElement));

            MouseEx.Click(parent);
        }
    }
}
