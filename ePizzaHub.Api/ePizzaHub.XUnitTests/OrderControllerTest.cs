using AutoFixture.Xunit2;
using ePizzaHub.Api.Controllers;
using ServiceLayer.Services;
using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace ePizzaHub.XUnitTests
{
    public class OrderControllerTest
    {

        public OrderControllerTest()
        {

        }

        [Theory]
        [AutoDomainData]
        public void GetAllOrders_OkResult([CollectionSize(3)] IEnumerable<Order> orders, [Frozen] Mock<IOrderRepository> mockOrderInfoRepo, [Greedy] OrderController orderController)
        {
            //Arrange
            mockOrderInfoRepo.Setup(x => x.GetOrdersAsync()).Returns(orders);

            //Act
            var result = orderController.GetAllOrders();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(orders.Count(), (expectedResult.Value as IEnumerable<Order>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetAllOrders_OkResultWithZeroCount([CollectionSize(0)] IEnumerable<Order> orders, [Frozen] Mock<IOrderRepository> mockOrderInfoRepo, [Greedy] OrderController orderController)
        {
            //Arrange
            mockOrderInfoRepo.Setup(x => x.GetOrdersAsync()).Returns(orders);

            //Act
            var result = orderController.GetAllOrders();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(orders.Count(), (expectedResult.Value as IEnumerable<Order>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetOrdersByUserId_OkResult([CollectionSize(1)] IEnumerable<Order> orders, [Frozen] Mock<IOrderRepository> mockOrderInfoRepo, [Greedy] OrderController orderController)
        {
            //Arrange
            orders.ToList()[0].UserId = 1;
            mockOrderInfoRepo.Setup(x => x.GetOrdersByUserIdAsync(1)).Returns(orders);

            //Act
            var result = orderController.GetOrdersByUserId(1);

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(orders.ToList()[0].UserId, (expectedResult.Value as IEnumerable<Order>).ToList()[0].UserId);
        }

        [Theory]
        [AutoDomainData]
        public void GetOrdersByUserId_NotFound([CollectionSize(1)] IEnumerable<Order> orders, [Frozen] Mock<IOrderRepository> mockOrderInfoRepo, [Greedy] OrderController orderController)
        {
            //Arrange
            orders.ToList()[0].UserId = 1;
            mockOrderInfoRepo.Setup(x => x.GetOrdersByUserIdAsync(1)).Returns(orders);

            //Act
            var result = orderController.GetOrdersByUserId(2);

            //Assert
            Assert.Equal((int)HttpStatusCode.NotFound, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result.Result).StatusCode);
            Assert.Null(result.Value);
        }


        [Theory]
        [AutoDomainData]
        public void GetSaveOrder_Created(Order order, [Frozen] Mock<IOrderRepository> mockOrderInfoRepo, [Greedy] OrderController orderController)
        {
            //Arrange
            int orderId = 12345;
            order.Id = orderId;
            mockOrderInfoRepo.Setup(x => x.SaveOrderChangesAsync(order)).Returns(order);

            //Act
            var result = orderController.SaveOrder(order);

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(orderId, (expectedResult.Value as Order).Id);
        }

        [Theory]
        [AutoDomainData]
        public void GetSaveOrder_NotCreated(Order order, [Frozen] Mock<IOrderRepository> mockOrderInfoRepo, [Greedy] OrderController orderController)
        {
            //Arrange
            int orderId = 12345;
            order.Id = orderId;
            mockOrderInfoRepo.Setup(x => x.SaveOrderChangesAsync(null)).Returns(order);

            //Act
            var result = orderController.SaveOrder(order);

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<CreatedAtActionResult>(result.Result);
            //Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Null(result.Value);
        }
    }
}
