// ***********************************************************************
//  Controller Name          : OSUController
//  Description              : Add,View,Edit,Update,Delete OSU details
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Jan 2021
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterApi.Model.OSU;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class OSUController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public IOSUProvider _objIOSUProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objOSUProvider"></param>
        public OSUController(IOSUProvider objOSUProvider)
        {
            _objIOSUProvider = objOSUProvider;
        }
        /// <summary>
        /// Add OSU details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(OSUmaster objOSUmaster)
        {
            return _objIOSUProvider.AddOSUmaster(objOSUmaster);
        }
        /// <summary>
        /// Bind District List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<OSUmaster> GetDistrictList(OSUmaster objOSUmaster)
        {
            return _objIOSUProvider.GetDistrictList(objOSUmaster);
        }
        /// <summary>
        /// Bind User Type List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<OSUmaster> GetUserTypeList(OSUmaster objOSUmaster)
        {
            return _objIOSUProvider.GetUserTypeList(objOSUmaster);
        }
        /// <summary>
        /// Bind Company Type List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<OSUmaster> GetCompanyList(OSUmaster objOSUmaster)
        {
            return _objIOSUProvider.GetCompanyList(objOSUmaster);
        }
        /// <summary>
        /// Bind Lessee Type List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<OSUmaster> GetLesseeTypeList(OSUmaster objOSUmaster)
        {
            return _objIOSUProvider.GetLesseeTypeList(objOSUmaster);
        }
        /// <summary>
        /// Bind Licensee Type List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<OSUmaster> GetLicenseeTypeList(OSUmaster objOSUmaster)
        {
            return _objIOSUProvider.GetLicenseeTypeList(objOSUmaster);
        }
        /// <summary>
        /// Get Change Status List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<OSUmaster> GetChangeStatusList(OSUmaster objOSUmaster)
        {
            return _objIOSUProvider.GetChangeStatusList(objOSUmaster);
        }
        /// <summary>
        /// To Update Encrypt Password
        /// </summary>
        /// <param name="updateEncryptPasswordModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel)
        {
            return await _objIOSUProvider.UpdateEncryptPassword(updateEncryptPasswordModel);
        }
    }
}