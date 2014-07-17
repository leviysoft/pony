using System.Windows.Forms;

namespace Pony.Views
{
    public interface IView
    {
        void Show();
        DialogResult ShowDialog();
    }

    public interface IView<T> where T : class
    {
        T Model { get; set; }
        DialogResult ShowDialog();
    }
}