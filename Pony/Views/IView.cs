using System.Windows.Forms;

namespace Pony.Views
{
    public interface IView
    {
        void Show();
        DialogResult ShowDialog();
    }
}