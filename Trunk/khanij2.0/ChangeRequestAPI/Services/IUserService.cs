using ChangeRequestAPI.Models;
using ChangeRequestAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeRequestAPI.Services
{
    public interface IUserService : IDisposable, IRepository
    {
        /// <summary>
        /// Authenticate method
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User> Authenticate(string username, string password);
        /// <summary>
        /// Getall method
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetAll();
    }
}
