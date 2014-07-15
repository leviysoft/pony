using System.Windows.Forms;
using Pony.Views;

namespace PonyMvc.Demo.Home
{
    public partial class MainForm : Form, IView
    {
        public MainForm()
        {
            InitializeComponent();
        }
    }
}
