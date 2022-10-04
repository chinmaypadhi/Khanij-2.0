// ***********************************************************************
//  Controller Name          : LoginController
//  Desciption               : Login controller details
//  Created By               : Lingaraj Dalai
//  Created On               : 21 September 2021
// ***********************************************************************
using GeologyApi.Model.Login;
using GeologyEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GeologyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
