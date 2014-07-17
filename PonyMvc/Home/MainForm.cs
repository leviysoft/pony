using System.Windows.Forms;
using Pony;
using Pony.Views;
using PonyMvc.Demo.Domain;

namespace PonyMvc.Demo.Home
{
    public partial class MainForm : Form, IView
    {
        private readonly IPonyApplication _application;

        public MainForm(IPonyApplication pony)
        {
            _application = pony;
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, System.EventArgs e)
        {
            _application.Editor<HomeController, Item>(x => x.AddItem, item => ItemList.Items.Add(item.Name + " " + item.Description));
        }
    }
}
