using Pony.Serialization;
using Pony.Views;

namespace Pony
{
    public interface IPonyApplication
    {
        OperationResult<T> Create<T>() where T : class;
        OperationResult<T> Edit<T>(T model) where T : class;
        ViewResult Show<TView>() where TView : IView;
        ISerializer<T> GetSerializer<T>();
    }
}