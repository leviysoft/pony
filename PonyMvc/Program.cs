using System;
using System.Windows.Forms;
using Pony;
using Pony.ControllerInterfaces;
using Pony.DI;
using Pony.Serialization;
using Pony.StructureMap;
using Pony.Views;
using PonyMvc.Demo.DAL;
using PonyMvc.Demo.Home;
using StructureMap;
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

            var structureMapContainer = new Container(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.AssembliesFromApplicationBaseDirectory();
                    scan.TheCallingAssembly();
                    scan.AddAllTypesOf<IView>();
                    scan.AddAllTypesOf(typeof (IView<>));
                    scan.AddAllTypesOf(typeof (ICanCreate<>));
                    scan.AddAllTypesOf(typeof (ICanEdit<>));
                    scan.AddAllTypesOf(typeof (IHandlesErrors<>));
                    scan.AddAllTypesOf(typeof (IHandlesAbort<>));
                    scan.AddAllTypesOf(typeof (IHandlesCancel<>));
                    scan.AddAllTypesOf(typeof (IHandlesIgnore<>));
                    scan.AddAllTypesOf(typeof (IHandlesRetry<>));
                    scan.AddAllTypesOf(typeof (ISerializer<>));
                });
                cfg.For<IDataContext>().Use(context);
                cfg.For<IPonyApplication>().Use<PonyApplication>();
                cfg.For<IPonyContainer>().Use<StructureMapPonyContainer>();
            });

            var demoApp = structureMapContainer.GetInstance<IPonyApplication>();
            demoApp.Show<MainForm>();
        }
    }
}
