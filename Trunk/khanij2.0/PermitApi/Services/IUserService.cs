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

using PermitApi.Model;
using PermitApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermitApi.Services
{
    public interface IUserService: IDisposable,IRepository
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        
    }
}
