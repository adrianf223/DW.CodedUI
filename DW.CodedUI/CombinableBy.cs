using System;
using System.Collections.Generic;
using System.Linq;
using DW.CodedUI.BasicElements;

namespace DW.CodedUI.UITree
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
            return AutomationId(automationId, StringComparison.CurrentCulture);
        }

        public new CombinableBy AutomationId(string automationId, StringComparison comparison)
        {
            if (string.IsNullOrWhiteSpace(automationId))
                throw new ArgumentException("automationId is null, empty or just whitespaces");

            _conditions.Add(element =>
            {
                if (element == null)
                    return false;
                return automationId.Equals(element.Properties.AutomationId, comparison);
            });
            _conditionDescriptions.Add(string.Format("element.AutomationId.Equals(\"{0}\", {1})", automationId, comparison));
            return this;
        }

        public new CombinableBy Name(string name)
        {
            return Name(name, StringComparison.CurrentCulture);
        }

        public new CombinableBy Name(string name, StringComparison comparison)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name is null, empty or just whitespaces");

            _conditions.Add(element =>
            {
                if (element == null)
                    return false;
                return name.Equals(element.Properties.Name, comparison);
            });
            _conditionDescriptions.Add(string.Format("element.Name.Equals(\"{0}\", {1})", name, comparison));
            return this;
        }

        public new CombinableBy ClassName(string className)
        {
            return ClassName(className, StringComparison.CurrentCulture);
        }

        public new CombinableBy ClassName(string className, StringComparison comparison)
        {
            if (string.IsNullOrWhiteSpace(className))
                throw new ArgumentException("className is null, empty or just whitespaces");

            _conditions.Add(element =>
            {
                if (element == null)
                    return false;
                return className.Equals(element.Properties.ClassName, comparison);
            });
            _conditionDescriptions.Add(string.Format("element.ClassName.Equals(\"{0}\", {1})", className, comparison));
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
