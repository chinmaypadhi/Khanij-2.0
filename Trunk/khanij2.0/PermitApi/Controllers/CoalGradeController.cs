using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermitApi.Model.CoalGrade;
using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class CoalGradeController : Controller
    {
        ICoalGradeProvider objIcoalgradeprovider;
        public CoalGradeController(ICoalGradeProvider objIcoalgradeprovider)
        {
            this.objIcoalgradeprovider = objIcoalgradeprovider;
        }
        [HttpPost]
        public async Task<List<SampleGradeModel>> CoalGradeDetailsByUserID(SampleGradeModel obj)
        {
            return await objIcoalgradeprovider.CoalGradeDetailsByUserID(obj);
        }
        [HttpPost]
        public async Task<ePermitModel> CoalGradeDetailsByPermitID(ePermitModel obj)
        {
            return await objIcoalgradeprovider.CoalGradeDetailsByPermitID(obj);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> GetMineralGradeCascadFromMineralNature(ePermitModel obj)
        {
            return await objIcoalgradeprovider.GetMineralGradeCascadFromMineralNature(obj);
        }
        [HttpPost]
        public async Task<List<ePaymentData>> RevisedPayableRoyaltyRate(RevisedPayableRoyaltyRate obj)
        {
            return await objIcoalgradeprovider.RevisedPayableRoyaltyRate(obj);
        }
    }
}
