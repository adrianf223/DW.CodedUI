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

namespace DW.CodedUI.Application
{
    /// <summary>
    /// Defines how to search for a window
    /// </summary>
    public enum WindowSearchCondition
    {
        /// <summary>
        /// The window title contains the given pattern
        /// </summary>
        TitleContains,

        /// <summary>
        /// The window title matches the pattern exact
        /// </summary>
        TitleEquals,

        /// <summary>
        /// The C# Regex method is matching the window title by the given pattern
        /// </summary>
        TitleRegex,

        /// <summary>
        /// The process name owning a window contains the given pattern
        /// </summary>
        /// <remarks>The process name does not contain a path of extension</remarks>
        ProcessContains,

        /// <summary>
        /// The process name owning a window matches the given pattern exact
        /// </summary>
        /// <remarks>The process name does not contain a path of extension</remarks>
        ProcessEquals,

        /// <summary>
        /// The C# Regex method is matching the process name owning a window by the given pattern
        /// </summary>
        /// <remarks>The process name does not contain a path of extension</remarks>
        ProcessRegex
    }
}