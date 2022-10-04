using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MineralConcessionEF;
using MineralConcessionApp.Models.Utility;

namespace MineralConcessionApp.Models.LesseeProfile
{
    public class Lesseprofile : ILesseprofile
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIHttpWebClients"></param>
        public Lesseprofile(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Bind CompMaster data list details in view
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public List<LeaseApplicationModel> GetCompMasterData(LeaseApplicationModel objPaymentTypemaster)
        {
            List<LeaseApplicationModel> objticket = new List<LeaseApplicationModel>();
            try
            {
                objticket = JsonConvert.DeserializeObject<List<LeaseApplicationModel>>(_objIHttpWebClients.PostRequest("Lesseeprofile/GetCompMasterData", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objticket;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Submit Lesseprofile details in view
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public MessageEF Add(LeaseApplicationModel objPaymentTypemaster)
        {
            string _result = "";
            try
            {
                MessageEF objMessageEF = new MessageEF();

                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Lesseeprofile/Add", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Lessee details data for edit
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public LeaseApplicationModel GetlesseEditdata (LeaseApplicationModel objPaymentTypemaster)
        {

            PreferredBidder objpreferred = new PreferredBidder();
            try
            {

                objPaymentTypemaster = JsonConvert.DeserializeObject<LeaseApplicationModel>(_objIHttpWebClients.PostRequest("Lesseeprofile/GetlesseEditdata", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objPaymentTypemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
