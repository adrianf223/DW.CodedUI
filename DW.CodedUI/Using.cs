using System;
using DW.CodedUI.BasicElements;

namespace DW.CodedUI
{
    public abstract class Using
    {
        public static CombinableUsing Title(string title)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Title(title);
        }

        public static CombinableUsing Title(string title, CompareKind comparison)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Title(title, comparison);
        }

        public static CombinableUsing Process(string name)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Process(name);
        }

        public static CombinableUsing Process(string name, CompareKind comparison)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Process(name, comparison);
        }

        public static CombinableUsing Condition(Predicate<BasicWindow> condition)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Condition(condition);
        }

        internal abstract Predicate<BasicWindow> GetCondition();
        internal abstract string GetConditionDescription();
    }
}