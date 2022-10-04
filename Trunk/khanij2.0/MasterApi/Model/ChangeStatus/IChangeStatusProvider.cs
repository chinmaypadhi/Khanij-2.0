// ***********************************************************************
//  Interface Name           : IChangeStatusProvider
//  Description              : Add,View,Edit,Update,Delete Change Status details
//  Created By               : Lingaraj Dalai
//  Created On               : 29 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;

namespace MasterApi.Model.ChangeStatus
{
    public interface IChangeStatusProvider
    {
        /// <summary>
        /// Add Change Status details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        MessageEF AddChangeStatusmaster(ChangeStatusmaster objChangeStatusmaster);
        /// <summary>
        /// Bind Division details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        List<ChangeStatusmaster> GetDivisionList(ChangeStatusmaster objChangeStatusmaster);
        /// <summary>
        /// Bind District details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        List<ChangeStatusmaster> GetDistrictList(ChangeStatusmaster objChangeStatusmaster);
        /// <summary>
        /// Bind User Type list details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        List<ChangeStatusmaster> GetUserTypeList(ChangeStatusmaster objChangeStatusmaster);
        /// <summary>
        /// Bind User Name List details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        List<ChangeStatusmaster> GetUserNameList(ChangeStatusmaster objChangeStatusmaster);
        /// <summary>
        /// Bind Change Status List details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        List<ChangeStatusmaster> GetChangeStatusList(ChangeStatusmaster objChangeStatusmaster);
        /// <summary>
        /// Bind Current Status List details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        ChangeStatusmaster GetCurrentStatusList(ChangeStatusmaster objChangeStatusmaster);
    }
}
