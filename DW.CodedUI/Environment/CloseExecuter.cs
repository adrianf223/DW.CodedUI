using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace DW.CodedUI.Environment
{
    public class CloseExecuter : Executer
    {
        public CloseExecuter(XElement element)
            : base(element)
        {
        }

        public override void Run()
        {
            if (string.IsNullOrWhiteSpace(The) || !File.Exists(The))
                return;

            var processName = Path.GetFileName(The);
            var processes = Process.GetProcesses().Where(p => p.ProcessName == processName).ToList();
            for (var nr = 0; nr < WithCheckAmount; ++nr)
            {
                foreach (var process in processes)
                {
                    var mainWindowHandle = process.MainWindowHandle;
                    if (mainWindowHandle == IntPtr.Zero)
                        continue;
                    process.Close();
                }
                processes = Process.GetProcesses().Where(p => p.ProcessName == processName).ToList();

                if (!processes.Any())
                    return;
            }
        }

        private string The { get { return GetValue("the"); } }

        private int WithCheckAmount
        {
            get
            {
                int checkAmount;
                var text = GetValue("withCheckAmount");
                int.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out checkAmount);
                if (checkAmount <= 0)
                    checkAmount = 3;
                return checkAmount;
            }
        }
    }
}