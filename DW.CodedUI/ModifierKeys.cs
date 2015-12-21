using System;

namespace DW.CodedUI
{
    /// <summary>
    /// Represents the modifier keys.
    /// </summary>
    [Flags]
    public enum ModifierKeys
    {
        /// <summary>
        /// The ALT key.
        /// </summary>
        Alt = 0x12,

        /// <summary>
        /// The CTRL key.
        /// </summary>
        Control = 0x11,

        /// <summary>
        /// The SHIFT key.
        /// </summary>
        Shift = 0x10,

        /// <summary>
        /// The Left Windows key (Natural keyboard).
        /// </summary>
        Windows = 0x5B
    }
}