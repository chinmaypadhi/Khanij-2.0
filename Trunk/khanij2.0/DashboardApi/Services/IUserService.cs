﻿// ***********************************************************************
//  Interface Name           : IUserService
//  Desciption               : Service class to authenticate 
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Dec 2020
// ***********************************************************************
using DashboardApi.Model;
using DashboardApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashboardApi.Services
{
    public interface IUserService: IDisposable,IRepository
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
