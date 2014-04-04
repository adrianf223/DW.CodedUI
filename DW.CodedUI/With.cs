using System.Collections.Generic;

namespace DW.CodedUI
{
    /// <summary>
    /// Defines all possibile settings to be used by searching for UI elements. See <see cref="DW.CodedUI.UI" />.
    /// </summary>
    public abstract class With
    {
        /// <summary>
        /// The UI element should be searched again and again as long this timeout is not elapsed.
        /// </summary>
        /// <param name="milliseconds">The timeout in milliseconds.</param>
        /// <returns>A combinable With to be able to append additional conditions.</returns>
        public static CombinableWith Timeout(uint milliseconds)
        {
            var combinableWith = new CombinableWith();
            return combinableWith.Timeout(milliseconds);
        }

        /// <summary>
        /// The UI element should be searched just once.
        /// </summary>
        /// <returns>A combinable With to be able to append additional conditions.</returns>
        public static CombinableWith NoTimeout()
        {
            var combinableWith = new CombinableWith();
            return combinableWith.NoTimeout();
        }

        /// <summary>
        /// If the UI element is not found an exception has to be thrown.
        /// </summary>
        /// <returns>A combinable With to be able to append additional conditions.</returns>
        public static CombinableWith Assert()
        {
            var combinableWith = new CombinableWith();
            return combinableWith.Assert();
        }

        /// <summary>
        /// If the UI element is not found no exception has to be thrown. In this case the Search returns null.
        /// </summary>
        /// <returns>A combinable With to be able to append additional conditions.</returns>
        public static CombinableWith NoAssert()
        {
            var combinableWith = new CombinableWith();
            return combinableWith.NoAssert();
        }

        /// <summary>
        /// The UI is searching for UI elements again and again as soon the timeout is not ellapsed. This defines the wait time beween each search run.
        /// </summary>
        /// <param name="milliseconds">The wait time in milliseconds between the searches</param>
        /// <returns>A combinable With to be able to append additional conditions.</returns>
        public static CombinableWith Interval(uint milliseconds)
        {
            var combinableWith = new CombinableWith();
            return combinableWith.Interval(milliseconds);
        }

        /// <summary>
        /// The UI is searching for windows again and again as soon the timeout is not ellapsed. This defines that there is no wait time between each search run.
        /// </summary>
        /// <returns>A combinable With to be able to append additional conditions.</returns>
        public static CombinableWith NoInterval()
        {
            var combinableWith = new CombinableWith();
            return combinableWith.NoInterval();
        }

        internal abstract List<WithCondition> GetConditions();
        internal abstract uint GetTimeout();
        internal abstract uint GetInterval();
    }
}