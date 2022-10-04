using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Model.VTDVendor;

namespace userregistrationEFApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class VTDVendorRegController : ControllerBase
    {
        private readonly IVTDVendorProvider vTDVendorProvider;

        public VTDVendorRegController(IVTDVendorProvider vTDVendorProvider)
        {
            this.vTDVendorProvider = vTDVendorProvider;
        }

        #region For VTD Vendor Registration
        /// <summary>
        /// Add VTD Vendor
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddVTDVendor(VTDVendorModel vTDVendorModel)
        {
            return await vTDVendorProvider.AddVTDVendor(vTDVendorModel);
        }

        /// <summary>
        /// Get VTD User Details By UserId
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<VTDVendorModel> GetVTDUserDetailsByUserId(VTDVendorModel vTDVendorModel)
        {
            return await vTDVendorProvider.GetVTDUserDetailsByUserId(vTDVendorModel);
        }

        /// <summary>
        /// Get State Details
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<CommonAddressDetails>> GetStateDetails(CommonAddressDetails commonAddressDetails)
        {
            return await vTDVendorProvider.GetStateDetails(commonAddressDetails);
        }

        /// <summary>
        /// Get District Details By StateId
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<CommonAddressDetails>> GetDistrictDetailsByStateId(CommonAddressDetails commonAddressDetails)
        {
            return await vTDVendorProvider.GetDistrictDetailsByStateId(commonAddressDetails);
        }

        /// <summary>
        /// Get Block Details By DistrictId
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<CommonAddressDetails>> GetBlockDetailsByDistrictId(CommonAddressDetails commonAddressDetails)
        {
            return await vTDVendorProvider.GetBlockDetailsByDistrictId(commonAddressDetails);
        }

        /// <summary>
        /// View VTD All Request
        /// </summary>
        /// <param name="messageEF"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<VTDVendorModel>> ViewVTDAllRequest(MessageEF messageEF)
        {
            return await vTDVendorProvider.ViewVTDAllRequest(messageEF);
        }

        /// <summary>
        /// Get VTD New Request Details
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        public async Task<VTDVendorModel> GetVTDNewRequestDetails(VTDVendorModel vTDVendorModel)
        {
            return await vTDVendorProvider.GetVTDNewRequestDetails(vTDVendorModel);
        }

        /// <summary>
        /// Approve End User
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<MessageEF> ApproveVTDUser(VTDVendorModel vTDVendorModel)
        {
            return await vTDVendorProvider.ApproveVTDUser(vTDVendorModel);
        }

        /// <summary>
        /// Reject End User
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<MessageEF> RejectVTDUser(VTDVendorModel vTDVendorModel)
        {
            return await vTDVendorProvider.RejectVTDUser(vTDVendorModel);
        }

        /// <summary>
        /// Action Taken Request
        /// </summary>
        /// <param name="OBJEU"></param>
        /// <returns></returns>
        public async Task<List<ForceFullDataVTDUser>> VTDActionTakenRequest(VTDVendorModel vTDVendorModel)
        {
            return await vTDVendorProvider.VTDActionTakenRequest(vTDVendorModel);
        }

        /// <summary>
        /// VTD User DataView
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        public async Task<VTDVendorModel> VTDUserDataView(VTDVendorModel vTDVendorModel)
        {
            return await vTDVendorProvider.VTDUserDataView(vTDVendorModel);
        }
        #endregion

        #region For VTD Vendor View,Update Profile
        /// <summary>
        /// View,Update VTD Vendor Profile details
        /// </summary>
        /// <param name="objVTDVendorProfileModel"></param>
        /// <returns></returns>
        public async Task<Result<VTDVendorProfileModel>> VTDUserProfileDataView(VTDVendorProfileModel objVTDVendorProfileModel)
        {
            return await vTDVendorProvider.VTDUserProfileDataView(objVTDVendorProfileModel);
        }
        /// <summary>
        /// Edit VTD Vendor Profile details
        /// </summary>
        /// <param name="objVTDVendorProfileModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateVTDVendor(VTDVendorProfileModel objVTDVendorProfileModel)
        {
            return await vTDVendorProvider.UpdateVTDVendor(objVTDVendorProfileModel);
        }
        [HttpPost]
        public async Task<MessageEF> VerifyMobileOnUpdate(TransporterModel transporterModel)
        {
            return await vTDVendorProvider.CheckMobileNoOnUpdate(transporterModel);
        }
        [HttpPost]
        public async Task<MessageEF> OTPDetailsOnUpdate(TransporterModel transporterModel)
        {
            return await vTDVendorProvider.GetOTPOnUpdate(transporterModel);
        }
        #endregion
    }
}
