using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace ElementFinder.BL
{
    public class InteractionObserver
    {
        public InteractionObserver()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += HandleSearchTimerTick;
        }

        private readonly DispatcherTimer _timer;

        public event EventHandler TakeElements;

        private void OnTakeElements()
        {
            var handler = TakeElements;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void HandleSearchTimerTick(object sender, EventArgs e)
        {
            if (!Keyboard.Modifiers.HasFlag(ModifierKeys.Control) || !Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
                return;

            OnTakeElements();
        }
    }
}
