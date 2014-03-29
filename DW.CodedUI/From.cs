using System;
using DW.CodedUI.BasicElements;

namespace DW.CodedUI.UITree
{
    public class From
    {
        private readonly BasicElement _sourceElement;

        private From(BasicElement sourceElement)
        {
            _sourceElement = sourceElement;
        }

        internal BasicElement GetSourceElement()
        {
            return _sourceElement;
        }

        public static From Element(BasicElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return new From(element);
        }
    }
}