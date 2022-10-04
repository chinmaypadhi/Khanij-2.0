// ***********************************************************************
//  Class Name               : CompanyModel
//  Description              : Add,View,Edit,Update,Delete Company Details
//  Created By               : Lingaraj Dalai
//  Created On               : 29 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Models.Company
{
    public class CompanyModel:ICompanyModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public CompanyModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Company Details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        public MessageEF Add(CompanyMaster objCompanyMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Company/Add", JsonConvert.SerializeObject(objCompanyMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Company Details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        public MessageEF Update(CompanyMaster objCompanyMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Company/Update", JsonConvert.SerializeObject(objCompanyMaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// View Company Details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        public List<CompanyMaster> View(CompanyMaster objCompanyMaster)
        {
            try
            {
                List<CompanyMaster> objlistCompany = new List<CompanyMaster>();
                objlistCompany = JsonConvert.DeserializeObject<List<CompanyMaster>>(_objIHttpWebClients.PostRequest("Company/View", JsonConvert.SerializeObject(objCompanyMaster)));
                return objlistCompany;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete Company Details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        public MessageEF Delete(CompanyMaster objCompanyMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Company/Delete", JsonConvert.SerializeObject(objCompanyMaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit Company Details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        public CompanyMaster Edit(CompanyMaster objCompanyMaster)
        {
            try
            {
                objCompanyMaster = JsonConvert.DeserializeObject<CompanyMaster>(_objIHttpWebClients.PostRequest("Company/Edit", JsonConvert.SerializeObject(objCompanyMaster)));
                return objCompanyMaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
