using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Utilities;
using ElementFinder.BL;
using ElementFinder.Shortcuts;

namespace ElementFinder.ViewModels
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

            _shortcutsCollector = new ShortcutsCollector();
            SetShortcuts();

            _shortcutsCollector.Start();

            IsEnabled = true;
        }

        private readonly InteractionObserver _interactionObserver;
        private readonly ElementsCatcher _elementsCatcher;
        private Highlighter _highlighter;
        private ShortcutsCollector _shortcutsCollector;

        public ObservableCollection<AutomationElementInfo> Elements { get; private set; }

        private void SetShortcuts()
        {
            _shortcutsCollector.SetShortcuts
                (
                    new Shortcut(() => IsEnabled = !IsEnabled, () => { }, Key.LeftCtrl, Key.E)
                );
        }

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

        public GridLength LeftColumnWidth
        {
            get { return _leftColumnWidth; }
            set
            {
                _leftColumnWidth = value;
                NotifyPropertyChanged("LeftColumnWidth");
            }
        }
        private GridLength _leftColumnWidth;

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

        public bool AutoCopyAutomationId
        {
            get { return _autoCopyAutomationId; }
            set
            {
                _autoCopyAutomationId = value;
                NotifyPropertyChanged("AutoCopyAutomationId");
            }
        }
        private bool _autoCopyAutomationId;

        public bool TopMost
        {
            get { return _topMost; }
            set
            {
                _topMost = value;
                NotifyPropertyChanged("TopMost");
            }
        }
        private bool _topMost;

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
            {
                CurrentElement.IsSelected = true;

                if (CurrentElement.HasAutomationId)
                    Clipboard.SetText(CurrentElement.AutomationId);
            }
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