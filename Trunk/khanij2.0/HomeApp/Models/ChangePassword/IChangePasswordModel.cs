// ***********************************************************************
//  Interface Name           : IChangePasswordModel
//  Desciption               : To Change User Password Details in view 
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Feb 2022
// ***********************************************************************
using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Models.ChangePassword
{
    public interface IChangePasswordModel
    {
        /// <summary>
        /// Change User Password Details 
        /// </summary>
        /// <param name="objChangePasswordEF"></param>
        /// <returns></returns>
        MessageEF ChangeUserPassword(ChangePasswordEF objChangePasswordEF);
    }
}
