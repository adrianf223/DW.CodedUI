using System.Collections.Generic;

namespace DW.CodedUI
{
    public abstract class And
    {
        public static CombinableAnd Timeout(uint milliseconds)
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.Timeout(milliseconds);
        }

        public static CombinableAnd NoTimeout()
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.NoTimeout();
        }

        public static CombinableAnd Assert()
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.Assert();
        }

        public static CombinableAnd NoAssert()
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.NoAssert();
        }

        public static CombinableAnd InstanceNumber(uint instanceNumber)
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.InstanceNumber(instanceNumber);
        }

        public static CombinableAnd Interval(uint milliseconds)
        {
            var combinableWith = new CombinableAnd();
            return combinableWith.Interval(milliseconds);
        }

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