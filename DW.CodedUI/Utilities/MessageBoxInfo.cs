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

using System.Windows;

namespace DW.CodedUI.Utilities
{
    // ReSharper disable ClassNeverInstantiated.Global

    /// <summary>
    /// Represents the single information how a specific MessageBox should be closed
    /// </summary>
    public class MessageBoxInfo
    {
        /// <summary>
        /// Gets the title of the MessageBox to close
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets the result how the MessageBox should be closed
        /// </summary>
        public MessageBoxResult MessageBoxResult { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MessageBoxInfo class
        /// </summary>
        /// <param name="title">The title of the BessageBox to close</param>
        /// <param name="messageBoxResult">The result how the MessageBox should be closed</param>
        public MessageBoxInfo(string title, MessageBoxResult messageBoxResult)
        {
            Title = title;
            MessageBoxResult = messageBoxResult;
        }
    }

    // ReSharper restore ClassNeverInstantiated.Global
}