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

using System.Diagnostics;

namespace DW.CodedUI.Application
{
    // ReSharper disable UnusedMember.Global

    /// <summary>
    /// Starts an application for test
    /// </summary>
    /// <example>
    /// <code lang="cs">
    /// <![CDATA[
    /// [CodedUITest]
    /// public class AnyWindowTests
    /// {
    ///     private TestableApplication _target;
    /// 
    ///     [TestInitialize]
    ///     public void Setup()
    ///     {
    ///         _target = ApplicationFactory.Launch(@"Application Window Title",
    ///                                             @"..\..\..\Anypath\MyApplication.exe");
    ///     }
    /// 
    ///     [TestCleanup]
    ///     public void Teatdown()
    ///     {
    ///         _target.Shutdown();
    ///     }
    /// 
    ///     [TestMethod]
    ///     public void Method_TestCondition_ExpectedResult()
    ///     {
    ///         var anyButton = BasicElementFinder.FindChildByAutomationId<BasicComboBox>(_target, "AnyButton");
    ///         
    ///         MouseEx.Click(anyButton);
    /// 
    ///         //Assert
    ///     }
    /// }]]>
    /// </code>
    /// </example>
    public static class ApplicationFactory
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        /// <param name="title">The title of the window which appears as soon the application has been started</param>
        /// <param name="applicationPath">The path to the application. (Can be relative)</param>
        /// <param name="instance">If there are multiple applications with the same title, this parameter says which instance should be used</param>
        /// <returns>The TestableApplication which can be used by other Coded UI tests</returns>
        public static TestableApplication Launch(string title, string applicationPath, int instance = 1)
        {
            var process = Process.Start(applicationPath);
            return new TestableApplication(title, process, instance);
        }
    }

    // ReSharper restore UnusedMember.Global
}
