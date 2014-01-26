using System.Drawing;
using System.Windows.Automation;
using System.Windows.Forms;
using DW.CodedUI.Internal;

namespace DW.CodedUI.Utilities
{
    public class Highlighter : Form
    {
        private Panel _mainPanel;

        public Highlighter()
        {
            InitializeComponent();
            Hide();
        }

        public void Highlight(AutomationElement element)
        {
            Highlight(new Rectangle((int)element.Current.BoundingRectangle.Left,
                                    (int)element.Current.BoundingRectangle.Top,
                                    (int)element.Current.BoundingRectangle.Width,
                                    (int)element.Current.BoundingRectangle.Height));
        }

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