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
            PonyApplication.AppInstance.ConfigureApplicationContainer(cfg => cfg.Scan(scan =>
            {
                scan.AssembliesFromApplicationBaseDirectory();
                scan.TheCallingAssembly();
                scan.AddAllTypesOf<IView>();
                scan.AddAllTypesOf<WinFormsController>();
            }));
            PonyApplication.AppInstance.Start<HomeController>(c => c.Index());
        }
    }
}
