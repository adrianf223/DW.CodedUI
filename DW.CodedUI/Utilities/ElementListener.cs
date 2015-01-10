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
using DW.CodedUI.BasicElements;
using DW.CodedUI.BasicElements.Data;

namespace DW.CodedUI.Utilities
{
    public class ElementListener : Listener
    {
        private BasicElement _element;
        private BasicElementData _elementData;
        private ElementFilters _filters;

        public event EventHandler<ElementInfoEventArgs> ElementIsEnabledStateChanged;
        public event EventHandler<ElementInfoEventArgs> ElementDestroyed;
        public event EventHandler<ElementInfoEventArgs> ElementIsVisibleStateChanged;
        public event EventHandler<ElementNameChangedEventArgs> ElementNameChanged;
        public event EventHandler<ElementPositionChangedEventArgs> ElementPositionChanged;

        public ElementListener(BasicElement element)
        {
            _element = element;
        }

        public ElementFilters Filters
        {
            get { return _filters; }
            set
            {
                _filters = value;
                SetChecks();
            }
        }

        public override void Start()
        {
            _elementData = _element.GetDataCopy();
            
            base.Start();
        }

        public override void Stop()
        {
            _elementData = null;
            _element = null;

            base.Stop();
        }

        protected override void ChecksOver()
        {
            _elementData = _element.GetDataCopy();
        }

        private void SetChecks()
        {
            _checks.Clear();

            if (Filters.HasFlag(ElementFilters.IsEnabledStateChanged))
                SetEnabledStateChangedCheck();
            if (Filters.HasFlag(ElementFilters.Destroyed))
                SetDestroyedCheck();
            if (Filters.HasFlag(ElementFilters.IsVisibleStateChanged))
                SetIsVisibleStateChangedCheck();
            if (Filters.HasFlag(ElementFilters.NameChanged))
                SetNameChangedChanged();
            if (Filters.HasFlag(ElementFilters.PositionChanged))
                SetPositionChangedChanged();
        }

        private void SetEnabledStateChangedCheck()
        {
            var condition = new Action(() =>
            {
                if (!_element.IsAvailable)
                    return;

                var copy = _element.GetDataCopy();
                if (_elementData.IsEnabled != copy.IsEnabled)
                    OnElementIsEnabledStateChanged(copy);
            });
            _checks.Add(condition);
        }

        private void SetDestroyedCheck()
        {
            var condition = new Action(() =>
            {
                if (!_element.IsAvailable)
                    OnElementDestroyed(_elementData);
            });
            _checks.Add(condition);
        }

        private void SetIsVisibleStateChangedCheck()
        {
            var condition = new Action(() =>
            {
                if (!_element.IsAvailable)
                    return;

                var copy = _element.GetDataCopy();
                if (_elementData.IsVisible != copy.IsVisible)
                    OnElementIsVisibleStateChanged(copy);
            });
            _checks.Add(condition);
        }

        private void SetNameChangedChanged()
        {
            var condition = new Action(() =>
            {
                if (!_element.IsAvailable)
                    return;

                var copy = _element.GetDataCopy();
                if (_elementData.Name != copy.Name)
                    OnElementNameChanged(_elementData, copy);
            });
            _checks.Add(condition);
        }

        private void SetPositionChangedChanged()
        {
            var condition = new Action(() =>
            {
                if (!_element.IsAvailable)
                    return;

                var copy = _element.GetDataCopy();

                if (!_elementData.BoundingRectangle.Equals(copy.BoundingRectangle))
                    OnElementPositionChanged(_elementData, copy);
            });
            _checks.Add(condition);
        }

        private void OnElementIsEnabledStateChanged(BasicElementData e)
        {
            var handler = ElementIsEnabledStateChanged;
            if (handler != null)
                handler(this, new ElementInfoEventArgs(new ElementInfo(e)));
        }

        private void OnElementDestroyed(BasicElementData e)
        {
            var handler = ElementDestroyed;
            if (handler != null)
                handler(this, new ElementInfoEventArgs(new ElementInfo(e)));
        }

        private void OnElementIsVisibleStateChanged(BasicElementData e)
        {
            var handler = ElementIsVisibleStateChanged;
            if (handler != null)
                handler(this, new ElementInfoEventArgs(new ElementInfo(e)));
        }

        private void OnElementNameChanged(BasicElementData oldElementData, BasicElementData newElementData)
        {
            var handler = ElementNameChanged;
            if (handler != null)
                handler(this, new ElementNameChangedEventArgs(new ElementInfo(oldElementData), new ElementInfo(newElementData)));
        }

        private void OnElementPositionChanged(BasicElementData oldElementData, BasicElementData newElementData)
        {
            var handler = ElementPositionChanged;
            if (handler != null)
                handler(this, new ElementPositionChangedEventArgs(new ElementInfo(oldElementData), new ElementInfo(newElementData)));
        }
    }
}
