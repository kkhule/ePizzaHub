using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Configurations
{
    public class AppConfig
    {
        public AppConfig()
        {
        }

        public PizzaConfig pizzaConfig { get; set; }

        public string ApplicationUrl { get; set; }
    }
}
