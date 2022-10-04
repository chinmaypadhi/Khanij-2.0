// ***********************************************************************
//  Class Name               : RouteModel
//  Description              : Add,View,Edit,Update,Delete Route Details
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Route
{
    public class RouteModel:IRouteModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public RouteModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Route Details in view
        /// </summary>
        /// <param name="objRoutemaster"></param>
        /// <returns></returns>
        public MessageEF Add(Routemaster objRoutemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Route/Add", JsonConvert.SerializeObject(objRoutemaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Route Details in view
        /// </summary>
        /// <param name="objRoutemaster"></param>
        /// <returns></returns>
        public MessageEF Update(Routemaster objRoutemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Route/Update", JsonConvert.SerializeObject(objRoutemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// View Route Details in view
        /// </summary>
        /// <param name="objRoutemaster"></param>
        /// <returns></returns>
        public List<Routemaster> View(Routemaster objRoutemaster)
        {
            try
            {
                List<Routemaster> objlistRoutemaster = new List<Routemaster>();
                objlistRoutemaster = JsonConvert.DeserializeObject<List<Routemaster>>(_objIHttpWebClients.PostRequest("Route/View", JsonConvert.SerializeObject(objRoutemaster)));
                return objlistRoutemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete Route Details in view
        /// </summary>
        /// <param name="objRoutemaster"></param>
        /// <returns></returns>
        public MessageEF Delete(Routemaster objRoutemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Route/Delete", JsonConvert.SerializeObject(objRoutemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit Route Details in view
        /// </summary>
        /// <param name="objRoutemaster"></param>
        /// <returns></returns>
        public Routemaster Edit(Routemaster objRoutemaster)
        {
            try
            {
                objRoutemaster = JsonConvert.DeserializeObject<Routemaster>(_objIHttpWebClients.PostRequest("Route/Edit", JsonConvert.SerializeObject(objRoutemaster)));
                return objRoutemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get District List details in view
        /// </summary>
        /// <param name="objRoutemaster"></param>
        /// <returns></returns>
        public List<Routemaster> GetDistrictList(Routemaster objRoutemaster)
        {
            try
            {
                List<Routemaster> objlistDistrict = new List<Routemaster>();
                objlistDistrict = JsonConvert.DeserializeObject<List<Routemaster>>(_objIHttpWebClients.PostRequest("Route/GetDistrictList", JsonConvert.SerializeObject(objRoutemaster)));
                return objlistDistrict;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
