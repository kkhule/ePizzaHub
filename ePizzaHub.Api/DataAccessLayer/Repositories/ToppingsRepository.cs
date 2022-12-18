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
    public class ToppingsRepository : IToppingsRepository
    {
        SerializationDeserialization serDerService;
        PizzaConfig pizzaConfig;
        string toppingJasonPath;

        public ToppingsRepository(IOptions<AppConfig> appConfig, Func<string, SerializationDeserialization> serviceResolver)
        {
            pizzaConfig = appConfig.Value.pizzaConfig;
            serDerService = serviceResolver(pizzaConfig.SerDesMethod);
            toppingJasonPath = PizzaHelper.CombinePath(PizzaHelper.JsonFilePath, pizzaConfig.PizzaToppingsFileName);
        }

        public Toppings GetToppingAsync(int toppingId)
        {
            var toppingList = serDerService.DeserializeData<List<Toppings>>(toppingJasonPath);
            if (toppingList == null)
            {
                toppingList = new List<Toppings>();
            }
            var topping = toppingList.Where(t => t.Id == toppingId).FirstOrDefault();
            return topping;
        }

        public IEnumerable<Toppings> GetToppingsAsync()
        {
            var toppingList = serDerService.DeserializeData<List<Toppings>>(toppingJasonPath);
            if (toppingList == null)
            {
                toppingList = new List<Toppings>();
            }
            return toppingList;
        }


        #region Generated jason file code
        //var list = new List<Toppings>()
        //    {
        //        new Toppings()
        //        {
        //            Id=1,
        //            Name="Cheese",
        //            Description="",
        //            Price=5,
        //            IsVeg=true
        //        },
        //        new Toppings()
        //        {
        //            Id=0,
        //            Name="Extra Cheese",
        //            Description="",
        //            Price=5,
        //            IsVeg=true
        //        },
        //        new Toppings()
        //        {
        //            Id=2,
        //            Name="Spiced paneer",
        //            Description="",
        //            Price=5,
        //            IsVeg=true,
        //        },
        //        new Toppings()
        //        {
        //            Id=3,
        //            Name="Onion",
        //            Description="",
        //            Price=6,
        //            IsVeg=true
        //        },
        //        new Toppings()
        //        {
        //            Id=4,
        //            Name="Green Capsicum",
        //            Description="",
        //            Price=8,
        //            IsVeg=true
        //        },
        //        new Toppings()
        //        {
        //            Id=5,
        //            Name="Black Olives",
        //            Description="",
        //            Price=11,
        //            IsVeg=true
        //        },
        //        new Toppings()
        //        {
        //            Id=6,
        //            Name="Mushroom",
        //            Description="",
        //            Price=9,
        //            IsVeg=true
        //        },
        //        new Toppings()
        //        {
        //            Id=7,
        //            Name="Sweet Corn",
        //            Description="",
        //            Price=8,
        //            IsVeg=true
        //        },
        //        new Toppings()
        //        {
        //            Id=8,
        //            Name="Herbed Onion",
        //            Description="",
        //            Price=12,
        //            IsVeg=true
        //        },
        //        new Toppings()
        //        {
        //            Id=9,
        //            Name="Veg Kebab",
        //            Description="",
        //            Price=15,
        //            IsVeg=true
        //        },
        //        new Toppings()
        //        {
        //            Id=10,
        //            Name="Tomato",
        //            Description="",
        //            Price=10,
        //            IsVeg=true
        //        },
        //        new Toppings()
        //        {
        //            Id=11,
        //            Name="Red Paprika",
        //            Description="",
        //            Price=13,
        //            IsVeg=true
        //        },
        //        new Toppings()
        //        {
        //            Id=12,
        //            Name="Herbed Chicken",
        //            Description="",
        //            Price=15,
        //            IsVeg=false
        //        },
        //        new Toppings()
        //        {
        //            Id=13,
        //            Name="Schezwan Chicken Meatball",
        //            Description="",
        //            Price=20,
        //            IsVeg=false
        //        },
        //        new Toppings()
        //        {
        //            Id=14,
        //            Name="Chicken Tikka",
        //            Description="",
        //            Price=18,
        //            IsVeg=false
        //        },
        //        new Toppings()
        //        {
        //            Id=15,
        //            Name="Chicken Malai Tikka",
        //            Description="",
        //            Price=20,
        //            IsVeg=false
        //        }
        //    };


        //serDerService.SerializeData(list, toppingJasonPath);
        //    return list; 
        #endregion
    }
}
