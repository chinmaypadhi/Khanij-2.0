using System;
using System.Collections.Generic;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Priority
{
    public class PriorityModel:IPriorityModel
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
        public PriorityModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Priority details in view
        /// </summary>
        /// <param name="objPrioritymaster"></param>
        /// <returns></returns>
        public MessageEF Add(Prioritymaster objPrioritymaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Priority/Add", JsonConvert.SerializeObject(objPrioritymaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Priority details in view
        /// </summary>
        /// <param name="objPrioritymaster"></param>
        /// <returns></returns>
        public MessageEF Update(Prioritymaster objPrioritymaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Priority/Update", JsonConvert.SerializeObject(objPrioritymaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Priority details in view
        /// </summary>
        /// <param name="objPrioritymaster"></param>
        /// <returns></returns>
        public List<Prioritymaster> View(Prioritymaster objPrioritymaster)
        {
            try
            {
                List<Prioritymaster> objlistPrioritymaster = new List<Prioritymaster>();
                objlistPrioritymaster = JsonConvert.DeserializeObject<List<Prioritymaster>>(_objIHttpWebClients.PostRequest("Priority/View", JsonConvert.SerializeObject(objPrioritymaster)));
                return objlistPrioritymaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete Priority details in view
        /// </summary>
        /// <param name="objPrioritymaster"></param>
        /// <returns></returns>
        public MessageEF Delete(Prioritymaster objPrioritymaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Priority/Delete", JsonConvert.SerializeObject(objPrioritymaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit Priority details in view
        /// </summary>
        /// <param name="objPrioritymaster"></param>
        /// <returns></returns>
        public Prioritymaster Edit(Prioritymaster objPrioritymaster)
        {
            try
            {
                objPrioritymaster = JsonConvert.DeserializeObject<Prioritymaster>(_objIHttpWebClients.PostRequest("Priority/Edit", JsonConvert.SerializeObject(objPrioritymaster)));
                return objPrioritymaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
