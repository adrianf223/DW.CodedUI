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
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.Utilities;

namespace DW.CodedUI.BasicElements
{
    // ReSharper disable MemberCanBeProtected.Global
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable UnusedVariable

    /// <summary>
    /// Represents a UI control
    /// </summary>
    public class BasicElement
    {
        private Highlighter _highlighter;

        /// <summary>
        /// Initializes a new instance of the BasicElement class
        /// </summary>
        /// <param name="automationElement">The automation control</param>
        public BasicElement(AutomationElement automationElement)
        {
            AutomationElement = automationElement;
        }

        /// <summary>
        /// Gets the automation control
        /// </summary>
        public AutomationElement AutomationElement { get; private set; }

        /// <summary>
        /// Gets an array or supported patterns
        /// </summary>
        public AutomationPattern[] SupportedPatterns
        {
            get { return AutomationElement.GetSupportedPatterns(); }
        }

        /// <summary>
        /// Gets the properties of the current control
        /// </summary>
        public AutomationElement.AutomationElementInformation Properties
        {
            get { return AutomationElement.Current; }
        }

        /// <summary>
        /// Gets the name
        /// </summary>
        public string Name
        {
            get { return Properties.Name; }
        }

        /// <summary>
        /// Gets if the control is visible
        /// </summary>
        public bool IsVisible
        {
            get { return !Properties.IsOffscreen; }
        }

        /// <summary>
        /// Gets of the control is enabled
        /// </summary>
        public bool IsEnabled
        {
            get { return Properties.IsEnabled; }
        }

        /// <summary>
        /// Waits that the control enables
        /// </summary>
        /// <remarks>It waits a maximum of 30 seconds and checks every 100 milliseconds the state</remarks>
        public void WaitForControlEnabled()
        {
            WaitForControlEnabled(TimeSpan.FromSeconds(30));
        }

        /// <summary>
        /// Waits that the control enables
        /// </summary>
        /// <param name="timeout">The timeout</param>
        /// <remarks>It checks every 100 milliseconds the state</remarks>
        public void WaitForControlEnabled(TimeSpan timeout)
        {
            WaitForControlEnabled(timeout, TimeSpan.FromMilliseconds(100));
        }

        /// <summary>
        /// Waits that the control enables
        /// </summary>
        /// <param name="timeout">The timeout</param>
        /// <param name="waitCycle">The interval for check the IsEnabled state</param>
        public void WaitForControlEnabled(TimeSpan timeout, TimeSpan waitCycle)
        {
            WaitForCondition(timeout, waitCycle, () => !Properties.IsEnabled);
        }

        /// <summary>
        /// Waits that the control gets visible
        /// </summary>
        public void WaitForControlVisible()
        {
            WaitForControlVisible(TimeSpan.FromSeconds(30));
        }

        /// <summary>
        /// Waits that the control gets visible
        /// </summary>
        /// <param name="timeout">The timeout</param>
        public void WaitForControlVisible(TimeSpan timeout)
        {
            WaitForControlVisible(timeout, TimeSpan.FromMilliseconds(100));
        }

        /// <summary>
        /// Waits that the control gets visible
        /// </summary>
        /// <param name="timeout">The timeout</param>
        /// <param name="waitCycle">The interval for check the IsVisible state</param>
        public void WaitForControlVisible(TimeSpan timeout, TimeSpan waitCycle)
        {
            WaitForCondition(timeout, waitCycle, () => Properties.IsOffscreen);
        }

        private void WaitForCondition(TimeSpan timeout, TimeSpan waitCycle, Func<bool> condition)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (condition())
            {
                Thread.Sleep(waitCycle);
                if (stopwatch.Elapsed >= timeout)
                {
                    stopwatch.Stop();
                    return;
                }
            }
        }

        /// <summary>
        /// Shows up the control highlight
        /// </summary>
        public void BeginHighlight()
        {
            if (_highlighter != null)
                _highlighter.Close();
            _highlighter = new Highlighter();
            _highlighter.Highlight(AutomationElement);
        }

        /// <summary>
        /// Removes the highlight
        /// </summary>
        public void EndHighlight()
        {
            if (_highlighter != null)
                _highlighter.Close();
        }

        /// <summary>
        /// Gets of the control is still available
        /// </summary>
        public bool IsAvailable
        {
            get
            {
                try
                {
                    var elementAvailbilityCheck = Name;
                    return true;
                }
                catch (ElementNotAvailableException)
                {
                    return false;
                }
            }
        }
    }

    // ReSharper restore MemberCanBeProtected.Global
    // ReSharper restore UnusedMember.Global
    // ReSharper restore MemberCanBePrivate.Global
    // ReSharper restore UnusedVariable
}
