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
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Model.Login
{
    public interface ILoginProvider:IDisposable, IRepository
    {
        UserLoginSession UserLogin(LoginEF obj);
        List<MenuEF> MenuList(menuonput objmenuonput);
    }
}
