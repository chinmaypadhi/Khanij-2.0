// ***********************************************************************
//  Interface Name           : IForgotPasswordModel
//  Desciption               : To Get Email, Mobile Details
//  Created By               : Prakash Chandra Biswal
//  Created On               : 24 DEC 2021
// ***********************************************************************
using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Models.ForgotPasswordApp
{
    public interface IForgotPwdModel
    {
        MessageEF ForgotPasswordMail(ForgotPassword forgotPassword);
        MessageEF Main(SMS sMS);
        ForgotPasswordModel GetMobileEmail(ForgotPasswordModel forgotPasswordModel);
        OTPModel SendOTP(OTPModel oTPModel);
        MessageEF ResetPassword(ForgotPasswordModel forgotPasswordModel);
    }
}
