using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.VTDVendor
{
    public interface IVTDVendorProvider : IDisposable, IRepository
    {
        #region For VTD Vendor Registration
        Task<MessageEF> AddVTDVendor(VTDVendorModel vTDVendorModel);
        Task<VTDVendorModel> GetVTDUserDetailsByUserId(VTDVendorModel vTDVendorModel);
        Task<List<CommonAddressDetails>> GetStateDetails(CommonAddressDetails commonAddressDetails);
        Task<List<CommonAddressDetails>> GetDistrictDetailsByStateId(CommonAddressDetails commonAddressDetails);
        Task<List<CommonAddressDetails>> GetBlockDetailsByDistrictId(CommonAddressDetails commonAddressDetails);
        Task<List<VTDVendorModel>> ViewVTDAllRequest(MessageEF messageEF);
        Task<VTDVendorModel> GetVTDNewRequestDetails(VTDVendorModel vTDVendorModel);
        Task<MessageEF> ApproveVTDUser(VTDVendorModel vTDVendorModel);
        Task<MessageEF> RejectVTDUser(VTDVendorModel vTDVendorModel);
        Task<List<ForceFullDataVTDUser>> VTDActionTakenRequest(VTDVendorModel vTDVendorModel);
        Task<VTDVendorModel> VTDUserDataView(VTDVendorModel vTDVendorModel);
        #endregion
        #region For VTD Vendor View,Update Profile
        /// <summary>
        /// View,Update VTD Vendor Profile details
        /// </summary>
        /// <param name="objVTDVendorProfileModel"></param>
        /// <returns></returns>
        Task<Result<VTDVendorProfileModel>> VTDUserProfileDataView(VTDVendorProfileModel objVTDVendorProfileModel);
        /// <summary>
        /// Edit VTD Vendor Profile details
        /// </summary>
        /// <param name="objVTDVendorProfileModel"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateVTDVendor(VTDVendorProfileModel objVTDVendorProfileModel);
        Task<MessageEF> CheckMobileNoOnUpdate(TransporterModel transporterModel);
        Task<MessageEF> GetOTPOnUpdate(TransporterModel transporterModel);
        #endregion
    }
}
