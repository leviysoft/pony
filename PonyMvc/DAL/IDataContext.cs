using System.Collections.Generic;
using PonyMvc.Demo.Domain;

namespace PonyMvc.Demo.DAL
{
    public interface IDataContext
    {
        IList<Item> Items { get; }  
    }
}