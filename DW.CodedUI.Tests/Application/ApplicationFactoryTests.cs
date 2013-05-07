using System.ComponentModel;
using DW.CodedUI.Application;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Application
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class ApplicationFactoryTests
    {
        [TestMethod]
        public void Launch_WithExistingExecutable_LaunchesTheApplication()
        {
            var toTestApplication = ApplicationFactory.Launch(ApplicationInfo.ExecutablePath, ApplicationInfo.FastStartArguments, timeout: 10000);

            Assert.IsNotNull(toTestApplication);

            toTestApplication.Unsafe.Close();
        }

        [TestMethod]
        public void Launch_WithExistingExecutable_LaunchesTheApplication2()
        {
            var toTestApplication = ApplicationFactory.Launch(ApplicationInfo.ExecutablePath);

            Assert.IsNotNull(toTestApplication);

            toTestApplication.Unsafe.Close();
        }

        [TestMethod, ExpectedException(typeof(Win32Exception))]
        public void Launch_WithInvalidExecutablePath_ThrowsException()
        {
            ApplicationFactory.Launch(@"DoesNotExist.exe");
        }
    }

    // ReSharper restore InconsistentNaming
}
