using AutoFixture.Xunit2;
using ePizzaHub.Api.Controllers;
using ServiceLayer.Services;
using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace ePizzaHub.XUnitTests
{
    public class AutoDomainDataAttribute : AutoDataAttribute
    {
        public AutoDomainDataAttribute() : base(
            () =>
            {
                var fixture = new Fixture();

                fixture.Create<Pizzas>();

                fixture.Customize(new AutoMoqCustomization());


                return fixture;
            }
            )
        {

        }
    }


    public class PizzaControllerTest
    {
        [Fact]
        public void Test1()
        {

        }

        [Theory]
        [AutoDomainData]
        public void GetAllPizza_OkResult([CollectionSize(3)] IEnumerable<Pizzas> pizzas, [Frozen] Mock<IPizzaRepository> mocPizzaInfoRepo, [Greedy] PizzaController pizzaController)
        {
            //Arrange
            mocPizzaInfoRepo.Setup(x => x.GetPizzasAsync()).Returns(pizzas);

            //Act
            var result = pizzaController.GetAllPizzas();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(pizzas.Count(), (expectedResult.Value as IEnumerable<Pizzas>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetAllPizza_OkResultWithZeroCount([CollectionSize(0)] IEnumerable<Pizzas> pizzas, [Frozen] Mock<IPizzaRepository> mocPizzaInfoRepo, [Greedy] PizzaController pizzaController)
        {
            //Arrange
            mocPizzaInfoRepo.Setup(x => x.GetPizzasAsync()).Returns(pizzas);

            //Act
            var result = pizzaController.GetAllPizzas();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(pizzas.Count(), (expectedResult.Value as IEnumerable<Pizzas>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetAllSauces_OkResult([CollectionSize(3)] IEnumerable<Sauces> sauces, [Frozen] Mock<ISaucesRepository> mockSaucesInfoRepo, [Greedy] PizzaController pizzaController)
        {
            //Arrange
            mockSaucesInfoRepo.Setup(x => x.GetSaucesAsync()).Returns(sauces);

            //Act
            var result = pizzaController.GetPizzaSauces();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(sauces.Count(), (expectedResult.Value as IEnumerable<Sauces>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetAllSauces_OkResultWithZeroCount([CollectionSize(0)] IEnumerable<Sauces> sauces, [Frozen] Mock<ISaucesRepository> mockSaucesInfoRepo, [Greedy] PizzaController pizzaController)
        {
            //Arrange
            mockSaucesInfoRepo.Setup(x => x.GetSaucesAsync()).Returns(sauces);

            //Act
            var result = pizzaController.GetPizzaSauces();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(sauces.Count(), (expectedResult.Value as IEnumerable<Sauces>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetAllToppings_OkResult([CollectionSize(3)] IEnumerable<Toppings> toppings, [Frozen] Mock<IToppingsRepository> mockToppingInfoRepo, [Greedy] PizzaController pizzaController)
        {
            //Arrange
            mockToppingInfoRepo.Setup(x => x.GetToppingsAsync()).Returns(toppings);

            //Act
            var result = pizzaController.GetPizzaToppings();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(toppings.Count(), (expectedResult.Value as IEnumerable<Toppings>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetAllToppings_OkResultWithZeroCount([CollectionSize(0)] IEnumerable<Toppings> toppings, [Frozen] Mock<IToppingsRepository> mockToppingInfoRepo, [Greedy] PizzaController pizzaController)
        {
            //Arrange
            mockToppingInfoRepo.Setup(x => x.GetToppingsAsync()).Returns(toppings);

            //Act
            var result = pizzaController.GetPizzaToppings();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(toppings.Count(), (expectedResult.Value as IEnumerable<Toppings>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetAllPizzaIngredients_OkResult([CollectionSize(3)] IEnumerable<PizzaIngredients> pizzaIngredients, [Frozen] Mock<IPizzaIngredientsRepository> mockpizzaIngredientsInfoRepo, [Greedy] PizzaController pizzaController)
        {
            //Arrange
            mockpizzaIngredientsInfoRepo.Setup(x => x.GetPizzasIngredientsAsync()).Returns(pizzaIngredients);

            //Act
            var result = pizzaController.GetPizzaIngredients();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(pizzaIngredients.Count(), (expectedResult.Value as IEnumerable<PizzaIngredients>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetAllPizzaIngredients_OkResultWithZeroCount([CollectionSize(0)] IEnumerable<PizzaIngredients> pizzaIngredients, [Frozen] Mock<IPizzaIngredientsRepository> mockpizzaIngredientsInfoRepo, [Greedy] PizzaController pizzaController)
        {
            //Arrange
            mockpizzaIngredientsInfoRepo.Setup(x => x.GetPizzasIngredientsAsync()).Returns(pizzaIngredients);

            //Act
            var result = pizzaController.GetPizzaIngredients();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(pizzaIngredients.Count(), (expectedResult.Value as IEnumerable<PizzaIngredients>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetAllPizzaSizes_OkResult([CollectionSize(3)] IEnumerable<Size> sizes, [Frozen] Mock<ISizeRepository> mockpizzaSizeInfoRepo, [Greedy] PizzaController pizzaController)
        {
            //Arrange
            mockpizzaSizeInfoRepo.Setup(x => x.GetAllPizzaSizesAsync()).Returns(sizes);

            //Act
            var result = pizzaController.GetPizzaSizes();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(sizes.Count(), (expectedResult.Value as IEnumerable<Size>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetAllPizzaSizes_OkResultWithZeroCount([CollectionSize(0)] IEnumerable<Size> sizes, [Frozen] Mock<ISizeRepository> mockpizzaSizeInfoRepo, [Greedy] PizzaController pizzaController)
        {
            //Arrange
            mockpizzaSizeInfoRepo.Setup(x => x.GetAllPizzaSizesAsync()).Returns(sizes);

            //Act
            var result = pizzaController.GetPizzaSizes();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(sizes.Count(), (expectedResult.Value as IEnumerable<Size>).Count());
        }
    }
}
