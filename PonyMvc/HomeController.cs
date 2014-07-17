using System.Windows.Forms;
using Pony;
using Pony.ControllerInterfaces;
using Pony.Views;
using PonyMvc.Demo.DAL;
using PonyMvc.Demo.Domain;
using PonyMvc.Demo.Home;

namespace PonyMvc.Demo
{
    public class HomeController : WinFormsController, ICController<Item>
    {
        private IDataContext Context { get; set; }

        public HomeController(IPonyApplication application, IDataContext context) : base(application)
        {
            Context = context;
        }

        public IView Index()
        {
            return View<MainForm>();
        }

        public OperationResult<Item> Create(IView<Item> view)
        {
            if (view.ShowDialog() == DialogResult.OK)
            {
                Context.Items.Add(view.Model);
                return OperationResult.Produce(OperationStatus.Completed, view.Model);
            }
            return OperationResult.Produce(OperationStatus.Error, (Item)null);
        }
    }
}
