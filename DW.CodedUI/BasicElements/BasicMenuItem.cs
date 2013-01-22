#region License
/*--------------------------------------------------------------------------------
    Copyright (c) 2012-2013 David Wendland

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
    THE SOFTWARE.
--------------------------------------------------------------------------------*/
#endregion License

using System.Collections.Generic;
using System.Windows.Automation;
using DW.CodedUI.UITree;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a MenuItem
    /// </summary>
    public class BasicMenuItem : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the BasicMenuItem class
        /// </summary>
        /// <param name="automationElement">The automation control</param>
        public BasicMenuItem(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);
        }

        /// <summary>
        /// Contains unsafe methods for interact with the control directly
        /// </summary>
        public class UnsafeMethods
        {
            private readonly AutomationElement _automationElement;

            internal UnsafeMethods(AutomationElement automationElement)
            {
                _automationElement = automationElement;
            }

            /// <summary>
            /// Expands the MenuItem
            /// </summary>
            public void Expand()
            {
                var expandCollapsePattern = (ExpandCollapsePattern)_automationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                expandCollapsePattern.Expand();
            }

            /// <summary>
            /// Collapses the MenuItem
            /// </summary>
            public void Collapse()
            {
                var expandCollapsePattern = (ExpandCollapsePattern)_automationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                expandCollapsePattern.Collapse();
            }
        }

        /// <summary>
        /// Gets access to unsafe methods
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

        /// <summary>
        /// Gets if the MenuItem is expanded or not
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                var pattern = (ExpandCollapsePattern)AutomationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                return pattern.Current.ExpandCollapseState == ExpandCollapseState.Expanded;
            }
        }

        /// <summary>
        /// Gets all available MenuItems
        /// </summary>
        public IEnumerable<BasicMenuItem> Items
        {
            get
            {
                Unsafe.Expand();
                return BasicElementFinder.FindChildrenByClassName<BasicMenuItem>(AutomationElement, "MenuItem");
            }
        }

        /// <summary>
        /// Gets the text written in the MenuItem
        /// </summary>
        /// <remarks>If AutomationProperties.AutomationName is set this text is replaced by this. To get the text a child TextBlox has to be searched.</remarks>
        public string Text
        {
            get { return Name; }
        }
    }
}