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
