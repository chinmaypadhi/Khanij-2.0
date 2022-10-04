using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Model.ContractorBuilder;

namespace userregistrationEFApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class ContractorBuilderController : ControllerBase
    {
        private readonly IContractorBuilderProvider contractorBuilderProvider;

        public ContractorBuilderController(IContractorBuilderProvider contractorBuilderProvider)
        {
            this.contractorBuilderProvider = contractorBuilderProvider;
        }

        /// <summary>
        /// Add Contractor Builder
        /// </summary>
        /// <param name="contractorBuilderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddContractorBuilder(ContractorBuilderModel contractorBuilderModel)
        {
            return await contractorBuilderProvider.AddContractorBuilder(contractorBuilderModel);
        }
        /// <summary>
        /// Add Contractor Builder
        /// </summary>
        /// <param name="contractorBuilderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> EditContractorBuilder(ContractorBuilderModel contractorBuilderModel)
        {
            return await contractorBuilderProvider.EditContractorBuilder(contractorBuilderModel);
        }
        /// <summary>
        /// Get Contractor Builder User Details By UserId
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ContractorBuilderModel> GetContractorBuilderUserDetailsByUserId(ContractorBuilderModel contractorBuilderModel)
        {
            return await contractorBuilderProvider.GetContractorBuilderUserDetailsByUserId(contractorBuilderModel);
        }

        /// <summary>
        /// Edit Contractor Builder
        /// </summary>
        /// <param name="contractorBuilderModel"></param>
        /// <returns></returns>
        //[HttpPost]
        //public async Task<MessageEF> EditContractorBuilder(ContractorBuilderModel contractorBuilderModel)
        //{
        //    return await contractorBuilderProvider.EditContractorBuilder(contractorBuilderModel);
        //}
    }
}
