using System.Windows.Threading;
using ElementFinder.Views;

namespace ElementFinder
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
