using System.IO;
using System.Xml.Linq;

namespace DW.CodedUI.Environment
{
    public class CreateExecuter : Executer
    {
        public CreateExecuter(XElement element)
            : base(element)
        {
        }

        public override void Run()
        {
            if (string.IsNullOrWhiteSpace(A) || string.IsNullOrWhiteSpace(WithTheName))
                return;

            switch (A)
            {
                case "Directory":
                    if (!Directory.Exists(WithTheName))
                        Directory.CreateDirectory(WithTheName);
                    break;
                case "File":
                    File.WriteAllText(WithTheName, AndTheContent);
                    break;
            }
        }

        private string A { get { return GetValue("a"); } }
        private string WithTheName { get { return GetValue("withTheName"); } }
        private string AndTheContent { get { return GetValue("andTheContent"); } }
    }
}