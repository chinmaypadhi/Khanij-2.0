using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeLApi.Factory;
using HomeEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HomeLApi.Model.Login;

namespace HomeLApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //public ILoginProvider _ObjILoginProvider;
        //public LoginController(ILoginProvider ObjloginProvider)
        //{
        //    _ObjILoginProvider = ObjloginProvider;
        //}
        //[HttpPost]
        //public UserLoginSession UserLogin(LoginEF objLoginEF)
        //{
        //    return _ObjILoginProvider.UserLogin(objLoginEF); ;
        //}

        [HttpGet]
        public ActionResult<IEnumerable<string>> Test()
        {
            return new string[] { "value1", "value2" };
        }
    }
}