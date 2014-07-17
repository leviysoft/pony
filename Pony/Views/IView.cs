using System.Windows.Forms;

namespace Pony.Views
{
    public interface IView
    {
        DialogResult ShowDialog();
    }

    public interface IView<T> where T : class
    {
        T Model { get; }
        void Fill(T model);
        DialogResult ShowDialog();
    }
}