using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Utilities;
using ElementFinder.BL;
using ElementFinder.Shortcuts;

namespace ElementFinder.ViewModels
{
    public class MainViewModel : ObservableObject
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

            _elementObserver = new ElementObserver();
            _elementObserver.ElementDied += HandleElementDied;
            _positionObserver = new PositionObserver(_elementObserver);

            IsEnabled = true;
        }

        private readonly ElementObserver _elementObserver;
        private readonly InteractionObserver _interactionObserver;
        private readonly PositionObserver _positionObserver;
        private readonly ElementsCatcher _elementsCatcher;
        private Highlighter _highlighter;
        private readonly ShortcutsCollector _shortcutsCollector;

        public ObservableCollection<AutomationElementInfo> Elements { get; private set; }

        private void SetShortcuts()
        {
            _shortcutsCollector.SetShortcuts
                (
                    new Shortcut(() => IsEnabled = !IsEnabled, () => { }, Key.LeftCtrl, Key.E)
                );
        }

        #region Properties

        public AutomationElementInfo CurrentElement
        {
            get { return _currentElement; }
            set
            {
                _currentElement = value;
                NotifyPropertyChanged("CurrentElement");

                if (_currentElement != null)
                    CurrentElementSet();
                else
                    CurrentElementRemoved();
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
                    EnableElementFinder();
                else
                    DisableElementFinder();
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

                SetQuickSearch(value);
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

        public bool TopMostHighlighter
        {
            get { return _topMostHighlighter; }
            set
            {
                _topMostHighlighter = value;
                NotifyPropertyChanged("TopMostHighlighter");

                SetTopMostHighlighter(_topMostHighlighter);
            }
        }
        private bool _topMostHighlighter;

        public bool NoticeHighlightPosition
        {
            get { return _noticeHighlightPosition; }
            set
            {
                _noticeHighlightPosition = value;
                NotifyPropertyChanged("NoticeHighlightPosition");

                if (_noticeHighlightPosition)
                    StartHighlightPositionObserver();
                else
                    StopHighlightPositionObserver();
            }
        }
        private bool _noticeHighlightPosition;

        #endregion Properties

        private void CurrentElementSet()
        {
            _elementObserver.Start(CurrentElement);
            _positionObserver.Start(_highlighter, CurrentElement);

            HighlightElement();
        }

        private void CurrentElementRemoved()
        {
            _elementObserver.Stop();
            _positionObserver.Stop();

            CloseHighlight();
        }

        private void EnableElementFinder()
        {
            _interactionObserver.Start();

            CurrentElement = CurrentElement;
        }

        private void DisableElementFinder()
        {
            CurrentElementRemoved();
        }

        private void SetQuickSearch(bool isQuickSearch)
        {
            _elementsCatcher.QuickSearch = isQuickSearch;
        }
        
        private void SetTopMostHighlighter(bool isToTopMost)
        {
            if (_highlighter != null)
                _highlighter.TopMost = isToTopMost;
        }

        private void HandleElementDied(object sender, EventArgs e)
        {
            CurrentElementRemoved();
        }

        private void HandleTakeElements(object sender, EventArgs e)
        {
            IsSearching = true;
            _elementsCatcher.BeginCatchElements();
        }

        private void StartHighlightPositionObserver()
        {
            if (_elementObserver.IsUsable() && NoticeHighlightPosition)
                _positionObserver.Start(_highlighter, CurrentElement);
        }

        private void StopHighlightPositionObserver()
        {
            _positionObserver.Stop();
        }

        private void HandleCatched(object sender, CatchedElementsEventArgs e)
        {
            IsSearching = false;

            if (e.AutomationElementInfo == null)
                return;

            Elements.Clear();
            Elements.Add(e.AutomationElementInfo);
            CurrentElement = Elements.FirstOrDefault();

            if (!_elementObserver.IsUsable())
                return;

            CurrentElement.IsSelected = true;
            if (CurrentElement.HasAutomationId)
                Clipboard.SetText(CurrentElement.AutomationId);
        }

        private void HighlightElement()
        {
            CloseHighlight();

            if (!_elementObserver.IsUsable())
                return;

            _highlighter = new Highlighter();
            _highlighter.TopMost = TopMostHighlighter;
            _highlighter.Highlight(CurrentElement.AutomationElement);

            StartHighlightPositionObserver();
        }

        private void CloseHighlight()
        {
            if (_highlighter != null)
            {
                _highlighter.Close();
                _highlighter = null;

                StopHighlightPositionObserver();
            }
        }
    }
}