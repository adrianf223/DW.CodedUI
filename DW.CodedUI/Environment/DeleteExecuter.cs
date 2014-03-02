using System.IO;
using System.Xml.Linq;

namespace DW.CodedUI.Environment
{
    public class DeleteExecuter : Executer
    {
        public DeleteExecuter(XElement element)
            : base(element)
        {
        }

        public override void Run()
        {
            if (string.IsNullOrWhiteSpace(The) || string.IsNullOrWhiteSpace(WithTheName))
                return;

            switch (The)
            {
                case "Directory":
                    if (Directory.Exists(WithTheName))
                        Directory.Delete(WithTheName, true);
                    break;
                case "File":
                    if (File.Exists(WithTheName))
                        File.Delete(WithTheName);
                    break;
            }
        }

        private string The { get { return GetValue("the"); } }
        private string WithTheName { get { return GetValue("withTheName"); } }
    }
}