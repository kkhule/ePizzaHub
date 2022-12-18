using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersAsync();

        IEnumerable<Order> GetOrdersByUserIdAsync(int userId);

        Order? GetOrderByOrderIdAsync(int orderId);

        Order? SaveOrderChangesAsync(Order order);
    }
}
