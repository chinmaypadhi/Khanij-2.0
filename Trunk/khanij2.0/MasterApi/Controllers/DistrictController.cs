// ***********************************************************************
//  Controller Name          : DesignationController
//  Description              : Add,View,Edit,Update,Delete District details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.District;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controlle}/{action}")]
    [ApiController]
    [Authorize]
    public class DistrictController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        private readonly IDistrictProvider districtProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="districtProvider"></param>
        #region Constructor
        public DistrictController(IDistrictProvider districtProvider)
        {
            this.districtProvider = districtProvider;
        }
        #endregion
        /// <summary>
        /// Add District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        #region Add
        [HttpPost]
        public MessageEF Add(DistrictModel districtModel)
        {
            return districtProvider.AddDistrict(districtModel);
        }
        #endregion
        /// <summary>
        /// View District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        #region View
        [HttpPost]
        public List<DistrictModel> ViewDetails(DistrictModel districtModel)
        {
            return districtProvider.ViewDistrict(districtModel);
        }
        #endregion
        /// <summary>
        /// Edit District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        #region Edit
        [HttpPost]
        public DistrictModel Edit(DistrictModel districtModel)
        {
            return districtProvider.EditDistrict(districtModel);
        }
        #endregion
        /// <summary>
        /// Delete District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        #region Delete 
        [HttpPost]
        public MessageEF Delete(DistrictModel districtModel)
        {
            return districtProvider.DeleteDistrict(districtModel);
        }
        #endregion
        /// <summary>
        /// Update District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        #region Update
        [HttpPost]
        public MessageEF Update(DistrictModel districtModel)
        {
            return districtProvider.UpdateDistrict(districtModel);
        }
        #endregion
    }
}