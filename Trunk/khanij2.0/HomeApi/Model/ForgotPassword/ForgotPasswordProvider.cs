// ***********************************************************************
//  Class Name               : ForgotPasswordProvider
//  Desciption               : To Get Email, Mobile Details
//  Created By               : Prakash Chandra Biswal
//  Created On               : 23 DEC 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using HomeApi.Factory;
using HomeApi.Model.ForgotPassword;
using HomeApi.Repository;
using HomeEF;

namespace HomeApi.Model.ForgotPassword
{
    public class ForgotPasswordProvider : RepositoryBase,IForgotPasswordProvider
    {
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public ForgotPasswordProvider(IConnectionFactory connectionFactory):base(connectionFactory)
        {

        }
        /// <summary>
        /// To Get Mobile and Email 
        /// </summary>
        /// <param name="forgotPasswordModel"></param>
        /// <returns></returns>
        public ForgotPasswordModel GetMobileEmail(ForgotPasswordModel forgotPasswordModel)
        {
            ForgotPasswordModel objforgotPasswordModel = new ForgotPasswordModel();
            try
            {
                var paramList = new
                {
                    UserCode = forgotPasswordModel.UserName,
                };
                var result =  Connection.Query<ForgotPasswordModel>("GET_MOBILE_EMAIL_FROM_USERNAME", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objforgotPasswordModel = result.FirstOrDefault();
                }
                return objforgotPasswordModel;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public OTPModel SendOTP(OTPModel oTPModel)
        {
            OTPModel objOTPModel = new OTPModel();
            try
            {
                var paramList = new
                {
                    Check = "6",
                    UserName = oTPModel.UserName,
                    Password = oTPModel.MobileNumber,
                    Remakrs= oTPModel.OptionData
                };
                var result = Connection.Query<OTPModel>("uspValidateUser", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objOTPModel = result.FirstOrDefault();
                }
                return objOTPModel;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public MessageEF ResetPassword(ForgotPasswordModel forgotPasswordModel)
        {
            ForgotPasswordModel objforgotPasswordModel = new ForgotPasswordModel();
            MessageEF messageEF = new MessageEF();
            try
            {
                var paramlist = new
                {
                    Check = 5,
                    ProfileUserId = forgotPasswordModel.UserId,
                    SubUserID=forgotPasswordModel.SubUserID,
                    UserLoginId=forgotPasswordModel.UserLoginId,
                    Password=forgotPasswordModel.Password,
                    EncryptPassword=objforgotPasswordModel.EncryptPassword
                };
                var result = Connection.Query<MessageEF>("uspValidateUser", paramlist, commandType: System.Data.CommandType.StoredProcedure);
                if(result.Count() > 0)
                {
                    messageEF.Satus = "1";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return messageEF;
        }   
    }
}
