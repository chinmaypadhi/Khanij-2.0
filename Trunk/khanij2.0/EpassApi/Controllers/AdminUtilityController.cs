using EpassApi.Model.AdminUtility;
using EpassEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class AdminUtilityController : Controller
    {
        public IAdminUtilityProvider _objAdminUtility;

        public AdminUtilityController(IAdminUtilityProvider objAdminUtility)
        {
            _objAdminUtility = objAdminUtility;
        }

        [HttpPost]
        public async Task<MessageEF> CancleTPApproval(TPCancelModelEF objLease)
        {
            return await _objAdminUtility.CancleTPApproval(objLease);
        }

    }
}
