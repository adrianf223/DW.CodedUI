using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests
{
    [CodedUITest]
    public class WindowFinderTests
    {
        [TestMethod] // TODO: Test
        public void ParentOf()
        {
            //var childWindow = WindowFinder.Search(Use.Title("ChildWindow"));

            //var basicWindow = WindowFinder.Search(Use.Title("MainWindow"), Is.ParentOf(childWindow));
        }

        [TestMethod] // TODO: Test
        public void ChildOf()
        {
            //var childWindow = WindowFinder.Search(Use.Title("MainWindow"));

            //var basicWindow = WindowFinder.Search(Use.Title("ChildWindow"), Is.ChildOf(childWindow));
        }

        [TestMethod] // TODO: Test
        public void ContainingElement()
        {
            //var childWindow = WindowFinder.Search(Use.Title("MainWindow"));
            //var button = UI.GetChild(By.AutomationId("CUI_Button"), From.LastWindow());

            //WindowFinder.Search(Use.ContainingElement())
        }

        [TestMethod] // TODO: Test
        public void GetParentWindow()
        {
            //var childWindow = WindowFinder.Search(Use.Title("ChildWindow"));
            //var basicWindow = WindowFinder.Search(Use.Title("MainWindow"));

            //var foundWindow = childWindow.GetParentWindow(true);
            //var foundWindow = childWindow.GetParentWindow(false);
        }
    }
}
