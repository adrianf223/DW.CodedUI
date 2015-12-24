#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2016 David Wendland

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
using System.Windows.Threading;

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Brings possibilities to let run actions continiously by a timer.
    /// </summary>
    public abstract class Listener
    {
        /// <summary>
        /// Gets or sets the check to be executed on each timer tick.
        /// </summary>
        protected readonly List<Action> _checks;

        private readonly DispatcherTimer _timer;

        internal Listener()
        {
            _checks = new List<Action>();
            _timer = new DispatcherTimer();
            _timer.Interval = CodedUIEnvironment.ListenerSettings.CheckInverval;
            _timer.Tick += TimerOnTick;
        }

        /// <summary>
        /// Starts the timer which runs all checks on each tick.
        /// </summary>
        public virtual void Start()
        {
            if (!_timer.IsEnabled)
                _timer.Start();
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public virtual void Stop()
        {
            _timer.Stop();
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            foreach (var check in _checks)
                check();
            ChecksOver();
        }

        /// <summary>
        /// Called when all checks are executed.
        /// </summary>
        protected virtual void ChecksOver()
        {
        }

        /// <summary>
        /// Invokes an event asynchronously or not dependent from the CodedUIEnvironment.ListenerSettings.AsyncEventInvoke property.
        /// </summary>
        /// <typeparam name="T">The type of the event args.</typeparam>
        /// <param name="handler">The event to invoke.</param>
        /// <param name="e">The event args to pass to the event.</param>
        protected void Invoke<T>(EventHandler<T> handler, T e) where T : EventArgs
        {
            if (CodedUIEnvironment.ListenerSettings.AsyncEventInvoke)
                handler.BeginInvoke(this, e, ar => { }, null);
            else
                handler.Invoke(this, e);
        }
    }
}
