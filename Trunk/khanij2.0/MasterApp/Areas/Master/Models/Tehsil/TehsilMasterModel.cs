using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Tehsil
{
    public class TehsilMasterModel : ITehsilMasterModel
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
        public TehsilMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        public MessageEF Add(TehsilModel tehsilModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Tehsil/Add", JsonConvert.SerializeObject(tehsilModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        public MessageEF Delete(TehsilModel tehsilModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Tehsil/Delete", JsonConvert.SerializeObject(tehsilModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Edit
        public TehsilModel Edit(TehsilModel tehsilModel)
        {
            try
            {
                tehsilModel = JsonConvert.DeserializeObject<TehsilModel>(_objIHttpWebClients.PostRequest("Tehsil/Edit", JsonConvert.SerializeObject(tehsilModel)));
                return tehsilModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        public MessageEF Update(TehsilModel tehsilModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Tehsil" +
                    "/Update", JsonConvert.SerializeObject(tehsilModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View
        public List<TehsilModel> View(TehsilModel tehsilModel)
        {
            try
            {
                List<TehsilModel> listDTehsilModel = new List<TehsilModel>();
                listDTehsilModel = JsonConvert.DeserializeObject<List<TehsilModel>>(_objIHttpWebClients.PostRequest("Tehsil/ViewDetails", JsonConvert.SerializeObject(tehsilModel)));
                return listDTehsilModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
