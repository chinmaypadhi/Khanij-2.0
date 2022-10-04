using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.TransportationMode
{
    public class TransportationModeModel:ITransportationModeModel
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
        public TransportationModeModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Transportation Mode details in view
        /// </summary>
        /// <param name="objTR"></param>
        /// <returns></returns>
        public MessageEF Add(TransportationModeMaster objTR)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("TransportationMode/Add", JsonConvert.SerializeObject(objTR)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Transportation Mode details in view
        /// </summary>
        /// <param name="objTR"></param>
        /// <returns></returns>
        public MessageEF Update(TransportationModeMaster objTR)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("TransportationMode/Update", JsonConvert.SerializeObject(objTR)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Transportation Mode details in view
        /// </summary>
        /// <param name="objTR"></param>
        /// <returns></returns>
        public List<TransportationModeMaster> View(TransportationModeMaster objTR)
        {
            try
            {
                List<TransportationModeMaster> objlistTR = new List<TransportationModeMaster>();
                objlistTR = JsonConvert.DeserializeObject<List<TransportationModeMaster>>(_objIHttpWebClients.PostRequest("TransportationMode/View", JsonConvert.SerializeObject(objTR)));
                return objlistTR;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete Transportation Mode details in view
        /// </summary>
        /// <param name="objTR"></param>
        /// <returns></returns>
        public MessageEF Delete(TransportationModeMaster objTR)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("TransportationMode/Delete", JsonConvert.SerializeObject(objTR)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit Transportation Mode details in view
        /// </summary>
        /// <param name="objTR"></param>
        /// <returns></returns>
        public TransportationModeMaster Edit(TransportationModeMaster objTR)
        {
            try
            {
                objTR = JsonConvert.DeserializeObject<TransportationModeMaster>(_objIHttpWebClients.PostRequest("TransportationMode/Edit", JsonConvert.SerializeObject(objTR)));
                return objTR;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
