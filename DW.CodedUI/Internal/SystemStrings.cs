using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DW.CodedUI.Internal
{
    internal static class SystemStrings
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int LoadString(IntPtr hInstance, uint stringId, StringBuilder lpBuffer, int nBufferMax);
        
        [DllImport("kernel32")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        internal const uint MinimizeButton = 900; // MinimizeButton button
        internal const uint MaximizeButton = 901; // Maxmize button
        internal const uint IncreaseButton = 902;
        internal const uint DecreaseButton = 903; // Normalize button
        internal const uint CloseButton = 905;    // CloseButton button 

        internal static string GetString(uint id)
        {
            var sb = new StringBuilder(256);
            var user32 = LoadLibrary(Environment.SystemDirectory + "\\User32.dll");
            LoadString(user32, id, sb, sb.Capacity);
            return sb.ToString();
        }
    }
}
