// ***********************************************************************
//  Controller Name          : CompanyController
//  Description              : Add,View,Edit,Update,Delete Company details
//  Created By               : Lingaraj Dalai
//  Created On               : 08 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MasterApi.Model.Company;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public ICompanyProvider _objICompanyProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objICompanyProvider"></param>
        public CompanyController(ICompanyProvider objICompanyProvider)
        {
            _objICompanyProvider = objICompanyProvider;
        }
        /// <summary>
        /// Add Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(CompanyMaster objCompanyMaster)
        {
            return _objICompanyProvider.AddCompany(objCompanyMaster);
        }
        /// <summary>
        /// View Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<CompanyMaster> View(CompanyMaster objCompanyMaster)
        {
            return _objICompanyProvider.ViewCompany(objCompanyMaster);
        }
        /// <summary>
        /// Edit Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public CompanyMaster Edit(CompanyMaster objCompanyMaster)
        {
            return _objICompanyProvider.EditCompany(objCompanyMaster);
        }
        /// <summary>
        /// Delete Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(CompanyMaster objCompanyMaster)
        {
            return _objICompanyProvider.DeleteCompany(objCompanyMaster);
        }
        /// <summary>
        /// Update Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(CompanyMaster objCompanyMaster)
        {
            return _objICompanyProvider.UpdateCompnay(objCompanyMaster);
        }
    }
}