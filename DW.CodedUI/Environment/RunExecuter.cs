using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace DW.CodedUI.Environment
{
    public class RunExecuter : Executer
    {
        public RunExecuter(XElement element)
            : base(element)
        {
        }

        public override void Run()
        {
            if (string.IsNullOrWhiteSpace(The) || !File.Exists(The))
                return;

            Process.Start(The);
        }

        private string The { get { return GetValue("the"); } }
    }
}