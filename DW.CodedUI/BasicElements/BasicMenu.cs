#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2016 David Wendland

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
    /// Represents a Menu or ContextMenu
    /// </summary>
    public class BasicMenu : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicMenu" /> class
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicMenu(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets all available MenuItems.
        /// </summary>
        public IEnumerable<BasicMenuItem> Items
        {
            get
            {
                return UI.GetChildren<BasicMenuItem>(By.ClassName("MenuItem"), From.Element(this));
            }
        }

        /// <summary>
        /// Make a shadow copy of the element at the current state which stays available even the element is gone.
        /// </summary>
        /// <returns>A shadow copy of the current element.</returns>
        public new BasicMenuData GetDataCopy()
        {
            var data = new BasicMenuData();
            FillData(data);
            var items = new List<BasicMenuItemData>();
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
            return data;
        }
    }
}