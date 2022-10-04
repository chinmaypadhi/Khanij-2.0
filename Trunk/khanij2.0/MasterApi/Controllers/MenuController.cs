// ***********************************************************************
//  Controller Name          : MenuController
//  Desciption               : To Add,Edit,Update,Delete Menu master details
//  Created By               : Lingaraj Dalai
//  Created On               : 29 Jan 2021
// ***********************************************************************
using System.Collections.Generic;
using MasterApi.Model.Menu;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public IMenuProvider _objIMenuProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objMenuProvider"></param>
        public MenuController(IMenuProvider objMenuProvider)
        {
            _objIMenuProvider = objMenuProvider;
        }
        /// <summary>
        /// Add Menu master
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(Menumaster objMenumaster)
        {
            return _objIMenuProvider.AddMenumaster(objMenumaster);
        }
        /// <summary>
        /// View Menu master
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Menumaster> View(Menumaster objMenumaster)
        {
            return _objIMenuProvider.ViewMenumaster(objMenumaster);
        }
        /// <summary>
        /// Edit Menu master
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        [HttpPost]
        public Menumaster Edit(Menumaster objMenumaster)
        {
            return _objIMenuProvider.EditMenumaster(objMenumaster);
        }
        /// <summary>
        /// Delete Menu master
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(Menumaster objMenumaster)
        {
            return _objIMenuProvider.DeleteMenumaster(objMenumaster);
        }
        /// <summary>
        /// Update Menu master
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(Menumaster objMenumaster)
        {
            return _objIMenuProvider.UpdateMenumaster(objMenumaster);
        }
        /// <summary>
        /// Parent Menu list details
        /// </summary>
        /// <param name="objMenumaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Menumaster> GetParentMenuList(Menumaster objMenumaster)
        {
            return _objIMenuProvider.GetParentMenuList(objMenumaster);
        }
    }
}