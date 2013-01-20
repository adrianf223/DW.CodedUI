#region License
/*--------------------------------------------------------------------------------
    Copyright (c) 2012-2013 David Wendland

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
--------------------------------------------------------------------------------*/
#endregion License

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents information about a UI control
    /// </summary>
    public class BasicElementInfo : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the automation control
        /// </summary>
        public AutomationElement AutomationElement { get; private set; }

        /// <summary>
        /// Gets all available child controls
        /// </summary>
        public List<BasicElementInfo> Children { get; private set; }

        /// <summary>
        /// Initializes a new instance of the BasicElementInfo class
        /// </summary>
        /// <param name="element">The automation control</param>
        public BasicElementInfo(AutomationElement element)
        {
            AutomationElement = element;
            Children = new List<BasicElementInfo>();
        }

        /// <summary>
        /// Provides a good visible feedback of the control
        /// </summary>
        /// <returns></returns>
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
        /// Gets if the control has an automation id
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
        /// Gets if the control is selected
        /// </summary>
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

        /// <summary>
        /// Gets of the control is still available
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

        #region NotifyPropertyChanged

        /// <summary>
        /// Occurs when a property value changes
        /// </summary>
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