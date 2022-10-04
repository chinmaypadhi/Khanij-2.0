// ***********************************************************************
//  Class Name               : ChangePasswordProvider
//  Desciption               : To Change User Password Details in view 
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Feb 2022
// ***********************************************************************
using Dapper;
using HomeApi.Factory;
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Model.ChangePassword
{
    public class ChangePasswordProvider: RepositoryBase, IChangePasswordProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public ChangePasswordProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Change User Password Details 
        /// </summary>
        /// <param name="objChangePasswordEF"></param>
        /// <returns></returns>
        public async Task<MessageEF> ChangeUserPassword(ChangePasswordEF objChangePasswordEF)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("ProfileUserId", objChangePasswordEF.UserId);
                p.Add("SubUserID", objChangePasswordEF.UserId);
                p.Add("Password", objChangePasswordEF.NewPassword);
                p.Add("EncryptPassword", objChangePasswordEF.EncryptPassword);
                p.Add("Check", "5");
                string response = await Connection.QueryFirstOrDefaultAsync<string>("uspValidateUser", p, commandType: CommandType.StoredProcedure);
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
    }
}
