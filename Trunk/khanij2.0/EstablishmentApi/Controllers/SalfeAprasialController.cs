using EstablishmentApi.Model.ClassIIIAppraisal;
using EstablishmentApi.Model.SelfeAprasial;
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
    public class SalfeAprasialController : ControllerBase
    {
        public ISalfeAprasialProvider _objSalfeAprasialProvider;
        public IClassIIIAppraisalProvider _objClassIIIAppraisalProvider;
        public SalfeAprasialController(ISalfeAprasialProvider objSalfeAprasialProvider, IClassIIIAppraisalProvider objClassIIIAppraisalProvider)
        {
            _objSalfeAprasialProvider = objSalfeAprasialProvider;
            _objClassIIIAppraisalProvider = objClassIIIAppraisalProvider;
        }
        [HttpPost]
        public List<SalfeAprasialEf> GetListData(SalfeAprasialEf objSalfeAprasialEf)
        {
            return _objSalfeAprasialProvider.GetListData(objSalfeAprasialEf);
        }
        [HttpPost]
        public SalfeAprasialEf Edit(SalfeAprasialEf objSalfeAprasialEf)
        {
            return _objSalfeAprasialProvider.Edit(objSalfeAprasialEf);
        }
        [HttpPost]
        public MessageEF Update(SalfeAprasialEf objSalfeAprasialEf)
        {
            return _objSalfeAprasialProvider.Update(objSalfeAprasialEf);
        }
        [HttpPost]
        public List<ClassIIIAppraisalEF> GetList(ClassIIIAppraisalEF objClassIIIAppraisalEF)
        {
            return _objClassIIIAppraisalProvider.GetList(objClassIIIAppraisalEF);
        }
        [HttpPost]
        public MessageEF AddPersonaldetails(ClassIIIAppraisalEF objClassIIIAppraisalEF)
        {
            return _objClassIIIAppraisalProvider.AddPersonaldetails(objClassIIIAppraisalEF);
        }
        [HttpPost]
        public ClassIIIAppraisalEF GetDetails(ClassIIIAppraisalEF objClassIIIAppraisalEF)
        {
            return _objClassIIIAppraisalProvider.GetDetails(objClassIIIAppraisalEF);
        }
        [HttpPost]
        public MessageEF AddSalfeAprasial(SalfeAprasialEf objSalfeAprasialEf)
        {
            return _objSalfeAprasialProvider.AddSalfeAprasial(objSalfeAprasialEf);
        }
    }
}
