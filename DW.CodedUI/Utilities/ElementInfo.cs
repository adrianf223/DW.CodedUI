#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2015 David Wendland

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
using DW.CodedUI.BasicElements.Data;

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Represents the data of the observed <see cref="DW.CodedUI.BasicElements.BasicElement" />.
    /// </summary>
    public class ElementInfo : IEquatable<ElementInfo>
    {
        /// <summary>
        /// Gets the data of the observed <see cref="DW.CodedUI.BasicElements.BasicElement" />.
        /// </summary>
        public BasicElementData BasicElementData { get; private set; }

        internal ElementInfo(BasicElementData basicElementData)
        {
            BasicElementData = basicElementData;
        }

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current <see cref="DW.CodedUI.Utilities.ElementInfo" />.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified System.Object is equal to the current <see cref="DW.CodedUI.Utilities.ElementInfo" />; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="DW.CodedUI.Utilities.ElementInfo" /> is equal to the current <see cref="DW.CodedUI.Utilities.ElementInfo" />.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>true if the specified <see cref="DW.CodedUI.Utilities.ElementInfo" /> is equal to the current <see cref="DW.CodedUI.Utilities.ElementInfo" />; otherwise, false.</returns>
        public bool Equals(ElementInfo other)
        {
            return Equals(BasicElementData, other.BasicElementData);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current <see cref="DW.CodedUI.Utilities.ElementInfo" />.</returns>
        public override int GetHashCode()
        {
            return (BasicElementData != null ? BasicElementData.GetHashCode() : 0);
        }
    }
}