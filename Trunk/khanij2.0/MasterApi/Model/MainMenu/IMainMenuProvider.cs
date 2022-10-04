using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.MainMenu
{
    public interface IMainMenuProvider : IDisposable, IRepository
    {
        Task<MessageEF> AddMainMenu(MainMenuMaster mainMenuMaster);
        Task<List<MainMenuMaster>> ViewMainMenu(MainMenuMaster mainMenuMaster);
        Task<MainMenuMaster> EditMainMenu(MainMenuMaster mainMenuMaster);
        Task<MessageEF> DeleteMainMenu(MainMenuMaster mainMenuMaster);
        Task<MessageEF> UpdateMainMenu(MainMenuMaster mainMenuMaster);
    }
}
