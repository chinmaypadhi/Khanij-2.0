using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.District
{
    public class DistrictMasterModel : IDistrictMasterModel
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
        public DistrictMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        /// <summary>
        /// Add District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        public MessageEF Add(DistrictModel districtModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("District/Add", JsonConvert.SerializeObject(districtModel)));
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
        /// Delete District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        public MessageEF Delete(DistrictModel districtModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("District/Delete", JsonConvert.SerializeObject(districtModel)));
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
        /// Edit District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        public DistrictModel Edit(DistrictModel districtModel)
        {
            try
            {
                districtModel = JsonConvert.DeserializeObject<DistrictModel>(_objIHttpWebClients.PostRequest("District/Edit", JsonConvert.SerializeObject(districtModel)));
                return districtModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Update District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        public MessageEF Update(DistrictModel districtModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("District" +
                    "/Update", JsonConvert.SerializeObject(districtModel)));
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
        /// Bind District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        public List<DistrictModel> View(DistrictModel districtModel)
        {
            try
            {
                List<DistrictModel> listDistrictModel = new List<DistrictModel>();
                listDistrictModel = JsonConvert.DeserializeObject<List<DistrictModel>>(_objIHttpWebClients.PostRequest("District/ViewDetails", JsonConvert.SerializeObject(districtModel)));
                return listDistrictModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
