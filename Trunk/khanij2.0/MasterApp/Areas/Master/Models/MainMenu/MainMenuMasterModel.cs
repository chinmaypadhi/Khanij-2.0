using MasterApp.Models.Utility;
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.MainMenu
{
    public class MainMenuMasterModel : IMainMenuMasterModel
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
         IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="httpWebClients"></param>
        public MainMenuMasterModel(IHttpWebClients httpWebClients)
        {
            _objIHttpWebClients = httpWebClients;
        }
        /// <summary>
        /// Add Main Menu
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        public MessageEF AddMainMenu(MainMenuMaster mainMenuMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MainMenu/Add", JsonConvert.SerializeObject(mainMenuMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete Main Menu
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        public MessageEF DeleteMainMenu(MainMenuMaster mainMenuMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MainMenu/Delete", JsonConvert.SerializeObject(mainMenuMaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Edit Main Menu
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        public MainMenuMaster EditMainMenu(MainMenuMaster mainMenuMaster)
        {
            try
            {
                mainMenuMaster = JsonConvert.DeserializeObject<MainMenuMaster>(_objIHttpWebClients.PostRequest("MainMenu/Edit", JsonConvert.SerializeObject(mainMenuMaster)));
                return mainMenuMaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Update Main Menu
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        public MessageEF UpdateMainMenu(MainMenuMaster mainMenuMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MainMenu" +"/Update", JsonConvert.SerializeObject(mainMenuMaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// View Main Menu
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        public List<MainMenuMaster> ViewMainMenu(MainMenuMaster mainMenuMaster)
        {
            try
            {
                List<MainMenuMaster> listMainMenuMaster = new List<MainMenuMaster>();
                listMainMenuMaster = JsonConvert.DeserializeObject<List<MainMenuMaster>>(_objIHttpWebClients.PostRequest("MainMenu/ViewDetails", JsonConvert.SerializeObject(mainMenuMaster)));
                return listMainMenuMaster;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// View Module Details
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>

        public List<ModuleMasterModel> ViewModuleDetails(ModuleMasterModel moduleMasterModel)
        {
            try
            {
                List<ModuleMasterModel> listModuleMasterModel = new List<ModuleMasterModel>();
                listModuleMasterModel = JsonConvert.DeserializeObject<List<ModuleMasterModel>>(_objIHttpWebClients.PostRequest("Module/View", JsonConvert.SerializeObject(moduleMasterModel)));
                return listModuleMasterModel;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
