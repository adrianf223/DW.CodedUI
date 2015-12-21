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
        LeftMouseButton = 0x01,

        /// <summary>
        /// The Right mouse button.
        /// </summary>
        RightMouseButton = 0x02,

        /// <summary>
        /// The Control-break processing.
        /// </summary>
        Cancel = 0x03,

        /// <summary>
        /// The Middle mouse button (three-button mouse).
        /// </summary>
        MiddleMouseButton = 0x04,

        /// <summary>
        /// The X1 mouse button.
        /// </summary>
        SpecialMouseButtonX1 = 0x05,

        /// <summary>
        /// The X2 mouse button.
        /// </summary>
        SpecialMouseButtonX2 = 0x06,

        /// <summary>
        /// The BACKSPACE key.
        /// </summary>
        Backspace = 0x08,

        /// <summary>
        /// The TAB key.
        /// </summary>
        Tab = 0x09,

        /// <summary>
        /// The CLEAR key.
        /// </summary>
        Clear = 0x0C,

        /// <summary>
        /// The ENTER key.
        /// </summary>
        Enter = 0x0D,

        /// <summary>
        /// The SHIFT key.
        /// </summary>
        Shift = 0x10,

        /// <summary>
        /// The CTRL key.
        /// </summary>
        Control = 0x11,

        /// <summary>
        /// The ALT key.
        /// </summary>
        Alt = 0x12,

        /// <summary>
        /// The PAUSE key.
        /// </summary>
        Pause = 0x13,

        /// <summary>
        /// The CAPS LOCK key.
        /// </summary>
        CapsLock = 0x14,

        /// <summary>
        /// The IME Kana mode.
        /// </summary>
        IME_KANA = 0x15,

        /// <summary>
        /// The IME Hanguel mode (maintained for compatibility; use VK_HANGUL).
        /// </summary>
        IME_Hanguel = 0x15,

        /// <summary>
        /// The IME Hangul mode.
        /// </summary>
        IME_Hangul = 0x15,

        /// <summary>
        /// The IME Junja mode.
        /// </summary>
        IME_Junja = 0x17,

        /// <summary>
        /// The IME final mode.
        /// </summary>
        IME_Final = 0x18,

        /// <summary>
        /// The IME Hanja mode.
        /// </summary>
        IME_Hanja = 0x19,

        /// <summary>
        /// The IME Kanji mode.
        /// </summary>
        IME_Kanji = 0x19,

        /// <summary>
        /// The ESC key.
        /// </summary>
        Esc = 0x1B,

        /// <summary>
        /// The IME convert.
        /// </summary>
        IME_Convert = 0x1C,

        /// <summary>
        /// The IME nonconvert.
        /// </summary>
        IME_NonConvert = 0x1D,

        /// <summary>
        /// The IME accept.
        /// </summary>
        IME_Accept = 0x1E,

        /// <summary>
        /// The IME mode change request.
        /// </summary>
        IME_ModeChangeRequest = 0x1F,

        /// <summary>
        /// The SPACEBAR.
        /// </summary>
        Space = 0x20,

        /// <summary>
        /// The PAGE UP key.
        /// </summary>
        PageUp = 0x21,

        /// <summary>
        /// The PAGE DOWN key.
        /// </summary>
        PageDown = 0x22,

        /// <summary>
        /// The END key.
        /// </summary>
        End = 0x23,

        /// <summary>
        /// The HOME key.
        /// </summary>
        Pos1 = 0x24,

        /// <summary>
        /// The LEFT ARROW key.
        /// </summary>
        Left = 0x25,

        /// <summary>
        /// The UP ARROW key.
        /// </summary>
        Up = 0x26,

        /// <summary>
        /// The RIGHT ARROW key.
        /// </summary>
        Right = 0x27,

        /// <summary>
        /// The DOWN ARROW key.
        /// </summary>
        Down = 0x28,

        /// <summary>
        /// The SELECT key.
        /// </summary>
        Select = 0x29,

        /// <summary>
        /// The PRINT key.
        /// </summary>
        Print = 0x2A,

        /// <summary>
        /// The EXECUTE key.
        /// </summary>
        Execute = 0x2B,

        /// <summary>
        /// The PRINT SCREEN key.
        /// </summary>
        Snapshot = 0x2C,

        /// <summary>
        /// The INS key.
        /// </summary>
        Insert = 0x2D,

        /// <summary>
        /// The DEL key.
        /// </summary>
        Delete = 0x2E,

        /// <summary>
        /// The HELP key.
        /// </summary>
        Help = 0x2F,

        /// <summary>
        /// The 0 key.
        /// </summary>
        D0 = 0x30,

        /// <summary>
        /// The 1 key.
        /// </summary>
        D1 = 0x31,

        /// <summary>
        /// The 2 key.
        /// </summary>
        D2 = 0x32,

        /// <summary>
        /// The 3 key.
        /// </summary>
        D3 = 0x33,

        /// <summary>
        /// The 4 key.
        /// </summary>
        D4 = 0x34,

        /// <summary>
        /// The 5 key.
        /// </summary>
        D5 = 0x35,

        /// <summary>
        /// The 6 key.
        /// </summary>
        D6 = 0x36,

        /// <summary>
        /// The 7 key.
        /// </summary>
        D7 = 0x37,

        /// <summary>
        /// The 8 key.
        /// </summary>
        D8 = 0x38,

        /// <summary>
        /// The 9 key.
        /// </summary>
        D9 = 0x39,

        /// <summary>
        /// The A key.
        /// </summary>
        A = 0x41,

        /// <summary>
        /// The B key.
        /// </summary>
        B = 0x42,
        
        /// <summary>
        /// The C key.
        /// </summary>
        C = 0x43,

        /// <summary>
        /// The D key.
        /// </summary>
        D = 0x44,

        /// <summary>
        /// The E key.
        /// </summary>
        E = 0x45,

        /// <summary>
        /// The F key.
        /// </summary>
        F = 0x46,

        /// <summary>
        /// The G key.
        /// </summary>
        G = 0x47,

        /// <summary>
        /// The H key.
        /// </summary>
        H = 0x48,

        /// <summary>
        /// The I key.
        /// </summary>
        I = 0x49,

        /// <summary>
        /// The J key.
        /// </summary>
        J = 0x4A,

        /// <summary>
        /// The K key.
        /// </summary>
        K = 0x4B,

        /// <summary>
        /// The L key.
        /// </summary>
        L = 0x4C,

        /// <summary>
        /// The M key.
        /// </summary>
        M = 0x4D,

        /// <summary>
        /// The N key.
        /// </summary>
        N = 0x4E,

        /// <summary>
        /// The O key.
        /// </summary>
        O = 0x4F,

        /// <summary>
        /// The P key.
        /// </summary>
        P = 0x50,

        /// <summary>
        /// The Q key.
        /// </summary>
        Q = 0x51,

        /// <summary>
        /// The R key.
        /// </summary>
        R = 0x52,

        /// <summary>
        /// The S key.
        /// </summary>
        S = 0x53,

        /// <summary>
        /// The T key.
        /// </summary>
        T = 0x54,

        /// <summary>
        /// The U key.
        /// </summary>
        U = 0x55,

        /// <summary>
        /// The V key.
        /// </summary>
        V = 0x56,

        /// <summary>
        /// The W key.
        /// </summary>
        W = 0x57,

        /// <summary>
        /// The X key.
        /// </summary>
        X = 0x58,

        /// <summary>
        /// The Y key.
        /// </summary>
        Y = 0x59,

        /// <summary>
        /// The Z key.
        /// </summary>
        Z = 0x5A,

        /// <summary>
        /// The Left Windows key (Natural keyboard).
        /// </summary>
        LeftWindows = 0x5B,

        /// <summary>
        /// The Right Windows key (Natural keyboard).
        /// </summary>
        RightWindows = 0x5C,

        /// <summary>
        /// The Applications key (Natural keyboard).
        /// </summary>
        Applications = 0x5D,

        /// <summary>
        /// The Computer Sleep key.
        /// </summary>
        Sleep = 0x5F,

        /// <summary>
        /// The Numeric keypad 0 key.
        /// </summary>
        Numpad0 = 0x60,

        /// <summary>
        /// The Numeric keypad 1 key.
        /// </summary>
        Numpad1 = 0x61,

        /// <summary>
        /// The Numeric keypad 2 key.
        /// </summary>
        Numpad2 = 0x62,

        /// <summary>
        /// The Numeric keypad 3 key.
        /// </summary>
        Numpad3 = 0x63,

        /// <summary>
        /// The Numeric keypad 4 key.
        /// </summary>
        Numpad4 = 0x64,

        /// <summary>
        /// The Numeric keypad 5 key.
        /// </summary>
        Numpad5 = 0x65,

        /// <summary>
        /// The Numeric keypad 6 key.
        /// </summary>
        Numpad6 = 0x66,

        /// <summary>
        /// The Numeric keypad 7 key.
        /// </summary>
        Numpad7 = 0x67,

        /// <summary>
        /// The Numeric keypad 8 key.
        /// </summary>
        Numpad8 = 0x68,

        /// <summary>
        /// The Numeric keypad 9 key.
        /// </summary>
        Numpad9 = 0x69,

        /// <summary>
        /// The Multiply key.
        /// </summary>
        Multiply = 0x6A,

        /// <summary>
        /// The Add key.
        /// </summary>
        Add = 0x6B,

        /// <summary>
        /// The Separator key.
        /// </summary>
        Separator = 0x6C,

        /// <summary>
        /// The Subtract key.
        /// </summary>
        Substract = 0x6D,

        /// <summary>
        /// The Decimal key.
        /// </summary>
        Decimal = 0x6E,

        /// <summary>
        /// The Divide key.
        /// </summary>
        Divide = 0x6F,

        /// <summary>
        /// The F1 key.
        /// </summary>
        F1 = 0x70,

        /// <summary>
        /// The F2 key.
        /// </summary>
        F2 = 0x71,

        /// <summary>
        /// The F3 key.
        /// </summary>
        F3 = 0x72,

        /// <summary>
        /// The F4 key.
        /// </summary>
        F4 = 0x73,

        /// <summary>
        /// The F5 key.
        /// </summary>
        F5 = 0x74,

        /// <summary>
        /// The F6 key.
        /// </summary>
        F6 = 0x75,

        /// <summary>
        /// The F7 key.
        /// </summary>
        F7 = 0x76,

        /// <summary>
        /// The F8 key.
        /// </summary>
        F8 = 0x77,

        /// <summary>
        /// The F9 key.
        /// </summary>
        F9 = 0x78,

        /// <summary>
        /// The F10 key.
        /// </summary>
        F10 = 0x79,

        /// <summary>
        /// The F11 key.
        /// </summary>
        F11 = 0x7A,

        /// <summary>
        /// The F12 key.
        /// </summary>
        F12 = 0x7B,

        /// <summary>
        /// The F13 key.
        /// </summary>
        F13 = 0x7C,

        /// <summary>
        /// The F14 key.
        /// </summary>
        F14 = 0x7D,

        /// <summary>
        /// The F15 key.
        /// </summary>
        F15 = 0x7E,

        /// <summary>
        /// The F16 key.
        /// </summary>
        F16 = 0x7F,

        /// <summary>
        /// The F17 key.
        /// </summary>
        F17 = 0x80,

        /// <summary>
        /// The F18 key.
        /// </summary>
        F18 = 0x81,

        /// <summary>
        /// The F19 key.
        /// </summary>
        F19 = 0x82,

        /// <summary>
        /// The F20 key.
        /// </summary>
        F20 = 0x83,

        /// <summary>
        /// The F21 key.
        /// </summary>
        F21 = 0x84,

        /// <summary>
        /// The F22 key.
        /// </summary>
        F22 = 0x85,

        /// <summary>
        /// The F23 key.
        /// </summary>
        F23 = 0x86,

        /// <summary>
        /// The F24 key.
        /// </summary>
        F24 = 0x87,

        /// <summary>
        /// The NUM LOCK key.
        /// </summary>
        Numlock = 0x90,

        /// <summary>
        /// The SCROLL LOCK key.
        /// </summary>
        Scroll = 0x91,

        /// <summary>
        /// The Left SHIFT key.
        /// </summary>
        LeftShift = 0xA0,

        /// <summary>
        /// The Right SHIFT key.
        /// </summary>
        RightShift = 0xA1,

        /// <summary>
        /// The Left CONTROL key.
        /// </summary>
        LeftControl = 0xA2,

        /// <summary>
        /// The Right CONTROL key.
        /// </summary>
        RightControl = 0xA3,

        /// <summary>
        /// The Left MENU key.
        /// </summary>
        LeftMenu = 0xA4,

        /// <summary>
        /// The Right MENU key.
        /// </summary>
        RightMenu = 0xA5,

        /// <summary>
        /// The Browser Back key.
        /// </summary>
        Browser_Back = 0xA6,

        /// <summary>
        /// The Browser Forward key.
        /// </summary>
        Browser_Forward = 0xA7,

        /// <summary>
        /// The Browser Refresh key.
        /// </summary>
        Browser_Refresh = 0xA8,

        /// <summary>
        /// The Browser Stop key.
        /// </summary>
        Browser_Stop = 0xA9,

        /// <summary>
        /// The Browser Search key.
        /// </summary>
        Browser_Search = 0xAA,

        /// <summary>
        /// The Browser Favorites key.
        /// </summary>
        Browser_Favorites = 0xAB,

        /// <summary>
        /// The Browser Start and Home key.
        /// </summary>
        Browser_Home = 0xAC,

        /// <summary>
        /// The Volume Mute key.
        /// </summary>
        Volumne_Mute = 0xAD,

        /// <summary>
        /// The Volume Down key.
        /// </summary>
        Volumne_Down = 0xAE,

        /// <summary>
        /// The Volume Up key.
        /// </summary>
        Volumne_Up = 0xAF,

        /// <summary>
        /// The Next Track key.
        /// </summary>
        Media_NextTrack = 0xB0,

        /// <summary>
        /// The Previous Track key.
        /// </summary>
        Media_PreviousTrack = 0xB1,

        /// <summary>
        /// The Stop Media key.
        /// </summary>
        Media_Stop = 0xB2,

        /// <summary>
        /// The Play/Pause Media key.
        /// </summary>
        Media_PlayPause = 0xB3,

        /// <summary>
        /// The Start Mail key.
        /// </summary>
        Launch_Mail = 0xB4,

        /// <summary>
        /// The Select Media key.
        /// </summary>
        Launch_MediaSelect = 0xB5,

        /// <summary>
        /// The Start Application 1 key.
        /// </summary>
        Launch_Application1 = 0xB6,

        /// <summary>
        /// The Start Application 2 key.
        /// </summary>
        Launch_Application2 = 0xB7,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ';:' key.
        /// </summary>
        OEM_1 = 0xBA,

        /// <summary>
        /// For any country/region, the '+' key.
        /// </summary>
        OEM_Plus = 0xBB,

        /// <summary>
        /// For any country/region, the ',' key.
        /// </summary>
        OEM_Comma = 0xBC,

        /// <summary>
        /// For any country/region, the '-' key.
        /// </summary>
        OEM_Minus = 0xBD,

        /// <summary>
        /// For any country/region, the '.' key.
        /// </summary>
        OEM_Period = 0xBE,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '/?' key.
        /// </summary>
        OEM_2 = 0xBF,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '`~' key.
        /// </summary>
        OEM_3 = 0xC0,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '[{' key.
        /// </summary>
        OEM_4 = 0xDB,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '\\|' key.
        /// </summary>
        OEM_5 = 0xDC,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ']}' key.
        /// </summary>
        OEM_6 = 0xDD,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the 'single-quote/double-quote' key.
        /// </summary>
        OEM_7 = 0xDE,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard..
        /// </summary>
        OEM_8 = 0xDF,

        /// <summary>
        /// Either the angle bracket key or the backslash key on the RT 102-key keyboard.
        /// </summary>
        OEM_102 = 0xE2,

        /// <summary>
        /// The IME PROCESS key.
        /// </summary>
        IME_Process = 0xE5,

        /// <summary>
        /// Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP.
        /// </summary>
        Packet = 0xE7,

        /// <summary>
        /// The Attn key.
        /// </summary>
        VK_ATTN = 0xF6,

        /// <summary>
        /// The CrSel key.
        /// </summary>
        CrSel = 0xF7,

        /// <summary>
        /// The ExSel key.
        /// </summary>
        ExSel = 0xF8,

        /// <summary>
        /// The Erase EOF key.
        /// </summary>
        EraseEOF = 0xF9,

        /// <summary>
        /// The Play key.
        /// </summary>
        Play = 0xFA,

        /// <summary>
        /// The Zoom key.
        /// </summary>
        Zoom = 0xFB,

        /// <summary>
        /// The PA1 key.
        /// </summary>
        PA1 = 0xFD,

        /// <summary>
        /// The Clear key.
        /// </summary>
        OEM_CLEAR = 0xFE
    }
}
