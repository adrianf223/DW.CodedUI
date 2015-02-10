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
    /// <summary>
    /// Brings possibilities to observe a <see cref="DW.CodedUI.BasicElements.BasicElement" /> to get events if something happened.
    /// </summary>
    public class ElementListener : Listener
    {
        private BasicElement _element;
        private BasicElementData _elementData;
        private ElementFilters _filters;

        /// <summary>
        /// Occurs when the IsEnabled state of the <see cref="DW.CodedUI.BasicElements.BasicElement" /> changes.
        /// </summary>
        public event EventHandler<ElementChangedEventArgs> ElementIsEnabledStateChanged;

        /// <summary>
        /// Occurs when the <see cref="DW.CodedUI.BasicElements.BasicElement" /> got destroyed.
        /// </summary>
        public event EventHandler<ElementChangedEventArgs> ElementDestroyed;

        /// <summary>
        /// Occurs when the IsVisible state of the <see cref="DW.CodedUI.BasicElements.BasicElement" /> changes.
        /// </summary>
        public event EventHandler<ElementChangedEventArgs> ElementIsVisibleStateChanged;

        /// <summary>
        /// Occurs when the Name of the <see cref="DW.CodedUI.BasicElements.BasicElement" /> changes.
        /// </summary>
        public event EventHandler<ElementChangedEventArgs> ElementNameChanged;

        /// <summary>
        /// Occurs when the position (BoundingRectangle) of the <see cref="DW.CodedUI.BasicElements.BasicElement" /> changes.
        /// </summary>
        public event EventHandler<ElementChangedEventArgs> ElementPositionChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.Utilities.ElementListener" /> class.
        /// </summary>
        /// <param name="element">The BasicElement which states should be listened to.</param>
        public ElementListener(BasicElement element)
        {
            _element = element;
        }

        /// <summary>
        /// Gets or sets values which indicates which properties of the <see cref="DW.CodedUI.BasicElements.BasicElement" /> should be observed.
        /// </summary>
        public ElementFilters Filters
        {
            get { return _filters; }
            set
            {
                _filters = value;
                SetChecks();
            }
        }

        /// <summary>
        /// Starts observing of the <see cref="DW.CodedUI.BasicElements.BasicElement" /> properties. To say which one see <see cref="DW.CodedUI.Utilities.ElementListener.Filters" />.
        /// </summary>
        public override void Start()
        {
            _elementData = _element.GetDataCopy();
            
            base.Start();
        }

        /// <summary>
        /// Stopps observing of the <see cref="DW.CodedUI.BasicElements.BasicElement" /> properties.
        /// </summary>
        /// <remarks>The <see cref="DW.CodedUI.Utilities.ElementListener.Filters" /> will not be resetted.</remarks>
        public override void Stop()
        {
            _elementData = null;
            _element = null;

            base.Stop();
        }

        /// <summary>
        /// All checks are done and the current <see cref="DW.CodedUI.BasicElements.BasicElement" /> state can be taken.
        /// </summary>
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
                    OnElementIsEnabledStateChanged(_elementData, copy);
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
                    OnElementIsVisibleStateChanged(_elementData, copy);
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

        private void OnElementIsEnabledStateChanged(BasicElementData oldElementData, BasicElementData newElementData)
        {
            var handler = ElementIsEnabledStateChanged;
            if (handler != null)
                Invoke(handler, new ElementChangedEventArgs(ElementChangeKind.Enabled, new ElementInfo(oldElementData), new ElementInfo(newElementData)));
        }

        private void OnElementDestroyed(BasicElementData e)
        {
            var handler = ElementDestroyed;
            if (handler != null)
                Invoke(handler, new ElementChangedEventArgs(ElementChangeKind.Destroyed, new ElementInfo(e), null));
        }

        private void OnElementIsVisibleStateChanged(BasicElementData oldElementData, BasicElementData newElementData)
        {
            var handler = ElementIsVisibleStateChanged;
            if (handler != null)
                Invoke(handler, new ElementChangedEventArgs(ElementChangeKind.VisibleStateChanged, new ElementInfo(oldElementData), new ElementInfo(newElementData)));
        }

        private void OnElementNameChanged(BasicElementData oldElementData, BasicElementData newElementData)
        {
            var handler = ElementNameChanged;
            if (handler != null)
                Invoke(handler, new ElementChangedEventArgs(ElementChangeKind.NameChanged, new ElementInfo(oldElementData), new ElementInfo(newElementData)));
        }

        private void OnElementPositionChanged(BasicElementData oldElementData, BasicElementData newElementData)
        {
            var handler = ElementPositionChanged;
            if (handler != null)
                Invoke(handler, new ElementChangedEventArgs(ElementChangeKind.PositionChanged, new ElementInfo(oldElementData), new ElementInfo(newElementData)));
        }
    }
}
