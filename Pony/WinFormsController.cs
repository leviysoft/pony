namespace Pony
{
    public class WinFormsController
    {
        protected IPonyApplication Application { get; private set; }

        protected WinFormsController(IPonyApplication application)
        {
            Application = application;
        }
    }
}
