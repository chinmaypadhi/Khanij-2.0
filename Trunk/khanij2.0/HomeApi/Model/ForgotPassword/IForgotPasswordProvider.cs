// ***********************************************************************
//  Interface Name           : IForgotPasswordProvider
//  Desciption               : To Get Email, Mobile Details
//  Created By               : Prakash Chandra Biswal
//  Created On               : 23 DEC 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
namespace HomeApi.Model.ForgotPassword
{
    public interface IForgotPasswordProvider : IDisposable
    {
        /// <summary>
        /// To Get Mobile and Email 
        /// </summary>
        /// <param name="forgotPasswordModel"></param>
        /// <returns></returns>
        ForgotPasswordModel GetMobileEmail(ForgotPasswordModel forgotPasswordModel);
        /// <summary>
        /// To Get OTP
        /// </summary>
        /// <param name="oTPModel"></param>
        /// <returns></returns>
        OTPModel SendOTP(OTPModel oTPModel);

        MessageEF ResetPassword(ForgotPasswordModel forgotPasswordModel);
    }
}
