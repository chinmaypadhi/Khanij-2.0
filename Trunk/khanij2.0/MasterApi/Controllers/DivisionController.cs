// ***********************************************************************
//  Controller Name          : CompanyController
//  Description              : Add,View,Edit,Update,Delete Division details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.Division;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class DivisionController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        private readonly IDivisionProvider divisionProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="divisionProvider"></param>
        #region Constructor
        public DivisionController(IDivisionProvider divisionProvider)
        {
            this.divisionProvider = divisionProvider;
        }
        #endregion
        /// <summary>
        /// Add Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        #region Add
        [HttpPost]
        public MessageEF Add(RegionalModel regionalModel)
        {
            return divisionProvider.AddDivision(regionalModel);
        }
        #endregion
        /// <summary>
        /// View Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        #region View
        [HttpPost]
        public List<RegionalModel> ViewDetails(RegionalModel regionalModel)
        {
            return divisionProvider.ViewDivision(regionalModel);
        }
        #endregion
        /// <summary>
        /// edit Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        #region Edit
        [HttpPost]
        public RegionalModel Edit(RegionalModel regionalModel)
        {
            return divisionProvider.EditDivision(regionalModel);
        }
        #endregion
        /// <summary>
        /// Delete Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        #region Delete 
        [HttpPost]
        public MessageEF Delete(RegionalModel regionalModel)
        {
            return divisionProvider.DeleteDivision(regionalModel);
        }
        #endregion
        /// <summary>
        /// Update Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        #region Update
        [HttpPost]
        public MessageEF Update(RegionalModel regionalModel)
        {
            return divisionProvider.UpdateDivision(regionalModel);
        }
        #endregion
    }
}