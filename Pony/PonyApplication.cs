using System;
using System.Windows.Forms;
using Pony.ControllerInterfaces;
using Pony.Serialization;
using Pony.Views;
using StructureMap;

namespace Pony
{
    public class PonyApplication : IPonyApplication
    {
        private IContainer Container { get; set; }

        public PonyApplication()
        {
            Container = ObjectFactory.Container;
        }

        public virtual void ConfigureApplicationContainer(Action<ConfigurationExpression> config)
        {
            Container.Configure(cfg => cfg.For<IPonyApplication>().Use<PonyApplication>());
            Container.Configure(config);
        }

        private OperationResult<T> ProcessDialogResult<T>(DialogResult viewResult, IView<T> view,
            Func<IView<T>, OperationResult<T>> defaultAction) 
            where T : class
        {
            IHandlesErrors<T> errorControler;
            switch (viewResult)
            {
                case DialogResult.OK:
                case DialogResult.Yes:
                case DialogResult.No:
                    return defaultAction(view);
                case DialogResult.Abort:
                    var abortController = Container.TryGetInstance<IHandlesAbort<T>>();
                    if (abortController != null)
                    {
                        return abortController.OnAbort(view);
                    }
                    errorControler = Container.TryGetInstance<IHandlesErrors<T>>();
                    if (errorControler != null)
                    {
                        return errorControler.OnError(view);
                    }
                    return defaultAction(view);
                case DialogResult.Cancel:
                    var cancelController = Container.TryGetInstance<IHandlesCancel<T>>();
                    if (cancelController != null)
                    {
                        return cancelController.OnCancel(view);
                    }
                    errorControler = Container.TryGetInstance<IHandlesErrors<T>>();
                    if (errorControler != null)
                    {
                        return errorControler.OnError(view);
                    }
                    return defaultAction(view);
                case DialogResult.Ignore:
                    var ignoreController = Container.TryGetInstance<IHandlesIgnore<T>>();
                    if (ignoreController != null)
                    {
                        return ignoreController.OnIgnore(view);
                    }
                    errorControler = Container.TryGetInstance<IHandlesErrors<T>>();
                    if (errorControler != null)
                    {
                        return errorControler.OnError(view);
                    }
                    return defaultAction(view);
                case DialogResult.Retry:
                    var retryController = Container.TryGetInstance<IHandlesRetry<T>>();
                    if (retryController != null)
                    {
                        return retryController.OnRetry(view);
                    }
                    errorControler = Container.TryGetInstance<IHandlesErrors<T>>();
                    if (errorControler != null)
                    {
                        return errorControler.OnError(view);
                    }
                    return defaultAction(view);
                default:
                    errorControler = Container.TryGetInstance<IHandlesErrors<T>>();
                    if (errorControler != null)
                    {
                        return errorControler.OnError(view);
                    }
                    return defaultAction(view);
            }
        }

        public ISerializer<T> GetSerializer<T>()
        {
            return Container.GetInstance<ISerializer<T>>();
        } 

        public DialogResult Show<TView>() where TView : IView
        {
            return Container.GetInstance<TView>().ShowDialog();
        }

        public OperationResult<T> Create<T>() where T : class
        {
            var view = Container.GetInstance<IView<T>>();
            var viewResult = view.ShowDialog();
            return ProcessDialogResult(viewResult, view, Container.GetInstance<ICanCreate<T>>().Create);
        }

        public OperationResult<T> Edit<T>(T model) where T : class
        {
            var view = Container.GetInstance<IView<T>>();
            view.SetModel(model);
            var viewResult = view.ShowDialog();
            return ProcessDialogResult(viewResult, view, Container.GetInstance<ICanEdit<T>>().Edit);
        }
    }
}
