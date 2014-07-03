using System;
using System.Drawing;
using System.Windows.Threading;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Utilities;

namespace ElementFinder.BL
{
    public class PositionObserver
    {
        public PositionObserver()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(0.5);
            _timer.Tick += OnTimerTick;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (_element == null || !_element.IsAvailable)
            {
                _timer.Stop();
                return;
            }
                
            if (_element.AutomationElement.Current.IsOffscreen)
                return;

            var rectangle = new Rectangle(_element.AutomationElement.Current.BoundingRectangle.Left,
                                          _element.AutomationElement.Current.BoundingRectangle.Top,
                                          _element.AutomationElement.Current.BoundingRectangle.Width,
                                          _element.AutomationElement.Current.BoundingRectangle.Height);

            _highlighter.Bounds = rectangle;
        }

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
