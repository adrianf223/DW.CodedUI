using System.Windows.Threading;

namespace AutomationElementFinder
{
    public partial class App
    {
        public App()
        {
            DispatcherUnhandledException += OnDispatcherUnhandledException;
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            var exceptionWindow = new ExceptionWindow(e.Exception);
            var result = exceptionWindow.ShowDialog();
            if (result != true)
                Shutdown(-1);
        }
    }
}
