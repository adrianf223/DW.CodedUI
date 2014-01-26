using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class BasicElementInfo : INotifyPropertyChanged
    {
        public AutomationElement AutomationElement { get; private set; }

        public List<BasicElementInfo> Children { get; private set; }

        public BasicElementInfo(AutomationElement element)
        {
            AutomationElement = element;
            Children = new List<BasicElementInfo>();
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