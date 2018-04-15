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
    /// Represents errors that occur if an window, dialog or messagebox cannot be found.
    /// </summary>
    public class WindowNotFoundException : LoggedException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.WindowNotFoundException" /> class.
        /// </summary>
        /// <param name="use">The conditions how the window has been searched.</param>
        /// <param name="useTimeout">A value that indicates if a timeout was used.</param>
        /// <param name="useInterval">A value that indicates if an interval was used.</param>
        /// <param name="intervalTime">The time used in the interval.</param>
        /// <param name="timeout">The elapsed search time.</param>
        /// <param name="is">The relationship to another object.</param>
        public WindowNotFoundException(Use use, bool useTimeout, bool useInterval, uint intervalTime, TimeSpan timeout, Is @is)
            : base(MessageBuilder.BuildErrorMessage(use, useTimeout, useInterval, intervalTime, timeout, @is))
        {
        }
    }
}