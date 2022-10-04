using EpassApp.Models.Utility;
using EpassEF;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.ePassConfiguration
{
    public class ePassConfigurationModel : IePassConfigurationModel
    {
        IHttpWebClients _objIHttpWebClients;
        public ePassConfigurationModel(IHttpWebClients objIHttpWebClients)
        {

            _objIHttpWebClients = objIHttpWebClients;
        }
        public List<ePassConfigurationEF> GetDistrict(ePassConfigurationEF objConfig)
        {
            try
            {
                List<ePassConfigurationEF> objePassConfiguration = new List<ePassConfigurationEF>();

                objePassConfiguration = JsonConvert.DeserializeObject<List<ePassConfigurationEF>>(_objIHttpWebClients.PostRequest("ePassConfiguration/GetDistrict", JsonConvert.SerializeObject(objConfig)));

                return objePassConfiguration;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<ePassConfigurationEF> GetUserType(ePassConfigurationEF objConfig)
        {
            try
            {
                List<ePassConfigurationEF> objePassConfiguration = new List<ePassConfigurationEF>();

                objePassConfiguration = JsonConvert.DeserializeObject<List<ePassConfigurationEF>>(_objIHttpWebClients.PostRequest("ePassConfiguration/GetUserType", JsonConvert.SerializeObject(objConfig)));

                return objePassConfiguration;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<ePassConfigurationEF> GetMineralType(ePassConfigurationEF objConfig)
        {
            try
            {
                List<ePassConfigurationEF> objePassConfiguration = new List<ePassConfigurationEF>();

                objePassConfiguration = JsonConvert.DeserializeObject<List<ePassConfigurationEF>>(_objIHttpWebClients.PostRequest("ePassConfiguration/GetMineralType", JsonConvert.SerializeObject(objConfig)));

                return objePassConfiguration;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<ePassConfigurationEF> GetTransportationMode(ePassConfigurationEF objConfig)
        {
            try
            {
                List<ePassConfigurationEF> objePassConfiguration = new List<ePassConfigurationEF>();

                objePassConfiguration = JsonConvert.DeserializeObject<List<ePassConfigurationEF>>(_objIHttpWebClients.PostRequest("ePassConfiguration/GetTransportationMode", JsonConvert.SerializeObject(objConfig)));

                return objePassConfiguration;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<ePassConfigurationEF> GetUserName(ePassConfigurationEF objConfig)
        {
            try
            {
                List<ePassConfigurationEF> objePassConfiguration = new List<ePassConfigurationEF>();

                objePassConfiguration = JsonConvert.DeserializeObject<List<ePassConfigurationEF>>(_objIHttpWebClients.PostRequest("ePassConfiguration/GetUserName", JsonConvert.SerializeObject(objConfig)));

                return objePassConfiguration;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<ePassConfigurationEF> GetMineralName(ePassConfigurationEF objConfig)
        {
            try
            {
                List<ePassConfigurationEF> objePassConfiguration = new List<ePassConfigurationEF>();

                objePassConfiguration = JsonConvert.DeserializeObject<List<ePassConfigurationEF>>(_objIHttpWebClients.PostRequest("ePassConfiguration/GetMineralName", JsonConvert.SerializeObject(objConfig)));

                return objePassConfiguration;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<ePassConfigurationEF> GetAllowConsignee(ePassConfigurationEF objConfig)
        {
            try
            {
                List<ePassConfigurationEF> objePassConfiguration = new List<ePassConfigurationEF>();

                objePassConfiguration = JsonConvert.DeserializeObject<List<ePassConfigurationEF>>(_objIHttpWebClients.PostRequest("ePassConfiguration/GetAllowConsignee", JsonConvert.SerializeObject(objConfig)));

                return objePassConfiguration;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public MessageEF AddPassConfiguration(ePassConfigurationEF objConfig)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("ePassConfiguration/AddEpassConfiguration", JsonConvert.SerializeObject(objConfig)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region View
        public MessageEF UpdatePassConfiguration(ePassConfigurationEF objConfig)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("ePassConfiguration/UpdateEpassConfiguration", JsonConvert.SerializeObject(objConfig)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        public MessageEF DeletePassConfiguration(ePassConfigurationEF objConfig)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("ePassConfiguration/DeleteEpassConfiguration", JsonConvert.SerializeObject(objConfig)));
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
        /// Bind Mineral details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        public List<ePassConfigurationEF> View(ePassConfigurationEF objConfig)
        {
            try
            {
                List<ePassConfigurationEF> listePassConfigurationModel = new List<ePassConfigurationEF>();
                listePassConfigurationModel = JsonConvert.DeserializeObject<List<ePassConfigurationEF>>(_objIHttpWebClients.PostRequest("ePassConfiguration/ViewEpassConfiguration", JsonConvert.SerializeObject(objConfig)));
                return listePassConfigurationModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region EditView
        /// <summary>
        /// Bind Mineral details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        public ePassConfigurationEF EditViewConfig(ePassConfigurationEF objConfig)
        {
            try
            {
                objConfig = JsonConvert.DeserializeObject<ePassConfigurationEF>(_objIHttpWebClients.PostRequest("ePassConfiguration/EditViewConfig", JsonConvert.SerializeObject(objConfig)));
                return objConfig;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion


    }
}