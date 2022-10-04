using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationApp.Areas.Contractor.Models.VTDVendor
{
    public interface IVTDVendor
    {
        #region For VTD Vendor Registration
        MessageEF AddVTDVendor(VTDVendorModel vTDVendorModel);
        VTDVendorModel GetVTDUserDetailsByUserId(VTDVendorModel vTDVendorModel);
        MessageEF UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel);
        List<CommonAddressDetails> GetStateDetails(CommonAddressDetails commonAddressDetails);
        List<CommonAddressDetails> GetDistrictDetailsByStateId(CommonAddressDetails commonAddressDetails);
        List<CommonAddressDetails> GetBlockDetailsByDistrictId(CommonAddressDetails commonAddressDetails);
        List<VTDVendorModel> ViewVTDAllRequest(MessageEF messageEF);
        VTDVendorModel GetVTDNewRequestDetails(VTDVendorModel vTDVendorModel);
        MessageEF ApproveVTDUser(VTDVendorModel vTDVendorModel);
        MessageEF RejectVTDUser(VTDVendorModel vTDVendorModel);
        List<ForceFullDataVTDUser> VTDActionTakenRequest(VTDVendorModel vTDVendorModel);
        VTDVendorModel VTDUserDataView(VTDVendorModel vTDVendorModel);
        #endregion

        #region For VTD Vendor View,Update Profile
        /// <summary>
        /// View,Update VTD Vendor Profile details
        /// </summary>
        /// <param name="objVTDVendorProfileModel"></param>
        /// <returns></returns>
        VTDVendorProfileModel VTDUserProfileDataView(VTDVendorProfileModel objVTDVendorProfileModel);
        /// <summary>
        /// Edit VTD Vendor Profile details
        /// </summary>
        /// <param name="objVTDVendorProfileModel"></param>
        /// <returns></returns>
        MessageEF UpdateVTDVendor(VTDVendorProfileModel objVTDVendorProfileModel);
        #endregion
    }
}
