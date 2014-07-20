using System;
using System.Windows.Forms;
using Pony.ControllerInterfaces;
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

        public DialogResult Show<TView>() where TView : IView
        {
            return Container.GetInstance<TView>().ShowDialog();
        }

        public OperationResult<T> Create<T>() where T : class
        {
            var view = Container.GetInstance<IView<T>>();
            var controller = Container.GetInstance<ICController<T>>();
            return controller.Create(view);
        }

        public OperationResult<T> Edit<T>(T model) where T : class
        {
            var view = Container.GetInstance<IView<T>>();
            view.SetModel(model);
            var controller = Container.GetInstance<IEController<T>>();
            return controller.Edit(view);
        }
    }
}
