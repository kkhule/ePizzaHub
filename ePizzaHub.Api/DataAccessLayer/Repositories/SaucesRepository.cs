using DataAccessLayer.Helper;
using DataModel.Configurations;
using DataModel.Models;
using ServiceLayer.Services;
using FileServices.FileCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class SaucesRepository : ISaucesRepository
    {
        SerializationDeserialization serDerService;
        PizzaConfig pizzaConfig;
        string saucesJasonPath;

        public SaucesRepository(IOptions<AppConfig> appConfig, Func<string, SerializationDeserialization> serviceResolver)
        {
            pizzaConfig = appConfig.Value.pizzaConfig;
            serDerService = serviceResolver(pizzaConfig.SerDesMethod);
            saucesJasonPath = PizzaHelper.CombinePath(PizzaHelper.JsonFilePath, pizzaConfig.PizzaSaucesFileName);
        }

        public Sauces GetSauceAsync(int SauceId)
        {
            var sauceList = serDerService.DeserializeData<List<Sauces>>(saucesJasonPath);
            if (sauceList == null)
            {
                sauceList = new List<Sauces>();
            }
            var sauces = sauceList.Where(t => t.Id == SauceId).FirstOrDefault();
            return sauces;
        }

        public IEnumerable<Sauces> GetSaucesAsync()
        {
            var saucesList = serDerService.DeserializeData<List<Sauces>>(saucesJasonPath);
            if (saucesList == null)
            {
                saucesList = new List<Sauces>();
            }
            return saucesList;
        }

        #region Generated jason file code
        //var list = new List<Sauces>()
        //    {
        //        new Sauces()
        //        {
        //            Id = 1,
        //            Name = "Pesto",
        //            Description = "",
        //            Price = 5
        //        },
        //        new Sauces()
        //        {
        //            Id = 2,
        //            Name = "Garlic Ranch Sauce",
        //            Description = "",
        //            Price = 8
        //        },
        //        new Sauces()
        //        {
        //            Id = 3,
        //            Name = "Marinara Sauce",
        //            Description = "",
        //            Price = 10
        //        },
        //        new Sauces()
        //        {
        //            Id = 4,
        //            Name = "Tomato Sauce",
        //            Description = "",
        //            Price = 6
        //        }
        //    };


        //serDerService.SerializeData(list, saucesJasonPath);
        //    return list; 
        #endregion
    }
}
