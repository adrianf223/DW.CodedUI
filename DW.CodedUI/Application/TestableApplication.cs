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
using System.Diagnostics;

namespace DW.CodedUI.Application
{
    // ReSharper disable UnusedMember.Global

    /// <summary>
    /// Represents the application under test
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
    public class TestableApplication : TestableWindow
    {
        private readonly Process _process;

        internal TestableApplication(string title, Process process, int instance)
            : base(title, instance)
        {
            _process = process;
        }

        /// <summary>
        /// Tries to close the main window of the application
        /// </summary>
        /// <returns>True if the close message was sent to the application successfully; otherwise false</returns>
        public bool Shutdown()
        {
            return _process.CloseMainWindow();
        }

        /// <summary>
        /// Getsthe application handle
        /// </summary>
        public IntPtr Handle
        {
            get { return _process.Handle; }
        }

        /// <summary>
        /// Gets the handle of the main window
        /// </summary>
        public IntPtr MainWindowHandle
        {
            get { return _process.MainWindowHandle; }
        }
    }
    
    // ReSharper restore UnusedMember.Global
}