using Pony;
using Pony.Views;
using PonyMvc.Demo.Domain;
using PonyMvc.Demo.Home;

namespace PonyMvc.Demo
{
    public class HomeController : WinFormsController
    {
        public HomeController(IPonyApplication application) : base(application)
        {
        }

        public IView Index()
        {
            return View<MainForm>();
        }

        public IView<Item> AddItem()
        {
            var model = new Item();
            return View(model);
        } 
    }
}
