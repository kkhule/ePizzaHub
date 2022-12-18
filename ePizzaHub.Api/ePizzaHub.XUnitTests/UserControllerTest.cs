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
    public class UserControllerTest
    {

        [Theory]
        [AutoDomainData]
        public void GetAllUsers_OkResult([CollectionSize(3)] IEnumerable<User> users, [Frozen] Mock<IUserRepository> mockUserInfoRepo, [Greedy] UserController userController)
        {
            //Arrange
            mockUserInfoRepo.Setup(x => x.GetUsersAsync()).Returns(users);

            //Act
            var result = userController.GetAllUsers();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(users.Count(), (expectedResult.Value as IEnumerable<User>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetAllUsers_OkResultWithZeroCount([CollectionSize(0)] IEnumerable<User> users, [Frozen] Mock<IUserRepository> mockUserInfoRepo, [Greedy] UserController userController)
        {
            //Arrange
            mockUserInfoRepo.Setup(x => x.GetUsersAsync()).Returns(users);

            //Act
            var result = userController.GetAllUsers();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(users.Count(), (expectedResult.Value as IEnumerable<User>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetUser_OkResult(User users, [Frozen] Mock<IUserRepository> mockUserInfoRepo, [Greedy] UserController userController)
        {
            //Arrange
            users.Id = 1;
            mockUserInfoRepo.Setup(x => x.GetUserAsync(1)).Returns(users);

            //Act
            var result = userController.GetUser(1);

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(users.Id, (expectedResult.Value as User).Id);
        }

        [Theory]
        [AutoDomainData]
        public void GetUser_NotFound(User users, [Frozen] Mock<IUserRepository> mockUserInfoRepo, [Greedy] UserController userController)
        {
            //Arrange
            users.Id = 1;
            mockUserInfoRepo.Setup(x => x.GetUserAsync(1)).Returns(users);

            //Act
            var result = userController.GetUser(2);

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotEqual(users.Id, (expectedResult.Value as User).Id);
        }

    }
}
