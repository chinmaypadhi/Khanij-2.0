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



using EpassApi.Model;
using EpassApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EpassApi.Services
{
    public interface IUserService: IDisposable,IRepository
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        
    }
}
