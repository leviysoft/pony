using System;
using System.Windows.Forms;
using Pony;
using Pony.ControllerInterfaces;
using Pony.Views;
using PonyMvc.Demo.DAL;
using PonyMvc.Demo.Home;
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
            var context = new DataContext();
            Application.EnableVisualStyles();
            var demoApp = new PonyApplication();
            demoApp.ConfigureApplicationContainer(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.AssembliesFromApplicationBaseDirectory();
                    scan.TheCallingAssembly();
                    scan.AddAllTypesOf<IView>();
                    scan.AddAllTypesOf(typeof (IView<>));
                    scan.AddAllTypesOf<WinFormsController>();
                    scan.AddAllTypesOf(typeof (ICController<>));
                    scan.AddAllTypesOf(typeof (IEController<>));
                });
                cfg.For<IDataContext>().Use(context);
            });
            demoApp.Show<MainForm>();
        }
    }
}
