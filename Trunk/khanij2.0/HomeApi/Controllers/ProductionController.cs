using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApi.Model.Graph;
using HomeEF;

namespace HomeApi.Controllers
{
    //[ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class ProductionController : ControllerBase
    {
        public IProductionProvider _objIProductionProvider;
        public ProductionController(IProductionProvider objIProductionProvider)
        {
            _objIProductionProvider = objIProductionProvider;
        }
        [HttpPost]
        public MessageEF Add(EditProductionModel obj)
        {
            return _objIProductionProvider.Add(obj);
        }
        [HttpPost]
        public MessageEF Edit(EditProductionModel objmodel)
        {
            return _objIProductionProvider.Edit(objmodel);
        }
        [HttpPost]
        public async Task<List<ViewProductionModel>> View(ViewProductionModel objmodel)
        {
            return await _objIProductionProvider.View(objmodel);
        }
        [HttpPost]
        public async Task<EditProductionModel> ViewByID(ViewProductionModel objmodel)
        {
            return await _objIProductionProvider.ViewByID(objmodel);
        }
        [HttpPost]
        public async Task<List<ViewProductionModel>> ViewByFinancialYear(ViewProductionModel objmodel)
        {
            return await _objIProductionProvider.ViewByFinancialYear(objmodel);
        }
        [HttpPost]
        public MessageEF Check(EditProductionModel obj)
        {
            return _objIProductionProvider.CheckProduction(obj);
        }
    }
}
