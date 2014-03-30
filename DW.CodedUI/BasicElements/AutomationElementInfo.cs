using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class AutomationElementInfo : INotifyPropertyChanged
    {
        public AutomationElement AutomationElement { get; private set; }

        public List<AutomationElementInfo> Children { get; private set; }

        public AutomationElementInfo(AutomationElement element)
        {
            AutomationElement = element;
            Children = new List<AutomationElementInfo>();
        }

        public override string ToString()
        {
            if (!IsAvailable)
                return "<N.A.>";

            var name = AutomationElement.Current.Name;
            if (string.IsNullOrWhiteSpace(name))
                name = "<no name>";

            var automationId = AutomationElement.Current.AutomationId;
            if (string.IsNullOrWhiteSpace(automationId))
                return name;

            return string.Format("{0} [{1}]", name, automationId);
        }

        public string AutomationId
        {
            get
            {
                if (!IsAvailable)
                    return "<element is gone>";

                var automationId = AutomationElement.Current.AutomationId;
                if (string.IsNullOrWhiteSpace(automationId))
                    return "<no automation id>";

                return automationId;
            }
        }

        public string Name
        {
            get
            {
                if (!IsAvailable)
                    return "<element is gone>";

                var name = AutomationElement.Current.Name;
                if (string.IsNullOrWhiteSpace(name))
                    return "<no name>";

                return name;
            }
        }

        public bool HasAutomationId
        {
            get
            {
                if (!IsAvailable)
                    return false;

                return !string.IsNullOrWhiteSpace(AutomationElement.Current.AutomationId);
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyPropertyChanged(() => IsSelected);
            }
        }

        private bool _isSelected;

        public bool IsAvailable
        {
            get
            {
                try
                {
                    var elementAvailabilityCheck = AutomationElement.Current.Name;
                    return true;
                }
                catch (ElementNotAvailableException )
                {
                    return false;
                }
            }
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged<T>(Expression<Func<T>> property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var memberExpression = property.Body as MemberExpression;
                handler(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
            }
        }

        #endregion NotifyPropertyChanged
    }
}