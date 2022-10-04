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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApi.ExceptionHandlear;
using HomeApi.Model.Login;
using HomeApi.Services;
using HomeEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/{controller}/{action}")]    
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        public ILoginProvider _ObjILoginProvider { get; set; }
        public LoginController(ILoginProvider ObjloginProvider)
        {
            _ObjILoginProvider = ObjloginProvider;
        }
        [HttpPost]
        public UserLoginSession UserLogin(LoginEF objLoginEF)
        {
            
            return _ObjILoginProvider.UserLogin(objLoginEF); 
        }
        [HttpPost]
        public List<MenuEF> MenuList(menuonput objmenuonput)
        {
            return _ObjILoginProvider.MenuList(objmenuonput);
        }
        public String Test()
        {
            return "Test";
        }
        public String eTest()
        {
            try
            {
                return Convert.ToInt32("YYY").ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}