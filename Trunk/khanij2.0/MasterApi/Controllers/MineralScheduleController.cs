// ***********************************************************************
//  Controller Name          : MineralFormController
//  Description              : Add,View,Edit,Update,Delete Mineral Schedule details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.MineralSchedule;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class MineralScheduleController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        private readonly IMineralScheduleProvider mineralScheduleProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="mineralScheduleProvider"></param>
        public MineralScheduleController(IMineralScheduleProvider mineralScheduleProvider)
        {
            this.mineralScheduleProvider = mineralScheduleProvider;
        }
        /// <summary>
        /// Add Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        #region Add
        public MessageEF Add(MineralScheduleModel mineralScheduleModel)
        {
            return mineralScheduleProvider.AddMineralSchedule(mineralScheduleModel);
        }
        #endregion
        /// <summary>
        /// View Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        #region View
        public List<MineralScheduleModel> ViewDetails(MineralScheduleModel mineralScheduleModel)
        {
            return mineralScheduleProvider.ViewMineralSchedule(mineralScheduleModel);
        }
        #endregion
        /// <summary>
        /// Edit Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        #region Edit
        public MineralScheduleModel Edit(MineralScheduleModel mineralScheduleModel)
        {
            return mineralScheduleProvider.EditMineralSchedule(mineralScheduleModel);
        }
        #endregion
        /// <summary>
        /// Delete Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        #region Delete
        public MessageEF Delete(MineralScheduleModel mineralScheduleModel)
        {
            return mineralScheduleProvider.DeleteMineralSchedule(mineralScheduleModel);
        }
        #endregion
        /// <summary>
        /// Update Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        #region Update
        public MessageEF Update(MineralScheduleModel mineralScheduleModel)
        {
            return mineralScheduleProvider.UpdateMineralSchedule(mineralScheduleModel);
        }
        #endregion
    }
}