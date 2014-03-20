using System.Threading;
using DW.CodedUI.Application;
using DW.CodedUI.Interaction;
using DW.CodedUI.UITree;
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
            var app = ApplicationFactory.Launch(@"D:\Public Sources\DW.CodedUI\bin\AutomationElementFinder.exe");
            Thread.Sleep(3000);

            Assert.AreEqual("AutomationElementFinder", app.Title);

            MouseEx.Click(app.TitleBar);
            Thread.Sleep(3000);

            MouseEx.Click(app.MaximizeButton);
            Thread.Sleep(3000);

            MouseEx.Click(app.RestoreButton);
            Thread.Sleep(3000);

            MouseEx.Click(app.MinimizeButton);
            Thread.Sleep(3000);

            app.Unsafe.Normalize();
            Thread.Sleep(3000);

            MouseEx.Click(app.CloseButton);
        }

        [TestMethod]
        public void WindowFinder_StartMinimizeMaximizeAndClose()
        {
            var window = WindowFinder.Search("AutomationEle");
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
    }
}
