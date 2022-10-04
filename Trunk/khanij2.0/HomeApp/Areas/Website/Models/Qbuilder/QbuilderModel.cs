// ***********************************************************************
//  Class Name               : QbuilderModel
//  Desciption               : Execute Query Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 30 Nov 2021
// ***********************************************************************
using HomeApp.Models.Utility;
using HomeEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Qbuilder
{
    public class QbuilderModel: IQbuilderModel
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public QbuilderModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Execute Query Details
        /// </summary>
        /// <param name="objQbuilderModel"></param>
        /// <returns></returns>
        //public MessageEF ExecuteQuery(QuerybuilderModel objQuerybuilderModel)
        //{
        //    try
        //    {
        //        MessageEF objMessageEF = new MessageEF();
        //        objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Qbuilder/ExecuteQuery", JsonConvert.SerializeObject(objQuerybuilderModel)));
        //        return objMessageEF;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public DataSet ExecuteQuery(QuerybuilderModel objQuerybuilderModel)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = JsonConvert.DeserializeObject<DataSet>(_objIHttpWebClients.PostRequest("Qbuilder/ExecuteQuery", JsonConvert.SerializeObject(objQuerybuilderModel)));
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Fetch query details in view
        /// </summary>
        /// <param name="query"></param>
        /// <param name="objQuerybuilderModel"></param>
        /// <returns></returns>
        public string FetchQuerydtls(string query, QuerybuilderModel objQuerybuilderModel)
        {
            try
            {
                query = (_objIHttpWebClients.PostRequest("Qbuilder/FetchQuerydtls", JsonConvert.SerializeObject(objQuerybuilderModel))).ToString();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Query insert in db
        /// </summary>
        /// <param name="objQuerybuilderModel"></param>
        /// <returns></returns>
        public int Queryinsert(QuerybuilderModel objQuerybuilderModel)
        {
            try
            {
                int respponse = JsonConvert.DeserializeObject<int>(_objIHttpWebClients.PostRequest("Qbuilder/Queryinsert", JsonConvert.SerializeObject(objQuerybuilderModel)));
                return respponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
