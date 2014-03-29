using System;
using System.Collections.Generic;
using System.Linq;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    public class CombinableUsing : Using
    {
        internal CombinableUsing()
        {
            _conditions = new List<Predicate<BasicWindow>>();
            _conditionDescriptions = new List<string>();
        }

        private readonly List<Predicate<BasicWindow>> _conditions;
        private readonly List<string> _conditionDescriptions;
        private bool _isAndCondition;

        public CombinableUsing And
        {
            get
            {
                _isAndCondition = true;
                return this;
            }
        }

        public CombinableUsing Or
        {
            get
            {
                _isAndCondition = false;
                return this;
            }
        }

        public new CombinableUsing Title(string title)
        {
            return Title(title, CompareKind.ContainsIgnoreCase);
        }

        public new CombinableUsing Title(string title, CompareKind comparison)
        {
            _conditions.Add(window => StringExtensions.Match(window.Title, title, comparison));
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(window.Title, \"{0}\", {1})", title, comparison));

            return this;
        }

        public new CombinableUsing Process(string name)
        {
            return Process(name, CompareKind.ContainsIgnoreCase);
        }

        public new CombinableUsing Process(string name, CompareKind comparison)
        {
            _conditions.Add(window => StringExtensions.Match(window.OwningProcess.ProcessName, name, comparison));
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(window.OwningProcess.ProcessName, \"{0}\", {1})", name, comparison));
            return this;
        }

        public new CombinableUsing Condition(Predicate<BasicWindow> condition)
        {
            _conditions.Add(condition);
            _conditionDescriptions.Add("condition(element)");
            return this;
        }

        internal override Predicate<BasicWindow> GetCondition()
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