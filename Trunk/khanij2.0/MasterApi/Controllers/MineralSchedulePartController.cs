// ***********************************************************************
//  Controller Name          : MineralFormController
//  Description              : Add,View,Edit,Update,Delete Mineral Schedule Part details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.MineralSchedulePart;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class MineralSchedulePartController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        private readonly IMineralSchedulePartProvider mineralSchedulePartProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="mineralSchedulePartProvider"></param>
        public MineralSchedulePartController(IMineralSchedulePartProvider mineralSchedulePartProvider)
        {
            this.mineralSchedulePartProvider = mineralSchedulePartProvider;
        }
        /// <summary>
        /// Add Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        #region Add
        public MessageEF Add(MineralSchedulePartModel mineralSchedulePartModel)
        {
           return mineralSchedulePartProvider.AddMineralSchedulePart(mineralSchedulePartModel);
        }
        #endregion
        /// <summary>
        /// View Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        #region View
        public List<MineralSchedulePartModel> ViewDetails(MineralSchedulePartModel mineralSchedulePartModel)
        {
            return mineralSchedulePartProvider.ViewMineralSchedulePart(mineralSchedulePartModel);
        }
        #endregion
        /// <summary>
        /// Edit Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        #region Edit
        public MineralSchedulePartModel Edit(MineralSchedulePartModel mineralSchedulePartModel)
        {
            return mineralSchedulePartProvider.EditMineralSchedulePart(mineralSchedulePartModel);
        }
        #endregion
        /// <summary>
        /// Delete Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        #region Delete
        public MessageEF Delete(MineralSchedulePartModel mineralSchedulePartModel)
        {
            return mineralSchedulePartProvider.DeleteMineralSchedulePart(mineralSchedulePartModel);
        }
        #endregion
        /// <summary>
        /// Update Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        #region Update
        public MessageEF Update(MineralSchedulePartModel mineralSchedulePartModel)
        {
            return mineralSchedulePartProvider.UpdateMineralSchedulePart(mineralSchedulePartModel);
        }
        #endregion
    }
}