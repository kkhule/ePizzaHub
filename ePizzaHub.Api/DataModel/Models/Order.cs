using DataModel.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class Order
    {
        public Order()
        {

        }

        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "User Id is required.")]
        public int UserId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        [ApplyNotNullAttribute(ErrorMessage = "Pizza details are required.")]
        public Pizzas pizza { get; set; }

        [ApplyNotNullAttribute(ErrorMessage = "Pizza should have at least one topping.")]
        public IEnumerable<Toppings> PizzaToppings { get; set; }

        public IEnumerable<Sauces> PizzaSauces { get; set; }

        public IEnumerable<NonPizzas> NonPizzas { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Total Pizza Price is missing.")]
        public int TotalPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Total number of pizzas are required.")]
        public int NumberOfPizza { get; set; }

    }
}
