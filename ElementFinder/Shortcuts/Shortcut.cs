using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;

namespace ElementFinder.Shortcuts
{
    public class Shortcut : IShortcut
    {
        private readonly Dictionary<Key, bool> _keys;
        private readonly Action _pressedAction;
        private readonly Action _releasedAction;

        public Shortcut(Action pressedAction, Action releasedAction, params Key[] keys)
        {
            _keys = new Dictionary<Key, bool>();
            foreach (var key in keys)
                _keys[key] = false;

            _pressedAction = pressedAction;
            _releasedAction = releasedAction;
        }

        public void KeyPressed(Key key)
        {
            if (_keys.ContainsKey(key) && !_keys[key])
            {
                _keys[key] = true;
                CheckStateChange();
            }
        }

        public void KeyReleased(Key key)
        {
            if (_keys.ContainsKey(key) && _keys[key])
            {
                _keys[key] = false;
                CheckStateChange();
            }
        }

        private void CheckStateChange()
        {
            if (_keys.Values.All(s => s))
            {
                if (_pressedAction != null)
                    _pressedAction();
            }
            else
            {
                if (_releasedAction != null)
                    _releasedAction();
            }
        }
    }
}
