using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.Railway;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class RailwayController : ControllerBase
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        private readonly IRailwayProvider railwayProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="railwayProvider"></param>
        public RailwayController(IRailwayProvider railwayProvider)
        {
            this.railwayProvider = railwayProvider;
        }

        #region Add
        /// <summary>
        /// To Add Railway
        /// </summary>
        /// <param name="railwayModel"></param>
        /// <returns></returns>
        public MessageEF Add(RailwayModel railwayModel)
        {
            return railwayProvider.AddRailway(railwayModel);
        }
        #endregion

        #region View
        /// <summary>
        /// To View Railway
        /// </summary>
        /// <param name="railwayModel"></param>
        /// <returns></returns>
        public List<RailwayModel> ViewDetails(RailwayModel railwayModel)
        {
            return railwayProvider.ViewRailway(railwayModel);
        }
        #endregion

        #region Edit
        /// <summary>
        /// To Edit Railway
        /// </summary>
        /// <param name="railwayModel"></param>
        /// <returns></returns>
        public RailwayModel Edit(RailwayModel railwayModel)
        {
            return railwayProvider.EditRailway(railwayModel);
        }
        #endregion

        #region Delete
        /// <summary>
        /// To Delete Railway
        /// </summary>
        /// <param name="railwayModel"></param>
        /// <returns></returns>
        public MessageEF Delete(RailwayModel railwayModel)
        {
            return railwayProvider.DeleteRailway(railwayModel);
        }
        #endregion

        #region Update
        /// <summary>
        /// To Update Railway
        /// </summary>
        /// <param name="railwayModel"></param>
        /// <returns></returns>
        public MessageEF Update(RailwayModel railwayModel)
        {
            return railwayProvider.UpdateRailway(railwayModel);
        }
        #endregion
    }
}