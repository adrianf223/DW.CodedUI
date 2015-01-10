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

using System.Collections.Generic;
using DW.CodedUI.Internal;
using DW.CodedUI.Utilities;

namespace DW.CodedUI
{
    /// <summary>
    /// Defines all possibile settings to be used by searching for windows. See <see cref="DW.CodedUI.WindowFinder" />.
    /// </summary>
    public class CombinableAnd : And
    {
        internal CombinableAnd()
        {
            _conditions = new List<AndCondition>();
        }

        private readonly List<AndCondition> _conditions;
        private uint _timeoutMilliseconds;
        private uint _instanceNumber;
        private uint _interval;

        /// <summary>
        /// Gets a combinable And to be able to append additional settings.
        /// </summary>
        public CombinableAnd And
        {
            get { return this; }
        }

        /// <summary>
        /// The window should be searched again and again as long this timeout is not elapsed.
        /// </summary>
        /// <param name="milliseconds">The timeout in milliseconds.</param>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public new CombinableAnd Timeout(uint milliseconds)
        {
            _timeoutMilliseconds = milliseconds;
            if (!_conditions.Contains(AndCondition.Timeout))
                _conditions.Add(AndCondition.Timeout);
            return this;
        }

        /// <summary>
        /// The window should be searched just once.
        /// </summary>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public new CombinableAnd NoTimeout()
        {
            if (!_conditions.Contains(AndCondition.NoTimeout))
                _conditions.Add(AndCondition.NoTimeout);
            return this;
        }

        /// <summary>
        /// If the window is not found an exception has to be thrown.
        /// </summary>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public new CombinableAnd Assert()
        {
            if (!_conditions.Contains(AndCondition.Assert))
                _conditions.Add(AndCondition.Assert);
            return this;
        }

        /// <summary>
        /// If the window is not found no exception has to be thrown. In this case the Search returns null.
        /// </summary>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public new CombinableAnd NoAssert()
        {
            if (!_conditions.Contains(AndCondition.NoAssert))
                _conditions.Add(AndCondition.NoAssert);
            return this;
        }

        /// <summary>
        /// If multiple windows got found the N. window get returned.
        /// </summary>
        /// <param name="instanceNumber">The instance number N.</param>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public new CombinableAnd InstanceNumber(uint instanceNumber)
        {
            _instanceNumber = instanceNumber;
            if (_instanceNumber == 0)
                _conditions.Remove(AndCondition.Instance);
            else if (!_conditions.Contains(AndCondition.Instance))
                _conditions.Add(AndCondition.Instance);
            return this;
        }

        /// <summary>
        /// The WindowFinder is searching for windows again and again as soon the timeout is not ellapsed. This defines the wait time beween each search run.
        /// </summary>
        /// <param name="milliseconds">The wait time in milliseconds between the searches</param>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public new CombinableAnd Interval(uint milliseconds)
        {
            _interval = milliseconds;
            if (milliseconds == 0)
            {
                _conditions.Remove(AndCondition.Interval);
                return NoInterval();
            }
            if (!_conditions.Contains(AndCondition.Interval))
                _conditions.Add(AndCondition.Interval);
            return this;
        }

        /// <summary>
        /// The WindowFinder is searching for windows again and again as soon the timeout is not ellapsed. This defines that there is no wait time between each search run.
        /// </summary>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public new CombinableAnd NoInterval()
        {
            if (!_conditions.Contains(AndCondition.NoInterval))
                _conditions.Add(AndCondition.NoInterval);
            return this;
        }

        internal override List<AndCondition> GetConditions()
        {
            var conditions = new List<AndCondition>();
            conditions.AddRange(_conditions);

            AdjustTimeoutCondition(conditions);
            AdjustAssertCondition(conditions);
            AdjustIntervalCondition(conditions);

            return conditions;
        }

        internal override uint GetTimeout()
        {
            return _timeoutMilliseconds;
        }
        
        internal override uint GetInstanceNumber()
        {
            return _instanceNumber;
        }

        internal override uint GetInterval()
        {
            return _interval;
        }

        private void AdjustTimeoutCondition(List<AndCondition> conditions)
        {
            if (!conditions.Contains(AndCondition.NoTimeout) && !conditions.Contains(AndCondition.Timeout))
            {
                conditions.Add(CodedUIEnvironment.DefaultSettings.Timeout == InExclude.With ? AndCondition.Timeout : AndCondition.NoTimeout);
                _timeoutMilliseconds = CodedUIEnvironment.DefaultSettings.TimeoutTime;
            }
            if (conditions.Contains(AndCondition.NoTimeout))
                conditions.Remove(AndCondition.Timeout);
            if (conditions.Contains(AndCondition.Timeout))
                conditions.Remove(AndCondition.NoTimeout);
        }

        private void AdjustAssertCondition(List<AndCondition> conditions)
        {
            if (!conditions.Contains(AndCondition.NoAssert) && !conditions.Contains(AndCondition.Assert))
                conditions.Add(CodedUIEnvironment.DefaultSettings.Assert == InExclude.With ? AndCondition.Assert : AndCondition.NoAssert);
            if (conditions.Contains(AndCondition.NoAssert))
                conditions.Remove(AndCondition.Assert);
            if (conditions.Contains(AndCondition.Assert))
                conditions.Remove(AndCondition.NoAssert);
        }

        private void AdjustIntervalCondition(List<AndCondition> conditions)
        {
            if (!conditions.Contains(AndCondition.NoInterval) && !conditions.Contains(AndCondition.Interval))
            {
                conditions.Add(CodedUIEnvironment.DefaultSettings.Interval == InExclude.With ? AndCondition.Interval : AndCondition.NoInterval);
                _interval = CodedUIEnvironment.DefaultSettings.IntervalTime;
            }
            if (conditions.Contains(AndCondition.NoInterval))
                conditions.Remove(AndCondition.Interval);
            if (conditions.Contains(AndCondition.Interval))
                conditions.Remove(AndCondition.NoInterval);
        }
    }
}