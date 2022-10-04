// ***********************************************************************
// Assembly         : Khanij
// Author           : Kumar jeevan jyoti
// Created          : 28-dec-2020
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************


using MasterApi.Factory;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInformationApi.Model;
using UserInformationApi.Repository;

namespace UserInformationApi.Services
{
    public class UserService : RepositoryBase,IUserService
    {
        public UserService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, ClientName = "MSTC", UserName = "mstc", Password = "mstc" },
            new User { Id = 2, ClientName = "Application User", UserName = "App", Password = "App" }
        };

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.UserName == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            user.Password = null;
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            // return users without passwords
            return await Task.Run(() => _users.Select(x =>
            {
                x.Password = null;
                return x;
            }));
        }

       
    }
}
