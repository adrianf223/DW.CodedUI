using System.Collections.Generic;

namespace DW.CodedUI.UITree
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

        internal abstract List<WithConditions> GetConditions();
        internal abstract uint GetTimeout();
    }
}