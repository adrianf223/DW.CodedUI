namespace DW.CodedUI
{
    /// <summary>
    /// Represents keys on the keyboard.
    /// </summary>
    public enum Key
    {
        /// <summary>
        /// The Left mouse button.
        /// </summary>
        VK_LBUTTON = 0x01,

        /// <summary>
        /// The Right mouse button.
        /// </summary>
        VK_RBUTTON = 0x02,

        /// <summary>
        /// The Control-break processing.
        /// </summary>
        VK_CANCEL = 0x03,

        /// <summary>
        /// The Middle mouse button (three-button mouse).
        /// </summary>
        VK_MBUTTON = 0x04,

        /// <summary>
        /// The X1 mouse button.
        /// </summary>
        VK_XBUTTON1 = 0x05,

        /// <summary>
        /// The X2 mouse button.
        /// </summary>
        VK_XBUTTON2 = 0x06,

        /// <summary>
        /// The BACKSPACE key.
        /// </summary>
        VK_BACK = 0x08,

        /// <summary>
        /// The TAB key.
        /// </summary>
        VK_TAB = 0x09,

        /// <summary>
        /// The CLEAR key.
        /// </summary>
        VK_CLEAR = 0x0C,

        /// <summary>
        /// The ENTER key.
        /// </summary>
        VK_RETURN = 0x0D,

        /// <summary>
        /// The SHIFT key.
        /// </summary>
        VK_SHIFT = 0x10,

        /// <summary>
        /// The CTRL key.
        /// </summary>
        VK_CONTROL = 0x11,

        /// <summary>
        /// The ALT key.
        /// </summary>
        VK_MENU = 0x12,

        /// <summary>
        /// The PAUSE key.
        /// </summary>
        VK_PAUSE = 0x13,

        /// <summary>
        /// The CAPS LOCK key.
        /// </summary>
        VK_CAPITAL = 0x14,

        /// <summary>
        /// The IME Kana mode.
        /// </summary>
        VK_KANA = 0x15,

        /// <summary>
        /// The IME Hanguel mode (maintained for compatibility; use VK_HANGUL).
        /// </summary>
        VK_HANGUEL = 0x15,

        /// <summary>
        /// The IME Hangul mode.
        /// </summary>
        VK_HANGUL = 0x15,

        /// <summary>
        /// The IME Junja mode.
        /// </summary>
        VK_JUNJA = 0x17,

        /// <summary>
        /// The IME final mode.
        /// </summary>
        VK_FINAL = 0x18,

        /// <summary>
        /// The IME Hanja mode.
        /// </summary>
        VK_HANJA = 0x19,

        /// <summary>
        /// The IME Kanji mode.
        /// </summary>
        VK_KANJI = 0x19,

        /// <summary>
        /// The ESC key.
        /// </summary>
        VK_ESCAPE = 0x1B,

        /// <summary>
        /// The IME convert.
        /// </summary>
        VK_CONVERT = 0x1C,

        /// <summary>
        /// The IME nonconvert.
        /// </summary>
        VK_NONCONVERT = 0x1D,

        /// <summary>
        /// The IME accept.
        /// </summary>
        VK_ACCEPT = 0x1E,

        /// <summary>
        /// The IME mode change request.
        /// </summary>
        VK_MODECHANGE = 0x1F,

        /// <summary>
        /// The SPACEBAR.
        /// </summary>
        VK_SPACE = 0x20,

        /// <summary>
        /// The PAGE UP key.
        /// </summary>
        VK_PRIOR = 0x21,

        /// <summary>
        /// The PAGE DOWN key.
        /// </summary>
        VK_NEXT = 0x22,

        /// <summary>
        /// The END key.
        /// </summary>
        VK_END = 0x23,

        /// <summary>
        /// The HOME key.
        /// </summary>
        VK_HOME = 0x24,

        /// <summary>
        /// The LEFT ARROW key.
        /// </summary>
        VK_LEFT = 0x25,

        /// <summary>
        /// The UP ARROW key.
        /// </summary>
        VK_UP = 0x26,

        /// <summary>
        /// The RIGHT ARROW key.
        /// </summary>
        VK_RIGHT = 0x27,

        /// <summary>
        /// The DOWN ARROW key.
        /// </summary>
        VK_DOWN = 0x28,

        /// <summary>
        /// The SELECT key.
        /// </summary>
        VK_SELECT = 0x29,

        /// <summary>
        /// The PRINT key.
        /// </summary>
        VK_PRINT = 0x2A,

        /// <summary>
        /// The EXECUTE key.
        /// </summary>
        VK_EXECUTE = 0x2B,

        /// <summary>
        /// The PRINT SCREEN key.
        /// </summary>
        VK_SNAPSHOT = 0x2C,

        /// <summary>
        /// The INS key.
        /// </summary>
        VK_INSERT = 0x2D,

        /// <summary>
        /// The DEL key.
        /// </summary>
        VK_DELETE = 0x2E,

        /// <summary>
        /// The HELP key.
        /// </summary>
        VK_HELP = 0x2F,

        /// <summary>
        /// The 0 key.
        /// </summary>
        K_0 = 0x30,

        /// <summary>
        /// The 1 key.
        /// </summary>
        K_1 = 0x31,

        /// <summary>
        /// The 2 key.
        /// </summary>
        K_2 = 0x32,

        /// <summary>
        /// The 3 key.
        /// </summary>
        K_3 = 0x33,

        /// <summary>
        /// The 4 key.
        /// </summary>
        K_4 = 0x34,

        /// <summary>
        /// The 5 key.
        /// </summary>
        K_5 = 0x35,

        /// <summary>
        /// The 6 key.
        /// </summary>
        K_6 = 0x36,

        /// <summary>
        /// The 7 key.
        /// </summary>
        K_7 = 0x37,

        /// <summary>
        /// The 8 key.
        /// </summary>
        K_8 = 0x38,

        /// <summary>
        /// The 9 key.
        /// </summary>
        K_9 = 0x39,

        /// <summary>
        /// The A key.
        /// </summary>
        K_A = 0x41,

        /// <summary>
        /// The B key.
        /// </summary>
        K_B = 0x42,

        /// <summary>
        /// The C key.
        /// </summary>
        K_C = 0x43,

        /// <summary>
        /// The D key.
        /// </summary>
        K_D = 0x44,

        /// <summary>
        /// The E key.
        /// </summary>
        K_E = 0x45,

        /// <summary>
        /// The F key.
        /// </summary>
        K_F = 0x46,

        /// <summary>
        /// The G key.
        /// </summary>
        K_G = 0x47,

        /// <summary>
        /// The H key.
        /// </summary>
        K_H = 0x48,

        /// <summary>
        /// The I key.
        /// </summary>
        K_I = 0x49,

        /// <summary>
        /// The J key.
        /// </summary>
        K_J = 0x4A,

        /// <summary>
        /// The K key.
        /// </summary>
        K_K = 0x4B,

        /// <summary>
        /// The L key.
        /// </summary>
        K_L = 0x4C,

        /// <summary>
        /// The M key.
        /// </summary>
        K_M = 0x4D,

        /// <summary>
        /// The N key.
        /// </summary>
        K_N = 0x4E,

        /// <summary>
        /// The O key.
        /// </summary>
        K_O = 0x4F,

        /// <summary>
        /// The P key.
        /// </summary>
        K_P = 0x50,

        /// <summary>
        /// The Q key.
        /// </summary>
        K_Q = 0x51,

        /// <summary>
        /// The R key.
        /// </summary>
        K_R = 0x52,

        /// <summary>
        /// The S key.
        /// </summary>
        K_S = 0x53,

        /// <summary>
        /// The T key.
        /// </summary>
        K_T = 0x54,

        /// <summary>
        /// The U key.
        /// </summary>
        K_U = 0x55,

        /// <summary>
        /// The V key.
        /// </summary>
        K_V = 0x56,

        /// <summary>
        /// The W key.
        /// </summary>
        K_W = 0x57,

        /// <summary>
        /// The X key.
        /// </summary>
        K_X = 0x58,

        /// <summary>
        /// The Y key.
        /// </summary>
        K_Y = 0x59,

        /// <summary>
        /// The Z key.
        /// </summary>
        K_Z = 0x5A,

        /// <summary>
        /// The Left Windows key (Natural keyboard).
        /// </summary>
        VK_LWIN = 0x5B,

        /// <summary>
        /// The Right Windows key (Natural keyboard).
        /// </summary>
        VK_RWIN = 0x5C,

        /// <summary>
        /// The Applications key (Natural keyboard).
        /// </summary>
        VK_APPS = 0x5D,

        /// <summary>
        /// The Computer Sleep key.
        /// </summary>
        VK_SLEEP = 0x5F,

        /// <summary>
        /// The Numeric keypad 0 key.
        /// </summary>
        VK_NUMPAD0 = 0x60,

        /// <summary>
        /// The Numeric keypad 1 key.
        /// </summary>
        VK_NUMPAD1 = 0x61,

        /// <summary>
        /// The Numeric keypad 2 key.
        /// </summary>
        VK_NUMPAD2 = 0x62,

        /// <summary>
        /// The Numeric keypad 3 key.
        /// </summary>
        VK_NUMPAD3 = 0x63,

        /// <summary>
        /// The Numeric keypad 4 key.
        /// </summary>
        VK_NUMPAD4 = 0x64,

        /// <summary>
        /// The Numeric keypad 5 key.
        /// </summary>
        VK_NUMPAD5 = 0x65,

        /// <summary>
        /// The Numeric keypad 6 key.
        /// </summary>
        VK_NUMPAD6 = 0x66,

        /// <summary>
        /// The Numeric keypad 7 key.
        /// </summary>
        VK_NUMPAD7 = 0x67,

        /// <summary>
        /// The Numeric keypad 8 key.
        /// </summary>
        VK_NUMPAD8 = 0x68,

        /// <summary>
        /// The Numeric keypad 9 key.
        /// </summary>
        VK_NUMPAD9 = 0x69,

        /// <summary>
        /// The Multiply key.
        /// </summary>
        VK_MULTIPLY = 0x6A,

        /// <summary>
        /// The Add key.
        /// </summary>
        VK_ADD = 0x6B,

        /// <summary>
        /// The Separator key.
        /// </summary>
        VK_SEPARATOR = 0x6C,

        /// <summary>
        /// The Subtract key.
        /// </summary>
        VK_SUBTRACT = 0x6D,

        /// <summary>
        /// The Decimal key.
        /// </summary>
        VK_DECIMAL = 0x6E,

        /// <summary>
        /// The Divide key.
        /// </summary>
        VK_DIVIDE = 0x6F,

        /// <summary>
        /// The F1 key.
        /// </summary>
        VK_F1 = 0x70,

        /// <summary>
        /// The F2 key.
        /// </summary>
        VK_F2 = 0x71,

        /// <summary>
        /// The F3 key.
        /// </summary>
        VK_F3 = 0x72,

        /// <summary>
        /// The F4 key.
        /// </summary>
        VK_F4 = 0x73,

        /// <summary>
        /// The F5 key.
        /// </summary>
        VK_F5 = 0x74,

        /// <summary>
        /// The F6 key.
        /// </summary>
        VK_F6 = 0x75,

        /// <summary>
        /// The F7 key.
        /// </summary>
        VK_F7 = 0x76,

        /// <summary>
        /// The F8 key.
        /// </summary>
        VK_F8 = 0x77,

        /// <summary>
        /// The F9 key.
        /// </summary>
        VK_F9 = 0x78,

        /// <summary>
        /// The F10 key.
        /// </summary>
        VK_F10 = 0x79,

        /// <summary>
        /// The F11 key.
        /// </summary>
        VK_F11 = 0x7A,

        /// <summary>
        /// The F12 key.
        /// </summary>
        VK_F12 = 0x7B,

        /// <summary>
        /// The F13 key.
        /// </summary>
        VK_F13 = 0x7C,

        /// <summary>
        /// The F14 key.
        /// </summary>
        VK_F14 = 0x7D,

        /// <summary>
        /// The F15 key.
        /// </summary>
        VK_F15 = 0x7E,

        /// <summary>
        /// The F16 key.
        /// </summary>
        VK_F16 = 0x7F,

        /// <summary>
        /// The F17 key.
        /// </summary>
        VK_F17 = 0x80,

        /// <summary>
        /// The F18 key.
        /// </summary>
        VK_F18 = 0x81,

        /// <summary>
        /// The F19 key.
        /// </summary>
        VK_F19 = 0x82,

        /// <summary>
        /// The F20 key.
        /// </summary>
        VK_F20 = 0x83,

        /// <summary>
        /// The F21 key.
        /// </summary>
        VK_F21 = 0x84,

        /// <summary>
        /// The F22 key.
        /// </summary>
        VK_F22 = 0x85,

        /// <summary>
        /// The F23 key.
        /// </summary>
        VK_F23 = 0x86,

        /// <summary>
        /// The F24 key.
        /// </summary>
        VK_F24 = 0x87,

        /// <summary>
        /// The NUM LOCK key.
        /// </summary>
        VK_NUMLOCK = 0x90,

        /// <summary>
        /// The SCROLL LOCK key.
        /// </summary>
        VK_SCROLL = 0x91,

        /// <summary>
        /// The Left SHIFT key.
        /// </summary>
        VK_LSHIFT = 0xA0,

        /// <summary>
        /// The Right SHIFT key.
        /// </summary>
        VK_RSHIFT = 0xA1,

        /// <summary>
        /// The Left CONTROL key.
        /// </summary>
        VK_LCONTROL = 0xA2,

        /// <summary>
        /// The Right CONTROL key.
        /// </summary>
        VK_RCONTROL = 0xA3,

        /// <summary>
        /// The Left MENU key.
        /// </summary>
        VK_LMENU = 0xA4,

        /// <summary>
        /// The Right MENU key.
        /// </summary>
        VK_RMENU = 0xA5,

        /// <summary>
        /// The Browser Back key.
        /// </summary>
        VK_BROWSER_BACK = 0xA6,

        /// <summary>
        /// The Browser Forward key.
        /// </summary>
        VK_BROWSER_FORWARD = 0xA7,

        /// <summary>
        /// The Browser Refresh key.
        /// </summary>
        VK_BROWSER_REFRESH = 0xA8,

        /// <summary>
        /// The Browser Stop key.
        /// </summary>
        VK_BROWSER_STOP = 0xA9,

        /// <summary>
        /// The Browser Search key.
        /// </summary>
        VK_BROWSER_SEARCH = 0xAA,

        /// <summary>
        /// The Browser Favorites key.
        /// </summary>
        VK_BROWSER_FAVORITES = 0xAB,

        /// <summary>
        /// The Browser Start and Home key.
        /// </summary>
        VK_BROWSER_HOME = 0xAC,

        /// <summary>
        /// The Volume Mute key.
        /// </summary>
        VK_VOLUME_MUTE = 0xAD,

        /// <summary>
        /// The Volume Down key.
        /// </summary>
        VK_VOLUME_DOWN = 0xAE,

        /// <summary>
        /// The Volume Up key.
        /// </summary>
        VK_VOLUME_UP = 0xAF,

        /// <summary>
        /// The Next Track key.
        /// </summary>
        VK_MEDIA_NEXT_TRACK = 0xB0,

        /// <summary>
        /// The Previous Track key.
        /// </summary>
        VK_MEDIA_PREV_TRACK = 0xB1,

        /// <summary>
        /// The Stop Media key.
        /// </summary>
        VK_MEDIA_STOP = 0xB2,

        /// <summary>
        /// The Play/Pause Media key.
        /// </summary>
        VK_MEDIA_PLAY_PAUSE = 0xB3,

        /// <summary>
        /// The Start Mail key.
        /// </summary>
        VK_LAUNCH_MAIL = 0xB4,

        /// <summary>
        /// The Select Media key.
        /// </summary>
        VK_LAUNCH_MEDIA_SELECT = 0xB5,

        /// <summary>
        /// The Start Application 1 key.
        /// </summary>
        VK_LAUNCH_APP1 = 0xB6,

        /// <summary>
        /// The Start Application 2 key.
        /// </summary>
        VK_LAUNCH_APP2 = 0xB7,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ';:' key.
        /// </summary>
        VK_OEM_1 = 0xBA,

        /// <summary>
        /// For any country/region, the '+' key.
        /// </summary>
        VK_OEM_PLUS = 0xBB,

        /// <summary>
        /// For any country/region, the ',' key.
        /// </summary>
        VK_OEM_COMMA = 0xBC,

        /// <summary>
        /// For any country/region, the '-' key.
        /// </summary>
        VK_OEM_MINUS = 0xBD,

        /// <summary>
        /// For any country/region, the '.' key.
        /// </summary>
        VK_OEM_PERIOD = 0xBE,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '/?' key.
        /// </summary>
        VK_OEM_2 = 0xBF,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '`~' key.
        /// </summary>
        VK_OEM_3 = 0xC0,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '[{' key.
        /// </summary>
        VK_OEM_4 = 0xDB,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '\\|' key.
        /// </summary>
        VK_OEM_5 = 0xDC,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ']}' key.
        /// </summary>
        VK_OEM_6 = 0xDD,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the 'single-quote/double-quote' key.
        /// </summary>
        VK_OEM_7 = 0xDE,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard..
        /// </summary>
        VK_OEM_8 = 0xDF,

        /// <summary>
        /// Either the angle bracket key or the backslash key on the RT 102-key keyboard.
        /// </summary>
        VK_OEM_102 = 0xE2,

        /// <summary>
        /// The IME PROCESS key.
        /// </summary>
        VK_PROCESSKEY = 0xE5,

        /// <summary>
        /// Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP.
        /// </summary>
        VK_PACKET = 0xE7,

        /// <summary>
        /// The Attn key.
        /// </summary>
        VK_ATTN = 0xF6,

        /// <summary>
        /// The CrSel key.
        /// </summary>
        VK_CRSEL = 0xF7,

        /// <summary>
        /// The ExSel key.
        /// </summary>
        VK_EXSEL = 0xF8,

        /// <summary>
        /// The Erase EOF key.
        /// </summary>
        VK_EREOF = 0xF9,

        /// <summary>
        /// The Play key.
        /// </summary>
        VK_PLAY = 0xFA,

        /// <summary>
        /// The Zoom key.
        /// </summary>
        VK_ZOOM = 0xFB,

        /// <summary>
        /// The PA1 key.
        /// </summary>
        VK_PA1 = 0xFD,

        /// <summary>
        /// The Clear key.
        /// </summary>
        VK_OEM_CLEAR = 0xFE
    }
}
