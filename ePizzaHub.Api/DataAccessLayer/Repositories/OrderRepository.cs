using DataAccessLayer.Helper;
using DataModel.Configurations;
using DataModel.Models;
using FileServices.FileCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ServiceLayer.Services;

namespace DataAccessLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        SerializationDeserialization serDerService;
        PizzaConfig pizzaConfig;
        string orderJasonPath;

        public OrderRepository(IOptions<AppConfig> appConfig, Func<string, SerializationDeserialization> serviceResolver)
        {
            pizzaConfig = appConfig.Value.pizzaConfig;
            serDerService = serviceResolver(pizzaConfig.SerDesMethod);
            orderJasonPath = PizzaHelper.CombinePath(PizzaHelper.JsonFilePath, pizzaConfig.PizzaOrdersFileName);
        }

        public Order GetOrderByOrderIdAsync(int orderId)
        {
            var orderList = serDerService.DeserializeData<List<Order>>(orderJasonPath);
            if (orderList == null)
            {
                orderList = new List<Order>();
            }
            var order = orderList.Where(t => t.Id == orderId).FirstOrDefault();
            return order;
        }

        public IEnumerable<Order> GetOrdersAsync()
        {
            var orderList = serDerService.DeserializeData<List<Order>>(orderJasonPath);
            if (orderList == null)
            {
                orderList = new List<Order>();
            }
            return orderList;
        }

        public IEnumerable<Order> GetOrdersByUserIdAsync(int userId)
        {
            var orderList = serDerService.DeserializeData<List<Order>>(orderJasonPath);
            if (orderList == null)
            {
                orderList = new List<Order>();
            }
            var orders = orderList.Where(t => t.UserId == userId).OrderByDescending(d=>d.OrderDate);
            return orders;
        }

        public Order SaveOrderChangesAsync(Order order)
        {
            var orderList = GetOrdersAsync().ToList();
            int neworderiD = 1;
            if (orderList.Count() > 0)
            {
                neworderiD = orderList.Max(o => o.Id);
                neworderiD++;
            }
            order.Id = neworderiD;

            orderList.Add(order);

            serDerService.SerializeData<List<Order>>(orderList, orderJasonPath);

            return order;

        }
    }
}
