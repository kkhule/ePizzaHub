using DataAccessLayer.Helper;
using DataModel.Configurations;
using DataModel.Models;
using ServiceLayer.Services;
using FileServices.FileCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {

        SerializationDeserialization serDerService;
        PizzaConfig pizzaConfig;
        string pizzaJasonPath;
        IPizzaIngredientsRepository pizzaIngredientsRepository;
        string appURL;

        public PizzaRepository(IOptions<AppConfig> appConfig, IPizzaIngredientsRepository pizzaIngredientsRepository,Func<string, SerializationDeserialization> serviceResolver)
        {
            pizzaConfig = appConfig.Value.pizzaConfig;
            appURL = appConfig.Value.ApplicationUrl;
            serDerService = serviceResolver(pizzaConfig.SerDesMethod);
            this.pizzaIngredientsRepository = pizzaIngredientsRepository;
            pizzaJasonPath = PizzaHelper.CombinePath(PizzaHelper.JsonFilePath, pizzaConfig.PizzaFileName);
        }

        public Pizzas GetPizzaAsync(int pizzaId)
        {
            var pizzaList=serDerService.DeserializeData<List<Pizzas>>(pizzaJasonPath);
            if (pizzaList == null)
            {
                pizzaList = new List<Pizzas>();
            }
            var pizza = pizzaList.Where(t => t.Id == pizzaId).FirstOrDefault();
            return pizza;
        }

        private void EnrichPizzaData(IEnumerable<Pizzas> pizzas)
        {
            foreach (var pizza in pizzas)
            {
                pizza.ImageUrl = string.Format("{0}/{1}", appURL, pizza.ImageUrl);
            }
        }

        public IEnumerable<Pizzas> GetPizzasAsync()
        {
            var pizzaList = serDerService.DeserializeData<List<Pizzas>>(pizzaJasonPath);
            if (pizzaList == null)
            {
                pizzaList = new List<Pizzas>();
            }
            EnrichPizzaData(pizzaList);
            return pizzaList;
        }

        #region Generated jason file code
        //var list = new List<Pizzas>()
        //    {
        //        new Pizzas()
        //        {
        //            Id = 1,
        //            Price = 289,
        //            SizeId = 1,
        //            IsVeg=true,
        //            SepcialStatus="Most Popular",
        //            Name = "Margherita",
        //            ImageUrl = "images/margherita.jpg",
        //            Description= "Cheese, Onion",
        //            IngredientIds = new List<int> { 1,3}
        //        },

        //       new Pizzas()
        //       {
        //           Id = 2,
        //           Price = 539,
        //           SizeId = 1,
        //           IsVeg=true,
        //           SepcialStatus="Most Popular",
        //           Name = "Tandoori Paneer",
        //           ImageUrl = "images/tandoori-paneer.jpg",
        //           Description = "Spiced paneer, Onion, Green Capsicum & Red Paprika in Tandoori Sauce",
        //           IngredientIds = new List<int> { 2, 3, 4, 11 }
        //       },


        //        new Pizzas()
        //        {
        //            Id = 3,
        //            SizeId = 1,
        //            Name = "Veggie Supreme",
        //            Price = 609,
        //            IsVeg=true,
        //            SepcialStatus="New",
        //            ImageUrl = "images/veggie-supreme.jpg",
        //            Description = "Black Olives, Green Capsicum, Mushroom, Onion, Red Paprika, Sweet Corn",
        //            IngredientIds = new List<int> { 5, 4, 6,3,11,7 }
        //        },

        //        new Pizzas()
        //        {
        //            Id = 4,
        //            SizeId = 1,
        //            Name = "Veg Kebab Surprise",
        //            IsVeg=true,
        //            SepcialStatus="New",
        //            Price = 609,
        //            ImageUrl = "images/veg-kebab-surprise.jpg",
        //            Description = "Veg Kebab, Onion, Green Capsicum, Tomato & Sweet Corn in Tandoori Sauce",
        //            IngredientIds = new List<int> { 9, 3, 4,10,7 }
        //        },

        //        new Pizzas()
        //        {
        //            Id = 5,
        //            SizeId = 1,
        //            Name = "Chicken Supreme",
        //            Price = 689,
        //            IsVeg=false,
        //            SepcialStatus="Most Popular",
        //            ImageUrl = "images/chicken-supreme.jpg",
        //            Description = "Herbed Chicken, Schezwan Chicken Meatball, Chicken Tikka",
        //            IngredientIds = new List<int> { 12, 13, 14 }
        //        }
        //        ,
        //        new Pizzas()
        //        {
        //            Id = 6,
        //            SizeId = 1,
        //            Name = "Chicken Tikka Supreme",
        //            Price = 689,
        //            IsVeg=false,
        //            SepcialStatus="New",
        //            ImageUrl = "images/chicken-tikka-supreme.jpg",
        //            Description = "A divine combination of delicious Chicken Tikka & Malai Chicken Tikka, Onion, spicy Red Paprika with flavourful pan sauce and 100% mozzarella cheese.",
        //            IngredientIds = new List<int> { 14, 15, 3, 11 }
        //        }

        //        };


        //string path = PizzaHelper.CombinePath(PizzaHelper.JsonFilePath, pizzaConfig.PizzaFileName);

        //serDerService.SerializeData(list, pizzaJasonPath);

        //    EnrichPizzaData(list);
        //    return list;

        //    var pizzaList = serDerService.DeserializeData<List<Pizzas>>(path);
        //    if (pizzaList == null)
        //    {
        //        pizzaList = new List<Pizzas>();
        //    }

        //    throw new NotImplementedException(); 
        #endregion
    }
}
