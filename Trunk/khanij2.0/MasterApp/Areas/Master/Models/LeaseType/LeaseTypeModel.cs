using System;
using System.Collections.Generic;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;


namespace MasterApp.Areas.Master.Models.LeaseType
{
    public class LeaseTypeModel:ILeaseTypeModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public LeaseTypeModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        public MessageEF Add(LeaseTypeMaster objLeaseType)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaseType/Add", JsonConvert.SerializeObject(objLeaseType)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        public MessageEF Update(LeaseTypeMaster objLeaseType)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaseType/Update", JsonConvert.SerializeObject(objLeaseType)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        public List<LeaseTypeMaster> View(LeaseTypeMaster objLeaseType)
        {
            try
            {
                List<LeaseTypeMaster> objlistLeaseType = new List<LeaseTypeMaster>();
                objlistLeaseType = JsonConvert.DeserializeObject<List<LeaseTypeMaster>>(_objIHttpWebClients.PostRequest("LeaseType/View", JsonConvert.SerializeObject(objLeaseType)));
                return objlistLeaseType;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        public MessageEF Delete(LeaseTypeMaster objLeaseType)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaseType/Delete", JsonConvert.SerializeObject(objLeaseType)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        public LeaseTypeMaster Edit(LeaseTypeMaster objLeaseType)
        {
            try
            {
                objLeaseType = JsonConvert.DeserializeObject<LeaseTypeMaster>(_objIHttpWebClients.PostRequest("LeaseType/Edit", JsonConvert.SerializeObject(objLeaseType)));
                return objLeaseType;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
