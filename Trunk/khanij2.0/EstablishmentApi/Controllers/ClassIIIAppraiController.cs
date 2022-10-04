using EstablishmentApi.Model.ClassIIIAppraisal;
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
    public class ClassIIIAppraiController : ControllerBase
    {
        public IClassIIIAppraisalProvider _objClassIIIAppraisalProvider;
        public ClassIIIAppraiController(IClassIIIAppraisalProvider objClassIIIAppraisalProvider)
        {
            _objClassIIIAppraisalProvider = objClassIIIAppraisalProvider;
        }
        [HttpPost]
        public List<ClassIIIAppraisalEF> GetList(ClassIIIAppraisalEF objClassIIIAppraisalEF)
        {
            return _objClassIIIAppraisalProvider.GetList(objClassIIIAppraisalEF);
        }
        [HttpPost]
        public ClassIIIAppraisalEF GetDetails(ClassIIIAppraisalEF objClassIIIAppraisalEF)
        {
            return _objClassIIIAppraisalProvider.GetDetails(objClassIIIAppraisalEF);
        }
        [HttpPost]
        public MessageEF AddPersonaldetails(ClassIIIAppraisalEF objClassIIIAppraisalEF)
        {
            return _objClassIIIAppraisalProvider.AddPersonaldetails(objClassIIIAppraisalEF);
        }
    }
}
