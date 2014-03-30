﻿using System;
using System.ComponentModel;
using DW.CodedUI.BasicElements;

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

            IsEnabled = true;
        }

        private readonly InteractionObserver _interactionObserver;
        private readonly ElementsCatcher _elementsCatcher;

        public AutomationElementInfo CurrentElement
        {
            get { return _currentElement; }
            set
            {
                _currentElement = value;
                NotifyPropertyChanged("CurrentElement");
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
                    _interactionObserver.Start();
                else
                    _interactionObserver.Stop();
            }
        }
        private bool _isEnabled;

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
        
        private void HandleTakeElements(object sender, EventArgs e)
        {
            IsSearching = true;
            _elementsCatcher.BeginCatchElements();
        }

        private void HandleCatched(object sender, CatchedElementsEventArgs e)
        {
            CurrentElement = e.AutomationElementInfo;
            IsSearching = false;
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