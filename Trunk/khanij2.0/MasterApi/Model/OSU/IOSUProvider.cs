// ***********************************************************************
//  Interface Name           : IOSUProvider
//  Description              : Add,View,Edit,Update,Delete OSU details
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Jan 2021
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterApi.Model.OSU
{
    public interface IOSUProvider
    {
        /// <summary>
        /// Add OSU details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        MessageEF AddOSUmaster(OSUmaster objOSUmaster);
        /// <summary>
        /// Bind District List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        List<OSUmaster> GetDistrictList(OSUmaster objOSUmaster);
        /// <summary>
        /// Bind User Type List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        List<OSUmaster> GetUserTypeList(OSUmaster objOSUmaster);
        /// <summary>
        /// Bind Company Type List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        List<OSUmaster> GetCompanyList(OSUmaster objOSUmaster);
        /// <summary>
        /// Bind Lessee Type List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        List<OSUmaster> GetLesseeTypeList(OSUmaster objOSUmaster);
        /// <summary>
        /// Bind Licensee Type List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        List<OSUmaster> GetLicenseeTypeList(OSUmaster objOSUmaster);
        /// <summary>
        /// Get Change Status List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        List<OSUmaster> GetChangeStatusList(OSUmaster objOSUmaster);
        /// <summary>
        /// To Update Encrypt Password
        /// </summary>
        /// <param name="updateEncryptPasswordModel"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel);

    }
}
