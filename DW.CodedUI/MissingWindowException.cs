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

namespace DW.CodedUI
{
    /// <summary>
    /// Represents errors that occur during searching for elements starting from a window.
    /// </summary>
    public class MissingWindowException : LoggedException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.MissingWindowException" /> class.
        /// </summary>
        /// <param name="lastWindow">True if the last window was tried to be used but is not there; false if its the main window.</param>
        public MissingWindowException(bool lastWindow)
            : base(BuildMessage(lastWindow))
        {
        }

        private static string BuildMessage(bool lastWindow)
        {
            if (lastWindow)
                return "There is no last window available; Either no WindowFinder.Search was run successfully or no BasicWindow got created with an existing item.";
            return "The MainWindow could not be determined. Either there is no last window or the process under test does not have a main window handle. The last window is set if a WindowFinder.Search was run successfully or a BasicWindow got created with an existing item.";
        }
    }
}
