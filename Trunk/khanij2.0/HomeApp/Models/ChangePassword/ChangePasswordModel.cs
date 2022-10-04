// ***********************************************************************
//  Class Name               : ChangePasswordModel
//  Desciption               : To Change User Password Details in view 
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Feb 2022
// ***********************************************************************

using HomeApp.Models.Utility;
using HomeEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Models.ChangePassword
{
    public class ChangePasswordModel:IChangePasswordModel
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="httpWebClients"></param>
        public ChangePasswordModel(IHttpWebClients httpWebClients)
        {
            _objIHttpWebClients = httpWebClients;
        }
        /// <summary>
        /// Change User Password Details 
        /// </summary>
        /// <param name="objChangePasswordEF"></param>
        /// <returns></returns>
        public MessageEF ChangeUserPassword(ChangePasswordEF objChangePasswordEF)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("ChangePassword/ChangeUserPassword", JsonConvert.SerializeObject(objChangePasswordEF)));
                return messageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
