// ***********************************************************************
//  Interface Name           : IUserService
//  Created By               : Kumar jeevan jyoti
//  Created On               : 28-dec-2020
// ***********************************************************************

using MasterApi.Model;
using MasterApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterApi.Services
{
    public interface IUserService: IDisposable,IRepository
    {
        /// <summary>
        /// Authentication Login credentials
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
