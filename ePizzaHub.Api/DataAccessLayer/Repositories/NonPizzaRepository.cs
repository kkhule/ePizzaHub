using DataAccessLayer.Helper;
using DataModel.Configurations;
using DataModel.Models;
using FileServices.FileCore;
using Microsoft.Extensions.Options;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class NonPizzaRepository : INonPizzaRepository
    {

        SerializationDeserialization serDerService;
        PizzaConfig pizzaConfig;
        string nonPizzaJasonPath;

        public NonPizzaRepository(IOptions<AppConfig> appConfig, Func<string, SerializationDeserialization> serviceResolver)
        {
            pizzaConfig = appConfig.Value.pizzaConfig;
            serDerService = serviceResolver(pizzaConfig.SerDesMethod);
            nonPizzaJasonPath = PizzaHelper.CombinePath(PizzaHelper.JsonFilePath, pizzaConfig.NonPizzaFileName);
        }

        public NonPizzas GetNonPizzaItemAsync(int Id)
        {
            var nonPizzaList = serDerService.DeserializeData<List<NonPizzas>>(nonPizzaJasonPath);
            if (nonPizzaList == null)
            {
                nonPizzaList = new List<NonPizzas>();
            }
            var nonPizzaItem = nonPizzaList.Where(t => t.Id == Id).FirstOrDefault();
            return nonPizzaItem;
        }

        public IEnumerable<NonPizzas> GetNonPizzaItemsAsync()
        {
            var nonPizzaList = serDerService.DeserializeData<List<NonPizzas>>(nonPizzaJasonPath);
            if (nonPizzaList == null)
            {
                nonPizzaList = new List<NonPizzas>();
            }
            return nonPizzaList;

            
        }

        #region Generated jason file code
        //var list = new List<NonPizzas>()
        //    {
        //        new NonPizzas()
        //        {
        //            Id = 1,
        //            Name = "Pepsi",
        //            Description = "Contains Caffeine",
        //            Price = 57
        //        },

        //        new NonPizzas()
        //        {
        //            Id = 2,
        //            Name = "Mirinda",
        //            Description = "Contains Caffeine",
        //            Price = 57
        //        },
        //        new NonPizzas()
        //        {
        //            Id = 3,
        //            Name = "Choco Volcano Cake",
        //            Description = "Choco Delight With A Gooey Chocolate Volcano Centre",
        //            Price = 119
        //        },
        //        new NonPizzas()
        //        {
        //            Id = 4,
        //            Name = "Choco Sundae",
        //            Description = "Choco Sundae Cup (100 ml)",
        //            Price = 29
        //        }
        //    };

        ////return list;

        //serDerService.SerializeData(list, nonPizzaJasonPath);
        //    return list; 
	#endregion
    }
}
