using MasterApi.Model.MainMenu;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class MainMenuController : ControllerBase
    {
        private readonly IMainMenuProvider mainMenuProvider;

        public MainMenuController(IMainMenuProvider mainMenuProvider)
        {
            this.mainMenuProvider = mainMenuProvider;
        }

        /// <summary>
        /// Add Main Menu
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<MessageEF> Add(MainMenuMaster mainMenuMaster)
        {
            return await mainMenuProvider.AddMainMenu(mainMenuMaster);
        }

        /// <summary>
        /// View Main Menu
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<List<MainMenuMaster>> ViewDetails(MainMenuMaster mainMenuMaster)
        {
            return await mainMenuProvider.ViewMainMenu(mainMenuMaster);
        }

        /// <summary>
        /// Edit Main Menu
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<MainMenuMaster> Edit(MainMenuMaster mainMenuMaster)
        {
            return await mainMenuProvider.EditMainMenu(mainMenuMaster);
        }

        /// <summary>
        /// Delete Main Menu
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<MessageEF> Delete(MainMenuMaster mainMenuMaster)
        {
            return await mainMenuProvider.DeleteMainMenu(mainMenuMaster);
        }

        /// <summary>
        /// Update Main Menu
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<MessageEF> Update(MainMenuMaster mainMenuMaster)
        {
            return await mainMenuProvider.UpdateMainMenu(mainMenuMaster);
        }
    }
}
