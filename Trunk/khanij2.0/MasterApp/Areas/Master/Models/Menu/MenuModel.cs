// ***********************************************************************
//  Class Name               : MenuModel
//  Desciption               : To Add,Edit,Update,Delete Menu master details
//  Created By               : Lingaraj Dalai
//  Created On               : 29 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterApp.Models.Utility;
using MasterEF;
using Newtonsoft.Json;

namespace MasterApp.Areas.Master.Models.Menu
{
    public class MenuModel:IMenuModel
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="httpWebClients"></param>
        public MenuModel(IHttpWebClients httpWebClients)
        {
            _objIHttpWebClients = httpWebClients;
        }
        /// <summary>
        /// Add Menu master model
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        public MessageEF Add(Menumaster objMenumaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Menu/Add", JsonConvert.SerializeObject(objMenumaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Update Menu master model
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        public MessageEF Update(Menumaster objMenumaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Menu/Update", JsonConvert.SerializeObject(objMenumaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// View Menu master list details model
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        public List<Menumaster> View(Menumaster objMenumaster)
        {
            try
            {
                List<Menumaster> objlistMenumaster = new List<Menumaster>();
                objlistMenumaster = JsonConvert.DeserializeObject<List<Menumaster>>(_objIHttpWebClients.PostRequest("Menu/View", JsonConvert.SerializeObject(objMenumaster)));
                return objlistMenumaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Delete Menu master model
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        public MessageEF Delete(Menumaster objMenumaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Menu/Delete", JsonConvert.SerializeObject(objMenumaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Edit Menu master model
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        public Menumaster Edit(Menumaster objMenumaster)
        {
            try
            {
                objMenumaster = JsonConvert.DeserializeObject<Menumaster>(_objIHttpWebClients.PostRequest("Menu/Edit", JsonConvert.SerializeObject(objMenumaster)));
                return objMenumaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Bind Parent Menu list details model
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        public List<Menumaster> GetParentMenuList(Menumaster objMenumaster)
        {
            try
            {
                List<Menumaster> objlistDistrict = new List<Menumaster>();
                objlistDistrict = JsonConvert.DeserializeObject<List<Menumaster>>(_objIHttpWebClients.PostRequest("Menu/GetParentMenuList", JsonConvert.SerializeObject(objMenumaster)));
                return objlistDistrict;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Bind Main Menu list details model
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>
        public List<MainMenuMaster> GetMainMenuList(MainMenuMaster mainMenuMaster)
        {
            try
            {
                List<MainMenuMaster> objlistmainMenuMaster = new List<MainMenuMaster>();
                objlistmainMenuMaster = JsonConvert.DeserializeObject<List<MainMenuMaster>>(_objIHttpWebClients.PostRequest("MainMenu/ViewDetails", JsonConvert.SerializeObject(mainMenuMaster)));
                return objlistmainMenuMaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
