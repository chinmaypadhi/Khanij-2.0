// ***********************************************************************
//  Controller Name          : LicenseeTypeController
//  Description              : Add,View,Edit,Update,Delete Licensee Type details
//  Created By               : Sanjay Kumar
//  Created On               : 08 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.LicenseeType;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LicenseeTypeController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public ILicenseeTypeProvider _objILicenseeTypeProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objILicenseeTypeProvider"></param>
        public LicenseeTypeController(ILicenseeTypeProvider objILicenseeTypeProvider)
        {
            _objILicenseeTypeProvider = objILicenseeTypeProvider;
        }
        /// <summary>
        /// Add Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(LicenseeTypeMaster objLicenseeType)
        {
            return _objILicenseeTypeProvider.AddLicenseeType(objLicenseeType);
        }
        /// <summary>
        /// View Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        [HttpPost]
        public List<LicenseeTypeMaster> View(LicenseeTypeMaster objLicenseeType)
        {
            return _objILicenseeTypeProvider.ViewLicenseeType(objLicenseeType);
        }
        /// <summary>
        /// Edit Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        [HttpPost]
        public LicenseeTypeMaster Edit(LicenseeTypeMaster objLicenseeType)
        {
            return _objILicenseeTypeProvider.EditLicenseeType(objLicenseeType);
        }
        /// <summary>
        /// Delete Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(LicenseeTypeMaster objLicenseeType)
        {
            return _objILicenseeTypeProvider.DeleteLicenseeType(objLicenseeType);
        }
        /// <summary>
        /// Update Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(LicenseeTypeMaster objLicenseeType)
        {
            return _objILicenseeTypeProvider.UpdateLicenseeType(objLicenseeType);
        }
    }
}