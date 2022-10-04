// ***********************************************************************
//  Class Name               : UsertypeModel
//  Description              : Add,View,Edit,Update,Delete Usertype Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using MasterApp.Models.Utility;
using MasterEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Usertype
{
    public class UsertypeModel:IUsertypeModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public UsertypeModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Usertype Details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        public MessageEF Add(UsertypeMaster objUsertypeMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Usertype/Add", JsonConvert.SerializeObject(objUsertypeMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Usertype Details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        public MessageEF Update(UsertypeMaster objUsertypeMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Usertype/Update", JsonConvert.SerializeObject(objUsertypeMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// View Usertype Details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        public List<UsertypeMaster> View(UsertypeMaster objUsertypeMaster)
        {
            try
            {
                List<UsertypeMaster> objlistCheckPostmaster = new List<UsertypeMaster>();
                objlistCheckPostmaster = JsonConvert.DeserializeObject<List<UsertypeMaster>>(_objIHttpWebClients.PostRequest("Usertype/View", JsonConvert.SerializeObject(objUsertypeMaster)));
                return objlistCheckPostmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Delete Usertype Details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        public MessageEF Delete(UsertypeMaster objUsertypeMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Usertype/Delete", JsonConvert.SerializeObject(objUsertypeMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Edit Usertype Details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        public UsertypeMaster Edit(UsertypeMaster objUsertypeMaster)
        {
            try
            {
                objUsertypeMaster = JsonConvert.DeserializeObject<UsertypeMaster>(_objIHttpWebClients.PostRequest("Usertype/Edit", JsonConvert.SerializeObject(objUsertypeMaster)));
                return objUsertypeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
