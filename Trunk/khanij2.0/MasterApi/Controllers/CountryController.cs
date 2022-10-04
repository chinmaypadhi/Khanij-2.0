using MasterApi.Model.Country;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class CountryController : ControllerBase
    {
        private readonly ICountryProvider countryProvider;

        public CountryController(ICountryProvider countryProvider)
        {
            this.countryProvider = countryProvider;
        }

        /// <summary>
        /// Add Country
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>
       
        [HttpPost]
        public async Task<MessageEF> Add(CountryMaster countryMaster)
        {
            return await countryProvider.AddCountry(countryMaster);
        }
       
        /// <summary>
        /// View Country
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>
       
        [HttpPost]
        public async Task<List<CountryMaster>> ViewDetails(CountryMaster countryMaster)
        {
            return await countryProvider.ViewCountry(countryMaster);
        }
      
        /// <summary>
        /// Edit Country
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>
        
        [HttpPost]
        public async Task<CountryMaster> Edit(CountryMaster countryMaster)
        {
            return await countryProvider.EditCountry(countryMaster);
        }
      
        /// <summary>
        /// Delete Country
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>
        
        [HttpPost]
        public async Task<MessageEF> Delete(CountryMaster countryMaster)
        {
            return await countryProvider.DeleteCountry(countryMaster);
        }
      
        /// <summary>
        /// Update Country
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>
       
        [HttpPost]
        public async Task<MessageEF> Update(CountryMaster countryMaster)
        {
            return await countryProvider.UpdateCountry(countryMaster);
        }
      
    }
}
