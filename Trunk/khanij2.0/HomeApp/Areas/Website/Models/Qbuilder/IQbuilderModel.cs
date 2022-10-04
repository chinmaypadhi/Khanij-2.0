// ***********************************************************************
//  Interface Name           : IQbuilderModel
//  Desciption               : Execute Query Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 30 Nov 2021
// ***********************************************************************
using HomeEF;
using System.Data;

namespace HomeApp.Areas.Website.Models.Qbuilder
{
    public interface IQbuilderModel
    {
        /// <summary>
        /// Execute Query Details 
        /// </summary>
        /// <param name="objQbuilderModel"></param>
        /// <returns></returns>
        //MessageEF ExecuteQuery(QuerybuilderModel objQuerybuilderModel);
        DataSet ExecuteQuery(QuerybuilderModel objQuerybuilderModel);
        /// <summary>
        /// Fetch query details
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="objQuerybuilderModel"></param>
        /// <returns></returns>
        string FetchQuerydtls(string Query, QuerybuilderModel objQuerybuilderModel);
        /// <summary>
        /// Query insert in db
        /// </summary>
        /// <param name="objQuerybuilderModel"></param>
        /// <returns></returns>
        int Queryinsert(QuerybuilderModel objQuerybuilderModel);
    }
}
