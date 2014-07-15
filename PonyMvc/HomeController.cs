using Pony;
using StructureMap;

namespace PonyMvc.Demo
{
    public class HomeController : WinFormsController
    {
        public HomeController(IContainer container) : base(container)
        {
        }

        public void Index()
        {
            View<Greeting>();
        }
    }
}
