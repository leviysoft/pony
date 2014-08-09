using System;
using Pony.Validation;

namespace PonyMvc.Demo.Domain
{
    public class Item
    {
        public Guid Uid { get; private set; }

        [MatchesRegex(@"\w{4,}", "Слишком короткое наименование")]
        public string Name { get; set; }

        [IntIsInRange(3, 10, "Мимо")]
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
