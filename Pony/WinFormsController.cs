using Pony.Views;

namespace Pony
{
    public class WinFormsController
    {
        protected IPonyApplication Application { get; private set; }

        protected WinFormsController(IPonyApplication application)
        {
            Application = application;
        }

        public IView View<TView>()
            where TView : IView
        {
            var view = Application.Container.GetInstance<TView>();
            return view;
        }

        public IView<T> View<T>(T model) 
            where T : class
        {
            var view = Application.Container.GetInstance<IView<T>>();
            view.Model = model;
            return view;
        }
    }
}
