// ***********************************************************************
//  Interface Name           : IAddFileProvider
//  Desciption               : Starrating Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 16 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using StarRatingApi.Repository;
using StarratingEF;

namespace StarRatingApi.Model.AddFile
{
    public interface IAddFileProvider: IDisposable, IRepository
    {
        /// <summary>
        /// View Additional File Provider
        /// </summary>
        /// <param name="objAddFilemaster"></param>
        /// <returns></returns>
        List<AddFilemaster> ViewAdditionalFile(AddFilemaster objAddFilemaster);
        /// <summary>
        /// Add Additional File Provider
        /// </summary>
        /// <param name="objAddFilemaster"></param>
        /// <returns></returns>
        MessageEF AddAdditionalFile(AddFilemaster objAddFilemaster);
    }
}
