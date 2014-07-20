using System.Linq;
using Pony;
using Pony.ControllerInterfaces;
using Pony.Views;
using PonyMvc.Demo.DAL;
using PonyMvc.Demo.Domain;

namespace PonyMvc.Demo
{
    public class ItemController : ICanCreate<Item>, ICanEdit<Item>, IHandlesErrors<Item>
    {
        private IDataContext Context { get; set; }

        public ItemController(IPonyApplication application, IDataContext context) : base()
        {
            Context = context;
        }

        public OperationResult<Item> Create(IView<Item> view)
        {
            Context.Items.Add(view.Model);
            return OperationResult.Produce(OperationStatus.Completed, view.Model);
        }

        public OperationResult<Item> Edit(IView<Item> view)
        {
            var exItem = Context.Items.SingleOrDefault(it => it.Uid == view.Model.Uid);
            Context.Items.Remove(exItem);
            Context.Items.Add(view.Model);
            return OperationResult.Produce(OperationStatus.Completed, view.Model);
        }

        public OperationResult<Item> OnError(IView<Item> view)
        {
            return OperationResult.Produce(OperationStatus.Cancelled, view.Model);
        }
    }
}
