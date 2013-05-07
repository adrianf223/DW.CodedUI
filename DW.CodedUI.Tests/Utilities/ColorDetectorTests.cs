using System.Threading;
using System.Drawing;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.UITree;
using DW.CodedUI.Utilities;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Utilities
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class ColorDetectorTests
    {
        private BasicWindow _application;
        private BasicElement _element;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _element = BasicElementFinder.FindChildByAutomationId(_application, "ColoredRectangleId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Unsafe.Close();
        }

        [TestMethod]
        public void GetColor_Called_ReturnsElementColor()
        {
            var color = ColorDetector.GetColor(_element, 50, 50);

            Assert.AreEqual(Color.Red.ToArgb(), color.ToArgb());
        }
    }

    // ReSharper restore InconsistentNaming
}
