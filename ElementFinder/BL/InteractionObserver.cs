using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using ElementFinder.Properties;

namespace ElementFinder.BL
{
    public class InteractionObserver
    {
        public InteractionObserver()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += HandleSearchTimerTick;

            _shortCuts = new List<Key>();

            UpdateShortcut();
        }

        private List<Key> _shortCuts;

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
            if (_shortCuts.All(Keyboard.IsKeyDown))
                OnTakeElements();
        }

        public void UpdateShortcut()
        {
            var keyStrings = Settings.Default.WatchForElementsShortcut.Split(new[] { " + " }, StringSplitOptions.RemoveEmptyEntries);
            var keys = ToKeys(keyStrings);

            _shortCuts.Clear();
            _shortCuts.AddRange(keys);
        }

        private List<Key> ToKeys(string[] keyStrings)
        {
            var keys = new List<Key>();
            foreach (var keyString in keyStrings)
            {
                Key key;
                if (Enum.TryParse(keyString, true, out key))
                    keys.Add(key);
            }

            return keys;
        }
    }
}
