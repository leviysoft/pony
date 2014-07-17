using System;
using System.Windows.Forms;
using Pony.Views;
using PonyMvc.Demo.Domain;

namespace PonyMvc.Demo.Home
{
    public partial class AddItem : Form, IView<Item>
    {
        private Item _model;

        public AddItem()
        {
            InitializeComponent();
        }

        public Item Model
        {
            get { return _model; }
        }

        public void Fill(Item model)
        {
            _model = model;
            NameBox.Text = model.Name;
            Description.Text = model.Description;
        }

        private void AddItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            var uid = _model != null ? _model.Uid : Guid.NewGuid();
            _model = new Item(uid)
            {
                Name = NameBox.Text, 
                Description = Description.Text
            };
        }
    }
}
