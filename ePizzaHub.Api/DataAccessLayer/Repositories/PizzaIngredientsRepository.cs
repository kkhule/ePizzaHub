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
    public class PizzaIngredientsRepository : IPizzaIngredientsRepository
    {
        SerializationDeserialization serDerService;
        PizzaConfig pizzaConfig;
        string IngredientJasonPath;

        public PizzaIngredientsRepository(IOptions<AppConfig> appConfig, Func<string, SerializationDeserialization> serviceResolver)
        {
            pizzaConfig = appConfig.Value.pizzaConfig;
            serDerService = serviceResolver(pizzaConfig.SerDesMethod);
            IngredientJasonPath = PizzaHelper.CombinePath(PizzaHelper.JsonFilePath, pizzaConfig.PizzaIngredientsFileName);
        }

        public PizzaIngredients GetPizzaIngredientByIngredientIdAsync(int ingredientId)
        {
            var ingredientList = serDerService.DeserializeData<List<PizzaIngredients>>(IngredientJasonPath);
            var ingredient = ingredientList.Where(t => t.Id == ingredientId).FirstOrDefault();
            return ingredient;
        }

        public IEnumerable<PizzaIngredients> GetPizzaIngredientByIngredientIdAsync(IEnumerable<int> ingredientIds)
        {
            var ingredientList = serDerService.DeserializeData<List<PizzaIngredients>>(IngredientJasonPath);
            var ingredients = ingredientList.Where(t => ingredientIds.Contains(t.Id));
            return ingredients;
        }

        public IEnumerable<PizzaIngredients> GetPizzasIngredientsAsync()
        {
            var ingredientList = serDerService.DeserializeData<List<PizzaIngredients>>(IngredientJasonPath);
            return ingredientList;


            var list = new List<PizzaIngredients>()
            {
                new PizzaIngredients()
                {
                    Id=1,
                    Name="Cheese",
                    Description="",
                    Price=0
                },
                new PizzaIngredients()
                {
                    Id=2,
                    Name="Spiced paneer",
                    Description="",
                    Price=0
                },
                new PizzaIngredients()
                {
                    Id=3,
                    Name="Onion",
                    Description="",
                    Price=0
                },
                new PizzaIngredients()
                {
                    Id=4,
                    Name="Green Capsicum",
                    Description="",
                    Price=0
                },
                new PizzaIngredients()
                {
                    Id=5,
                    Name="Black Olives",
                    Description="",
                    Price=0
                },
                new PizzaIngredients()
                {
                    Id=6,
                    Name="Mushroom",
                    Description="",
                    Price=0
                },
                new PizzaIngredients()
                {
                    Id=7,
                    Name="Sweet Corn",
                    Description="",
                    Price=0
                },
                new PizzaIngredients()
                {
                    Id=8,
                    Name="Herbed Onion",
                    Description="",
                    Price=0
                },
                new PizzaIngredients()
                {
                    Id=9,
                    Name="Veg Kebab",
                    Description="",
                    Price=0
                },
                new PizzaIngredients()
                {
                    Id=10,
                    Name="Tomato",
                    Description="",
                    Price=0
                },
                new PizzaIngredients()
                {
                    Id=11,
                    Name="Red Paprika",
                    Description="",
                    Price=0
                }
            };

            // string path = PizzaHelper.CombinePath(PizzaHelper.JsonFilePath, pizzaConfig.PizzaFileName);

            serDerService.SerializeData(list, IngredientJasonPath);
        }
    }
}
