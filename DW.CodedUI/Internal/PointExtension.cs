namespace DW.CodedUI.Tests.Internal
{
    internal static class PointExtension
    {
        internal static System.Drawing.Point ToDrawingPoint(this System.Windows.Point point)
        {
            return new System.Drawing.Point((int)point.X, (int)point.Y);
        }

        internal static System.Windows.Point ToWindowsPoint(this System.Drawing.Point point)
        {
            return new System.Windows.Point(point.X, point.Y);
        }
    }
}
