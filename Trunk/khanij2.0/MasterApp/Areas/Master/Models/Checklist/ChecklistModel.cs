// ***********************************************************************
//  Class Name               : ChecklistModel
//  Description              : Add,View,Edit,Update,Delete Checklist Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using MasterApp.Models.Utility;
using MasterEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Checklist
{
    public class ChecklistModel:IChecklistModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public ChecklistModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Checklist Details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        public MessageEF Add(ChecklistMaster objChecklistMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Checklist/Add", JsonConvert.SerializeObject(objChecklistMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Checklist Details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        public MessageEF Update(ChecklistMaster objChecklistMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Checklist/Update", JsonConvert.SerializeObject(objChecklistMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// View Checklist Details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        public List<ChecklistMaster> View(ChecklistMaster objChecklistMaster)
        {
            try
            {
                List<ChecklistMaster> objlistCheckPostmaster = new List<ChecklistMaster>();
                objlistCheckPostmaster = JsonConvert.DeserializeObject<List<ChecklistMaster>>(_objIHttpWebClients.PostRequest("Checklist/View", JsonConvert.SerializeObject(objChecklistMaster)));
                return objlistCheckPostmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Delete Checklist Details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        public MessageEF Delete(ChecklistMaster objChecklistMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Checklist/Delete", JsonConvert.SerializeObject(objChecklistMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Edit Checklist Details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        public ChecklistMaster Edit(ChecklistMaster objChecklistMaster)
        {
            try
            {
                objChecklistMaster = JsonConvert.DeserializeObject<ChecklistMaster>(_objIHttpWebClients.PostRequest("Checklist/Edit", JsonConvert.SerializeObject(objChecklistMaster)));
                return objChecklistMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Bind Module List details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        public List<ChecklistMaster> GetModuleList(ChecklistMaster objChecklistMaster)
        {
            try
            {
                List<ChecklistMaster> objlistDistrict = new List<ChecklistMaster>();
                objlistDistrict = JsonConvert.DeserializeObject<List<ChecklistMaster>>(_objIHttpWebClients.PostRequest("Checklist/GetModuleList", JsonConvert.SerializeObject(objChecklistMaster)));
                return objlistDistrict;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
