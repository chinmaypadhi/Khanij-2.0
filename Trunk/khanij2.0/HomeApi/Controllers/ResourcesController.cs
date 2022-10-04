using HomeApi.Model.Graph;
using HomeEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Controllers
{
    //[ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class ResourcesController : ControllerBase
    {
        public IResourcesProvider _objIResourcesProvider;
        public ResourcesController(IResourcesProvider objIResourcesProvider)
        {
            _objIResourcesProvider = objIResourcesProvider;
        }
        [HttpPost]
        public MessageEF Edit(EditResourcesModel obj)
        {
            return _objIResourcesProvider.Edit(obj);
        }
        [HttpPost]
        public async Task<EditResourcesModel> ViewByID(ViewResourcesModel objmodel)
        {
            return await _objIResourcesProvider.ViewByID(objmodel);
        }
        [HttpPost]
        public async Task<ViewResourcesModel> View(ViewResourcesModel objmodel)
        {
            return await _objIResourcesProvider.View(objmodel);
        }
    }
}
