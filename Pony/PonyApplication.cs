using System;
using Pony.Views;
using StructureMap;

namespace Pony
{
    public class PonyApplication
    {
        protected IContainer Container;

        public PonyApplication()
        {
            Container = ObjectFactory.Container;
        }

        public virtual void ConfigureApplicationContainer(Action<ConfigurationExpression> config)
        {
            Container.Configure(config);
        }

        public void Start<TController>(Func<TController, Lazy<IView>> action)
        {
            action(Container.GetInstance<TController>()).Value.ShowDialog();
        }
    }
}
