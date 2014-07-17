using System;
using Pony.Views;
using StructureMap;

namespace Pony
{
    public sealed class PonyApplication
    {
        private static readonly IContainer Container = ObjectFactory.Container;
        private static readonly PonyApplication Instance = new PonyApplication();

        //Required for correct static fields initialization.
        static PonyApplication() {}

        private PonyApplication() {}

        public static PonyApplication AppInstance { get { return Instance; } }

        public void ConfigureApplicationContainer(Action<ConfigurationExpression> config)
        {
            Container.Configure(config);
        }

        public void Start<TController>(Func<TController, Lazy<IView>> action)
        {
            action(Container.GetInstance<TController>()).Value.ShowDialog();
        }
    }
}
