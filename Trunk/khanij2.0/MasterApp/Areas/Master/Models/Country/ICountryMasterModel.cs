using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Country
{
    public interface ICountryMasterModel
    {
        MessageEF AddCountry(CountryMaster countryMaster);
        List<CountryMaster> ViewCountry(CountryMaster countryMaster);
        CountryMaster EditCountry(CountryMaster countryMaster);
        MessageEF DeleteCountry(CountryMaster countryMaster);
        MessageEF UpdateCountry(CountryMaster countryMaster);
    }
}
