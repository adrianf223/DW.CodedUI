using System;
using System.Windows.Input;

namespace ElementFinder.Shortcuts
{
    public class GlobalShortcut : IShortcut
    {
        public GlobalShortcut(Action<Key> pressedAction, Action<Key> releasedAction)
        {
            _pressedAction = pressedAction;
            _releasedAction = releasedAction;
        }

        private readonly Action<Key> _pressedAction;
        private readonly Action<Key> _releasedAction;

        public void KeyPressed(Key key)
        {
            _pressedAction(key);
        }

        public void KeyReleased(Key key)
        {
            _releasedAction(key);
        }
    }
}