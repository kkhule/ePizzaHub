using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface ISaucesRepository
    {

        IEnumerable<Sauces> GetSaucesAsync();

        Sauces? GetSauceAsync(int SauceId);
    }
}
