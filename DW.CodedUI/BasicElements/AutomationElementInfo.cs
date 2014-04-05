using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents information about an UI control.
    /// </summary>
    /// <remarks>This object is intended to be used in the ElementFinder.</remarks>
    public class AutomationElementInfo : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the automation control.
        /// </summary>
        public AutomationElement AutomationElement { get; private set; }

        /// <summary>
        /// Gets all available child controls.
        /// </summary>
        public List<AutomationElementInfo> Children { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.AutomationElementInfo" /> class
        /// </summary>
        /// <param name="element">The automation control.</param>
        public AutomationElementInfo(AutomationElement element)
        {
            AutomationElement = element;
            Children = new List<AutomationElementInfo>();
        }

        /// <summary>
        /// Provides a good visible feedback of the control.
        /// </summary>
        /// <returns>A good name of the control with the automation ID if any.</returns>
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

        /// <summary>
        /// Gets the automation ID of the control if available; otherwise "&lt;no automation id&gt;" or "&lt;element is gone&gt;". Consider using <see cref="DW.CodedUI.BasicElements.AutomationElementInfo.HasAutomationId" />.
        /// </summary>
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

        /// <summary>
        /// Gets the name of the control if available; otherwise "&lt;no aname&gt;" or "&lt;element is gone&gt;".
        /// </summary>
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

        /// <summary>
        /// Gets a value that indicated if the control has an automation id.
        /// </summary>
        public bool HasAutomationId
        {
            get
            {
                if (!IsAvailable)
                    return false;

                return !string.IsNullOrWhiteSpace(AutomationElement.Current.AutomationId);
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates of the element is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyPropertyChanged("IsSelected");
            }
        }

        private bool _isSelected;

        /// <summary>
        /// Gets a value that indicates of the the control is still available.
        /// </summary>
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

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string property)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(property));
        }
    }
}