using System;
using System.Windows.Threading;
using DW.CodedUI.BasicElements;

namespace ElementFinder.BL
{
    public class ElementObserver
    {
        public ElementObserver()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(0.5);
            _timer.Tick += OnTimerTick;
        }

        private AutomationElementInfo _element;
        private readonly DispatcherTimer _timer;

        public event EventHandler ElementDied;

        public void Start(AutomationElementInfo element)
        {
            _element = element;
            _timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (!IsAlive())
            {
                Stop();

                var handler = ElementDied;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }

        public void Stop()
        {
            _timer.Stop();
            _element = null;
        }

        public bool IsAlive()
        {
            if (_element == null || !_element.IsAvailable)
            {
                _element = null;
                return false;
            }
            return true;
        }

        public bool IsUsable()
        {
            return IsAlive() && !_element.AutomationElement.Current.IsOffscreen;
        }
    }
}
