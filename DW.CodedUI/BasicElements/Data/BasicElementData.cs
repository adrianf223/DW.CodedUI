#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2016 David Wendland

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

using System.Collections.Generic;
using System.Drawing;

namespace DW.CodedUI.BasicElements.Data
{
    /// <summary>
    /// Represents the data of a <see cref="DW.CodedUI.BasicElements.BasicElement" /> at the time of the call <see cref="DW.CodedUI.BasicElements.BasicElement.GetDataCopy()" />.
    /// </summary>
    public class BasicElementData
    {
        internal BasicElementData()
        {
            Children = new List<BasicElementData>();
        }

        /// <summary>
        /// Gets the automation ID.
        /// </summary>
        public string AutomationId { get; internal set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the position and size.
        /// </summary>
        public Rectangle BoundingRectangle { get; internal set; }

        /// <summary>
        /// Gets the class name.
        /// </summary>
        public string ClassName { get; internal set; }

        /// <summary>
        /// Gets the window handle if any; otherwise 0.
        /// </summary>
        public int NativeWindowHandle { get; internal set; }

        /// <summary>
        /// Gets the process ID which the elements belongs to.
        /// </summary>
        public int ProcessId { get; internal set; }

        /// <summary>
        /// Gets the child elements of the current element. This will be filled by use the <see cref="DW.CodedUI.UI.GetFullUITreeData" />.
        /// </summary>
        public IEnumerable<BasicElementData> Children { get; set; }

        /// <summary>
        /// Gets a value that indicates if the element is enabled or not.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets a value that indicates if the element is visible or not.
        /// </summary>
        public bool IsVisible { get; set; }
    }
}
