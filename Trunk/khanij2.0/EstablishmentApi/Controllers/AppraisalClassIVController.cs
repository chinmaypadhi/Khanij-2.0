using EstablishmentApi.Model.AppraisalClassIV;
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

    
    public class AppraisalClassIVController : ControllerBase
    {
        public IAppraisalClassIVprovider _IAppraisalClassIVprovider;
        public AppraisalClassIVController(IAppraisalClassIVprovider IAppraisalClassIVprovider)
        {
            _IAppraisalClassIVprovider = IAppraisalClassIVprovider;
        }
        [HttpPost]
        public MessageEF AddAppraisal(AppraisalClassIVEF objAppraisalClassIVEF)
        {
            return _IAppraisalClassIVprovider.AddAppraisal(objAppraisalClassIVEF);
        }
        [HttpPost]
        public List<AppraisalClassIVEF> getList(AppraisalClassIVEF objAppraisalClassIVEF)
        {
            return _IAppraisalClassIVprovider.getList(objAppraisalClassIVEF);
        }
        [HttpPost]
        public AppraisalClassIVEF getdataedit(AppraisalClassIVEF objAppraisalClassIVEF)
        {

            return _IAppraisalClassIVprovider.getdataedit(objAppraisalClassIVEF);
        }
    }
}
