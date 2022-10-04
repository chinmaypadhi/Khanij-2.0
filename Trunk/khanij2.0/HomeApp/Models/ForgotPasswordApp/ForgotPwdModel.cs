// ***********************************************************************
//  Class Name               : ForgotPasswordModel
//  Desciption               : To Get Email, Mobile Details
//  Created By               : Prakash Chandra Biswal
//  Created On               : 24 DEC 2021
// ***********************************************************************

using HomeApp.Models.Utility;
using HomeEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Models.ForgotPasswordApp
{
    public class ForgotPwdModel : IForgotPwdModel
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        public ForgotPwdModel(IHttpWebClients httpWebClients)
        {
            _objIHttpWebClients = httpWebClients;
        }
        public ForgotPasswordModel GetMobileEmail(ForgotPasswordModel forgotPasswordModel)
        {
            ForgotPasswordModel objforgotPassword = new ForgotPasswordModel();
            try
            {

                objforgotPassword = JsonConvert.DeserializeObject<ForgotPasswordModel>(_objIHttpWebClients.PostRequest("ForgotPassword/GetMobileEmail", JsonConvert.SerializeObject(forgotPasswordModel)));
                return objforgotPassword;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { }

        }

        public OTPModel SendOTP(OTPModel oTPModel)
        {
            OTPModel objoTPModel = new OTPModel();
            try
            {
                objoTPModel = JsonConvert.DeserializeObject<OTPModel>(_objIHttpWebClients.PostRequest("ForgotPassword/SendOTP", JsonConvert.SerializeObject(oTPModel)));
                return objoTPModel;
            }
            catch (Exception)
            {

                throw;
            }
            finally { }
        }

        public MessageEF ForgotPasswordMail(ForgotPassword forgotPassword)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MailService/ForgotPasswordMail", JsonConvert.SerializeObject(forgotPassword)));
                return messageEF;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public MessageEF Main(SMS sMS)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SMSService/Main", JsonConvert.SerializeObject(sMS)));
                return messageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public MessageEF ResetPassword(ForgotPasswordModel forgotPasswordModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("ForgotPassword/ResetPassword", JsonConvert.SerializeObject(forgotPasswordModel)));
                return messageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
