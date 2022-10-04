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
using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Models.Login
{
  public  interface ILoginModel
    {
        UserLoginSession LoginUser(LoginEF ObjloginEF);
        List<MenuEF> MenuList(menuonput objmenuonput);
    }
}
