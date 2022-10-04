using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;
using Newtonsoft.Json;
using PermitApp.Models.Utility;

namespace PermitApp.Models.ValidityExpired
{
    public class ValidityExpiredModel : IValidityExpiredModel
    {
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// View Profile Requests of IBM Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public ValidityExpiredModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public List<ValidityExpiredEF> GetValidityExpiredDetails(ValidityExpiredEF objPermit)
        {
            try
            {
                List<ValidityExpiredEF> objlistNotice = new List<ValidityExpiredEF>();
                objlistNotice = JsonConvert.DeserializeObject<List<ValidityExpiredEF>>(_objIHttpWebClients.PostRequest("ValidityExpired/GetValidityExpiredDetails", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
