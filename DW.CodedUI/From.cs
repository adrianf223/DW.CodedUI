using System;
using DW.CodedUI.BasicElements;

namespace DW.CodedUI
{
    /// <summary>
    /// Defines where the UI element search has to start from. See <see cref="DW.CodedUI.UI" />.
    /// </summary>
    public class From
    {
#if TRIAL
        static From()
        {
            License1.License.Display();
        }
#endif

        private readonly BasicElement _sourceElement;

        private From(BasicElement sourceElement)
        {
            _sourceElement = sourceElement;
        }

        /// <summary>
        /// The UI element search has to start from a BasicElement.
        /// </summary>
        /// <param name="element">The element to start the UI search from.</param>
        /// <returns>Instance of the From to be used in the <see cref="DW.CodedUI.UI" /> object.</returns>
        /// <exception cref="System.ArgumentNullException">element is null.</exception>
        public static From Element(BasicElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return new From(element);
        }

        internal BasicElement GetSourceElement()
        {
            return _sourceElement;
        }
    }
}