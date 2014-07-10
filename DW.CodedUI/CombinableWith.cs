using System.Collections.Generic;
using DW.CodedUI.Internal;
using DW.CodedUI.Utilities;

namespace DW.CodedUI
{
    /// <summary>
    /// Defines all possibile settings to be used by searching for UI elements. See <see cref="DW.CodedUI.UI" />.
    /// </summary>
    public class CombinableWith : With
    {
#if TRIAL
        static CombinableWith()
        {
            License1.License.Display();
        }
#endif

        internal CombinableWith()
        {
            _conditions = new List<WithCondition>();
        }

        private readonly List<WithCondition> _conditions;
        private uint _timeoutMilliseconds;
        private uint _interval;

        /// <summary>
        /// Gets a combinable With to be able to append additional conditions.
        /// </summary>
        public CombinableWith And
        {
            get { return this; }
        }

        /// <summary>
        /// The UI element should be searched again and again as long this timeout is not elapsed.
        /// </summary>
        /// <param name="milliseconds">The timeout in milliseconds.</param>
        /// <returns>A combinable With to be able to append additional conditions.</returns>
        public new CombinableWith Timeout(uint milliseconds)
        {
            _timeoutMilliseconds = milliseconds;
            if (milliseconds == 0)
            {
                _conditions.Remove(WithCondition.Timeout);
                return NoTimeout();
            }
            if (!_conditions.Contains(WithCondition.Timeout))
                _conditions.Add(WithCondition.Timeout);
            return this;
        }

        /// <summary>
        /// The UI element should be searched just once.
        /// </summary>
        /// <returns>A combinable With to be able to append additional conditions.</returns>
        public new CombinableWith NoTimeout()
        {
            if (!_conditions.Contains(WithCondition.NoTimeout))
                _conditions.Add(WithCondition.NoTimeout);
            return this;
        }

        /// <summary>
        /// If the UI element is not found an exception has to be thrown.
        /// </summary>
        /// <returns>A combinable With to be able to append additional conditions.</returns>
        public new CombinableWith Assert()
        {
            if (!_conditions.Contains(WithCondition.Assert))
                _conditions.Add(WithCondition.Assert);
            return this;
        }

        /// <summary>
        /// If the UI element is not found no exception has to be thrown. In this case the Search returns null.
        /// </summary>
        /// <returns>A combinable With to be able to append additional conditions.</returns>
        public new CombinableWith NoAssert()
        {
            if (!_conditions.Contains(WithCondition.NoAssert))
                _conditions.Add(WithCondition.NoAssert);
            return this;
        }

        /// <summary>
        /// The UI is searching for UI elements again and again as soon the timeout is not ellapsed. This defines the wait time beween each search run.
        /// </summary>
        /// <param name="milliseconds">The wait time in milliseconds between the searches</param>
        /// <returns>A combinable With to be able to append additional conditions.</returns>
        public new CombinableWith Interval(uint milliseconds)
        {
            _interval = milliseconds;
            if (milliseconds == 0)
            {
                _conditions.Remove(WithCondition.Interval);
                return NoInterval();
            }
            if (!_conditions.Contains(WithCondition.Interval))
                _conditions.Add(WithCondition.Interval);
            return this;
        }

        /// <summary>
        /// The UI is searching for windows again and again as soon the timeout is not ellapsed. This defines that there is no wait time between each search run.
        /// </summary>
        /// <returns>A combinable With to be able to append additional conditions.</returns>
        public new CombinableWith NoInterval()
        {
            if (!_conditions.Contains(WithCondition.NoInterval))
                _conditions.Add(WithCondition.NoInterval);
            return this;
        }

        internal override List<WithCondition> GetConditions()
        {
            var conditions = new List<WithCondition>();
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

        internal override uint GetInterval()
        {
            return _interval;
        }

        private void AdjustTimeoutCondition(List<WithCondition> conditions)
        {
            if (!conditions.Contains(WithCondition.NoTimeout) && !conditions.Contains(WithCondition.Timeout))
            {
                conditions.Add(CodedUIEnvironment.DefaultSettings.Timeout == InExclude.With ? WithCondition.Timeout : WithCondition.NoTimeout);
                _timeoutMilliseconds = CodedUIEnvironment.DefaultSettings.TimeoutTime;
            }
            if (conditions.Contains(WithCondition.NoTimeout))
                conditions.Remove(WithCondition.Timeout);
            if (conditions.Contains(WithCondition.Timeout))
                conditions.Remove(WithCondition.NoTimeout);
        }

        private void AdjustAssertCondition(List<WithCondition> conditions)
        {
            if (!conditions.Contains(WithCondition.NoAssert) && !conditions.Contains(WithCondition.Assert))
                conditions.Add(CodedUIEnvironment.DefaultSettings.Assert == InExclude.With ? WithCondition.Assert : WithCondition.NoAssert);
            if (conditions.Contains(WithCondition.NoAssert))
                conditions.Remove(WithCondition.Assert);
            if (conditions.Contains(WithCondition.Assert))
                conditions.Remove(WithCondition.NoAssert);
        }

        private void AdjustIntervalCondition(List<WithCondition> conditions)
        {
            if (!conditions.Contains(WithCondition.NoInterval) && !conditions.Contains(WithCondition.Interval))
            {
                conditions.Add(CodedUIEnvironment.DefaultSettings.Interval == InExclude.With ? WithCondition.Interval : WithCondition.NoInterval);
                _interval = CodedUIEnvironment.DefaultSettings.IntervalTime;
            }
            if (conditions.Contains(WithCondition.NoInterval))
                conditions.Remove(WithCondition.Interval);
            if (conditions.Contains(WithCondition.Interval))
                conditions.Remove(WithCondition.NoInterval);
        }
    }
}