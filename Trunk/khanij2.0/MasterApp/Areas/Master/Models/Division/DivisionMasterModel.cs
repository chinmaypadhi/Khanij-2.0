using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Division
{
    public class DivisionMasterModel : IDivisionMasterModel
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
        public DivisionMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        /// <summary>
        /// Add Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        public MessageEF Add(RegionalModel regionalModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Division/Add", JsonConvert.SerializeObject(regionalModel)));
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
        /// Delete Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        public MessageEF Delete(RegionalModel regionalModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Division/Delete", JsonConvert.SerializeObject(regionalModel)));
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
        /// Edit Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        public RegionalModel Edit(RegionalModel regionalModel)
        {
            try
            {
                regionalModel = JsonConvert.DeserializeObject<RegionalModel>(_objIHttpWebClients.PostRequest("Division/Edit", JsonConvert.SerializeObject(regionalModel)));
                return regionalModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Update Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        public MessageEF Update(RegionalModel regionalModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Division" +
                    "/Update", JsonConvert.SerializeObject(regionalModel)));
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
        /// Bind Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        public List<RegionalModel> View(RegionalModel regionalModel)
        {
            try
            {
                List<RegionalModel> listRoleTypeModel = new List<RegionalModel>();
                listRoleTypeModel = JsonConvert.DeserializeObject<List<RegionalModel>>(_objIHttpWebClients.PostRequest("Division/ViewDetails", JsonConvert.SerializeObject(regionalModel)));
                return listRoleTypeModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
