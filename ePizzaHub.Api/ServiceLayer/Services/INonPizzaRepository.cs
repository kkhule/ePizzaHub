using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface INonPizzaRepository
    {
        IEnumerable<NonPizzas> GetNonPizzaItemsAsync();

        NonPizzas? GetNonPizzaItemAsync(int Id);
    }
}
