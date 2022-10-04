using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HomeApi.Model.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;

namespace HomeApi.Controllers
{
    //[ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class RevenueController : ControllerBase
    {
        public IRevenueProvider _objIRevenueProvider;
        public RevenueController(IRevenueProvider objIRevenueProvider)
        {
            _objIRevenueProvider = objIRevenueProvider;
        }
        [HttpPost]
        public MessageEF Add(EditRevenueModel obj)
        {
            return _objIRevenueProvider.Add(obj);
        }
        [HttpPost]
        public MessageEF Edit(EditRevenueModel objmodel)
        {
            return _objIRevenueProvider.Edit(objmodel);
        }
        [HttpPost]
        public async Task<List<ViewRevenueModel>> View(ViewRevenueModel objmodel)
        {
            return await _objIRevenueProvider.View(objmodel);
        }
        [HttpPost]
        public async Task<EditRevenueModel> ViewByID(ViewRevenueModel objmodel)
        {
            return await _objIRevenueProvider.ViewByID(objmodel);
        }
        [HttpPost]
        public async Task<List<ViewRevenueModel>> ViewByFinancialYear(ViewRevenueModel objmodel)
        {
            return await _objIRevenueProvider.ViewByFinancialYear(objmodel);
        }
        [HttpPost]
        public MessageEF Check(EditRevenueModel obj)
        {
            return _objIRevenueProvider.CheckRevenue(obj);
        }
    }
}
