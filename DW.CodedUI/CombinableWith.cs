using System.Collections.Generic;

namespace DW.CodedUI.UITree
{
    public class CombinableWith : With
    {
        private readonly List<WithConditions> _conditions;
        private uint _timeoutMilliseconds;

        internal CombinableWith()
        {
            _conditions = new List<WithConditions>();
        }

        public CombinableWith And
        {
            get { return this; }
        }

        public new CombinableWith Timeout(uint milliseconds)
        {
            _timeoutMilliseconds = milliseconds;
            if (milliseconds == 0)
                return NoTimeout();
            
            if (!_conditions.Contains(WithConditions.Timeout))
                _conditions.Add(WithConditions.Timeout);
            return this;
        }

        public new CombinableWith NoTimeout()
        {
            if (!_conditions.Contains(WithConditions.NoTimeout))
                _conditions.Add(WithConditions.NoTimeout);
            return this;
        }

        public new CombinableWith Assert()
        {
            if (!_conditions.Contains(WithConditions.Assert))
                _conditions.Add(WithConditions.Assert);
            return this;
        }

        public new CombinableWith NoAssert()
        {
            if (!_conditions.Contains(WithConditions.NoAssert))
                _conditions.Add(WithConditions.NoAssert);
            return this;
        }

        private void AdjustTimeoutCondition(List<WithConditions> conditios)
        {
            if (!conditios.Contains(WithConditions.NoTimeout) && !conditios.Contains(WithConditions.Timeout))
            {
                conditios.Add(WithConditions.Timeout);
                _timeoutMilliseconds = 10000;
            }
            if (conditios.Contains(WithConditions.NoTimeout))
                conditios.Remove(WithConditions.Timeout);
            if (conditios.Contains(WithConditions.Timeout))
                conditios.Remove(WithConditions.NoTimeout);
        }

        private void AdjustAssertCondition(List<WithConditions> conditios)
        {
            if (!conditios.Contains(WithConditions.NoAssert) && !conditios.Contains(WithConditions.Assert))
                conditios.Add(WithConditions.Assert);
            if (conditios.Contains(WithConditions.NoAssert))
                conditios.Remove(WithConditions.Assert);
            if (conditios.Contains(WithConditions.Assert))
                conditios.Remove(WithConditions.NoAssert);
        }

        internal override List<WithConditions> GetConditions()
        {
            var conditios = new List<WithConditions>();
            conditios.AddRange(_conditions);

            AdjustTimeoutCondition(conditios);
            AdjustAssertCondition(conditios);

            return conditios;
        }

        internal override uint GetTimeout()
        {
            return _timeoutMilliseconds;
        }
    }
}