using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermitApi.Model.ValidityExpired;
using PermitEF;

namespace PermitApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class ValidityExpiredController : Controller
    {
        public IValidityExpiredProvider _objIValidityExpiredProvider;
        public ValidityExpiredController(IValidityExpiredProvider objIValidityExpiredProvider)
        {
            _objIValidityExpiredProvider = objIValidityExpiredProvider;
        }
        [HttpPost]
        public async Task<List<ValidityExpiredEF>> GetValidityExpiredDetails(ValidityExpiredEF objLease)
        {
            return await _objIValidityExpiredProvider.GetValidityExpiredDetails(objLease);
        }
    }
}
