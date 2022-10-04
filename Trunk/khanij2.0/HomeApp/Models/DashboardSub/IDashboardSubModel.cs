using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
namespace HomeApp.Models.DashboardSub
{
    public interface IDashboardSubModel
    {
       // List<ModuleMasterModel> ViewModuleDetails(ModuleMasterModel moduleMasterModel);
        List<MainMenuMaster> ViewMainMenu(MainMenuMaster mainMenuMaster);
    }
}
