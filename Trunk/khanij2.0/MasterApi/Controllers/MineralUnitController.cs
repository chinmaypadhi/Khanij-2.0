// ***********************************************************************
//  Controller Name          : MineralUnitController
//  Description              : Add,View,Edit,Update,Delete Mineral Unit details
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Jan 2021
// ***********************************************************************
using System.Collections.Generic;
using MasterApi.Model.MineralUnit;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class MineralUnitController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public IMineralUnitProvider _objIMineralUnitProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objPriorityProvider"></param>
        public MineralUnitController(IMineralUnitProvider objPriorityProvider)
        {
            _objIMineralUnitProvider = objPriorityProvider;
        }
        /// <summary>
        /// Add Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(MineralUnitmaster objMineralUnitmaster)
        {
            return _objIMineralUnitProvider.AddMineralUnitMaster(objMineralUnitmaster);
        }
        /// <summary>
        /// View Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<MineralUnitmaster> View(MineralUnitmaster objMineralUnitmaster)
        {
            return _objIMineralUnitProvider.ViewMineralUnitMaster(objMineralUnitmaster);
        }
        /// <summary>
        /// Edit Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MineralUnitmaster Edit(MineralUnitmaster objMineralUnitmaster)
        {
            return _objIMineralUnitProvider.EditMineralUnitMaster(objMineralUnitmaster);
        }
        /// <summary>
        /// Delete Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(MineralUnitmaster objMineralUnitmaster)
        {
            return _objIMineralUnitProvider.DeleteMineralUnitMaster(objMineralUnitmaster);
        }
        /// <summary>
        /// Update Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(MineralUnitmaster objMineralUnitmaster)
        {
            return _objIMineralUnitProvider.UpdateMineralUnitMaster(objMineralUnitmaster);
        }
        /// <summary>
        /// View Lessee Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<MineralUnitmaster> ViewLesseeUnit(MineralUnitmaster objMineralUnitmaster)
        {
            return _objIMineralUnitProvider.ViewLesseeMineralUnitMaster(objMineralUnitmaster);
        }
    }
}