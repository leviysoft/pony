using System;
using Pony;
using Pony.Views;
using PonyMvc.Demo.Home;

namespace PonyMvc.Demo
{
    public class HomeController : WinFormsController
    {
        public HomeController(IPonyApplication application) : base(application)
        {
        }

        public Lazy<IView> Index()
        {
            return View<MainForm>();
        }
    }
}
