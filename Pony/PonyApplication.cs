using System;
using System.Windows.Forms;
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

        public void Start<TController>(Func<TController, IView> action)
        {
            action(Container.GetInstance<TController>()).ShowDialog();
        }

        public void Editor<TController, T>(
            Func<TController, Func<IView<T>>> method,
            Action<T> onOk) 
            where T : class
        {
            var view = method(Container.GetInstance<TController>())();
            var result = view.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    onOk(view.Model);
                    break;
            }
        }
    }
}
