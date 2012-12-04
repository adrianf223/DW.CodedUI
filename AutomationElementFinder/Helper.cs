using System.Windows.Automation;

namespace AutomationElementFinder
{
    public static class Helper
    {
        public static bool IsAvailable(AutomationElement element)
        {
            try
            {
                var checkitemAvailbility = element.Current.FrameworkId;
            }
            catch (ElementNotAvailableException)
            {
                return false;
            }
            return true;
        }
    }
}
