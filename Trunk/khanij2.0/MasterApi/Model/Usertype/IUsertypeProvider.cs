// ***********************************************************************
//  Interface Name           : IUsertypeProvider
//  Description              : Add,View,Edit,Update,Delete Usertype Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MasterApi.Model.Usertype
{
    public interface IUsertypeProvider
    {
        /// <summary>
        /// Add Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        Task<MessageEF> AddUsertypemaster(UsertypeMaster objUsertypeMaster);
        /// <summary>
        /// View Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        Task<List<UsertypeMaster>> ViewUsertypeMaster(UsertypeMaster objUsertypeMaster);
        /// <summary>
        /// Edit Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        Task<UsertypeMaster> EditUsertypeMaster(UsertypeMaster objUsertypeMaster);
        /// <summary>
        /// Delete Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        Task<MessageEF> DeleteUsertypeMaster(UsertypeMaster objUsertypeMaster);
        /// <summary>
        /// Update Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateUsertypeMaster(UsertypeMaster objUsertypeMaster);
    }
}
