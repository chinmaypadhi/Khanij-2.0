using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.MainMenu
{
    public interface IMainMenuMasterModel
    {
        MessageEF AddMainMenu(MainMenuMaster mainMenuMaster);
        List<MainMenuMaster> ViewMainMenu(MainMenuMaster mainMenuMaster);
        MainMenuMaster EditMainMenu(MainMenuMaster mainMenuMaster);
        MessageEF DeleteMainMenu(MainMenuMaster mainMenuMaster);
        MessageEF UpdateMainMenu(MainMenuMaster mainMenuMaster);
        List<ModuleMasterModel> ViewModuleDetails(ModuleMasterModel moduleMasterModel);
    }
}
