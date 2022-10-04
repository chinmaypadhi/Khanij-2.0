using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.StateMaster
{
    public class StateMasterModel: IStateMasterModel
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
        public StateMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add State details in view
        /// </summary>
        /// <param name="objStatemaster"></param>
        /// <returns></returns>
        public MessageEF Add(Statemaster objStatemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("StateMaster/Add", JsonConvert.SerializeObject(objStatemaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update State details in view
        /// </summary>
        /// <param name="objStatemaster"></param>
        /// <returns></returns>
        public MessageEF Update(Statemaster objStatemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("StateMaster/Update", JsonConvert.SerializeObject(objStatemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind State details in view
        /// </summary>
        /// <param name="objStatemaster"></param>
        /// <returns></returns>
        public List<Statemaster> View(Statemaster objStatemaster)
        {
            try
            {
                List<Statemaster> objlistStatemaster = new List<Statemaster>();
                objlistStatemaster = JsonConvert.DeserializeObject<List<Statemaster>>(_objIHttpWebClients.PostRequest("StateMaster/View", JsonConvert.SerializeObject(objStatemaster)));
                return objlistStatemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete State details in view
        /// </summary>
        /// <param name="objStatemaster"></param>
        /// <returns></returns>
        public MessageEF Delete(Statemaster objStatemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("StateMaster/Delete", JsonConvert.SerializeObject(objStatemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit State details in view
        /// </summary>
        /// <param name="objStatemaster"></param>
        /// <returns></returns>
        public Statemaster Edit(Statemaster objStatemaster)
        {
            try
            {
                objStatemaster = JsonConvert.DeserializeObject<Statemaster>(_objIHttpWebClients.PostRequest("StateMaster/Edit", JsonConvert.SerializeObject(objStatemaster)));
                return objStatemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
