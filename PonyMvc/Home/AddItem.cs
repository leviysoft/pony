using Pony;
using Pony.Views;
using Pony.Windows.Forms;
using PonyMvc.Demo.Domain;

namespace PonyMvc.Demo.Home
{
    public partial class AddItem : ItemView, IView<Item>
    {
        public AddItem(IPonyApplication ponyApplication) : base(ponyApplication)
        {
            InitializeComponent();
            Bind(m => m.Name, (AddItem f) => f.NameBox);
            Bind(m => m.Quantity, (AddItem f) => f.Quantity);
            Bind(m => m.Description, (AddItem f) => f.Description);
        }


        public new ViewResult ShowDialog()
        {
            return (ViewResult)base.ShowDialog();
        }
    }

    public class ItemView : View<Item> {
        private ItemView() : base(null) { }

        public ItemView(IPonyApplication ponyApplication) : base(ponyApplication)
        {
        }
    }
}
