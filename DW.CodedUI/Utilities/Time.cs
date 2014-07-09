namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Holds a bunch of available time length to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep" />.
    /// </summary>
    public enum Time
    {
        /// <summary>
        /// Represents a very short time. The time can be adjusted in the <see cref="DW.CodedUI.CodedUIEnvironment.SleepSettings" />.VeryShort. The default is 500 milliseconds.
        /// </summary>
        VeryShort,

        /// <summary>
        /// Represents a very short time. The time can be adjusted in the <see cref="DW.CodedUI.CodedUIEnvironment.SleepSettings" />.Short. The default is 1000 milliseconds.
        /// </summary>
        Short,

        /// <summary>
        /// Represents a very short time. The time can be adjusted in the <see cref="DW.CodedUI.CodedUIEnvironment.SleepSettings" />.Medium. The default is 1500 milliseconds.
        /// </summary>
        Medium,

        /// <summary>
        /// Represents a very short time. The time can be adjusted in the <see cref="DW.CodedUI.CodedUIEnvironment.SleepSettings" />.Long. The default is 2000 milliseconds.
        /// </summary>
        Long,

        /// <summary>
        /// Represents a very short time. The time can be adjusted in the <see cref="DW.CodedUI.CodedUIEnvironment.SleepSettings" />.VeryLong. The default is 2500 milliseconds.
        /// </summary>
        VeryLong
    }
}