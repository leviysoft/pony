using Pony.Views;

namespace Pony.ControllerInterfaces
{
    /// <summary>
    /// Supports creation of T
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    public interface ICanCreate<T> where T : class
    {
        OperationResult<T> Create(IView<T> view);
    }

    /// <summary>
    /// Supports edition of T
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    public interface ICanEdit<T> where T : class
    {
        OperationResult<T> Edit(IView<T> view);
    }
}
