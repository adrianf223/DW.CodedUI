using DW.CodedUI.Utilities;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Utilities
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class CodedUIBaseTests
    {
        [TestMethod]
        public void UIMap_ReadSeveralTimes_ReturnsSameObjectEveryTimes()
        {
            var target = new TestableCodedUIBase();

            object old = null;
            for (var i = 0; i < 20; ++i)
            {
                if (old == null)
                {
                    old = target.Item();
                    continue;
                }
                Assert.AreSame(old, target.Item());
                old = target.Item();
            }
        }

        [TestMethod]
        public void RefreshUIMap_Called_CreatesNewObject()
        {
            var target = new TestableCodedUIBase();

            var item1 = target.Item();
            var item2 = target.Item();
            Assert.AreSame(item1, item2);

            target.CallRefreshUIMap();
            var item3 = target.Item();
            var item4 = target.Item();
            Assert.AreNotSame(item2, item3);
            Assert.AreSame(item3, item4);
        }
    }

    public class TestableCodedUIBase : CodedUIBase<object>
    {
        public object Item()
        {
            return UIMap;
        }

        public void CallRefreshUIMap()
        {
            RefreshUIMap();
        }
    }

    // ReSharper restore InconsistentNaming
}
