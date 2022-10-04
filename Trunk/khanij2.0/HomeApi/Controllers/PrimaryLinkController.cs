using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApi.Model.PrimaryLink;
using HomeEF;

namespace HomeApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class PrimaryLinkController : ControllerBase
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        public IPrimaryLinkProvider _objPrimarylinkProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="primaryLinkProvider"></param>
        public PrimaryLinkController(IPrimaryLinkProvider primaryLinkProvider)
        {
            _objPrimarylinkProvider = primaryLinkProvider;
        }
        /// <summary>
        /// To add Primary Link Details
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(AddPrimaryLinkModel addPrimaryLinkModel)
        {
            return _objPrimarylinkProvider.AddPrimarylLink(addPrimaryLinkModel);
        }
        /// <summary>
        /// To Bind Page Details List 
        /// </summary>
        /// <param name="objaddPrimaryLinkModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<AddPrimaryLinkModel>>> GetPageList(AddPrimaryLinkModel  objaddPrimaryLinkModel)
        {
            return await _objPrimarylinkProvider.GetPageList(objaddPrimaryLinkModel);
        }
        /// <summary>
        /// To Bind Global Link List
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<AddPrimaryLinkModel>>> GetGlobalLinkList(AddPrimaryLinkModel addPrimaryLinkModel)
        {
            return await _objPrimarylinkProvider.GetGlobalLinkList(addPrimaryLinkModel);
        }
        /// <summary>
        /// For About us Link 
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AddPrimaryLinkModel> AboutUs(AddPrimaryLinkModel addPrimaryLinkModel)
        {
            return await _objPrimarylinkProvider.AboutUs(addPrimaryLinkModel);
        }
        /// <summary>
        /// For Registration Link
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AddPrimaryLinkModel> Registrations(AddPrimaryLinkModel addPrimaryLinkModel)
        {
            return await _objPrimarylinkProvider.Registrations(addPrimaryLinkModel);
        }
        /// <summary>
        /// To Bind Statistical Reports
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AddPrimaryLinkModel> StatisticalReports(AddPrimaryLinkModel addPrimaryLinkModel)
        {
            return await _objPrimarylinkProvider.StatisticalReports(addPrimaryLinkModel);
        }
    }
}
