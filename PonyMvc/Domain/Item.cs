using System;

namespace PonyMvc.Demo.Domain
{
    public class Item
    {
        public Guid Uid { get; private set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public Item()
        {
            Uid = Guid.NewGuid();
        }

        public Item(Guid uid)
        {
            Uid = uid;
        }
    }
}
