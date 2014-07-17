using System;
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

        public Lazy<IView> View<TView>()
            where TView : IView
        {
            var view = Application.Container.GetInstance<TView>();
            return new Lazy<IView>(() => view);
        }
    }
}
