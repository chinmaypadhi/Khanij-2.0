using EpassApi.Model.MineralReceive;
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
    public class MineralReceiveController : Controller
    {
        private IMineralReceiveProvider _objIMineralReceiveProvider;
        /// <summary>
        /// Added by suroj on 7-jul-2021  to fetch Permit No
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        public MineralReceiveController(IMineralReceiveProvider objIMineralReceiveProvider)
        {
            _objIMineralReceiveProvider = objIMineralReceiveProvider;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<List<EndUser_ETransitPassModel>> MineralReceiveData(EndUser_ETransitPassModel objtran)
        {
            return await _objIMineralReceiveProvider.MineralReceiveData(objtran);
        }
        public async Task<List<EndUser_ETransitPassModel>> BindReceivePermit(EndUser_ETransitPassModel objtran)
        {
            return await _objIMineralReceiveProvider.BindReceivePermit(objtran);
        }

        public async Task<List<EndUser_ETransitPassModel>> GetGridData(EndUser_ETransitPassModel objtran)
        {
            return await _objIMineralReceiveProvider.GetGridData(objtran);
        }
        public async Task<string> UpdateMineralReceipt(EndUser_ETransitPassModel model)
        {
            return await _objIMineralReceiveProvider.UpdateMineralReceipt(model);
        }

        public async Task<List<EndUser_ETransitPassModel>> EndUserMineralReceiptReports(MineralReceiveModel objtran)
        {
            return await _objIMineralReceiveProvider.GetClosedGridData(objtran);
        }
    }
}
