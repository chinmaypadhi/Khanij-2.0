using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.LicenseeType
{
    public class LicenseeTypeModel:ILicenseeTypeModel
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
        public LicenseeTypeModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        public MessageEF Add(LicenseeTypeMaster objLicenseeType)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseeType/Add", JsonConvert.SerializeObject(objLicenseeType)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        public MessageEF Update(LicenseeTypeMaster objLicenseeType)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseeType/Update", JsonConvert.SerializeObject(objLicenseeType)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        public List<LicenseeTypeMaster> View(LicenseeTypeMaster objLicenseeType)
        {
            try
            {
                List<LicenseeTypeMaster> objlistLicenseeType = new List<LicenseeTypeMaster>();
                objlistLicenseeType = JsonConvert.DeserializeObject<List<LicenseeTypeMaster>>(_objIHttpWebClients.PostRequest("LicenseeType/View", JsonConvert.SerializeObject(objLicenseeType)));
                return objlistLicenseeType;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        public MessageEF Delete(LicenseeTypeMaster objLicenseeType)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseeType/Delete", JsonConvert.SerializeObject(objLicenseeType)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        public LicenseeTypeMaster Edit(LicenseeTypeMaster objLicenseeType)
        {
            try
            {
                objLicenseeType = JsonConvert.DeserializeObject<LicenseeTypeMaster>(_objIHttpWebClients.PostRequest("LicenseeType/Edit", JsonConvert.SerializeObject(objLicenseeType)));
                return objLicenseeType;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
