using System.Linq;
using System.Windows.Forms;
using Pony;
using Pony.ControllerInterfaces;
using Pony.Views;
using PonyMvc.Demo.DAL;
using PonyMvc.Demo.Domain;

namespace PonyMvc.Demo
{
    public class ItemController : WinFormsController, ICController<Item>, IEController<Item>
    {
        private IDataContext Context { get; set; }

        public ItemController(IPonyApplication application, IDataContext context) : base(application)
        {
            Context = context;
        }

        public OperationResult<Item> Create(IView<Item> view)
        {
            if (view.ShowDialog() == DialogResult.OK)
            {
                Context.Items.Add(view.Model);
                return OperationResult.Produce(OperationStatus.Completed, view.Model);
            }
            return OperationResult.Produce(OperationStatus.Cancelled, (Item)null);
        }

        public OperationResult<Item> Edit(IView<Item> view)
        {
            if (view.ShowDialog() == DialogResult.OK)
            {
                var exItem = Context.Items.SingleOrDefault(it => it.Uid == view.Model.Uid);
                Context.Items.Remove(exItem);
                Context.Items.Add(view.Model);
                return OperationResult.Produce(OperationStatus.Completed, view.Model);
            }
            return OperationResult.Produce(OperationStatus.Cancelled, view.Model);
        }
    }
}
