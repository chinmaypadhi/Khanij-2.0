using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstablishmentApi.Model.officeLevel;
using EstablishmentEf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstablishmentApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class OfficeLevelController : ControllerBase
    {
        public IOfficeLevelProvider _objIOfficeLevelProvider;
        public OfficeLevelController(IOfficeLevelProvider objIOfficeLevelProvider)
        {
            _objIOfficeLevelProvider = objIOfficeLevelProvider;
        }
        [HttpPost]
        public MessageEF AddUpdateDelete(officeLevelEF officeLevel)
        {
            return _objIOfficeLevelProvider.AddUpdateDelete(officeLevel);
        }
        [HttpPost]
        public List<officeLevelEF> GetOfficeLevel(officeLevelEF officeLevel)
        {
            return _objIOfficeLevelProvider.GetOfficeLevel(officeLevel);
        }
        [HttpPost]
        public officeLevelEF EditOfficeLevel(officeLevelEF officeLevel)
        {
            return _objIOfficeLevelProvider.EditOfficeLevel(officeLevel);
        }
    }
}