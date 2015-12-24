#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2016 David Wendland

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
