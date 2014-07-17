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
                ItemList.Items.Add(result.Result.Name + " " + result.Result.Description);
            }
            else
            {
                MessageBox.Show("Failed to add...");
            }
        }

        private void EditBtn_Click(object sender, System.EventArgs e)
        {
            if (ItemList.SelectedIndex > -1)
            {
                var index = ItemList.SelectedIndex;
                var result = _application.Edit(_context.Items[index]);
                if (result.Status == OperationStatus.Completed)
                {
                    ItemList.Items.RemoveAt(index);
                    ItemList.Items.Add(result.Result.Name + " " + result.Result.Description);
                }
                else
                {
                    MessageBox.Show("Failed to edit...");
                }
            }
        }
    }
}
