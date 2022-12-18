using DataAccessLayer.Helper;
using DataModel.Configurations;
using DataModel.Models;
using ServiceLayer.Services;
using FileServices.FileCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        SerializationDeserialization serDerService;
        PizzaConfig pizzaConfig;
        string userJasonPath;

        public UserRepository(IOptions<AppConfig> appConfig, Func<string, SerializationDeserialization> serviceResolver)
        {
            pizzaConfig = appConfig.Value.pizzaConfig;
            serDerService = serviceResolver(pizzaConfig.SerDesMethod);
            userJasonPath = PizzaHelper.CombinePath(PizzaHelper.JsonFilePath, pizzaConfig.UsersFileName); 
        }

        public User GetUserAsync(int userId)
        {
            var userList = serDerService.DeserializeData<List<User>>(userJasonPath);
            if (userList == null)
            {
                userList = new List<User>();
            }
            var user = userList.Where(t => t.Id == userId).FirstOrDefault();
            return user;
        }

        public IEnumerable<User> GetUsersAsync()
        {
            var userList = serDerService.DeserializeData<List<User>>(userJasonPath);
            if (userList == null)
            {
                userList = new List<User>();
            }
            return userList;
        }

        #region Generated jason file code
        //var list = new List<User>()
        //    {
        //        new User()
        //        {
        //            Id=1,
        //            Name="Kailas",
        //            Address="Rahatani Pune"
        //        },

        //        new User()
        //        {
        //            Id=2,
        //            Name="Ranul",
        //            Address="Wakad Pune"
        //        }
        //    };

        //serDerService.SerializeData(list, userJasonPath);
        //    return list; 
        #endregion
    }

}
