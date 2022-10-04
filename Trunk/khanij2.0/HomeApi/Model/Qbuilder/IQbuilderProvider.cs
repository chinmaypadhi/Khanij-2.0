// ***********************************************************************
//  Interface Name           : IQbuilderProvider
//  Desciption               : Query builder 
//  Created By               : Lingaraj Dalai
//  Created On               : 30 Nov 2021
// ***********************************************************************
using HomeApi.Repository;
using HomeEF;
using System;
using System.Data;
using System.Threading.Tasks;

namespace HomeApi.Model.Qbuilder
{
    public interface IQbuilderProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Execute Query builder Details 
        /// </summary>
        /// <param name="objQuerybuilderModel"></param>
        /// <returns></returns>
        //Task<MessageEF> ExecuteQuery(QuerybuilderModel objQuerybuilderModel);
        Task<DataSet> ExecuteQuery(QuerybuilderModel objQuerybuilderModel);
        /// <summary>
        /// Fetch Query Details
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="objQuerybuilderModel"></param>
        /// <returns></returns>
        Task<string> FetchQuerydtls(string Query, QuerybuilderModel objQuerybuilderModel);
        /// <summary>
        /// For DML operations
        /// </summary>
        /// <param name="objQuerybuilderModel"></param>
        /// <returns></returns>
        Task<int> Queryinsert(QuerybuilderModel objQuerybuilderModel);
    }
}
