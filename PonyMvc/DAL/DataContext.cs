using System.Collections.Generic;
using PonyMvc.Demo.Domain;

namespace PonyMvc.Demo.DAL
{
    public class DataContext : IDataContext
    {
        public IList<Item> Items { get; private set; }

        public DataContext()
        {
            Items = new List<Item>();
        }
    }
}