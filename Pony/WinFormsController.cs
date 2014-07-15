using System;
using Pony.Views;
using StructureMap;

namespace Pony
{
    public class WinFormsController
    {
        private readonly IContainer _container;

        protected WinFormsController(IContainer container)
        {
            _container = container;
        }

        public Lazy<IView> View<TView>()
            where TView : IView
        {
            var view = _container.GetInstance<TView>();
            return new Lazy<IView>(() => view);
        }
    }
}
