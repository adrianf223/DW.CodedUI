using DW.CodedUI.UITree;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.UITree
{
    [CodedUITest]
    public class WindowFinderTests
    {
        // TODO: Write tests

        [TestMethod]
        public void Method_TestCondition_ExpectedResult()
        {
            var window = WindowFinder.GetForegroundWindow();
            if (window != null)
            {
                var title = window.Title;
                int i = 0;
            }
        }
    }
}
