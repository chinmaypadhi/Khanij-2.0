using EstablishmentApi.Model.AppraisalDriver;
using EstablishmentEf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]

    public class AppraisalDriverController : ControllerBase
    {
        public IAppraisalDriverProvider _IAppraisalDriverProvider;
        public AppraisalDriverController(IAppraisalDriverProvider IAppraisalDriverProvider)
        {
            _IAppraisalDriverProvider = IAppraisalDriverProvider;
        }
        [HttpPost]
        public List<AppraisalDriverEF> getList(AppraisalDriverEF objClassIIIAppraisalEF)
        {
            return _IAppraisalDriverProvider.getList(objClassIIIAppraisalEF);
        }
        [HttpPost]
        public AppraisalDriverEF getdataedit(AppraisalDriverEF objClassIIIAppraisalEF)
        {
            return _IAppraisalDriverProvider.getdataedit(objClassIIIAppraisalEF);
        }
        [HttpPost]
        public MessageEF AddAppraisal(AppraisalDriverEF objClassIIIAppraisalEF)
        {
            return _IAppraisalDriverProvider.AddAppraisal(objClassIIIAppraisalEF);
        }
    }
}
