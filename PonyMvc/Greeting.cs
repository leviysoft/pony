using System.Windows.Forms;
using Pony.Views;

namespace PonyMvc.Demo
{
    public partial class Greeting : Form, IView
    {
        public Greeting()
        {
            InitializeComponent();
        }
    }
}
