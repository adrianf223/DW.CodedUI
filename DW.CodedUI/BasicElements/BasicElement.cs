using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.Utilities;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a UI control.
    /// </summary>
    public class BasicElement
    {
#if TRIAL
        static BasicElement()
        {
            License1.License.Display();
        }
#endif

        private Highlighter _highlighter;

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicElement" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicElement(AutomationElement automationElement)
        {
            AutomationElement = automationElement;
        }

        /// <summary>
        /// Gets the automation control.
        /// </summary>
        public AutomationElement AutomationElement { get; private set; }

        /// <summary>
        /// Gets an array or supported patterns.
        /// </summary>
        public AutomationPattern[] SupportedPatterns
        {
            get { return AutomationElement.GetSupportedPatterns(); }
        }

        /// <summary>
        /// Gets the properties of the current control.
        /// </summary>
        public AutomationElement.AutomationElementInformation Properties
        {
            get { return AutomationElement.Current; }
        }

        /// <summary>
        /// Gets the automation ID.
        /// </summary>
        public string AutomationId
        {
            get { return Properties.AutomationId; }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get { return Properties.Name; }
        }

        /// <summary>
        /// Gets a value that indicates if the control is visible.
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
        /// Waits that the control enables.
        /// </summary>
        /// <remarks>It waits a maximum of 30 seconds and checks every 100 milliseconds the state.</remarks>
        public void WaitForControlEnabled()
        {
            WaitForControlEnabled(TimeSpan.FromSeconds(30));
        }

        /// <summary>
        /// Waits that the control enables.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <remarks>It checks every 100 milliseconds the state.</remarks>
        public void WaitForControlEnabled(TimeSpan timeout)
        {
            WaitForControlEnabled(timeout, TimeSpan.FromMilliseconds(100));
        }

        /// <summary>
        /// Waits that the control enables.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="waitCycle">The interval for check the IsEnabled state.</param>
        public void WaitForControlEnabled(TimeSpan timeout, TimeSpan waitCycle)
        {
            WaitForCondition(timeout, waitCycle, () => !Properties.IsEnabled);
        }

        /// <summary>
        /// Waits that the control gets visible.
        /// </summary>
        /// <remarks>It waits a maximum of 30 seconds and checks every 100 milliseconds the state.</remarks>
        public void WaitForControlVisible()
        {
            WaitForControlVisible(TimeSpan.FromSeconds(30));
        }

        /// <summary>
        /// Waits that the control gets visible.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <remarks>It checks every 100 milliseconds the state.</remarks>
        public void WaitForControlVisible(TimeSpan timeout)
        {
            WaitForControlVisible(timeout, TimeSpan.FromMilliseconds(100));
        }

        /// <summary>
        /// Waits that the control gets visible.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="waitCycle">The interval for check the IsVisible state.</param>
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
        /// Shows up the control highlight.
        /// </summary>
        public void BeginHighlight()
        {
            if (_highlighter != null)
                _highlighter.Close();
            _highlighter = new Highlighter();
            _highlighter.Highlight(AutomationElement);
        }

        /// <summary>
        /// Removes the highlight.
        /// </summary>
        public void EndHighlight()
        {
            if (_highlighter != null)
                _highlighter.Close();
            _highlighter = null;
        }

        /// <summary>
        /// Gets a value that indicates if the control is still available.
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
        /// Gets a combinable Do to be able to append additional settings.
        /// </summary>
        public CombinableDo Do
        {
            get { return new CombinableDo(); }
        }
    }
}
