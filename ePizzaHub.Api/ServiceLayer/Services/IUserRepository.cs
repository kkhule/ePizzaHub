using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsersAsync();

        User? GetUserAsync(int userId);
    }
}
