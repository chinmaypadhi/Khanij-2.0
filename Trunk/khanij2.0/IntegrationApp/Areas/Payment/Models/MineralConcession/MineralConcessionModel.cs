using IntegrationApp.Models.Utility;
using IntegrationEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApp.Areas.Payment.Models.MineralConcession
{
    public class MineralConcessionModel:IMineralConcessionModel
    {
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIHttpWebClients"></param>
        public MineralConcessionModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Added by suroj 12-may-2021 to load first installment page
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public LeaseApplicationModel GetFirstinstallment(LeaseApplicationModel objPaymentTypemaster)
        {
            try
            {
                objPaymentTypemaster = JsonConvert.DeserializeObject<LeaseApplicationModel>(_objIHttpWebClients.PostRequest("MinorMineral/GetFirstinstallment", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objPaymentTypemaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddPayment(LeaseApplicationModel objPaymentTypemaster)
        {
            string _result = "";
            try
            {
                MessageEF objMessageEF = new MessageEF();

                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MinorMineral/AddPayment", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
