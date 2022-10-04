// ***********************************************************************
//  Controller Name          : CriticalityController
//  Description              : Add,View,Edit,Update,Delete Criticality details
//  Created By               : Akshaya Dalei
//  Created On               : 15 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.CriticalityMasters;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class CriticalityController : Controller
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        private readonly ICriticalityMasterProvider criticalityMasterProvider;

        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objICompanyProvider"></param>
        #region Constructor
        public CriticalityController(ICriticalityMasterProvider criticalityMasterProvider)
        {
            this.criticalityMasterProvider = criticalityMasterProvider;
        }
        #endregion
        /// <summary>
        /// Add Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        #region Add
        [HttpPost]
        public MessageEF Add(CriticalityMaster criticalityMaster)
        {
            return criticalityMasterProvider.AddCriticalityMaster(criticalityMaster);
        }
        #endregion
        /// <summary>
        /// View Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        #region View
        [HttpPost]
        public List<CriticalityMaster> ViewDetails(CriticalityMaster criticalityMaster)
        {
            return criticalityMasterProvider.ViewCriticalityMaster(criticalityMaster);
        }
        #endregion
        /// <summary>
        /// Edit Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        #region Edit
        [HttpPost]
        public CriticalityMaster Edit(CriticalityMaster criticalityMaster)
        {
            return criticalityMasterProvider.EditCriticalityMaster(criticalityMaster);
        }
        #endregion
        /// <summary>
        /// Delete Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        #region Delete
        [HttpPost]
        public MessageEF Delete(CriticalityMaster criticalityMaster)
        {
            return criticalityMasterProvider.DeleteCriticalityMaster(criticalityMaster);
        }
        #endregion
        /// <summary>
        /// Udpate Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        #region Update
        [HttpPost]
        public MessageEF Update(CriticalityMaster criticalityMaster)
        {
            return criticalityMasterProvider.UpdateCriticalityMaster(criticalityMaster);
        }
        #endregion
    }


}