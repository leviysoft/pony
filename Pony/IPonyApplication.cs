using System.Windows.Forms;
using Pony.Views;
using StructureMap;

namespace Pony
{
    public interface IPonyApplication
    {
        IContainer Container { get; }
        OperationResult<T> Create<T>() where T : class;
        OperationResult<T> Edit<T>(T model) where T : class;
        DialogResult Show<TView>() where TView : IView;
    }
}