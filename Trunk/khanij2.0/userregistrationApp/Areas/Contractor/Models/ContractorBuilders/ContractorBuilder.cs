using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Areas.Contractor.Models.ContractorBuilders
{
    public class ContractorBuilder:IContractorBuilder
    {
        IHttpWebClients _objIHttpWebClients;
        public ContractorBuilder(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }

        /// <summary>
        /// Add Contractor Builder
        /// </summary>
        /// <param name="contractorBuilderModel"></param>
        /// <returns></returns>
        public MessageEF AddContractorBuilder(ContractorBuilderModel contractorBuilderModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("ContractorBuilder/AddContractorBuilder", JsonConvert.SerializeObject(contractorBuilderModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Update Encrypted Password
        /// </summary>
        /// <param name="updateEncryptPasswordModel"></param>
        /// <returns></returns>
        public MessageEF UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel)
        {
            try
            {

                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseApplication/UpdateEncryptPassword", JsonConvert.SerializeObject(updateEncryptPasswordModel)));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Contractor Builder User Details By UserId
        /// </summary>
        /// <param name="contractorBuilderModel"></param>
        /// <returns></returns>
        public ContractorBuilderModel GetContractorBuilderUserDetailsByUserId(ContractorBuilderModel contractorBuilderModel)
        {
            try
            {

                return JsonConvert.DeserializeObject<ContractorBuilderModel>(_objIHttpWebClients.PostRequest("ContractorBuilder/GetContractorBuilderUserDetailsByUserId", JsonConvert.SerializeObject(contractorBuilderModel)));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
