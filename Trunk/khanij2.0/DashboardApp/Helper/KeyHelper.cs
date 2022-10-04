// ***********************************************************************
//  Class Name               : KeyHelper
//  Desciption               : static class for User key
//  Created By               : Lingaraj Dalai
//  Created On               : 23 Jan 2022
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardApp.Web
{
    /// <summary>
    /// This class manages static keys
    /// </summary>
    public static class KeyHelper
    {
        /// <summary>
        /// Stores the user information
        /// </summary>
        public static string UserKey { get { return "USER.KEY"; } }
    }
}
