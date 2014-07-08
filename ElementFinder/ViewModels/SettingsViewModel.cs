using ElementFinder.Properties;

namespace ElementFinder.ViewModels
{
    public class SettingsViewModel : ObservableObject
    {
        public bool QuickSearch
        {
            get { return _quickSearch; }
            set
            {
                _quickSearch = value;
                NotifyPropertyChanged("QuickSearch");
            }
        }
        private bool _quickSearch;

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
            }
        }
        private bool _noticeHighlightPosition;

        public string EnableDisableShortcut
        {
            get { return _enableDisableShortcut; }
            set
            {
                _enableDisableShortcut = value;
                NotifyPropertyChanged("EnableDisableShortcut");
            }
        }
        private string _enableDisableShortcut;

        public string CopyAutomationIdShortcut
        {
            get { return _copyAutomationIdShortcut; }
            set
            {
                _copyAutomationIdShortcut = value;
                NotifyPropertyChanged("CopyAutomationIdShortcut");
            }
        }
        private string _copyAutomationIdShortcut;

        public string BringOnTopShortcut
        {
            get { return _bringOnTopShortcut; }
            set
            {
                _bringOnTopShortcut = value;
                NotifyPropertyChanged("BringOnTopShortcut");
            }
        }
        private string _bringOnTopShortcut;

        public string ToggleViewShortcut
        {
            get { return _toggleViewShortcut; }
            set
            {
                _toggleViewShortcut = value;
                NotifyPropertyChanged("ToggleViewShortcut");
            }
        }
        private string _toggleViewShortcut;

        public string WatchForElementsShortcut
        {
            get { return _watchForElementsShortcut; }
            set
            {
                _watchForElementsShortcut = value;
                NotifyPropertyChanged("WatchForElementsShortcut");
            }
        }
        private string _watchForElementsShortcut;

        public string BlacklistedProcesses
        {
            get { return _blacklistedProcesses; }
            set
            {
                _blacklistedProcesses = value;
                NotifyPropertyChanged("BlacklistedProcesses");
            }
        }
        private string _blacklistedProcesses;

        public void Load()
        {
            QuickSearch = Settings.Default.QuickSearch;
            ExpandAfterSearch = Settings.Default.ExpandAfterSearch;
            HideEmptyEntries = Settings.Default.HideEmptyEntries;
            AutoCopyAutomationId = Settings.Default.AutoCopyAutomationId;
            TopMost = Settings.Default.TopMost;
            TopMostHighlighter = Settings.Default.TopMostHighlighter;
            NoticeHighlightPosition = Settings.Default.NoticeHighlightPosition;

            EnableDisableShortcut = Settings.Default.EnableDisableShortcut;
            CopyAutomationIdShortcut = Settings.Default.CopyAutomationIdShortcut;
            BringOnTopShortcut = Settings.Default.BringOnTopShortcut;
            ToggleViewShortcut = Settings.Default.ToggleViewShortcut;
            WatchForElementsShortcut = Settings.Default.WatchForElementsShortcut;

            BlacklistedProcesses = Settings.Default.BlacklistedProcesses;
        }

        public void Save()
        {
            Settings.Default.QuickSearch = QuickSearch;
            Settings.Default.ExpandAfterSearch = ExpandAfterSearch;
            Settings.Default.HideEmptyEntries = HideEmptyEntries;
            Settings.Default.AutoCopyAutomationId = AutoCopyAutomationId;
            Settings.Default.TopMost = TopMost;
            Settings.Default.TopMostHighlighter = TopMostHighlighter;
            Settings.Default.NoticeHighlightPosition = NoticeHighlightPosition;

            Settings.Default.EnableDisableShortcut = EnableDisableShortcut;
            Settings.Default.CopyAutomationIdShortcut = CopyAutomationIdShortcut;
            Settings.Default.BringOnTopShortcut = BringOnTopShortcut;
            Settings.Default.ToggleViewShortcut = ToggleViewShortcut;
            Settings.Default.WatchForElementsShortcut = WatchForElementsShortcut;

            Settings.Default.BlacklistedProcesses = BlacklistedProcesses;

            Settings.Default.Save();
        }
    }
}
