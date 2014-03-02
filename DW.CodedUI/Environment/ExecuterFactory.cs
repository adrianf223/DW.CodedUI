using System.Xml.Linq;

namespace DW.CodedUI.Environment
{
    public static class ExecuterFactory
    {
        public static Executer GetExecuter(XElement element)
        {
            switch (element.Name.ToString())
            {
                case "Delete":
                    return new DeleteExecuter(element);
                case "Create":
                    return new CreateExecuter(element);
                case "Copy":
                    return new CopyExecuter(element);
                case "Close":
                    return new CloseExecuter(element);
                case "Run":
                    return new RunExecuter(element);
                case "Wait":
                    return new WaitExecuter(element);
            }
            return null;
        }
    }
}