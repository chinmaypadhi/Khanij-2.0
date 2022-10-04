using EstablishmentApi.Model.PAStatffAppraisal;
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
    public class PAStatffAppraisalController : ControllerBase
    {
        public IPAStatffAppraisalProvider _objPAStatffAppraisalProvider;
        public PAStatffAppraisalController(IPAStatffAppraisalProvider objPAStatffAppraisalProvider)
        {
            _objPAStatffAppraisalProvider = objPAStatffAppraisalProvider;
        }
        [HttpPost]
        public MessageEF ReportingAuthority(PastaffEF objPastaffEF)
        {
            return _objPAStatffAppraisalProvider.ReportingAuthority(objPastaffEF);
        }
        [HttpPost]
        public List<PastaffEF> getList(PastaffEF objPastaffEF)
        {
            return _objPAStatffAppraisalProvider.getList(objPastaffEF);
        }
        [HttpPost]
        public  PastaffEF ReportingAuthorityEdit(PastaffEF objPastaffEF)
        {
            return _objPAStatffAppraisalProvider.ReportingAuthorityEdit(objPastaffEF);
        }

    }
}
