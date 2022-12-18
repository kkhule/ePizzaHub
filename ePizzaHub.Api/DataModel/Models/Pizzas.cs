using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class Pizzas
    {
        public Pizzas()
        {
                
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int  SizeId { get; set; }

        public bool IsVeg { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string SepcialStatus { get; set; }

        public IEnumerable<int> IngredientIds { get; set; }
    }


    public enum PizzaSize
    {
        Small,
        Medium,
        Large
    }

    public enum PizzaType
    {
        Veg,
        NonVeg
    }
}
