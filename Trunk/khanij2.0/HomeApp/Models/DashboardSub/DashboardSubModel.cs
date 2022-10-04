using HomeApp.Models.Utility;
using HomeEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Models.DashboardSub
{
    public class DashboardSubModel : IDashboardSubModel
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="httpWebClients"></param>
        public DashboardSubModel(IHttpWebClients httpWebClients)
        {
            _objIHttpWebClients = httpWebClients;
        }
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
    }
}
