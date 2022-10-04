using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Areas.Contractor.Models.SandStone
{
    public class SandStoneModel: ISandStoneModel
    {
        IHttpWebClients _objIHttpWebClients;
        public SandStoneModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Submit Sand Stone Regd
        /// </summary>
        /// <param name="contractorBuilderModel"></param>
        /// <returns></returns>
        public MessageEF SubmitSandStoneRegd(SandStoneModels SandStoneModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SandStone/SubmitSandStoneRegd", JsonConvert.SerializeObject(SandStoneModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Get State
        /// </summary>
        /// <param name="objDD"></param>
        /// <returns>GetMineralResult class</returns>
        public List<SandStoneModels> GetState(SandStoneModels SandStoneModel)
        {
            try
            {
                List<SandStoneModels> objlistDD = new List<SandStoneModels>();
                return JsonConvert.DeserializeObject<List<SandStoneModels>>(_objIHttpWebClients.PostRequest("SandStone/GetState", JsonConvert.SerializeObject(SandStoneModel)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get District
        /// </summary>
        /// <param name="objDD"></param>
        /// <returns>GetMineralResult class</returns>
        public List<SandStoneModels> GetDistrict(SandStoneModels SandStoneModel)
        {
            try
            {
                List<SandStoneModels> objlistDD = new List<SandStoneModels>();
                return JsonConvert.DeserializeObject<List<SandStoneModels>>(_objIHttpWebClients.PostRequest("SandStone/GetDistrict", JsonConvert.SerializeObject(SandStoneModel)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get Block
        /// </summary>
        /// <param name="objDD"></param>
        /// <returns>GetMineralResult class</returns>
        public List<SandStoneModels> GetBlock(SandStoneModels SandStoneModel)
        {
            try
            {
                List<SandStoneModels> objlistDD = new List<SandStoneModels>();
                return JsonConvert.DeserializeObject<List<SandStoneModels>>(_objIHttpWebClients.PostRequest("SandStone/GetBlock", JsonConvert.SerializeObject(SandStoneModel)));

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Get Mineral Name
        /// </summary>
        /// <param name="objDD"></param>
        /// <returns>GetMineralResult class</returns>
        public List<SandStoneModels> GetMineralName(SandStoneModels SandStoneModel)
        {
            try
            {
                List<SandStoneModels> objlistDD = new List<SandStoneModels>();
                return JsonConvert.DeserializeObject<List<SandStoneModels>>(_objIHttpWebClients.PostRequest("SandStone/GetMineralName", JsonConvert.SerializeObject(SandStoneModel)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get UserType
        /// </summary>
        /// <param name="objDD"></param>
        /// <returns>GetMineralResult class</returns>
        public List<SandStoneModels> GetUserType(SandStoneModels SandStoneModel)
        {
            try
            {
                List<SandStoneModels> objlistDD = new List<SandStoneModels>();
                return JsonConvert.DeserializeObject<List<SandStoneModels>>(_objIHttpWebClients.PostRequest("SandStone/GetUserType", JsonConvert.SerializeObject(SandStoneModel)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get Ko_Id
        /// </summary>
        /// <param name="objDD"></param>
        /// <returns>GetMineralResult class</returns>
        public List<SandStoneModels> GetKo_Id(SandStoneModels SandStoneModel)
        {
            try
            {
                List<SandStoneModels> objlistDD = new List<SandStoneModels>();
                return JsonConvert.DeserializeObject<List<SandStoneModels>>(_objIHttpWebClients.PostRequest("SandStone/GetKo_Id", JsonConvert.SerializeObject(SandStoneModel)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }         
        /// <summary>
        /// Get Mineral Form
        /// </summary>
        /// <param name="objDD"></param>
        /// <returns>GetMineralResult class</returns>
        public List<SandStoneModels> GetMineralForm(SandStoneModels SandStoneModel)
        {
            try
            {
                List<SandStoneModels> objlistDD = new List<SandStoneModels>();
                return JsonConvert.DeserializeObject<List<SandStoneModels>>(_objIHttpWebClients.PostRequest("SandStone/GetMineralForm", JsonConvert.SerializeObject(SandStoneModel)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get Mineral Form
        /// </summary>
        /// <param name="objDD"></param>
        /// <returns>GetMineralResult class</returns>
        public SandStoneModels GetSandStoneNamePass(SandStoneModels SandStoneModel)
        {
            try
            {
                List<SandStoneModels> objlistDD = new List<SandStoneModels>();
                return JsonConvert.DeserializeObject<SandStoneModels>(_objIHttpWebClients.PostRequest("SandStone/GetSandStoneNamePass", JsonConvert.SerializeObject(SandStoneModel)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #region Update Encrypted Password
        /// <summary>
        /// Update Encrypted Password
        /// </summary>
        /// <param name="updateEncryptPasswordModel"></param>
        /// <returns></returns>
        public MessageEF UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel)
        {
            try
            {

                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseApplication/UpdateEncryptPassword", JsonConvert.SerializeObject(updateEncryptPasswordModel)));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
