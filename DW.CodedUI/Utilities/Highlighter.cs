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

using System.Drawing;
using System.Windows.Automation;
using System.Windows.Forms;
using DW.CodedUI.Internal;

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Shows you an colored border on a UI control.
    /// </summary>
    public class Highlighter : Form
    {
        private Panel _mainPanel;

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.Utilities" /> class.
        /// </summary>
        public Highlighter()
        {
            InitializeComponent();
            Hide();
        }

        /// <summary>
        /// Highlight the given control.
        /// </summary>
        /// <param name="element">The control to highlight.</param>
        public void Highlight(AutomationElement element)
        {
            Highlight(new Rectangle((int)element.Current.BoundingRectangle.Left,
                                    (int)element.Current.BoundingRectangle.Top,
                                    (int)element.Current.BoundingRectangle.Width,
                                    (int)element.Current.BoundingRectangle.Height));
        }

        /// <summary>
        /// Highlight the given region.
        /// </summary>
        /// <param name="region">The region to highlight.</param>
        public void Highlight(Rectangle region)
        {
            Bounds = new Rectangle(2, 2, 2, 2);
            Show();
            Bounds = region;
            var windowLong = (int)WinApi.GetWindowLongPtr(Handle, -20);
            WinApi.SetWindowLong(Handle, -20, windowLong | 524288 | 32);
        }

        private void InitializeComponent()
        {
            _mainPanel = new Panel();
            SuspendLayout();
            _mainPanel.BackColor = Color.White;
            _mainPanel.Dock = DockStyle.Fill;
            _mainPanel.Location = new Point(1, 1);
            _mainPanel.Name = "_mainPanel";
            _mainPanel.Size = new Size(282, 262);
            _mainPanel.TabIndex = 0;
            AutoScaleMode = AutoScaleMode.None;
            AutoValidate = AutoValidate.Disable;
            BackColor = Color.Blue;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(284, 264);
            ControlBox = false;
            Controls.Add(_mainPanel);
            Enabled = false;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Highlighter";
            Padding = new Padding(1);
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            TransparencyKey = Color.White;
            ResumeLayout(false);
        }
    }
}