// ***********************************************************************
//  Interface Name           : IUsertypeModel
//  Description              : Add,View,Edit,Update,Delete Usertype Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using System.Collections.Generic;
using MasterEF;

namespace MasterApp.Areas.Master.Models.Usertype
{
    public interface IUsertypeModel
    {
        /// <summary>
        /// Add Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        MessageEF Add(UsertypeMaster objUsertypeMaster);
        /// <summary>
        /// Update Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        MessageEF Update(UsertypeMaster objUsertypeMaster);
        /// <summary>
        /// Bind Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        List<UsertypeMaster> View(UsertypeMaster objUsertypeMaster);
        /// <summary>
        /// Delete Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        MessageEF Delete(UsertypeMaster objUsertypeMaster);
        /// <summary>
        /// Edit Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        UsertypeMaster Edit(UsertypeMaster objUsertypeMaster);
    }
}
