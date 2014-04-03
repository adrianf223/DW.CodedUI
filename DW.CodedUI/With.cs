using System.Collections.Generic;

namespace DW.CodedUI
{
    public abstract class With
    {
        public static CombinableWith Timeout(uint milliseconds)
        {
            var combinableWith = new CombinableWith();
            return combinableWith.Timeout(milliseconds);
        }

        public static CombinableWith Assert()
        {
            var combinableWith = new CombinableWith();
            return combinableWith.Assert();
        }

        public static CombinableWith NoTimeout()
        {
            var combinableWith = new CombinableWith();
            return combinableWith.NoTimeout();
        }

        public static CombinableWith NoAssert()
        {
            var combinableWith = new CombinableWith();
            return combinableWith.NoAssert();
        }

        public static CombinableWith Interval(uint milliseconds)
        {
            var combinableWith = new CombinableWith();
            return combinableWith.Interval(milliseconds);
        }

        public static CombinableWith NoInterval()
        {
            var combinableWith = new CombinableWith();
            return combinableWith.NoInterval();
        }

        internal abstract List<WithCondition> GetConditions();
        internal abstract uint GetTimeout();
        internal abstract uint GetInterval();
    }
}