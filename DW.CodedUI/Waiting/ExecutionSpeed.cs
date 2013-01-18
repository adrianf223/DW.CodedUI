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

namespace DW.CodedUI.Waiting
{
    // ReSharper disable UnusedMember.Global

    /// <summary>
    /// Attribute to define how long all DynamicSleep.Wait methods has to wait in the current focus
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
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExecutionSpeed : Attribute
    {
        /// <summary>
        /// Gets the time to wait
        /// </summary>
        public int Milliseconds { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ExecutionSpeed class
        /// </summary>
        /// <param name="milliseconds">The time to wait</param>
        public ExecutionSpeed(int milliseconds)
        {
            Milliseconds = milliseconds;
        }

        /// <summary>
        /// Initializes a new instance of the ExecutionSpeed class
        /// </summary>
        /// <param name="speed">The execution speed</param>
        public ExecutionSpeed(Speed speed)
        {
            switch (speed)
            {
                case Speed.Slow:
                    Milliseconds = 3000;
                    break;
                case Speed.Fast:
                    Milliseconds = 1000;
                    break;
                case Speed.MaximumSpeed:
                    Milliseconds = 0;
                    break;
            }
        }
    }

    // ReSharper restore UnusedMember.Global
}
