#region License
/*--------------------------------------------------------------------------------
    Copyright (c) 2012-2013 David Wendland

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
    THE SOFTWARE.
--------------------------------------------------------------------------------*/
#endregion License

using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace DW.CodedUI.Application
{
    /// <summary>
    /// Represents a single open WPF window
    /// </summary>
    /// <example>
    /// <code lang="cs">
    /// <![CDATA[
    /// [TestMethod]
    /// public void Method_TestCondition_ExpectedResult1()
    /// {
    ///     // do anything and a window appears
    /// 
    ///     var window = new TestableWindow("The title");
    /// 
    ///     // Assert anything in the window
    /// }
    /// ]]>
    /// </code>
    /// </example>
    [Obsolete("The TestableWindow is not supported anyore. Use the BasicWindow instead")]
    public class TestableWindow : WpfWindow
    {
        /// <summary>
        /// Initializes a new instance of the TestableWindow class
        /// </summary>
        /// <param name="title">The window title</param>
        /// <remarks>The window title has to match exactly and the first window instance is taken</remarks>
        public TestableWindow(string title)
            : this(title, 1, TitleSearchCondition.IsEqual)
        {
        }

        /// <summary>
        /// Initializes a new instance of the TestableWindow class
        /// </summary>
        /// <param name="title">The window title</param>
        /// <param name="instance">The window instance</param>
        /// <remarks>The window title has to match exactly</remarks>
        public TestableWindow(string title, int instance)
            : this(title, instance, TitleSearchCondition.IsEqual)
        {
        }

        /// <summary>
        /// Initializes a new instance of the TestableWindow class
        /// </summary>
        /// <param name="title">The window title</param>
        /// <param name="titleSearchCondition">How to compare the window title</param>
        /// <remarks>The first window instance is taken</remarks>
        public TestableWindow(string title, TitleSearchCondition titleSearchCondition)
            : this(title, 1, titleSearchCondition)
        {
        }

        /// <summary>
        /// Initializes a new instance of the TestableWindow class
        /// </summary>
        /// <param name="title">The window title</param>
        /// <param name="instance">The window instance</param>
        /// <param name="titleSearchCondition">How to compare the window title</param>
        public TestableWindow(string title, int instance, TitleSearchCondition titleSearchCondition)
        {
            SearchProperties[UITestControl.PropertyNames.Instance] = instance.ToString(CultureInfo.InvariantCulture);
            SearchProperties.Add(new PropertyExpression(UITestControl.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            SearchProperties.Add(new PropertyExpression(UITestControl.PropertyNames.Name, title, (PropertyExpressionOperator)titleSearchCondition));
        }
    }
}