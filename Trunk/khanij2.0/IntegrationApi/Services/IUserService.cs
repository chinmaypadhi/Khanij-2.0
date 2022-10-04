// ***********************************************************************
// Assembly         : Khanij
// Author           : sanjay kumar
// Created          : 28-dec-2020
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************

using IntegrationApi.Model;
using IntegrationApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegrationApi.Services
{
    public interface IUserService: IDisposable,IRepository
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        
    }
}
