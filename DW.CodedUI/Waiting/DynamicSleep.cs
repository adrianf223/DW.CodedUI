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

using System.Threading;

namespace DW.CodedUI.Waiting
{
    // ReSharper disable UnusedMember.Global

    /// <summary>
    /// Brings possibility to have dynamic sleeps between test methods
    /// </summary>
    /// <example>
    /// <code lang="cs">
    /// <![CDATA[
    /// [ExecutionSpeed(Speed.MaximumSpeed)]
    /// public class TryOut
    /// {
    ///     [TestMethod]
    ///     public void Method_TestCondition_ExpectedResult()
    ///     {
    ///         DynamicSleep.Wait(); // Uses "MaximumSpeed" which is no wait
    ///     }
    /// 
    ///     [TestMethod]
    ///     [ExecutionSpeed(Speed.Slow)]
    ///     public void Method_TestCondition_ExpectedResult2()
    ///     {
    ///         DynamicSleep.Wait(); // Uses "Slow" which is one second
    ///     }
    /// }]]>
    /// </code>
    /// </example>
    public static class DynamicSleep
    {
        /// <summary>
        /// Let the thread sleep
        /// </summary>
        /// <remarks>The time to sleep is defined in the ExecutionSpeed attribute</remarks>
        public static void Wait()
        {
            Thread.Sleep(CodedUIConfiguration.GetSpeed());
        }
    }

    // ReSharper restore UnusedMember.Global
}
