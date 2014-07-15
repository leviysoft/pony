using System;
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

        public void Start<TController>(Action<TController> action)
        {
            action(Container.GetInstance<TController>());
        }
    }
}
