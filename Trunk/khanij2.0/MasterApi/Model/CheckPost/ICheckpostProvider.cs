// ***********************************************************************
//  Interface Name           : ICheckPostProvider
//  Description              : Add,View,Edit,Update,Delete Checkpost details
//  Created By               : Lingaraj Dalai
//  Created On               : 20 Jan 2021
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;

namespace MasterApi.Model.Checkpost
{
    public interface ICheckPostProvider
    {
        /// <summary>
        /// Add Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        MessageEF AddCheckPostmaster(Checkpostmaster objCheckpostmaster);
        /// <summary>
        /// View Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        List<Checkpostmaster> ViewCheckPostmaster(Checkpostmaster objCheckpostmaster);
        /// <summary>
        /// Edit Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        Checkpostmaster EditCheckPostmaster(Checkpostmaster objCheckpostmaster);
        /// <summary>
        /// Delete Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        MessageEF DeleteCheckPostmaster(Checkpostmaster objCheckpostmaster);
        /// <summary>
        /// Update Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        MessageEF UpdateCheckPostmaster(Checkpostmaster objCheckpostmaster);
        /// <summary>
        /// Bind District List Details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        List<Checkpostmaster> GetDistrictList(Checkpostmaster objCheckpostmaster);
        /// <summary>
        /// Bind User List details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        List<Checkpostmaster> GetUserList(Checkpostmaster objCheckpostmaster);
    }
}
