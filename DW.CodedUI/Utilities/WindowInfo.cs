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

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Represents the data of a window.
    /// </summary>
    public class WindowInfo : IEquatable<WindowInfo>
    {
        internal WindowInfo()
        {
        }

        /// <summary>
        /// Gets the handle of the window.
        /// </summary>
        public IntPtr Handle { get; internal set; }

        /// <summary>
        /// Gets the title of the window.
        /// </summary>
        public string Title { get; internal set; }

        /// <summary>
        /// Gets a value which indicates if the window is visible or not.
        /// </summary>
        public bool IsVisible { get; internal set; }

        /// <summary>
        /// Determines whether the specified <see cref="DW.CodedUI.Utilities.WindowInfo" /> is equal to the current <see cref="DW.CodedUI.Utilities.WindowInfo" />.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>true if the specified <see cref="DW.CodedUI.Utilities.WindowInfo" /> is equal to the current <see cref="DW.CodedUI.Utilities.WindowInfo" />; otherwise, false.</returns>
        public bool Equals(WindowInfo other)
        {
            return Handle.Equals(other.Handle);
        }

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current <see cref="DW.CodedUI.Utilities.WindowInfo" />.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified System.Object is equal to the current <see cref="DW.CodedUI.Utilities.WindowInfo" />; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WindowInfo)obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current <see cref="DW.CodedUI.Utilities.WindowInfo" />.</returns>
        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }
    }
}