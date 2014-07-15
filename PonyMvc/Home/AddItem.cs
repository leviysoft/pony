using System.Windows.Forms;
using Pony.Views;
using PonyMvc.Demo.Domain;

namespace PonyMvc.Demo.Home
{
    public partial class AddItem : Form, IView<Item>
    {
        public AddItem()
        {
            InitializeComponent();
            Closing += (sender, args) =>
            {
                Model = new Item {Name = NameBox.Text, Description = Description.Text};
            };
        }

        public Item Model { get; private set; }
    }
}
