#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2015 David Wendland

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
THE SOFTWARE
*/
#endregion License

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
