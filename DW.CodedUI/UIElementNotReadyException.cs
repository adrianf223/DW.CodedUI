#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2018 David Wendland

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

using System;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    /// <summary>
    /// Represents errors that occur if an element got found in the UI but became not ready to use.
    /// </summary>
    public class UIElementNotReadyException : LoggedException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.UIElementNotReadyException" /> class.
        /// </summary>
        /// <param name="isEnabled">A value that indicates if the element was enabled.</param>
        /// <param name="isVisible">A value that indicates if the element was visible.</param>
        /// <param name="by">The conditions how the element has been searched.</param>
        /// <param name="useTimeout">A value that indicates if a timeout was used.</param>
        /// <param name="useInterval">A value that indicates if an interval was used.</param>
        /// <param name="intervalTime">The time used in the interval.</param>
        /// <param name="timeout">The elapsed search time.</param>
        /// <param name="multiply">A value that indicates if one or multiple elements has been searched.</param>
        public UIElementNotReadyException(bool isEnabled, bool isVisible, By by, bool useTimeout, bool useInterval, uint intervalTime, TimeSpan timeout, bool multiply)
            : base(MessageBuilder.BuildErrorMessage(isEnabled, isVisible, by, useTimeout, useInterval, intervalTime, timeout, multiply))
        {
        }
    }
}
