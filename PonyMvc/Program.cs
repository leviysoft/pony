using System;
using System.Windows.Forms;
using Pony;
using Pony.Views;
using StructureMap.Graph;

namespace PonyMvc.Demo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            var demoApp = new PonyApplication();
            demoApp.ConfigureApplicationContainer(cfg => cfg.Scan(scan =>
            {
                scan.AssembliesFromApplicationBaseDirectory();
                scan.TheCallingAssembly();
                scan.AddAllTypesOf<IView>();
                scan.AddAllTypesOf(typeof (IView<>));
                scan.AddAllTypesOf<WinFormsController>();
            }));
            demoApp.Start<HomeController>(c => c.Index());
        }
    }
}
