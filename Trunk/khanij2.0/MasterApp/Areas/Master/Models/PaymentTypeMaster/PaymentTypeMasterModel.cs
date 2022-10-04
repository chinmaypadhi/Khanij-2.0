using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.PaymentTypeMaster
{
    public class PaymentTypeMasterModel: IPaymentTypeMasterModel
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
        public PaymentTypeMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Payment Type Master details in view
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public MessageEF Add(PaymenttypeMaster objPaymentTypemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentTypeMaster/Add", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Payment Type Master details in view
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public MessageEF Update(PaymenttypeMaster objPaymentTypemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentTypeMaster/Update", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Payment Type Master details in view
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public List<PaymenttypeMaster> View(PaymenttypeMaster objPaymentTypemaster)
        {
            try
            {
                List<PaymenttypeMaster> objlistPaymentTypemaster = new List<PaymenttypeMaster>();
                objlistPaymentTypemaster = JsonConvert.DeserializeObject<List<PaymenttypeMaster>>(_objIHttpWebClients.PostRequest("PaymentTypeMaster/View", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objlistPaymentTypemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete Payment Type Master details in view
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public MessageEF Delete(PaymenttypeMaster objPaymentTypemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentTypeMaster/Delete", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit Payment Type Master details in view
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public PaymenttypeMaster Edit(PaymenttypeMaster objPaymentTypemaster)
        {
            try
            {
                objPaymentTypemaster = JsonConvert.DeserializeObject<PaymenttypeMaster>(_objIHttpWebClients.PostRequest("PaymentTypeMaster/Edit", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objPaymentTypemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
