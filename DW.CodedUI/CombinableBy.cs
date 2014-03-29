using System;
using System.Collections.Generic;
using System.Linq;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    public class CombinableBy : By
    {
        internal CombinableBy()
        {
            _conditions = new List<Predicate<BasicElement>>();
            _conditionDescriptions = new List<string>();
            _isAndCondition = true;
        }

        public CombinableBy And
        {
            get
            {
                _isAndCondition = true;
                return this;
            }
        }

        public CombinableBy Or
        {
            get
            {
                _isAndCondition = false;
                return this;
            }
        }

        private readonly List<Predicate<BasicElement>> _conditions;
        private readonly List<string> _conditionDescriptions;
        private bool _isAndCondition;

        public new CombinableBy AutomationId(string automationId)
        {
            return AutomationId(automationId, CompareKind.Exact);
        }

        public new CombinableBy AutomationId(string automationId, CompareKind comparison)
        {
            if (string.IsNullOrWhiteSpace(automationId))
                throw new ArgumentException("automationId is null, empty or just whitespaces");

            _conditions.Add(element =>
            {
                if (element == null)
                    return false;
                return StringExtensions.Match(element.Properties.AutomationId, automationId, comparison);
            });
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(element.Properties.AutomationId, \"{0}\", {1})", automationId, comparison));
            return this;
        }

        public new CombinableBy Name(string name)
        {
            return Name(name, CompareKind.Exact);
        }

        public new CombinableBy Name(string name, CompareKind comparison)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name is null, empty or just whitespaces");

            _conditions.Add(element =>
            {
                if (element == null)
                    return false;
                return StringExtensions.Match(element.Properties.Name, name, comparison);
            });
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(element.Properties.Name, \"{0}\", {1})", name, comparison));
            return this;
        }

        public new CombinableBy ClassName(string className)
        {
            return ClassName(className, CompareKind.Exact);
        }

        public new CombinableBy ClassName(string className, CompareKind comparison)
        {
            if (string.IsNullOrWhiteSpace(className))
                throw new ArgumentException("className is null, empty or just whitespaces");

            _conditions.Add(element =>
            {
                if (element == null)
                    return false;
                return StringExtensions.Match(element.Properties.ClassName, className, comparison);
            });
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(element.Properties.ClassName, \"{0}\", {1})", className, comparison));
            return this;
        }

        public new CombinableBy Condition(Predicate<BasicElement> condition)
        {
            if (condition == null)
                throw new ArgumentNullException("condition");

            _conditions.Add(condition);
            _conditionDescriptions.Add("condition(element)");
            return this;
        }

        internal override Predicate<BasicElement> GetCondition()
        {
            if (_isAndCondition)
                return element => _conditions.All(e => e(element));
            return element => _conditions.Any(e => e(element));
        }

        internal override string GetConditionDescription()
        {
            var andSeparator = Environment.NewLine + " AND " + Environment.NewLine;
            var orSeparator = Environment.NewLine + " OR " + Environment.NewLine;
            return string.Join(_isAndCondition ? andSeparator : orSeparator, _conditionDescriptions);
        }
    }
}
