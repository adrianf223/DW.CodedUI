namespace DW.CodedUI.Demo
{
    public partial class App
    {
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            if (e.Args.Length == 1 && e.Args[0] == "/FastStart")
                new FastStartWindow().Show();
            else
                new ControlsWindow().Show();
            base.OnStartup(e);
        }
    }
}
