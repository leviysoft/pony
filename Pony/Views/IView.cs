namespace Pony.Views
{
    public interface IView
    {
        ViewResult ShowDialog();
    }

    public interface IView<T> where T : class
    {
        T Model { get; }
        void SetModel(T model);
        ViewResult ShowDialog();
    }
}