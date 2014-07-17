using System;
using Pony.Views;
using StructureMap;

namespace Pony
{
    public interface IPonyApplication
    {
        IContainer Container { get; }

        void Editor<TController, T>(
            Func<TController, Func<IView<T>>> method,
            Action<T> onOk) 
            where T : class;
    }
}