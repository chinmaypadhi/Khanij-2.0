// ***********************************************************************
//  Controller Name          : CompanyController
//  Description              : Add,View,Edit,Update,Delete LeaseType details
//  Created By               : Lingaraj Dalai
//  Created On               : 08 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.LeaseType;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LeaseTypeController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public ILeaseTypeProvider _objILeaseTypeProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objILeaseTypeProvider"></param>
        public LeaseTypeController(ILeaseTypeProvider objILeaseTypeProvider)
        {
            _objILeaseTypeProvider = objILeaseTypeProvider;
        }
        /// <summary>
        /// Add LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(LeaseTypeMaster objLeaseType)
        {
            return _objILeaseTypeProvider.AddLeaseType(objLeaseType);
        }
        /// <summary>
        /// View LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        [HttpPost]
        public List<LeaseTypeMaster> View(LeaseTypeMaster objLeaseType)
        {
            return _objILeaseTypeProvider.ViewLeaseType(objLeaseType);
        }
        /// <summary>
        /// Edit LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        [HttpPost]
        public LeaseTypeMaster Edit(LeaseTypeMaster objLeaseType)
        {
            return _objILeaseTypeProvider.EditLeaseType(objLeaseType);
        }
        /// <summary>
        /// Delete LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(LeaseTypeMaster objLeaseType)
        {
            return _objILeaseTypeProvider.DeleteLeaseType(objLeaseType);
        }
        /// <summary>
        /// Update LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(LeaseTypeMaster objLeaseType)
        {
            return _objILeaseTypeProvider.UpdateLeaseType(objLeaseType);
        }
    }
}