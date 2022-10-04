// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 18-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MasterApi.Model.Route
{
    public class RouteProvider: RepositoryBase, IRouteProvider
    {
        public RouteProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddRouteMaster(Routemaster objRoutemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("RouteName", objRoutemaster.RouteName);
                p.Add("DistrictID", objRoutemaster.DistrictID);
                p.Add("ActiveStatus", objRoutemaster.IsActive);
                p.Add("Remarks", objRoutemaster.Remarks);
                p.Add("AddedBy", objRoutemaster.CreatedBy);
                p.Add("UserLoginID", objRoutemaster.CreatedBy);               
                p.Add("chk", "1");
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("SP_IUDRouteMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Output");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response == "0")
                {
                    objMessage.Satus = "3";
                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public List<Routemaster> ViewRouteMaster(Routemaster objRoutemaster)
        {
            List<Routemaster> ListRoutemaster = new List<Routemaster>();
            try
            {
                var paramList = new
                {
                    RouteName = objRoutemaster.RouteName,
                    Chk = "2",
                };
                var result = Connection.Query<Routemaster>("SP_IUDRouteMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListRoutemaster = result.ToList();
                }

                return ListRoutemaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListRoutemaster = null;
            }
        }
        public Routemaster EditRouteMaster(Routemaster objRoutemaster)
        {
            Routemaster LobjRouteMaster = new Routemaster();
            try
            {
                var paramList = new
                {
                    RouteID = objRoutemaster.RouteID,
                    Chk = "5",
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<Routemaster>("SP_IUDRouteMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjRouteMaster = result.FirstOrDefault();
                }

                return LobjRouteMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjRouteMaster = null;
            }
        }
        public MessageEF DeleteRouteMaster(Routemaster objRoutemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "RouteID",objRoutemaster.RouteID,
                        "Chk","4"
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("Output");
                var result = Connection.Query<string>("SP_IUDRouteMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("Output");
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF UpdateRouteMaster(Routemaster objRoutemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("RouteName", objRoutemaster.RouteName);
                p.Add("RouteID", objRoutemaster.RouteID);
                p.Add("DistrictID", objRoutemaster.DistrictID);
                p.Add("Remarks", objRoutemaster.Remarks);
                p.Add("UpdatedBy", objRoutemaster.CreatedBy);
                p.Add("UserLoginID", objRoutemaster.CreatedBy); 
                p.Add("ActiveStatus", objRoutemaster.IsActive);
                p.Add("Chk", "3");
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("SP_IUDRouteMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Output");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response == "2")
                {
                    objMessage.Satus = "3";
                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public List<Routemaster> GetDistrictList(Routemaster objRoutemaster)
        {
            List<Routemaster> ObjDistrictList = new List<Routemaster>();

            try
            {
                var paramList = new
                {
                    //DistrictId = objRoutemaster.DistrictID
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<Routemaster>("Usp_GetDistrict", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjDistrictList = result.ToList();
                }

                return ObjDistrictList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
