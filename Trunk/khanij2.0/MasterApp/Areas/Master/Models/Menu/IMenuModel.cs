// ***********************************************************************
//  Interface Name           : IMenuModel
//  Desciption               : To Add,Edit,Update,Delete Menu master details
//  Created By               : Lingaraj Dalai
//  Created On               : 29 Jan 2021
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;

namespace MasterApp.Areas.Master.Models.Menu
{
    public interface IMenuModel
    {
        /// <summary>
        /// Add Menu master model
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        MessageEF Add(Menumaster objMenumaster);

        /// <summary>
        /// Update Menu master model
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        MessageEF Update(Menumaster objMenumaster);

        /// <summary>
        /// View Menu master list details model
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        List<Menumaster> View(Menumaster objMenumaster);

        /// <summary>
        /// Delete Menu master model
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        MessageEF Delete(Menumaster objMenumaster);

        /// <summary>
        /// Edit Menu master model
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        Menumaster Edit(Menumaster objMenumaster);

        /// <summary>
        /// Bind Parent Menu list details model
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        List<Menumaster> GetParentMenuList(Menumaster parentmenuResult);

        /// <summary>
        /// Bind Main Menu list details model
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>
        List<MainMenuMaster> GetMainMenuList(MainMenuMaster mainMenuMaster);
    }
}
