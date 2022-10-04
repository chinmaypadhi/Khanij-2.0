// ***********************************************************************
//  Interface Name           : IExceptionProvider
//  Desciption               : Exception Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 04 Feb 2022
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using DashboardApi.Repository;
using DashboardEF;

namespace DashboardApi.Model.ExceptionList
{    
    public interface IExceptionProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Bind Error list details
        /// </summary>
        /// <param name="objLogEntry"></param>
        /// <returns></returns>
        string ErrorList(LogEntry objLogEntry);
        /// <summary>
        /// Get user list details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        UserLoginSession getuserDetail(LoginEF model);
        /// <summary>
        /// Get Menu list details
        /// </summary>
        /// <param name="objmenuonput"></param>
        /// <returns></returns>
        List<MenuEF> MenuList(menuonput objmenuonput);
        /// <summary>
        /// Method Convert datareader to dataset
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataSet ConvertDataReaderToDataSet(IDataReader data);
    }
}
