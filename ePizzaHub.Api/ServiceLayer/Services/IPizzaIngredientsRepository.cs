using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IPizzaIngredientsRepository
    {

        IEnumerable<PizzaIngredients> GetPizzasIngredientsAsync();

        IEnumerable<PizzaIngredients> GetPizzaIngredientByIngredientIdAsync(IEnumerable<int> ingredientIds);
        PizzaIngredients? GetPizzaIngredientByIngredientIdAsync(int ingredientId);
    }
}
