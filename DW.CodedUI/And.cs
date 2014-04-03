using System.Collections.Generic;

namespace DW.CodedUI
{
    /// <summary>
    /// Defines all possibile settings to be used by searching for windows. See <see cref="DW.CodedUI.WindowFinder" />.
    /// </summary>
    public abstract class And
    {
        /// <summary>
        /// The window should be searched again and again as long this timeout is not elapsed.
        /// </summary>
        /// <param name="milliseconds">The timeout in milliseconds.</param>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public static CombinableAnd Timeout(uint milliseconds)
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.Timeout(milliseconds);
        }

        /// <summary>
        /// The window should be searched just once.
        /// </summary>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public static CombinableAnd NoTimeout()
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.NoTimeout();
        }

        /// <summary>
        /// If the window is not found an exception has to be thrown.
        /// </summary>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public static CombinableAnd Assert()
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.Assert();
        }

        /// <summary>
        /// If the window is not found no exception has to be thrown. In this case the Search returns null.
        /// </summary>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public static CombinableAnd NoAssert()
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.NoAssert();
        }

        /// <summary>
        /// If multiple windows got found the N. window get returned.
        /// </summary>
        /// <param name="instanceNumber">The instance number N.</param>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public static CombinableAnd InstanceNumber(uint instanceNumber)
        {
            var combinableAndSetting = new CombinableAnd();
            return combinableAndSetting.InstanceNumber(instanceNumber);
        }

        /// <summary>
        /// The WindowFinder is searching for windows again and again as soon the timeout is not ellapsed. This defines the wait time beween each search run.
        /// </summary>
        /// <param name="milliseconds">The wait time in milliseconds between the searches</param>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public static CombinableAnd Interval(uint milliseconds)
        {
            var combinableWith = new CombinableAnd();
            return combinableWith.Interval(milliseconds);
        }

        /// <summary>
        /// The WindowFinder is searching for windows again and again as soon the timeout is not ellapsed. This defines that there is no wait time between each search run.
        /// </summary>
        /// <returns>A combinable And to be able to append additional settings.</returns>
        public static CombinableAnd NoInterval()
        {
            var combinableWith = new CombinableAnd();
            return combinableWith.NoInterval();
        }

        internal abstract List<AndCondition> GetConditions();
        internal abstract uint GetTimeout();
        internal abstract uint GetInstanceNumber();
        internal abstract uint GetInterval();
    }
}