using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Rule
{
    public class RuleMasterModel: IRuleMasterModel
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
        public RuleMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Rule details in view
        /// </summary>
        /// <param name="objRulemaster"></param>
        /// <returns></returns>
        public MessageEF Add(RuleMaster objRulemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("RuleMaster/Add", JsonConvert.SerializeObject(objRulemaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Rule details in view
        /// </summary>
        /// <param name="objRulemaster"></param>
        /// <returns></returns>
        public MessageEF Update(RuleMaster objRulemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("RuleMaster/Update", JsonConvert.SerializeObject(objRulemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Rule details in view
        /// </summary>
        /// <param name="objRulemaster"></param>
        /// <returns></returns>
        public List<RuleMaster> View(RuleMaster objRulemaster)
        {
            try
            {
                List<RuleMaster> objlistRuleMaster = new List<RuleMaster>();
                objlistRuleMaster = JsonConvert.DeserializeObject<List<RuleMaster>>(_objIHttpWebClients.PostRequest("RuleMaster/View", JsonConvert.SerializeObject(objRulemaster)));
                return objlistRuleMaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete Rule details in view
        /// </summary>
        /// <param name="objRulemaster"></param>
        /// <returns></returns>
        public MessageEF Delete(RuleMaster objRulemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("RuleMaster/Delete", JsonConvert.SerializeObject(objRulemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit Rule details in view
        /// </summary>
        /// <param name="objRulemaster"></param>
        /// <returns></returns>
        public RuleMaster Edit(RuleMaster objRulemaster)
        {
            try
            {
                objRulemaster = JsonConvert.DeserializeObject<RuleMaster>(_objIHttpWebClients.PostRequest("RuleMaster/Edit", JsonConvert.SerializeObject(objRulemaster)));
                return objRulemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
