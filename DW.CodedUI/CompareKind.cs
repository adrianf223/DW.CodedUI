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

namespace DW.CodedUI
{
    /// <summary>
    /// Defines how to compare texts.
    /// </summary>
    public enum CompareKind
    {
        /// <summary>
        /// Compares the string to see if the first is the same like the second.
        /// </summary>
        Exact,

        /// <summary>
        /// Compares the string to see if the first contains the second.
        /// </summary>
        Contains,

        /// <summary>
        /// Compares the string to see if the first starts with the second.
        /// </summary>
        StartsWith,

        /// <summary>
        /// Compares the string to see if the first ends with the second.
        /// </summary>
        EndsWith,

        /// <summary>
        /// Compares the string to match exact with ignoring the casing.
        /// </summary>
        ExactIgnoreCase,

        /// <summary>
        /// Compares the string to see if the first contains the second with ignoring the casing.
        /// </summary>
        ContainsIgnoreCase,

        /// <summary>
        /// Compares the string to see if the first starts with the second with ignoring the casing.
        /// </summary>
        StartsWithIgnoreCase,

        /// <summary>
        /// Compares the string to see if the first ends with the second with ignoring the casing.
        /// </summary>
        EndsWithIgnoreCase
    }
}