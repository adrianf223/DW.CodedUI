using DW.CodedUI.Utilities;
using Microsoft.VisualStudio.TestTools.UITest.Common.UIMap;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class TryOut2 : CodedUIBase<UIMap>
    {
        [TestMethod]
        public void Method_TestCondition_ExpectedResult()
        {
            var map = UIMap;

            RefreshUIMap();
        }
    }

    // ReSharper restore InconsistentNaming
}
