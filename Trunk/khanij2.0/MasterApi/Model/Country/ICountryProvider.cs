using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Country
{
    public interface ICountryProvider : IDisposable, IRepository
    {
        Task<MessageEF> AddCountry(CountryMaster countryMaster);
        Task<List<CountryMaster>> ViewCountry(CountryMaster countryMaster);
        Task<CountryMaster> EditCountry(CountryMaster countryMaster);
        Task<MessageEF> DeleteCountry(CountryMaster countryMaster);
        Task<MessageEF> UpdateCountry(CountryMaster countryMaster);
    }
}
