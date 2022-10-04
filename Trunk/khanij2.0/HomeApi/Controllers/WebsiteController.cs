using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApi.Model.WebsiteGallery;
using HomeEF;

namespace HomeApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class WebsiteController : ControllerBase
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        public IWebsiteGarlleryProvider _objIGalleryProvider;
        /// <summary>
        /// Constructor initilisation
        /// </summary>
        /// <param name="websiteGarlleryProvider"></param>
        public WebsiteController(IWebsiteGarlleryProvider websiteGarlleryProvider)
        {
            _objIGalleryProvider = websiteGarlleryProvider;
        }
        /// <summary>
        /// To Bind Gallery Image Details
        /// </summary>
        /// <param name="viewGalleryWebsite"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewGalleryWebsite>>> ViewGallery(ViewGalleryWebsite viewGalleryWebsite)
        {
            return await _objIGalleryProvider.ViewGallery(viewGalleryWebsite);
        }
    }
}
