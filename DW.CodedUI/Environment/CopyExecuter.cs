using System.IO;
using System.Xml.Linq;

namespace DW.CodedUI.Environment
{
    public class CopyExecuter : Executer
    {
        public CopyExecuter(XElement element)
            : base(element)
        {
        }

        public override void Run()
        {
            if (string.IsNullOrWhiteSpace(The) || string.IsNullOrWhiteSpace(From) || string.IsNullOrWhiteSpace(To))
                return;

            switch (The)
            {
                case "Directory":
                    if (!Directory.Exists(From))
                        return;
                    Copy(From, To);
                    break;
                case "File":
                    if (!File.Exists(From))
                        return;
                    File.Copy(From, To, true);
                    break;
            }
        }

        private string The { get { return GetValue("the"); } }
        private string From { get { return GetValue("from"); } }
        private string To { get { return GetValue("to"); } }

        #region MS Way to copy everything in a directory
        // http://msdn.microsoft.com/en-us/library/system.io.directoryinfo.aspx
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            if (!Directory.Exists(target.FullName))
                Directory.CreateDirectory(target.FullName);

            foreach (var fi in source.GetFiles())
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);

            foreach (var diSourceSubDir in source.GetDirectories())
            {
                var nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
        #endregion
    }
}