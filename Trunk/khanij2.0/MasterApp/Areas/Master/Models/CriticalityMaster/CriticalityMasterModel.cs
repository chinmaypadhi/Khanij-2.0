using MasterApp.Areas.Master.Models.CriticalityMasters;
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.CriticalityMasters
{
    public class CriticalityMasterModel : ICriticalityMasterModel
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
        public CriticalityMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        /// <summary>
        /// Add Criticality details in view
        /// </summary>
        /// <param name="objCriticalityMaster"></param>
        /// <returns></returns>
        public MessageEF Add(CriticalityMaster objCriticalityMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Criticality/Add", JsonConvert.SerializeObject(objCriticalityMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete Criticality details in view
        /// </summary>
        /// <param name="objCriticalityMaster"></param>
        /// <returns></returns>
        public MessageEF Delete(CriticalityMaster objCriticalityMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Criticality/Delete", JsonConvert.SerializeObject(objCriticalityMaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Edit
        /// <summary>
        /// Edit Criticality details in view
        /// </summary>
        /// <param name="objCriticalityMaster"></param>
        /// <returns></returns>
        public CriticalityMaster Edit(CriticalityMaster objCriticalityMaster)
        {
            try
            {
                objCriticalityMaster = JsonConvert.DeserializeObject<CriticalityMaster>(_objIHttpWebClients.PostRequest("Criticality/Edit", JsonConvert.SerializeObject(objCriticalityMaster)));
                return objCriticalityMaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Update
        /// <summary>
        /// Update Criticality details in view
        /// </summary>
        /// <param name="objCriticalityMaster"></param>
        /// <returns></returns>
        public MessageEF Update(CriticalityMaster objCriticalityMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Criticality/Update", JsonConvert.SerializeObject(objCriticalityMaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View
        /// <summary>
        /// View Criticality details in view
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        public List<CriticalityMaster> View(CriticalityMaster criticalityMaster)
        {
            try
            {
                List<CriticalityMaster> listCriticalityMaster = new List<CriticalityMaster>();
                listCriticalityMaster = JsonConvert.DeserializeObject<List<CriticalityMaster>>(_objIHttpWebClients.PostRequest("Criticality/ViewDetails", JsonConvert.SerializeObject(criticalityMaster)));
                return listCriticalityMaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion
    }
}
