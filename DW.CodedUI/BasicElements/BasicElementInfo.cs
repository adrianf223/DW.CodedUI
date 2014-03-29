using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    // TODO: Adjust obsolet text
    [Obsolete("Methods in this object are not supported anymore. ")]
    public class BasicElementInfo : INotifyPropertyChanged
    {
        [Obsolete]
        public AutomationElement AutomationElement { get; private set; }

        [Obsolete]
        public List<BasicElementInfo> Children { get; private set; }

        [Obsolete]
        public BasicElementInfo(AutomationElement element)
        {
            AutomationElement = element;
            Children = new List<BasicElementInfo>();
        }

        [Obsolete]
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

        [Obsolete]
        public bool HasAutomationId
        {
            get
            {
                if (!IsAvailable)
                    return false;

                return !string.IsNullOrWhiteSpace(AutomationElement.Current.AutomationId);
            }
        }

        [Obsolete]
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

        [Obsolete]
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

        [Obsolete]
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