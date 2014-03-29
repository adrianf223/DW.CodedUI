using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.Utilities;

namespace DW.CodedUI.BasicElements
{
    public class BasicElement
    {
        private Highlighter _highlighter;

        public BasicElement(AutomationElement automationElement)
        {
            AutomationElement = automationElement;
        }

        public AutomationElement AutomationElement { get; private set; }

        public AutomationPattern[] SupportedPatterns
        {
            get { return AutomationElement.GetSupportedPatterns(); }
        }

        public AutomationElement.AutomationElementInformation Properties
        {
            get { return AutomationElement.Current; }
        }

        public string AutomationId
        {
            get { return Properties.AutomationId; }
        }

        public string Name
        {
            get { return Properties.Name; }
        }

        public bool IsVisible
        {
            get { return !Properties.IsOffscreen; }
        }

        public bool IsEnabled
        {
            get { return Properties.IsEnabled; }
        }

        public void WaitForControlEnabled()
        {
            WaitForControlEnabled(TimeSpan.FromSeconds(30));
        }

        public void WaitForControlEnabled(TimeSpan timeout)
        {
            WaitForControlEnabled(timeout, TimeSpan.FromMilliseconds(100));
        }

        public void WaitForControlEnabled(TimeSpan timeout, TimeSpan waitCycle)
        {
            WaitForCondition(timeout, waitCycle, () => !Properties.IsEnabled);
        }

        public void WaitForControlVisible()
        {
            WaitForControlVisible(TimeSpan.FromSeconds(30));
        }

        public void WaitForControlVisible(TimeSpan timeout)
        {
            WaitForControlVisible(timeout, TimeSpan.FromMilliseconds(100));
        }

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

        public void BeginHighlight()
        {
            if (_highlighter != null)
                _highlighter.Close();
            _highlighter = new Highlighter();
            _highlighter.Highlight(AutomationElement);
        }

        public void EndHighlight()
        {
            if (_highlighter != null)
                _highlighter.Close();
        }

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
    }
}
