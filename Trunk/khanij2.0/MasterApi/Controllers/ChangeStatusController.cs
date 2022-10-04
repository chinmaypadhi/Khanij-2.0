// ***********************************************************************
//  Controller Name          : ChangeStatusController
//  Description              : Add,View,Edit,Update,Delete Change Status details
//  Created By               : Lingaraj Dalai
//  Created On               : 29 Jan 2021
// ***********************************************************************
using System.Collections.Generic;
using MasterApi.Model.ChangeStatus;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class ChangeStatusController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public IChangeStatusProvider _objIChangeStatusProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objICompanyProvider"></param>
        public ChangeStatusController(IChangeStatusProvider objChangeStatusProvider)
        {
            _objIChangeStatusProvider = objChangeStatusProvider;
        }
        /// <summary>
        /// Add Change Status details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(ChangeStatusmaster objChangeStatusmaster)
        {
            return _objIChangeStatusProvider.AddChangeStatusmaster(objChangeStatusmaster);
        }
        /// <summary>
        /// Bind District details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<ChangeStatusmaster> GetDistrictList(ChangeStatusmaster objChangeStatusmaster)
        {
            return _objIChangeStatusProvider.GetDistrictList(objChangeStatusmaster);
        }
        /// <summary>
        /// Bind Division details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<ChangeStatusmaster> GetDivisionList(ChangeStatusmaster objChangeStatusmaster)
        {
            return _objIChangeStatusProvider.GetDivisionList(objChangeStatusmaster);
        }
        /// <summary>
        /// Bind User Type list details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<ChangeStatusmaster> GetUserTypeList(ChangeStatusmaster objChangeStatusmaster)
        {
            return _objIChangeStatusProvider.GetUserTypeList(objChangeStatusmaster);
        }
        /// <summary>
        /// Bind User Name List details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<ChangeStatusmaster> GetUserNameList(ChangeStatusmaster objChangeStatusmaster)
        {
            return _objIChangeStatusProvider.GetUserNameList(objChangeStatusmaster);
        }
        /// <summary>
        /// Bind Change Status List details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<ChangeStatusmaster> GetChangeStatusList(ChangeStatusmaster objChangeStatusmaster)
        {
            return _objIChangeStatusProvider.GetChangeStatusList(objChangeStatusmaster);
        }
        /// <summary>
        /// Bind Current Status List details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public ChangeStatusmaster GetCurrentStatusList(ChangeStatusmaster objChangeStatusmaster)
        {
            return _objIChangeStatusProvider.GetCurrentStatusList(objChangeStatusmaster);
        }
    }
}