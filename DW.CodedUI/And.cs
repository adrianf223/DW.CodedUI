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

using System.Collections.Generic;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    /// <summary>
    /// Defines all possibile settings to be used by searching for windows. See <see cref="DW.CodedUI.WindowFinder" />.
    /// </summary>
    public abstract class And
    {
        /// <summary>
        /// The window should be searched again and again as long this timeout is not elapsed.
        /// </summary>
        /// <param name="milliseconds">The timeout in milliseconds.</param>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public static CombinableAnd Timeout(uint milliseconds)
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.Timeout(milliseconds);
        }

        /// <summary>
        /// The window should be searched just once.
        /// </summary>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public static CombinableAnd NoTimeout()
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.NoTimeout();
        }

        /// <summary>
        /// If the window is not found an exception has to be thrown.
        /// </summary>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public static CombinableAnd Assert()
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.Assert();
        }

        /// <summary>
        /// If the window is not found no exception has to be thrown. In this case the Search returns null.
        /// </summary>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public static CombinableAnd NoAssert()
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.NoAssert();
        }

        /// <summary>
        /// If multiple windows got found the N. window get returned.
        /// </summary>
        /// <param name="instanceNumber">The instance number N.</param>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public static CombinableAnd InstanceNumber(uint instanceNumber)
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.InstanceNumber(instanceNumber);
        }

        /// <summary>
        /// The WindowFinder is searching for windows again and again as soon the timeout is not ellapsed. This defines the wait time beween each search run.
        /// </summary>
        /// <param name="milliseconds">The wait time in milliseconds between the searches</param>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public static CombinableAnd Interval(uint milliseconds)
        {
            var combinableWith = new CombinableAnd();
            return combinableWith.Interval(milliseconds);
        }

        /// <summary>
        /// The WindowFinder is searching for windows again and again as soon the timeout is not ellapsed. This defines that there is no wait time between each search run.
        /// </summary>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public static CombinableAnd NoInterval()
        {
            var combinableWith = new CombinableAnd();
            return combinableWith.NoInterval();
        }

        internal abstract List<AndCondition> GetConditions();
        internal abstract uint GetTimeout();
        internal abstract uint GetInstanceNumber();
        internal abstract uint GetInterval();
    }
}