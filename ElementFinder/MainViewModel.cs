using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Utilities;
using ElementFinder.Properties;

namespace ElementFinder
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            _interactionObserver = new InteractionObserver();
            _interactionObserver.TakeElements += HandleTakeElements;

            _elementsCatcher = new ElementsCatcher();
            _elementsCatcher.Catched += HandleCatched;

            Elements = new ObservableCollection<AutomationElementInfo>();

            IsEnabled = true;
        }

        private readonly InteractionObserver _interactionObserver;
        private readonly ElementsCatcher _elementsCatcher;
        private Highlighter _highlighter;

        public ObservableCollection<AutomationElementInfo> Elements { get; private set; }

        public AutomationElementInfo CurrentElement
        {
            get { return _currentElement; }
            set
            {
                _currentElement = value;
                NotifyPropertyChanged("CurrentElement");

                HighlightElement();
            }
        }
        private AutomationElementInfo _currentElement;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                NotifyPropertyChanged("IsEnabled");

                if (_isEnabled)
                {
                    HighlightElement();
                    _interactionObserver.Start();
                }
                else
                {
                    CloseHighlight();
                    _interactionObserver.Stop();
                }
            }
        }
        private bool _isEnabled;

        public bool QuickSearch
        {
            get { return _quickSearch; }
            set
            {
                _quickSearch = value;
                NotifyPropertyChanged("QuickSearch");
                _elementsCatcher.QuickSearch = value;
            }
        }
        private bool _quickSearch;

        public bool IsSearching
        {
            get { return _isSearching; }
            set
            {
                _isSearching = value;
                NotifyPropertyChanged("IsSearching");
            }
        }
        private bool _isSearching;

        public bool ExpandAfterSearch
        {
            get { return _expandAfterSearch; }
            set
            {
                _expandAfterSearch = value;
                NotifyPropertyChanged("ExpandAfterSearch");
            }
        }
        private bool _expandAfterSearch;

        public bool HideEmptyEntries
        {
            get { return _hideEmptyEntries; }
            set
            {
                _hideEmptyEntries = value;
                NotifyPropertyChanged("HideEmptyEntries");
            }
        }
        private bool _hideEmptyEntries;

        private void HandleTakeElements(object sender, EventArgs e)
        {
            IsSearching = true;
            _elementsCatcher.BeginCatchElements();
        }

        private void HandleCatched(object sender, CatchedElementsEventArgs e)
        {
            IsSearching = false;

            if (e.AutomationElementInfo == null)
                return;

            Elements.Clear();
            Elements.Add(e.AutomationElementInfo);
            CurrentElement = Elements.FirstOrDefault();

            if (CurrentElement != null)
                CurrentElement.IsSelected = true;
        }

        private void HighlightElement()
        {
            CloseHighlight();

            if (CurrentElement == null || !CurrentElement.IsAvailable || CurrentElement.AutomationElement.Current.IsOffscreen)
                return;

            _highlighter = new Highlighter();
            _highlighter.Highlight(CurrentElement.AutomationElement);
        }

        private void CloseHighlight()
        {
            if (_highlighter != null)
                _highlighter.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string property)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(property));
        }
    }
}