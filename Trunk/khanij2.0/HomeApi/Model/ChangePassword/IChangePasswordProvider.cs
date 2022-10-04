// ***********************************************************************
//  Interface Name           : IChangePasswordProvider
//  Desciption               : To Change User Password Details in view 
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Feb 2022
// ***********************************************************************
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Model.ChangePassword
{
    public interface IChangePasswordProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Change User Password Details 
        /// </summary>
        /// <param name="objChangePasswordEF"></param>
        /// <returns></returns>
        Task<MessageEF> ChangeUserPassword(ChangePasswordEF objChangePasswordEF);
    }
}
