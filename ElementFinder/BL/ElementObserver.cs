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
