using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.RailwayZone;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class RailwayZoneController : ControllerBase
    {
        /// <summary>
        /// Global Decalaration
        /// </summary>
        private readonly IRailwayZoneProvider railwayZoneProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="railwayZoneProvider"></param>
        public RailwayZoneController(IRailwayZoneProvider railwayZoneProvider)
        {
            this.railwayZoneProvider = railwayZoneProvider;
        }

        #region Add
        /// <summary>
        /// To Add RailwayZone
        /// </summary>
        /// <param name="railwayZoneModel"></param>
        /// <returns></returns>
        public MessageEF Add(RailwayZoneModel railwayZoneModel)
        {
           return railwayZoneProvider.AddRailwayZone(railwayZoneModel);
        }
        #endregion

        #region View
        /// <summary>
        /// To View RailwayZone
        /// </summary>
        /// <param name="railwayZoneModel"></param>
        /// <returns></returns>
        public List<RailwayZoneModel> ViewDetails(RailwayZoneModel railwayZoneModel)
        {
            return railwayZoneProvider.ViewRailwayZone(railwayZoneModel);
        }
        #endregion

        #region Edit
        /// <summary>
        /// To Edit RailwayZone
        /// </summary>
        /// <param name="railwayZoneModel"></param>
        /// <returns></returns>
        public RailwayZoneModel Edit(RailwayZoneModel railwayZoneModel)
        {
            return railwayZoneProvider.EditRailwayZone(railwayZoneModel);
        }
        #endregion

        #region Delete
        /// <summary>
        /// To Delete RailwayZone
        /// </summary>
        /// <param name="railwayZoneModel"></param>
        /// <returns></returns>
        public MessageEF Delete(RailwayZoneModel railwayZoneModel)
        {
            return railwayZoneProvider.DeleteRailwayZone(railwayZoneModel);
        }
        #endregion

        #region Update RailwayZone
        /// <summary>
        /// To Update 
        /// </summary>
        /// <param name="railwayZoneModel"></param>
        /// <returns></returns>
        public MessageEF Update(RailwayZoneModel railwayZoneModel)
        {
            return railwayZoneProvider.UpdateRailwayZoneModel(railwayZoneModel);
        }
        #endregion

    }
}