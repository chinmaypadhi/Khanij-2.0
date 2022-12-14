using ChangeRequestAPI.Models;
using ChangeRequestAPI.Repository;
using ChangeRequestAPI.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeRequestAPI.Services
{
    public class UserService : RepositoryBase, IUserService
    {
        public UserService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To bind user list details dataa in view
        /// </summary>
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, ClientName = "MSTC", UserName = "mstc", Password = "mstc" },
            new User { Id = 2, ClientName = "Application User", UserName = "App", Password = "App" }
        };
        /// <summary>
        /// Authenticate method
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Getall method
        /// </summary>
        /// <returns></returns>
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
