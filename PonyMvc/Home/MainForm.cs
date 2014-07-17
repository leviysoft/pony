using System.Windows.Forms;
using Pony;
using Pony.Views;
using PonyMvc.Demo.DAL;
using PonyMvc.Demo.Domain;

namespace PonyMvc.Demo.Home
{
    public partial class MainForm : Form, IView
    {
        private readonly IPonyApplication _application;
        private readonly IDataContext _context;

        public MainForm(IPonyApplication pony, IDataContext context)
        {
            _application = pony;
            _context = context;
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, System.EventArgs e)
        {
            var result = _application.Create<Item>();
            if (result.Status == OperationStatus.Completed)
            {
                ItemList.Items.Clear();
                foreach (var i in _context.Items)
                {
                    ItemList.Items.Add(i.Name + " " + i.Description);
                }
            }
            else
            {
                MessageBox.Show("Failed to add...");
            }
        }
    }
}
