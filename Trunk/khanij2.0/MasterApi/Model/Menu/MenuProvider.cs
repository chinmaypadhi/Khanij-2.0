// ***********************************************************************
//  Class Name               : MenuProvider
//  Desciption               : To Add,Edit,Update,Delete Menu master details
//  Created By               : Lingaraj Dalai
//  Created On               : 29 Jan 2021
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MasterApi.Model.Menu
{
    public class MenuProvider: RepositoryBase,IMenuProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objMenuProvider"></param>
        public MenuProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Menu master class
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        public MessageEF AddMenumaster(Menumaster objMenumaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("MenuName", objMenumaster.MenuName);
                p.Add("Description", objMenumaster.Description);
                p.Add("ParentId", objMenumaster.ParentId);
                p.Add("IsActive", objMenumaster.IsActive);
                p.Add("CreatedBy", objMenumaster.CreatedBy);
                p.Add("Controller", objMenumaster.Controller);
                p.Add("ActionName", objMenumaster.ActionName);
                p.Add("Area", objMenumaster.Area);
                p.Add("Operation", objMenumaster.Operation);
                p.Add("url", objMenumaster.url);
                p.Add("GifIcon", objMenumaster.GifIcon);
                p.Add("Check", "1");
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("spMenuMaster_New", p, commandType: CommandType.StoredProcedure);
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

        /// <summary>
        /// View Menu master list details class
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        public List<Menumaster> ViewMenumaster(Menumaster objMenumaster)
        {
            List<Menumaster> ListMenumaster = new List<Menumaster>();
            try
            {
                var paramList = new
                {
                    MenuName = objMenumaster.MenuName,
                    Check = "0",
                };
                var Output = Connection.Query<Menumaster>("spMenuMaster_New", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {

                    ListMenumaster = Output.ToList();
                }

                return ListMenumaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Edit Menu master class
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        public Menumaster EditMenumaster(Menumaster objMenumaster)
        {
            Menumaster LobjMenumaster = new Menumaster();
            try
            {
                var paramList = new
                {
                    MenuId = objMenumaster.MenuId,
                    Check = "0",

                };
                DynamicParameters param = new DynamicParameters();

                var Output = Connection.Query<Menumaster>("spMenuMaster_New", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {

                    LobjMenumaster = Output.FirstOrDefault();
                }

                return LobjMenumaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete Menu master class
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        public MessageEF DeleteMenumaster(Menumaster objMenumaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "MenuId",objMenumaster.MenuId,
                        "Check","3"
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("Output");
                var Output = Connection.Query<string>("spMenuMaster_New", _param, commandType: System.Data.CommandType.StoredProcedure);
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

        /// <summary>
        /// Update Menu master
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        public MessageEF UpdateMenumaster(Menumaster objMenumaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("MenuId", objMenumaster.MenuId);
                p.Add("MenuName", objMenumaster.MenuName);
                p.Add("Description", objMenumaster.Description);
                p.Add("ParentId", objMenumaster.ParentId);
                p.Add("IsActive", objMenumaster.IsActive);
                p.Add("CreatedBy", objMenumaster.CreatedBy);
                p.Add("Controller", objMenumaster.Controller);
                p.Add("ActionName", objMenumaster.ActionName);
                p.Add("Area", objMenumaster.Area);
                p.Add("Operation", objMenumaster.Operation);
                p.Add("url", objMenumaster.url);
                p.Add("GifIcon", objMenumaster.GifIcon);
                p.Add("Check", "2");
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("spMenuMaster_New", p, commandType: CommandType.StoredProcedure);
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

        /// <summary>
        /// Bind Parent Menu list details
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        public List<Menumaster> GetParentMenuList(Menumaster objMenumaster)
        {
            List<Menumaster> ObjParentMenuList = new List<Menumaster>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();

                var Output = Connection.Query<Menumaster>("spMenuMaster_New", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {

                    ObjParentMenuList = Output.ToList();
                }

                return ObjParentMenuList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
