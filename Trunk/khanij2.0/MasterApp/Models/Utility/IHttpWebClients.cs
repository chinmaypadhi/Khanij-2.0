// ***********************************************************************
//  Interface Name           : IHttpWebClients
//  Description              : Httpwebclient Details
//  Created By               : Lingaraj Dalai
//  Created On               : 16 December 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Models.Utility
{
    public interface IHttpWebClients
    {
        /// <summary>
        /// Post request method
        /// </summary>
        /// <param name="URI"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        string PostRequest(string URI, string parameterValues);
        /// <summary>
        /// Get Request method
        /// </summary>
        /// <param name="URI"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        string GetRequest(string URI, object parameterValues);
        /// <summary>
        /// Await Post request method
        /// </summary>
        /// <param name="URI"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        Task<string> AwaitPostRequest(string URI, string parameterValues);
    }
}
