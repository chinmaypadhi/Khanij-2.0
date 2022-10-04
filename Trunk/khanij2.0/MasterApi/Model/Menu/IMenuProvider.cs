// ***********************************************************************
//  Interface Name           : IMenuProvider
//  Desciption               : To Add,Edit,Update,Delete Menu master details
//  Created By               : Lingaraj Dalai
//  Created On               : 29 Jan 2021
// ***********************************************************************
using System.Collections.Generic;
using MasterEF;

namespace MasterApi.Model.Menu
{
    public interface IMenuProvider
    {
        /// <summary>
        /// Add Menu master
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        MessageEF AddMenumaster(Menumaster objMenumaster);
        /// <summary>
        /// View Menu master list details
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        List<Menumaster> ViewMenumaster(Menumaster objMenumaster);
        /// <summary>
        /// Edit Menu master
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        Menumaster EditMenumaster(Menumaster objMenumaster);
        /// <summary>
        /// Delete Menu master
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        MessageEF DeleteMenumaster(Menumaster objMenumaster);
        /// <summary>
        /// Update Menu master
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        MessageEF UpdateMenumaster(Menumaster objMenumaster);
        /// <summary>
        /// Bind Parent Menu list details
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        List<Menumaster> GetParentMenuList(Menumaster objMenumaster);
    }
}
