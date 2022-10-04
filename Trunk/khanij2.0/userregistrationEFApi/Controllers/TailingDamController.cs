using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Model.TailingDam;

namespace userregistrationEFApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class TailingDamController : ControllerBase
    {
        private readonly ITailingDamProvider tailingDamProvider;

        public TailingDamController(ITailingDamProvider tailingDamProvider)
        {
            this.tailingDamProvider = tailingDamProvider;
        }

        /// <summary>
        /// Add TailingDam
        /// </summary>
        /// <param name="tailingDam"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddTailingDam(cls_TailingDam tailingDam)
        {
            return await tailingDamProvider.AddTailingDam(tailingDam);
        }

        /// <summary>
        /// Get Company List
        /// </summary>
        /// <param name="companyDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<CompanyDetails>> GetCompanyList(CompanyDetails companyDetails)
        {
            return await tailingDamProvider.GetCompanyList(companyDetails);
        }

        /// <summary>
        /// Get State District List
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<CommonAddressDetails>> GetStateDistrictList(CommonAddressDetails commonAddressDetails)
        {
            return await tailingDamProvider.GetStateDistrictList(commonAddressDetails);
        }

        /// <summary>
        /// Get Tehsil List By DistrictID
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<CommonAddressDetails>> GetTehsilListByDistrictID(CommonAddressDetails commonAddressDetails)
        {
            return await tailingDamProvider.GetTehsilListByDistrictID(commonAddressDetails);
        }

        /// <summary>
        /// Get village From TehsilID
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<CommonAddressDetails>> GetvillageFromTehsilID(CommonAddressDetails commonAddressDetails)
        {
            return await tailingDamProvider.GetvillageFromTehsilID(commonAddressDetails);
        }

        /// <summary>
        /// Get Type Of Site List
        /// </summary>
        /// <param name="messageEF"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<TypeOfSite>> GetTypeOfSiteList(MessageEF messageEF)
        {
            return await tailingDamProvider.GetTypeOfSiteList(messageEF);
        }

        /// <summary>
        /// Get MineralType List_TailingDam
        /// </summary>
        /// <param name="mineralType"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MineralType>> GetMineralTypeList_TailingDam(MineralType mineralType)
        {
            return await tailingDamProvider.GetMineralTypeList_TailingDam(mineralType);
        }

        /// <summary>
        /// Get Mineral Name By MineralTypeId
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MineralDetails>> GetCascadeMineral(MineralDetails mineralDetails)
        {
            return await tailingDamProvider.GetCascadeMineral(mineralDetails);
        }

        /// <summary>
        /// Get Cascade MineralNature
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MineralDetails>> GetCascadeMineralNature(MineralDetails mineralDetails)
        {
            return await tailingDamProvider.GetCascadeMineralNature(mineralDetails);
        }

        /// <summary>
        /// Get Cascade MineralGrade
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MineralDetails>> GetCascadeMineralGrade(MineralDetails mineralDetails)
        {
            return await tailingDamProvider.GetCascadeMineralGrade(mineralDetails);
        }
        #region Update Tailing dam profile details
        /// <summary>
        /// Update TailingDam
        /// </summary>
        /// <param name="tailingDam"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateTailingDam(cls_TailingDam tailingDam)
        {
            return await tailingDamProvider.UpdateTailingDam(tailingDam);
        }
        /// <summary>
        /// Bind Profile details in view
        /// </summary>
        /// <param name="objcls_TailingDam"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<cls_TailingDam> GetProfileDetails(cls_TailingDam objcls_TailingDam)
        {
            return await tailingDamProvider.GetProfileDetails(objcls_TailingDam);
        }
        #endregion
        
        #region Update Royalty details of Lessee/Licensee users
        /// <summary>
        /// Update Royalty pay details
        /// </summary>
        /// <param name="tailingDam"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateRoyaltyPay(cls_TailingDam tailingDam)
        {
            return await tailingDamProvider.UpdateRoyaltyPay(tailingDam);
        }
        #endregion
        
        #region Existing User Details
        /// <summary>
        /// Get Existing user details in view
        /// </summary>
        /// <param name="objcls_TailingDam"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<cls_TailingDam> GetExistingUserDetails(cls_TailingDam objcls_TailingDam)
        {
            return await tailingDamProvider.GetExistingUserDetails(objcls_TailingDam);
        }
        #endregion
        #region DD View/Approve Tailing Dam details
        /// <summary>
        /// Get TailingDumpDDApprove
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<IEnumerable<cls_TailingDam>> View(cls_TailingDam objTailingDamDDApprove)
        {
            return tailingDamProvider.ViewTailingDumpDDApprove(objTailingDamDDApprove);
        }
        /// <summary>
        /// Approve Tailing dam details by DD
        /// </summary>
        /// <param name="tailingDam"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> TailingDumpDDApprove(cls_TailingDam tailingDam)
        {
            return await tailingDamProvider.TailingDumpDDApprove(tailingDam);
        }
        #endregion
    }
}
