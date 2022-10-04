using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationApp.Areas.Contractor.Models.TailingDam
{
    public interface ITailingDamModel
    {
        List<CompanyDetails> GetCompanyList(CompanyDetails companyDetails);
        List<CommonAddressDetails> GetStateDistrictList(CommonAddressDetails commonAddressDetails);
        List<CommonAddressDetails> GetTehsilListByDistrictID(CommonAddressDetails commonAddressDetails);
        List<CommonAddressDetails> GetvillageFromTehsilID(CommonAddressDetails commonAddressDetails);
        List<TypeOfSite> GetTypeOfSiteList(MessageEF messageEF);
        List<MineralType> GetMineralTypeList_TailingDam(MineralType mineralType);
        List<MineralDetails> GetCascadeMineral(MineralDetails mineralDetails);
        List<MineralDetails> GetCascadeMineralNature(MineralDetails mineralDetails);
        List<MineralDetails> GetCascadeMineralGrade(MineralDetails mineralDetails);
        MessageEF AddTailingDam(cls_TailingDam tailingDam);
        #region Update Tailing dam profile details
        cls_TailingDam GetProfileDetails(cls_TailingDam objcls_TailingDam);
        MessageEF UpdateTailingDam(cls_TailingDam objcls_TailingDam);
        #endregion
        #region Update Royalty details of Lessee/Licensee users
        MessageEF UpdateRoyaltyPay(cls_TailingDam objcls_TailingDam);
        #endregion
        #region Existing User Details
        cls_TailingDam GetExistingUserDetails(cls_TailingDam objcls_TailingDam);
        #endregion
        #region DD View/Approve Tailing Dam details
        /// <summary>
        /// Get TailingDumpDDApprove
        /// </summary>
        /// <param name="objTailingDumpDDApprove"></param>
        /// <returns></returns>
        List<cls_TailingDam> ViewTailingDumpDDApprove(cls_TailingDam objTailingDumpDDApprove);
        /// <summary>
        /// Approve Tailing dam details by DD
        /// </summary>
        /// <param name="objcls_TailingDam"></param>
        /// <returns></returns>
        MessageEF TailingDumpDDApprove(cls_TailingDam objcls_TailingDam);
        #endregion
    }
}
