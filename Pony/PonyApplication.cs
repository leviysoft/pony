using System;
using Pony.Views;
using StructureMap;

namespace Pony
{
    public class PonyApplication : IPonyApplication
    {
        public IContainer Container { get; protected set; }

        public PonyApplication()
        {
            Container = ObjectFactory.Container;
        }

        public virtual void ConfigureApplicationContainer(Action<ConfigurationExpression> config)
        {
            Container.Configure(cfg => cfg.For<IPonyApplication>().Use<PonyApplication>());
            Container.Configure(config);
        }

        public void Start<TController>(Func<TController, Lazy<IView>> action)
        {
            action(Container.GetInstance<TController>()).Value.ShowDialog();
        }
    }
}
