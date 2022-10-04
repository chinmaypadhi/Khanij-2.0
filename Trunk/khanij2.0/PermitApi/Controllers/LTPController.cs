using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermitApi.Model.LTP;
using PermitEF;

namespace PermitApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LTPController : Controller
    {
        public ILTPProvider _objILTPProvider;
        public LTPController(ILTPProvider objILTPProvider)
        {
            _objILTPProvider = objILTPProvider;
        }
        [HttpPost]
        public async Task<List<LTPInfo>> GetRTPPassList(LTPInfo objLease)
        {
            return await _objILTPProvider.GetRTPPassList(objLease);
        }
        [HttpPost]
        public async Task<List<LTPInfo>> GetCascadeMineral(LTPInfo objLease)
        {
            return await _objILTPProvider.GetCascadeMineral(objLease);
        }
        [HttpPost]
        public async Task<List<LTPInfo>> GetMineralNatureList(LTPInfo objLease)
        {
            return await _objILTPProvider.GetMineralNatureList(objLease);
        }
        [HttpPost]
        public async Task<List<LTPInfo>> GetMineralGradList(LTPInfo objLease)
        {
            return await _objILTPProvider.GetMineralGradList(objLease);
        }
        [HttpPost]
        public async Task<List<LTPInfo>> GetRailwaySiding(LTPInfo objLease)
        {
            return await _objILTPProvider.GetRailwaySiding(objLease);
        }
        [HttpPost]
        public async Task<List<LTPInfo>> GetRailwaySidingDestination(LTPInfo objLease)
        {
            return await _objILTPProvider.GetRailwaySidingDestination(objLease);
        }
        [HttpPost]
        public async Task<List<LTPInfo>> GetuserDetailsUsingRTP(LTPInfo objLease)
        {
            return await _objILTPProvider.GetuserDetailsUsingRTP(objLease);
        }
        [HttpPost]
        public async Task<List<LTPInfo>> getAddLTPDetails(LTPInfo objLease)
        {
            return await _objILTPProvider.getAddLTPDetails(objLease);
        }
        [HttpPost]
        public async Task<List<LTPInfo>> getLTPDetails(LTPInfo objLease)
        {
            return await _objILTPProvider.getLTPDetails(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> AddLTPApplication(LTPInfo objLease)
        {
            return await _objILTPProvider.AddLTPApplication(objLease);
        }
        [HttpPost]
        public async Task<List<ListofLTP>> DownloadLTP(ListofLTP objLease)
        {
            return await _objILTPProvider.DownloadLTP(objLease);
        }
        [HttpPost]
        public async Task<List<ListofLTP>> GetPendigLTPList(ListofLTP objLease)
        {
            return await _objILTPProvider.GetPendigLTPList(objLease);
        }

    }
}
