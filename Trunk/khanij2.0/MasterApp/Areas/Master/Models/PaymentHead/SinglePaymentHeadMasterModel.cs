using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.PaymentHead
{
    public class SinglePaymentHeadMasterModel : ISinglePaymentHeadMasterModel
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
        public SinglePaymentHeadMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Payment Head Master details in view
        /// </summary>
        /// <param name="singlePaymentHeadModel"></param>
        /// <returns></returns>
        public MessageEF Add(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SinglePaymentHead/Add", JsonConvert.SerializeObject(singlePaymentHeadModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Delete Payment Head Master details in view
        /// </summary>
        /// <param name="singlePaymentHeadModel"></param>
        /// <returns></returns>
        public MessageEF Delete(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SinglePaymentHead/Delete", JsonConvert.SerializeObject(singlePaymentHeadModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind District List details in view
        /// </summary>
        /// <param name="singlePaymentHeadModel"></param>
        /// <returns></returns>
        public List<SinglePaymentHeadModel> District(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            try
            {
                List<SinglePaymentHeadModel> listSinglePaymentHeadModel = new List<SinglePaymentHeadModel>();
                listSinglePaymentHeadModel = JsonConvert.DeserializeObject<List<SinglePaymentHeadModel>>(_objIHttpWebClients.PostRequest("SinglePaymentHead/DistrictDetails", JsonConvert.SerializeObject(singlePaymentHeadModel)));
                return listSinglePaymentHeadModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Edit Payment Head Master details in view
        /// </summary>
        /// <param name="singlePaymentHeadModel"></param>
        /// <returns></returns>
        public SinglePaymentHeadModel Edit(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            try
            {
                singlePaymentHeadModel = JsonConvert.DeserializeObject<SinglePaymentHeadModel>(_objIHttpWebClients.PostRequest("SinglePaymentHead/Edit", JsonConvert.SerializeObject(singlePaymentHeadModel)));
                return singlePaymentHeadModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Payment Head Details in view
        /// </summary>
        /// <param name="singlePaymentHeadModel"></param>
        /// <returns></returns>
        public List<SinglePaymentHeadModel> PaymentHead(SinglePaymentHeadModel singlePaymentHeadModel)
        {

            try
            {
                List<SinglePaymentHeadModel> listSinglePaymentHeadModel = new List<SinglePaymentHeadModel>();
                listSinglePaymentHeadModel = JsonConvert.DeserializeObject<List<SinglePaymentHeadModel>>(_objIHttpWebClients.PostRequest("SinglePaymentHead/HeadDataDetails", JsonConvert.SerializeObject(singlePaymentHeadModel)));
                return listSinglePaymentHeadModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Payment Head Master details in view
        /// </summary>
        /// <param name="singlePaymentHeadModel"></param>
        /// <returns></returns>
        public MessageEF Update(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SinglePaymentHead" +
                    "/Update", JsonConvert.SerializeObject(singlePaymentHeadModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Payment Head Master details in view
        /// </summary>
        /// <param name="singlePaymentHeadModel"></param>
        /// <returns></returns>
        public List<SinglePaymentHeadModel> View(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            try
            {
                List<SinglePaymentHeadModel> listSinglePaymentHeadModel = new List<SinglePaymentHeadModel>();
                listSinglePaymentHeadModel = JsonConvert.DeserializeObject<List<SinglePaymentHeadModel>>(_objIHttpWebClients.PostRequest("SinglePaymentHead/ViewDetails", JsonConvert.SerializeObject(singlePaymentHeadModel)));
                return listSinglePaymentHeadModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
