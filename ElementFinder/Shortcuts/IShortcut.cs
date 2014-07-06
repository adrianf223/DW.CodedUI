using System.Windows.Input;

namespace ElementFinder.Shortcuts
{
    public interface IShortcut
    {
        void KeyPressed(Key key);
        void KeyReleased(Key key);
    }
}