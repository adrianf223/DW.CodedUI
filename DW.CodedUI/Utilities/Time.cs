#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2014 David Wendland

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

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Holds a bunch of available time length to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep" />.
    /// </summary>
    public enum Time
    {
        /// <summary>
        /// Represents a very short time. The time can be adjusted in the <see cref="DW.CodedUI.CodedUIEnvironment.SleepSettings" />.VeryShort. The default is 500 milliseconds.
        /// </summary>
        VeryShort,

        /// <summary>
        /// Represents a very short time. The time can be adjusted in the <see cref="DW.CodedUI.CodedUIEnvironment.SleepSettings" />.Short. The default is 1000 milliseconds.
        /// </summary>
        Short,

        /// <summary>
        /// Represents a very short time. The time can be adjusted in the <see cref="DW.CodedUI.CodedUIEnvironment.SleepSettings" />.Medium. The default is 1500 milliseconds.
        /// </summary>
        Medium,

        /// <summary>
        /// Represents a very short time. The time can be adjusted in the <see cref="DW.CodedUI.CodedUIEnvironment.SleepSettings" />.Long. The default is 2000 milliseconds.
        /// </summary>
        Long,

        /// <summary>
        /// Represents a very short time. The time can be adjusted in the <see cref="DW.CodedUI.CodedUIEnvironment.SleepSettings" />.VeryLong. The default is 2500 milliseconds.
        /// </summary>
        VeryLong
    }
}