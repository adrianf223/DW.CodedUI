using System;
using System.Threading.Tasks;
using System.Windows;

namespace DW.CodedUI.Demo
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowRandomMessageBoxes_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new TaskFactory().StartNew(() => System.Windows.Forms.MessageBox.Show("Any", "Wurst1"));
            new TaskFactory().StartNew(() => System.Windows.Forms.MessageBox.Show("Any", "Wurst2"));
            new TaskFactory().StartNew(() => System.Windows.Forms.MessageBox.Show("Any", "Wurst3"));
        }
    }
}
