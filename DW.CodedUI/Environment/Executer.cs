using System.Xml.Linq;

namespace DW.CodedUI.Environment
{
    public abstract class Executer
    {
        private readonly XElement _element;

        protected Executer(XElement element)
        {
            _element = element;
        }

        public abstract void Run();

        protected string GetValue(string name)
        {
            var attribute = _element.Attribute(name);
            return attribute == null ? null : attribute.Value;
        }
    }
}