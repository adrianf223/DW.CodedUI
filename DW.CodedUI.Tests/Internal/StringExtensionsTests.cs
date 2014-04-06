using DW.CodedUI.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Internal
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void Match_SourceStringIsNull_ReturnsFalse()
        {
            var matches = StringExtensions.Match(null, "asd", CompareKind.Contains);

            Assert.IsFalse(matches);
        }

        [TestMethod]
        public void Match_SearchPatternIsNull_ReturnsFalse()
        {
            var matches = StringExtensions.Match("asd", null, CompareKind.Contains);

            Assert.IsFalse(matches);
        }
    }
}
