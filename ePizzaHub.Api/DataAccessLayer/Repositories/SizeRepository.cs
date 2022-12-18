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
    public class SizeRepository : ISizeRepository
    {
        SerializationDeserialization serDerService;
        PizzaConfig pizzaConfig;
        string pizzaSizeJasonPath;

        public SizeRepository(IOptions<AppConfig> appConfig,  Func<string, SerializationDeserialization> serviceResolver)
        {
            pizzaConfig = appConfig.Value.pizzaConfig;
            serDerService = serviceResolver(pizzaConfig.SerDesMethod);
            pizzaSizeJasonPath = PizzaHelper.CombinePath(PizzaHelper.JsonFilePath, pizzaConfig.PizzaSizeFileName);
        }

        public IEnumerable<Size> GetAllPizzaSizesAsync()
        {
            var sizeList = serDerService.DeserializeData<List<Size>>(pizzaSizeJasonPath);
            if (sizeList == null)
            {
                sizeList = new List<Size>();
            }
            return sizeList;
        }

        public Size GetPizzaSizeAsync(int sizeId)
        {
            var pizzSizeList = serDerService.DeserializeData<List<Size>>(pizzaSizeJasonPath);
            var size = pizzSizeList.Where(t => t.Id == sizeId).FirstOrDefault();
            return size;
        }

        #region Generated jason file code
        //var list = new List<Size>()
        //    {
        //        new Size()
        //        {
        //            Id=1,
        //            Name="Small",
        //            Multiplier=1
        //        },
        //        new Size()
        //        {
        //            Id=2,
        //            Name="Medium",
        //            Multiplier=1.25
        //        },
        //        new Size()
        //        {
        //            Id=3,
        //            Name="Large",
        //            Multiplier=1.5
        //        }

        //    };

        //serDerService.SerializeData(list, pizzaSizeJasonPath);
        //    return list; 
        #endregion
    }
}
