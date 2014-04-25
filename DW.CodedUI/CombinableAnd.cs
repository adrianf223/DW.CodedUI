using System.Collections.Generic;

namespace DW.CodedUI
{
    /// <summary>
    /// Defines all possibile settings to be used by searching for windows. See <see cref="DW.CodedUI.WindowFinder" />.
    /// </summary>
    public class CombinableAnd : And
    {
#if TRIAL
        static CombinableAnd()
        {
            License1.License.Display();
        }
#endif

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
            var conditios = new List<AndCondition>();
            conditios.AddRange(_conditions);

            AdjustTimeoutCondition(conditios);
            AdjustAssertCondition(conditios);
            AdjustIntervalCondition(conditios);

            return conditios;
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

        private void AdjustTimeoutCondition(List<AndCondition> conditios)
        {
            if (!conditios.Contains(AndCondition.NoTimeout) && !conditios.Contains(AndCondition.Timeout))
            {
                conditios.Add(AndCondition.Timeout);
                _timeoutMilliseconds = 10000;
            }
            if (conditios.Contains(AndCondition.NoTimeout))
                conditios.Remove(AndCondition.Timeout);
            if (conditios.Contains(AndCondition.Timeout))
                conditios.Remove(AndCondition.NoTimeout);
        }

        private void AdjustAssertCondition(List<AndCondition> conditios)
        {
            if (!conditios.Contains(AndCondition.NoAssert) && !conditios.Contains(AndCondition.Assert))
                conditios.Add(AndCondition.Assert);
            if (conditios.Contains(AndCondition.NoAssert))
                conditios.Remove(AndCondition.Assert);
            if (conditios.Contains(AndCondition.Assert))
                conditios.Remove(AndCondition.NoAssert);
        }

        private void AdjustIntervalCondition(List<AndCondition> conditios)
        {
            if (!conditios.Contains(AndCondition.NoInterval) && !conditios.Contains(AndCondition.Interval))
                conditios.Add(AndCondition.NoInterval);
            if (conditios.Contains(AndCondition.NoInterval))
                conditios.Remove(AndCondition.Interval);
            if (conditios.Contains(AndCondition.Interval))
                conditios.Remove(AndCondition.NoInterval);
        }
    }
}