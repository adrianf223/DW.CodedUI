#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2015 David Wendland

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
    internal static class WinApi
    {
        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

        [DllImport("user32.dll")]
        internal static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        internal delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        internal static extern bool EnumThreadWindows(uint dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);

        [DllImport("user32.dll")]
        internal static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

        internal static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
        {
            return IntPtr.Size == 8 ? GetWindowLongPtr64(hWnd, nIndex) : GetWindowLongPtr32(hWnd, nIndex);
        }

        [DllImport("user32.dll")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        internal delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        internal delegate bool EnumDelegate(IntPtr hWnd, int lParam);

        [DllImport("user32.dll")]
        internal static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

        [DllImport("user32.dll")]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);

        [DllImport("user32.dll")]
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateDC(string strDriver, string strDevice, string strOutput, IntPtr pData);

        [DllImport("gdi32.dll")]
        internal static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        internal static extern int GetPixel(IntPtr hdc, int x, int y);

        [DllImport("user32.dll")]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        internal static extern IntPtr GetWindow(IntPtr hWnd, GetWindowFlags uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        internal static class KeyboardEventFlags
        {
            internal static int KEY_DOWN_EVENT = 0x0001;
            internal static int KEY_UP_EVENT = 0x0001;
        }

        //http://www.pinvoke.net/default.aspx/Enums/VK.html
        internal static class KeyboardKey
        {
            ///<summary>
            ///Left mouse button
            ///</summary>
            internal static byte LBUTTON = 0x01;
            ///<summary>
            ///Right mouse button
            ///</summary>
            internal static byte RBUTTON = 0x02;
            ///<summary>
            ///Control-break processing
            ///</summary>
            internal static byte CANCEL = 0x03;
            ///<summary>
            ///Middle mouse button (three-button mouse)
            ///</summary>
            internal static byte MBUTTON = 0x04;
            ///<summary>
            ///Windows 2000/XP: X1 mouse button
            ///</summary>
            internal static byte XBUTTON1 = 0x05;
            ///<summary>
            ///Windows 2000/XP: X2 mouse button
            ///</summary>
            internal static byte XBUTTON2 = 0x06;
            ///<summary>
            ///BACKSPACE key
            ///</summary>
            internal static byte BACK = 0x08;
            ///<summary>
            ///TAB key
            ///</summary>
            internal static byte TAB = 0x09;
            ///<summary>
            ///CLEAR key
            ///</summary>
            internal static byte CLEAR = 0x0C;
            ///<summary>
            ///ENTER key
            ///</summary>
            internal static byte RETURN = 0x0D;
            ///<summary>
            ///SHIFT key
            ///</summary>
            internal static byte SHIFT = 0x10;
            ///<summary>
            ///CTRL key
            ///</summary>
            internal static byte CONTROL = 0x11;
            ///<summary>
            ///ALT key
            ///</summary>
            internal static byte MENU = 0x12;
            ///<summary>
            ///PAUSE key
            ///</summary>
            internal static byte PAUSE = 0x13;
            ///<summary>
            ///CAPS LOCK key
            ///</summary>
            internal static byte CAPITAL = 0x14;
            ///<summary>
            ///Input Method Editor (IME) Kana mode
            ///</summary>
            internal static byte KANA = 0x15;
            ///<summary>
            ///IME Hangul mode
            ///</summary>
            internal static byte HANGUL = 0x15;
            ///<summary>
            ///IME Junja mode
            ///</summary>
            internal static byte JUNJA = 0x17;
            ///<summary>
            ///IME final mode
            ///</summary>
            internal static byte FINAL = 0x18;
            ///<summary>
            ///IME Hanja mode
            ///</summary>
            internal static byte HANJA = 0x19;
            ///<summary>
            ///IME Kanji mode
            ///</summary>
            internal static byte KANJI = 0x19;
            ///<summary>
            ///ESC key
            ///</summary>
            internal static byte ESCAPE = 0x1B;
            ///<summary>
            ///IME convert
            ///</summary>
            internal static byte CONVERT = 0x1C;
            ///<summary>
            ///IME nonconvert
            ///</summary>
            internal static byte NONCONVERT = 0x1D;
            ///<summary>
            ///IME accept
            ///</summary>
            internal static byte ACCEPT = 0x1E;
            ///<summary>
            ///IME mode change request
            ///</summary>
            internal static byte MODECHANGE = 0x1F;
            ///<summary>
            ///SPACEBAR
            ///</summary>
            internal static byte SPACE = 0x20;
            ///<summary>
            ///PAGE UP key
            ///</summary>
            internal static byte PRIOR = 0x21;
            ///<summary>
            ///PAGE DOWN key
            ///</summary>
            internal static byte NEXT = 0x22;
            ///<summary>
            ///END key
            ///</summary>
            internal static byte END = 0x23;
            ///<summary>
            ///HOME key
            ///</summary>
            internal static byte HOME = 0x24;
            ///<summary>
            ///LEFT ARROW key
            ///</summary>
            internal static byte LEFT = 0x25;
            ///<summary>
            ///UP ARROW key
            ///</summary>
            internal static byte UP = 0x26;
            ///<summary>
            ///RIGHT ARROW key
            ///</summary>
            internal static byte RIGHT = 0x27;
            ///<summary>
            ///DOWN ARROW key
            ///</summary>
            internal static byte DOWN = 0x28;
            ///<summary>
            ///SELECT key
            ///</summary>
            internal static byte SELECT = 0x29;
            ///<summary>
            ///PRINT key
            ///</summary>
            internal static byte PRINT = 0x2A;
            ///<summary>
            ///EXECUTE key
            ///</summary>
            internal static byte EXECUTE = 0x2B;
            ///<summary>
            ///PRINT SCREEN key
            ///</summary>
            internal static byte SNAPSHOT = 0x2C;
            ///<summary>
            ///INS key
            ///</summary>
            internal static byte INSERT = 0x2D;
            ///<summary>
            ///DEL key
            ///</summary>
            internal static byte DELETE = 0x2E;
            ///<summary>
            ///HELP key
            ///</summary>
            internal static byte HELP = 0x2F;
            ///<summary>
            ///0 key
            ///</summary>
            internal static byte KEY_0 = 0x30;
            ///<summary>
            ///1 key
            ///</summary>
            internal static byte KEY_1 = 0x31;
            ///<summary>
            ///2 key
            ///</summary>
            internal static byte KEY_2 = 0x32;
            ///<summary>
            ///3 key
            ///</summary>
            internal static byte KEY_3 = 0x33;
            ///<summary>
            ///4 key
            ///</summary>
            internal static byte KEY_4 = 0x34;
            ///<summary>
            ///5 key
            ///</summary>
            internal static byte KEY_5 = 0x35;
            ///<summary>
            ///6 key
            ///</summary>
            internal static byte KEY_6 = 0x36;
            ///<summary>
            ///7 key
            ///</summary>
            internal static byte KEY_7 = 0x37;
            ///<summary>
            ///8 key
            ///</summary>
            internal static byte KEY_8 = 0x38;
            ///<summary>
            ///9 key
            ///</summary>
            internal static byte KEY_9 = 0x39;
            ///<summary>
            ///A key
            ///</summary>
            internal static byte KEY_A = 0x41;
            ///<summary>
            ///B key
            ///</summary>
            internal static byte KEY_B = 0x42;
            ///<summary>
            ///C key
            ///</summary>
            internal static byte KEY_C = 0x43;
            ///<summary>
            ///D key
            ///</summary>
            internal static byte KEY_D = 0x44;
            ///<summary>
            ///E key
            ///</summary>
            internal static byte KEY_E = 0x45;
            ///<summary>
            ///F key
            ///</summary>
            internal static byte KEY_F = 0x46;
            ///<summary>
            ///G key
            ///</summary>
            internal static byte KEY_G = 0x47;
            ///<summary>
            ///H key
            ///</summary>
            internal static byte KEY_H = 0x48;
            ///<summary>
            ///I key
            ///</summary>
            internal static byte KEY_I = 0x49;
            ///<summary>
            ///J key
            ///</summary>
            internal static byte KEY_J = 0x4A;
            ///<summary>
            ///K key
            ///</summary>
            internal static byte KEY_K = 0x4B;
            ///<summary>
            ///L key
            ///</summary>
            internal static byte KEY_L = 0x4C;
            ///<summary>
            ///M key
            ///</summary>
            internal static byte KEY_M = 0x4D;
            ///<summary>
            ///N key
            ///</summary>
            internal static byte KEY_N = 0x4E;
            ///<summary>
            ///O key
            ///</summary>
            internal static byte KEY_O = 0x4F;
            ///<summary>
            ///P key
            ///</summary>
            internal static byte KEY_P = 0x50;
            ///<summary>
            ///Q key
            ///</summary>
            internal static byte KEY_Q = 0x51;
            ///<summary>
            ///R key
            ///</summary>
            internal static byte KEY_R = 0x52;
            ///<summary>
            ///S key
            ///</summary>
            internal static byte KEY_S = 0x53;
            ///<summary>
            ///T key
            ///</summary>
            internal static byte KEY_T = 0x54;
            ///<summary>
            ///U key
            ///</summary>
            internal static byte KEY_U = 0x55;
            ///<summary>
            ///V key
            ///</summary>
            internal static byte KEY_V = 0x56;
            ///<summary>
            ///W key
            ///</summary>
            internal static byte KEY_W = 0x57;
            ///<summary>
            ///X key
            ///</summary>
            internal static byte KEY_X = 0x58;
            ///<summary>
            ///Y key
            ///</summary>
            internal static byte KEY_Y = 0x59;
            ///<summary>
            ///Z key
            ///</summary>
            internal static byte KEY_Z = 0x5A;
            ///<summary>
            ///Left Windows key (Microsoft Natural keyboard) 
            ///</summary>
            internal static byte LWIN = 0x5B;
            ///<summary>
            ///Right Windows key (Natural keyboard)
            ///</summary>
            internal static byte RWIN = 0x5C;
            ///<summary>
            ///Applications key (Natural keyboard)
            ///</summary>
            internal static byte APPS = 0x5D;
            ///<summary>
            ///Computer Sleep key
            ///</summary>
            internal static byte SLEEP = 0x5F;
            ///<summary>
            ///Numeric keypad 0 key
            ///</summary>
            internal static byte NUMPAD0 = 0x60;
            ///<summary>
            ///Numeric keypad 1 key
            ///</summary>
            internal static byte NUMPAD1 = 0x61;
            ///<summary>
            ///Numeric keypad 2 key
            ///</summary>
            internal static byte NUMPAD2 = 0x62;
            ///<summary>
            ///Numeric keypad 3 key
            ///</summary>
            internal static byte NUMPAD3 = 0x63;
            ///<summary>
            ///Numeric keypad 4 key
            ///</summary>
            internal static byte NUMPAD4 = 0x64;
            ///<summary>
            ///Numeric keypad 5 key
            ///</summary>
            internal static byte NUMPAD5 = 0x65;
            ///<summary>
            ///Numeric keypad 6 key
            ///</summary>
            internal static byte NUMPAD6 = 0x66;
            ///<summary>
            ///Numeric keypad 7 key
            ///</summary>
            internal static byte NUMPAD7 = 0x67;
            ///<summary>
            ///Numeric keypad 8 key
            ///</summary>
            internal static byte NUMPAD8 = 0x68;
            ///<summary>
            ///Numeric keypad 9 key
            ///</summary>
            internal static byte NUMPAD9 = 0x69;
            ///<summary>
            ///Multiply key
            ///</summary>
            internal static byte MULTIPLY = 0x6A;
            ///<summary>
            ///Add key
            ///</summary>
            internal static byte ADD = 0x6B;
            ///<summary>
            ///Separator key
            ///</summary>
            internal static byte SEPARATOR = 0x6C;
            ///<summary>
            ///Subtract key
            ///</summary>
            internal static byte SUBTRACT = 0x6D;
            ///<summary>
            ///Decimal key
            ///</summary>
            internal static byte DECIMAL = 0x6E;
            ///<summary>
            ///Divide key
            ///</summary>
            internal static byte DIVIDE = 0x6F;
            ///<summary>
            ///F1 key
            ///</summary>
            internal static byte F1 = 0x70;
            ///<summary>
            ///F2 key
            ///</summary>
            internal static byte F2 = 0x71;
            ///<summary>
            ///F3 key
            ///</summary>
            internal static byte F3 = 0x72;
            ///<summary>
            ///F4 key
            ///</summary>
            internal static byte F4 = 0x73;
            ///<summary>
            ///F5 key
            ///</summary>
            internal static byte F5 = 0x74;
            ///<summary>
            ///F6 key
            ///</summary>
            internal static byte F6 = 0x75;
            ///<summary>
            ///F7 key
            ///</summary>
            internal static byte F7 = 0x76;
            ///<summary>
            ///F8 key
            ///</summary>
            internal static byte F8 = 0x77;
            ///<summary>
            ///F9 key
            ///</summary>
            internal static byte F9 = 0x78;
            ///<summary>
            ///F10 key
            ///</summary>
            internal static byte F10 = 0x79;
            ///<summary>
            ///F11 key
            ///</summary>
            internal static byte F11 = 0x7A;
            ///<summary>
            ///F12 key
            ///</summary>
            internal static byte F12 = 0x7B;
            ///<summary>
            ///F13 key
            ///</summary>
            internal static byte F13 = 0x7C;
            ///<summary>
            ///F14 key
            ///</summary>
            internal static byte F14 = 0x7D;
            ///<summary>
            ///F15 key
            ///</summary>
            internal static byte F15 = 0x7E;
            ///<summary>
            ///F16 key
            ///</summary>
            internal static byte F16 = 0x7F;
            ///<summary>
            ///F17 key  
            ///</summary>
            internal static byte F17 = 0x80;
            ///<summary>
            ///F18 key  
            ///</summary>
            internal static byte F18 = 0x81;
            ///<summary>
            ///F19 key  
            ///</summary>
            internal static byte F19 = 0x82;
            ///<summary>
            ///F20 key  
            ///</summary>
            internal static byte F20 = 0x83;
            ///<summary>
            ///F21 key  
            ///</summary>
            internal static byte F21 = 0x84;
            ///<summary>
            ///F22 key; (PPC only) Key used to lock device.
            ///</summary>
            internal static byte F22 = 0x85;
            ///<summary>
            ///F23 key  
            ///</summary>
            internal static byte F23 = 0x86;
            ///<summary>
            ///F24 key  
            ///</summary>
            internal static byte F24 = 0x87;
            ///<summary>
            ///NUM LOCK key
            ///</summary>
            internal static byte NUMLOCK = 0x90;
            ///<summary>
            ///SCROLL LOCK key
            ///</summary>
            internal static byte SCROLL = 0x91;
            ///<summary>
            ///Left SHIFT key
            ///</summary>
            internal static byte LSHIFT = 0xA0;
            ///<summary>
            ///Right SHIFT key
            ///</summary>
            internal static byte RSHIFT = 0xA1;
            ///<summary>
            ///Left CONTROL key
            ///</summary>
            internal static byte LCONTROL = 0xA2;
            ///<summary>
            ///Right CONTROL key
            ///</summary>
            internal static byte RCONTROL = 0xA3;
            ///<summary>
            ///Left MENU key
            ///</summary>
            internal static byte LMENU = 0xA4;
            ///<summary>
            ///Right MENU key
            ///</summary>
            internal static byte RMENU = 0xA5;
            ///<summary>
            ///Windows 2000/XP: Browser Back key
            ///</summary>
            internal static byte BROWSER_BACK = 0xA6;
            ///<summary>
            ///Windows 2000/XP: Browser Forward key
            ///</summary>
            internal static byte BROWSER_FORWARD = 0xA7;
            ///<summary>
            ///Windows 2000/XP: Browser Refresh key
            ///</summary>
            internal static byte BROWSER_REFRESH = 0xA8;
            ///<summary>
            ///Windows 2000/XP: Browser Stop key
            ///</summary>
            internal static byte BROWSER_STOP = 0xA9;
            ///<summary>
            ///Windows 2000/XP: Browser Search key 
            ///</summary>
            internal static byte BROWSER_SEARCH = 0xAA;
            ///<summary>
            ///Windows 2000/XP: Browser Favorites key
            ///</summary>
            internal static byte BROWSER_FAVORITES = 0xAB;
            ///<summary>
            ///Windows 2000/XP: Browser Start and Home key
            ///</summary>
            internal static byte BROWSER_HOME = 0xAC;
            ///<summary>
            ///Windows 2000/XP: Volume Mute key
            ///</summary>
            internal static byte VOLUME_MUTE = 0xAD;
            ///<summary>
            ///Windows 2000/XP: Volume Down key
            ///</summary>
            internal static byte VOLUME_DOWN = 0xAE;
            ///<summary>
            ///Windows 2000/XP: Volume Up key
            ///</summary>
            internal static byte VOLUME_UP = 0xAF;
            ///<summary>
            ///Windows 2000/XP: Next Track key
            ///</summary>
            internal static byte MEDIA_NEXT_TRACK = 0xB0;
            ///<summary>
            ///Windows 2000/XP: Previous Track key
            ///</summary>
            internal static byte MEDIA_PREV_TRACK = 0xB1;
            ///<summary>
            ///Windows 2000/XP: Stop Media key
            ///</summary>
            internal static byte MEDIA_STOP = 0xB2;
            ///<summary>
            ///Windows 2000/XP: Play/Pause Media key
            ///</summary>
            internal static byte MEDIA_PLAY_PAUSE = 0xB3;
            ///<summary>
            ///Windows 2000/XP: Start Mail key
            ///</summary>
            internal static byte LAUNCH_MAIL = 0xB4;
            ///<summary>
            ///Windows 2000/XP: Select Media key
            ///</summary>
            internal static byte LAUNCH_MEDIA_SELECT = 0xB5;
            ///<summary>
            ///Windows 2000/XP: Start Application 1 key
            ///</summary>
            internal static byte LAUNCH_APP1 = 0xB6;
            ///<summary>
            ///Windows 2000/XP: Start Application 2 key
            ///</summary>
            internal static byte LAUNCH_APP2 = 0xB7;
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            internal static byte OEM_1 = 0xBA;
            ///<summary>
            ///Windows 2000/XP: For any country/region; the '+' key
            ///</summary>
            internal static byte OEM_PLUS = 0xBB;
            ///<summary>
            ///Windows 2000/XP: For any country/region; the ';' key
            ///</summary>
            internal static byte OEM_COMMA = 0xBC;
            ///<summary>
            ///Windows 2000/XP: For any country/region; the '-' key
            ///</summary>
            internal static byte OEM_MINUS = 0xBD;
            ///<summary>
            ///Windows 2000/XP: For any country/region; the '.' key
            ///</summary>
            internal static byte OEM_PERIOD = 0xBE;
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            internal static byte OEM_2 = 0xBF;
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            internal static byte OEM_3 = 0xC0;
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            internal static byte OEM_4 = 0xDB;
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            internal static byte OEM_5 = 0xDC;
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            internal static byte OEM_6 = 0xDD;
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            internal static byte OEM_7 = 0xDE;
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            internal static byte OEM_8 = 0xDF;
            ///<summary>
            ///Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard
            ///</summary>
            internal static byte OEM_102 = 0xE2;
            ///<summary>
            ///Windows 95/98/Me; Windows NT 4.0; Windows 2000/XP: IME PROCESS key
            ///</summary>
            internal static byte PROCESSKEY = 0xE5;
            ///<summary>
            ///Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information; see Remark in KEYBDINPUT; SendInput; WM_KEYDOWN; and WM_KEYUP
            ///</summary>
            internal static byte PACKET = 0xE7;
            ///<summary>
            ///Attn key
            ///</summary>
            internal static byte ATTN = 0xF6;
            ///<summary>
            ///CrSel key
            ///</summary>
            internal static byte CRSEL = 0xF7;
            ///<summary>
            ///ExSel key
            ///</summary>
            internal static byte EXSEL = 0xF8;
            ///<summary>
            ///Erase EOF key
            ///</summary>
            internal static byte EREOF = 0xF9;
            ///<summary>
            ///Play key
            ///</summary>
            internal static byte PLAY = 0xFA;
            ///<summary>
            ///Zoom key
            ///</summary>
            internal static byte ZOOM = 0xFB;
            ///<summary>
            ///Reserved 
            ///</summary>
            internal static byte NONAME = 0xFC;
            ///<summary>
            ///PA1 key
            ///</summary>
            internal static byte PA1 = 0xFD;

            ///<summary>
            ///Clear key
            ///</summary>
            internal static byte OEM_CLEAR = 0xFE;
        }

        [Flags]
        internal enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            WHEEL = 0x00000800,
            XDOWN = 0x00000080,
            XUP = 0x00000100
        }

        //Use the values of this enum for the 'dwData' parameter
        //to specify an X button when using MouseEventFlags.XDOWN or
        //MouseEventFlags.XUP for the dwFlags parameter.
        internal enum MouseEventDataXButtons : uint
        {
            XBUTTON1 = 0x00000001,
            XBUTTON2 = 0x00000002
        }

        internal const int ID_Close = 0x10;

        internal const uint WS_DISABLED = 0x8000000;

        internal enum ShowWindowCommands
        {
            Hide = 0,
            Normal = 1,
            ShowMinimized = 2,
            Maximize = 3,
            ShowMaximized = 3,
            ShowNoActivate = 4,
            Show = 5,
            Minimize = 6,
            ShowMinNoActive = 7,
            ShowNA = 8,
            Restore = 9,
            ShowDefault = 10,
            ForceMinimize = 11
        }

        internal enum GetWindowFlags : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public WindowState showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        internal enum WindowLongFlags : int
        {
            GWL_EXSTYLE = -20,
            GWLP_HINSTANCE = -6,
            GWLP_HWNDPARENT = -8,
            GWL_ID = -12,
            GWL_STYLE = -16,
            GWL_USERDATA = -21,
            GWL_WNDPROC = -4,
            DWLP_USER = 0x8,
            DWLP_MSGRESULT = 0x0,
            DWLP_DLGPROC = 0x4
        }

        internal static class HwndInsertAfter
        {
            public static IntPtr HWND_NOTOPMOST = new IntPtr(-2);
            public static IntPtr HWND_TOPMOST = new IntPtr(-1);
            public static IntPtr HWND_TOP = new IntPtr(0);
            public static IntPtr HWND_BOTTOM = new IntPtr(1);
        }

        internal static class SetWindowPositionFlags
        {
            public static readonly uint SWP_NOSIZE = 0x0001;
            public static readonly uint SWP_NOMOVE = 0x0002;
            public static readonly uint SWP_NOZORDER = 0x0004;
            public static readonly uint SWP_NOREDRAW = 0x0008;
            public static readonly uint SWP_NOACTIVATE = 0x0010;
            public static readonly uint SWP_DRAWFRAME = 0x0020;
            public static readonly uint SWP_FRAMECHANGED = 0x0020;
            public static readonly uint SWP_SHOWWINDOW = 0x0040;
            public static readonly uint SWP_HIDEWINDOW = 0x0080;
            public static readonly uint SWP_NOCOPYBITS = 0x0100;
            public static readonly uint SWP_NOOWNERZORDER = 0x0200;
            public static readonly uint SWP_NOREPOSITION = 0x0200;
            public static readonly uint SWP_NOSENDCHANGING = 0x0400;
            public static readonly uint SWP_DEFERERASE = 0x2000;
            public static readonly uint SWP_ASYNCWINDOWPOS = 0x4000;
        }
    }
}
