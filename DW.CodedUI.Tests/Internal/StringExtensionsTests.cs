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

        [TestMethod]
        public void Match_WithContainsAndItReallyContains_ReturnsTrue()
        {
            var matches = StringExtensions.Match("Hans", "ns", CompareKind.Contains);

            Assert.IsTrue(matches);
        }

        [TestMethod]
        public void Match_WithContainsButDoesNotContain_ReturnsFalse()
        {
            var matches = StringExtensions.Match("Hans", "fri", CompareKind.Contains);

            Assert.IsFalse(matches);
        }

        [TestMethod]
        public void Match_WithContainsAndItReallyContainsButInWrongCase_ReturnsFalse()
        {
            var matches = StringExtensions.Match("Hans", "Ns", CompareKind.Contains);

            Assert.IsFalse(matches);
        }
    }
}
