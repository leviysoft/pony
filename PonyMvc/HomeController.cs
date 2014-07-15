using System;
using Pony;
using Pony.Views;
using PonyMvc.Demo.Home;
using StructureMap;

namespace PonyMvc.Demo
{
    public class HomeController : WinFormsController
    {
        public HomeController(IContainer container) : base(container)
        {
        }

        public Lazy<IView> Index()
        {
            return View<MainForm>();
        }
    }
}
