using System;
using DW.CodedUI.BasicElements;

namespace DW.CodedUI
{
    public abstract class By
    {
        public static CombinableBy AutomationId(string automationId)
        {
            var combinableBy = new CombinableBy();
            return combinableBy.AutomationId(automationId);
        }

        public static CombinableBy AutomationId(string automationId, StringComparison comparison)
        {
            var combinableBy = new CombinableBy();
            return combinableBy.AutomationId(automationId, comparison);
        }

        public static CombinableBy Name(string name)
        {
            var combinableBy = new CombinableBy();
            return combinableBy.Name(name);
        }

        public static CombinableBy Name(string name, StringComparison comparison)
        {
            var combinableBy = new CombinableBy();
            return combinableBy.Name(name, comparison);
        }

        public static CombinableBy ClassName(string className)
        {
            var combinableBy = new CombinableBy();
            return combinableBy.ClassName(className);
        }

        public static CombinableBy ClassName(string className, StringComparison comparison)
        {
            var combinableBy = new CombinableBy();
            return combinableBy.ClassName(className, comparison);
        }

        public static CombinableBy Condition(Predicate<BasicElement> condition)
        {
            var combinableBy = new CombinableBy();
            return combinableBy.Condition(condition);
        }

        internal abstract Predicate<BasicElement> GetCondition();
        internal abstract string GetConditionDescription();
    }
}
