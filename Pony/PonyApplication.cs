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

        private static void ProcessEdit<T>(IView<T> view, 
            Action<T> onOk = null,
            Action<T> onCancel = null,
            Action<T> onAbort = null,
            Action<T> onRetry = null,
            Action<T> onIgnore = null,
            Action<T> onYes = null,
            Action<T> onNo = null,
            Action<T> onNone = null)
            where T : class 
        {
            var result = view.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    if (onOk != null) onOk(view.Model);
                    break;
                case DialogResult.Cancel:
                    if (onCancel != null) onCancel(view.Model);
                    break;
                case DialogResult.Abort:
                    if (onAbort != null) onAbort(view.Model);
                    break;
                case DialogResult.Retry:
                    if (onRetry != null) onRetry(view.Model);
                    break;
                case DialogResult.Ignore:
                    if (onIgnore != null) onIgnore(view.Model);
                    break;
                case DialogResult.Yes:
                    if (onYes != null) onYes(view.Model);
                    break;
                case DialogResult.No:
                    if (onNo != null) onNo(view.Model);
                    break;
                default:
                    if (onNone != null) onNone(view.Model);
                    break;
            }
        }

        public void Editor<TController, T>(
            Func<TController, Func<IView<T>>> method,
            Action<T> onOk) 
            where T : class
        {
            var view = method(Container.GetInstance<TController>())();
            ProcessEdit(view, onOk);
        }
    }
}
