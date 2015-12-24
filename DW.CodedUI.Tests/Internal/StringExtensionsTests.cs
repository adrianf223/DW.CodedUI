#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2016 David Wendland

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
