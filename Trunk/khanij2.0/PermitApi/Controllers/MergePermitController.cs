using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermitApi.Model.MergePermit;
using PermitEF;

namespace PermitApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class MergePermitController : Controller
    {
        public IMergePermitProvider _objIMergePermitProvider;
        public MergePermitController(IMergePermitProvider objIMergePermitProvider)
        {
            _objIMergePermitProvider = objIMergePermitProvider;
        }
        [HttpPost]
        public async Task<List<ePermitModel>> GetMergePermitList(ePermitModel objLease)
        {
            return await _objIMergePermitProvider.GetMergePermitList(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetMergePermitMineralGrade(ePermitModel objLease)
        {
            return await _objIMergePermitProvider.GetMergePermitMineralGrade(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> ClosePermit(ePermitModel objLease)
        {
            return await _objIMergePermitProvider.ClosePermit(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> SaveAndGenerateEpermit(ePermitModel objLease)
        {
            return await _objIMergePermitProvider.SaveAndGenerateEpermit(objLease);
        }
        /// <summary>
        /// Get Mineral Name for CoalMerge permit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ePermitResult> GetMineralName(ePermitModel objLease)
        {
            return await _objIMergePermitProvider.GetMineralName(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> CheckMergePermitDetails(ePermitModel objLease)
        {
            return await _objIMergePermitProvider.CheckMergePermitDetails(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetMergePermitTransDetails(ePermitModel objLease)
        {
            return await _objIMergePermitProvider.GetMergePermitTransDetails(objLease);
        }
    }
}