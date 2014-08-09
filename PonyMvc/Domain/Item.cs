using System;
using Pony.Validation;

namespace PonyMvc.Demo.Domain
{
    public class Item
    {
        public Guid Uid { get; private set; }

        [ValidateAgainstRegex(@"\w{4,}", "Слишком короткое наименование")]
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
