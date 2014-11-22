using System;

namespace Pony.Views
{
    public interface IView : IDisposable
    {
        ViewResult ShowDialog();
    }

    public interface IView<T> : IDisposable where T : class
    {
        T Model { get; }
        void SetModel(T model);
        ViewResult ShowDialog();
    }
}