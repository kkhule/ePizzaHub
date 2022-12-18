using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLayer.Services;
using DataModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ePizzaHub.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger,IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }


        [HttpGet("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _userRepository.GetUsersAsync();

            _logger.LogInformation($"Total {users.Count()} users are returned.");
            return Ok(users);
        }

        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetUser(int userId)
        {
            var user = _userRepository.GetUserAsync(userId);

            if (user == null)
            {
                _logger.LogInformation($"user with id {userId} wasn't found when accessing user.");
                return NotFound();
            }

            _logger.LogInformation($"user with Id {userId} is returned.");
            return Ok(user);
        }
    }
}
