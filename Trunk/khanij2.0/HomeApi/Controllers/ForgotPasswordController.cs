// ***********************************************************************
//  Controller Name          : ForgotPasswordController
//  Desciption               : To Get Email, Mobile Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 23 DEC 2021
// ***********************************************************************
using HomeApi.Model.ForgotPassword;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using Microsoft.AspNetCore.Authorization;

namespace HomeApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class ForgotPasswordController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration 
        /// </summary>
        private IForgotPasswordProvider _objforgotPasswordProvider;
        /// <summary>
        /// Constructor Dependency Injection
        /// </summary>
        /// <param name="forgotPasswordProvider"></param>
        public ForgotPasswordController(IForgotPasswordProvider objforgotPasswordProvider)
        {
            _objforgotPasswordProvider = objforgotPasswordProvider;
        }

        [HttpPost]
        public ForgotPasswordModel GetMobileEmail(ForgotPasswordModel forgotPasswordModel)
        {
            return _objforgotPasswordProvider.GetMobileEmail(forgotPasswordModel);
        }
        [HttpPost]
        public OTPModel SendOTP(OTPModel oTPModel)
        {
            return _objforgotPasswordProvider.SendOTP(oTPModel);
        }
        [HttpPost]
        public MessageEF ResetPassword(ForgotPasswordModel forgotPasswordModel)
        {
            return _objforgotPasswordProvider.ResetPassword(forgotPasswordModel);
        }

    }
}
