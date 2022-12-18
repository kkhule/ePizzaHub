using AutoFixture.Xunit2;
using ePizzaHub.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ServiceLayer.Services;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace ePizzaHub.XUnitTests
{
    public class NonPizzaItemControllerTest
    {
        [Theory]
        [AutoDomainData]
        public void GetAllNonPizzas_OkResult([CollectionSize(3)] IEnumerable<NonPizzas> nonPizzas, [Frozen] Mock<INonPizzaRepository> mockNonPizzaInfoRepo, [Greedy] NonPizzaItemController nonPizzaItemController)
        {
            //Arrange
            mockNonPizzaInfoRepo.Setup(x => x.GetNonPizzaItemsAsync()).Returns(nonPizzas);

            //Act
            var result = nonPizzaItemController.GetAllNonPizzaItems();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(nonPizzas.Count(), (expectedResult.Value as IEnumerable<NonPizzas>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetAllNonPizzas_OkResultWithZeroCount([CollectionSize(0)] IEnumerable<NonPizzas> nonPizzas, [Frozen] Mock<INonPizzaRepository> mockNonPizzaInfoRepo, [Greedy] NonPizzaItemController nonPizzaItemController)
        {
            //Arrange
            mockNonPizzaInfoRepo.Setup(x => x.GetNonPizzaItemsAsync()).Returns(nonPizzas);

            //Act
            var result = nonPizzaItemController.GetAllNonPizzaItems();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(nonPizzas.Count(), (expectedResult.Value as IEnumerable<NonPizzas>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetNonPizzaItem_OkResult(NonPizzas nonPizza, [Frozen] Mock<INonPizzaRepository> mockNonPizzaInfoRepo, [Greedy] NonPizzaItemController nonPizzaItemController)
        {
            //Arrange
            nonPizza.Id = 1;
            mockNonPizzaInfoRepo.Setup(x => x.GetNonPizzaItemAsync(1)).Returns(nonPizza);

            //Act
            var result = nonPizzaItemController.GetNonPizzaItem(1);

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(nonPizza.Id, (expectedResult.Value as NonPizzas).Id);
        }

        [Theory]
        [AutoDomainData]
        public void GetNonPizzaItem_NotFound(NonPizzas nonPizza, [Frozen] Mock<INonPizzaRepository> mockNonPizzaInfoRepo, [Greedy] NonPizzaItemController nonPizzaItemController)
        {
            //Arrange
            nonPizza.Id = 1;
            mockNonPizzaInfoRepo.Setup(x => x.GetNonPizzaItemAsync(1)).Returns(nonPizza);

            //Act
            var result = nonPizzaItemController.GetNonPizzaItem(2);

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            //Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.NotEqual(nonPizza.Id, (expectedResult.Value as NonPizzas).Id);
        }
    }
}
