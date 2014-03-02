using System.Linq;
using System.Xml.Linq;

namespace DW.CodedUI.Environment
{
    public class EnvironmentSetup
    {
        private readonly XElement _setupElement;
        private readonly XElement _cleanupElement;

        public EnvironmentSetup(string configurationFilePath)
            : this(XDocument.Load(configurationFilePath))
        {
        }

        public EnvironmentSetup(XDocument configurationFile)
        {
            _setupElement = configurationFile.Descendants("setup").FirstOrDefault();
            _cleanupElement = configurationFile.Descendants("cleanup").FirstOrDefault();
        }

        public void RunSetup()
        {
            foreach (var setupElement in _setupElement.Elements())
            {
                var element = ExecuterFactory.GetExecuter(setupElement);
                if (element != null)
                    element.Run();
            }
        }

        public void CleanupSetup()
        {
            foreach (var cleanUpElement in _cleanupElement.Elements())
            {
                var element = ExecuterFactory.GetExecuter(cleanUpElement);
                if (element != null)
                    element.Run();
            }
        }
    }
}
