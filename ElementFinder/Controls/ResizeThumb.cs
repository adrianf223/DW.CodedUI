using System.Windows;
using System.Windows.Controls.Primitives;

namespace ElementFinder.Controls
{
    public class ResizeThumb : Thumb
    {
        static ResizeThumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResizeThumb), new FrameworkPropertyMetadata(typeof(ResizeThumb)));
        }
    }
}
