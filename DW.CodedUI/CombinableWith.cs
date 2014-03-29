using System.Collections.Generic;

namespace DW.CodedUI
{
    public class CombinableWith : With
    {
        private readonly List<WithCondition> _conditions;
        private uint _timeoutMilliseconds;

        internal CombinableWith()
        {
            _conditions = new List<WithCondition>();
        }

        public CombinableWith And
        {
            get { return this; }
        }

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

        public new CombinableWith NoTimeout()
        {
            if (!_conditions.Contains(WithCondition.NoTimeout))
                _conditions.Add(WithCondition.NoTimeout);
            return this;
        }

        public new CombinableWith Assert()
        {
            if (!_conditions.Contains(WithCondition.Assert))
                _conditions.Add(WithCondition.Assert);
            return this;
        }

        public new CombinableWith NoAssert()
        {
            if (!_conditions.Contains(WithCondition.NoAssert))
                _conditions.Add(WithCondition.NoAssert);
            return this;
        }

        internal override List<WithCondition> GetConditions()
        {
            var conditios = new List<WithCondition>();
            conditios.AddRange(_conditions);

            AdjustTimeoutCondition(conditios);
            AdjustAssertCondition(conditios);

            return conditios;
        }

        internal override uint GetTimeout()
        {
            return _timeoutMilliseconds;
        }

        private void AdjustTimeoutCondition(List<WithCondition> conditios)
        {
            if (!conditios.Contains(WithCondition.NoTimeout) && !conditios.Contains(WithCondition.Timeout))
            {
                conditios.Add(WithCondition.Timeout);
                _timeoutMilliseconds = 10000;
            }
            if (conditios.Contains(WithCondition.NoTimeout))
                conditios.Remove(WithCondition.Timeout);
            if (conditios.Contains(WithCondition.Timeout))
                conditios.Remove(WithCondition.NoTimeout);
        }

        private void AdjustAssertCondition(List<WithCondition> conditios)
        {
            if (!conditios.Contains(WithCondition.NoAssert) && !conditios.Contains(WithCondition.Assert))
                conditios.Add(WithCondition.Assert);
            if (conditios.Contains(WithCondition.NoAssert))
                conditios.Remove(WithCondition.Assert);
            if (conditios.Contains(WithCondition.Assert))
                conditios.Remove(WithCondition.NoAssert);
        }
    }
}