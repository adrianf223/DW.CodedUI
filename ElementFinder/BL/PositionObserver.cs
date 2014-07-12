#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2014 David Wendland

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
using System.Drawing;
using System.Windows.Threading;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Utilities;

namespace ElementFinder.BL
{
    public class PositionObserver
    {
        public PositionObserver(ElementObserver elementObserver)
        {
            _elementObserver = elementObserver;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(0.5);
            _timer.Tick += OnTimerTick;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (!_elementObserver.IsAlive())
            {
                _timer.Stop();
                return;
            }

            if (!_elementObserver.IsUsable())
                return;

            var rectangle = new Rectangle(_element.AutomationElement.Current.BoundingRectangle.Left,
                                          _element.AutomationElement.Current.BoundingRectangle.Top,
                                          _element.AutomationElement.Current.BoundingRectangle.Width,
                                          _element.AutomationElement.Current.BoundingRectangle.Height);

            _highlighter.Bounds = rectangle;
        }

        private readonly ElementObserver _elementObserver;
        private readonly DispatcherTimer _timer;
        private Highlighter _highlighter;
        private AutomationElementInfo _element;

        public void Start(Highlighter highlighter, AutomationElementInfo element)
        {
            _highlighter = highlighter;
            _element = element;

            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
