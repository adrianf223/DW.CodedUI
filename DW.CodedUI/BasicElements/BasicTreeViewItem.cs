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

using System.Collections.Generic;
using System.Windows.Automation;
using DW.CodedUI.BasicElements.Data;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a TreeViewItem.
    /// </summary>
    public class BasicTreeViewItem : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicTreeViewItem" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicTreeViewItem(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);
        }

        /// <summary>
        /// Contains unsafe methods for interact with the control directly.
        /// </summary>
        public class UnsafeMethods
        {
            private readonly AutomationElement _automationElement;

            internal UnsafeMethods(AutomationElement automationElement)
            {
                _automationElement = automationElement;
            }

            /// <summary>
            /// Expands the item.
            /// </summary>
            public void Expand()
            {
                var pattern = (ExpandCollapsePattern)_automationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                pattern.Expand();
            }

            /// <summary>
            /// Collapses the item.
            /// </summary>
            public void Collapse()
            {
                var pattern = (ExpandCollapsePattern)_automationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                pattern.Collapse();
            }

            /// <summary>
            /// Selects the item.
            /// </summary>
            public void Select()
            {
                var pattern = (SelectionItemPattern)_automationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                pattern.Select();
            }

            /// <summary>
            /// Deselects the item.
            /// </summary>
            public void Deselect()
            {
                var pattern = (SelectionItemPattern)_automationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                pattern.RemoveFromSelection();
            }

            /// <summary>
            /// Scrolls the parent TreeView to the item.
            /// </summary>
            public void ScrollIntoView()
            {
                var pattern = (ScrollItemPattern)_automationElement.GetCurrentPattern(ScrollItemPattern.Pattern);
                pattern.ScrollIntoView();   
            }
        }

        /// <summary>
        /// Gets access to unsafe methods.
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

        /// <summary>
        /// Gets a value that indicates if it is selected or not.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                var pattern = (SelectionItemPattern)AutomationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                return pattern.Current.IsSelected;
            }
        }

        /// <summary>
        /// Gets a value that indicates if it is expanded or not.
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
        /// Gets all available child tree items. In WPF normally all child items get created first as soon they became visible.
        /// </summary>
        public IEnumerable<BasicTreeViewItem> Items
        {
            get
            {
                Unsafe.Expand();
                Unsafe.Collapse();
                return UI.GetChildren<BasicTreeViewItem>(By.ClassName("TreeViewItem"), From.Element(this));
            }
        }

        /// <summary>
        /// Gets the text written in the TreeViewItem.
        /// </summary>
        public string Text
        {
            get { return Name; }
        }

        /// <summary>
        /// Make a shadow copy of the element at the current state which stays available even the element is gone.
        /// </summary>
        /// <returns>A shadow copy of the current element.</returns>
        public new BasicTreeViewItemData GetDataCopy()
        {
            var data = new BasicTreeViewItemData();
            FillData(data);
            data.IsSelected = GetSafeData(() => IsSelected);
            data.IsExpanded = GetSafeData(() => IsExpanded);

            var items = new List<BasicTreeViewItemData>();
            data.Items = items;
            try
            {
                foreach (var item in Items)
                {
                    if (item != null)
                        items.Add(item.GetDataCopy());
                }
            }
            catch { }

            data.Text = GetSafeData(() => Text);
            return data;
        }
    }
}