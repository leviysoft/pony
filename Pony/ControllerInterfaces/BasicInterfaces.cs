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

    /// <summary>
    /// Supports handling errors during operations with T
    /// This method will be hit instead of OnAbort, OnCancel, OnIgnore or OnRetry
    /// if there if no specific interface that handles such dialog result.
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    public interface IHandlesErrors<T> where T : class
    {
        OperationResult<T> OnError(IView<T> view);
    }

    /// <summary>
    /// Supports handling "Abort" dialog result during operations with T
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    public interface IHandlesAbort<T> where T : class
    {
        OperationResult<T> OnAbort(IView<T> view);
    }

    /// <summary>
    /// Supports handling "Cancel" dialog result during operations with T
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    public interface IHandlesCancel<T> where T : class
    {
        OperationResult<T> OnCancel(IView<T> view);
    }

    /// <summary>
    /// Supports handling "Ignore" dialog result during operations with T
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    public interface IHandlesIgnore<T> where T : class
    {
        OperationResult<T> OnIgnore(IView<T> view);
    }

    /// <summary>
    /// Supports handling "Retry" dialog result during operations with T
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    public interface IHandlesRetry<T> where T : class
    {
        OperationResult<T> OnRetry(IView<T> view);
    }
}
