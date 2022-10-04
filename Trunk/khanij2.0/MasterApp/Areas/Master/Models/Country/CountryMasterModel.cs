using MasterApp.Models.Utility;
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Country
{
    public class CountryMasterModel: ICountryMasterModel
    {
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Add Country
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>
        public CountryMasterModel(IHttpWebClients httpWebClients)
        {
            _objIHttpWebClients = httpWebClients;
        }
        public MessageEF AddCountry(CountryMaster countryMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Country/Add", JsonConvert.SerializeObject(countryMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }      

        /// <summary>
        /// Delete Country
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>

        public MessageEF DeleteCountry(CountryMaster countryMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Country/Delete", JsonConvert.SerializeObject(countryMaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       

        /// <summary>
        /// Edit Country
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>
        
        public CountryMaster EditCountry(CountryMaster countryMaster)
        {
            try
            {
                countryMaster = JsonConvert.DeserializeObject<CountryMaster>(_objIHttpWebClients.PostRequest("Country/Edit", JsonConvert.SerializeObject(countryMaster)));
                return countryMaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }      

        /// <summary>
        /// Update Country
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>
        
        public MessageEF UpdateCountry(CountryMaster countryMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Country" +
                    "/Update", JsonConvert.SerializeObject(countryMaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        /// <summary>
        /// View Country
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>
       
        public List<CountryMaster> ViewCountry(CountryMaster countryMaster)
        {
            try
            {
                List<CountryMaster> listCountryMaster = new List<CountryMaster>();
                listCountryMaster = JsonConvert.DeserializeObject<List<CountryMaster>>(_objIHttpWebClients.PostRequest("Country/ViewDetails", JsonConvert.SerializeObject(countryMaster)));
                return listCountryMaster;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
    }
}
