using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Configurations
{
    public class PizzaConfig
    {
        public string PizzaImageFilePath { get; set; }

        public string PizzaJsonFilePath { get; set; }

        public string SerDesMethod { get; set; }

        public string PizzaFileName { get; set; }

        public string NonPizzaFileName { get; set; }

        public string PizzaIngredientsFileName { get; set; }

        public string PizzaSaucesFileName { get; set; }

        public string PizzaToppingsFileName { get; set; }

        public string PizzaOrdersFileName { get; set; }

        public string UsersFileName { get; set; }

        public string PizzaSizeFileName { get; set; }
    }
}
