// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 18-Jan-2021
// ***********************************************************************
using System.Collections.Generic;
using MasterApi.Model.Route;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class RouteController : ControllerBase
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        public IRouteProvider _objIRouteProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="objRouteProvider"></param>
        public RouteController(IRouteProvider objRouteProvider)
        {
            _objIRouteProvider = objRouteProvider;
        }
        /// <summary>
        /// To Add Route
        /// </summary>
        /// <param name="objRoutemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(Routemaster objRoutemaster)
        {
            return _objIRouteProvider.AddRouteMaster(objRoutemaster);
        }
        /// <summary>
        /// To View Route
        /// </summary>
        /// <param name="objRoutemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Routemaster> View(Routemaster objRoutemaster)
        {
            return _objIRouteProvider.ViewRouteMaster(objRoutemaster);
        }
        /// <summary>
        /// To Edit Route
        /// </summary>
        /// <param name="objRoutemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public Routemaster Edit(Routemaster objRoutemaster)
        {
            return _objIRouteProvider.EditRouteMaster(objRoutemaster);
        }
        /// <summary>
        /// To Delete Route
        /// </summary>
        /// <param name="objRoutemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(Routemaster objRoutemaster)
        {
            return _objIRouteProvider.DeleteRouteMaster(objRoutemaster);
        }
        /// <summary>
        /// To Update Route
        /// </summary>
        /// <param name="objRoutemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(Routemaster objRoutemaster)
        {
            return _objIRouteProvider.UpdateRouteMaster(objRoutemaster);
        }
        /// <summary>
        /// To Get District List
        /// </summary>
        /// <param name="objRoutemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Routemaster> GetDistrictList(Routemaster objRoutemaster)
        {
            return _objIRouteProvider.GetDistrictList(objRoutemaster);
        }
    }
}