using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEFApi.Repository;
using userregistrationEF;
namespace userregistrationEFApi.Model.TailingDam
{
    public interface ITailingDamProvider : IDisposable, IRepository
    {
        Task<MessageEF> AddTailingDam(cls_TailingDam tailingDam);
        Task<List<CompanyDetails>> GetCompanyList(CompanyDetails companyDetails);
        Task<List<CommonAddressDetails>> GetStateDistrictList(CommonAddressDetails commonAddressDetails);
        Task<List<CommonAddressDetails>> GetTehsilListByDistrictID(CommonAddressDetails commonAddressDetails);
        Task<List<CommonAddressDetails>> GetvillageFromTehsilID(CommonAddressDetails commonAddressDetails);
        Task<List<TypeOfSite>> GetTypeOfSiteList(MessageEF messageEF);
        Task<List<MineralType>> GetMineralTypeList_TailingDam(MineralType mineralType);
        Task<List<MineralDetails>> GetCascadeMineral(MineralDetails mineralDetails);
        Task<List<MineralDetails>> GetCascadeMineralNature(MineralDetails mineralDetails);
        Task<List<MineralDetails>> GetCascadeMineralGrade(MineralDetails mineralDetails);
        #region Update Tailing dam profile details
        /// <summary>
        /// Bind Profile details in view
        /// </summary>
        /// <param name="objcls_TailingDam"></param>
        /// <returns></returns>
        Task<cls_TailingDam> GetProfileDetails(cls_TailingDam objcls_TailingDam);
        /// <summary>
        /// Update Tailing dam profile details
        /// </summary>
        /// <param name="tailingDam"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateTailingDam(cls_TailingDam tailingDam);
        #endregion
        #region Update Royalty details of Lessee/Licensee users
        /// <summary>
        /// Update Royalty pay details
        /// </summary>
        /// <param name="tailingDam"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateRoyaltyPay(cls_TailingDam tailingDam);
        #endregion
        #region Existing User Details
        /// <summary>
        /// Get Existing user details in view
        /// </summary>
        /// <param name="objcls_TailingDam"></param>
        /// <returns></returns>
        Task<cls_TailingDam> GetExistingUserDetails(cls_TailingDam objcls_TailingDam);
        #endregion
        #region DD View/Approve Tailing Dam details
        /// <summary>
        /// Get TailingDumpDDApprove
        /// </summary>
        /// <param name="objTailingDumpDDApprove"></param>
        /// <returns></returns>
        Task<IEnumerable<cls_TailingDam>> ViewTailingDumpDDApprove(cls_TailingDam objTailingDumpDDApprove);
        /// <summary>
        /// Approve Tailing dam details by DD
        /// </summary>
        /// <param name="tailingDam"></param>
        /// <returns></returns>
        Task<MessageEF> TailingDumpDDApprove(cls_TailingDam tailingDam);
        #endregion
    }
}
