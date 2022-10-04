using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.Aec.Models.ClassIIIAppraisal
{
   public interface IClassIIIAppraisalModel
    {
        List<ClassIIIAppraisalEF> GetList(ClassIIIAppraisalEF objClassIIIAppraisalEF);
        ClassIIIAppraisalEF GetDetails(ClassIIIAppraisalEF objClassIIIAppraisalEF);
        MessageEF AddPersonaldetails(ClassIIIAppraisalEF objClassIIIAppraisalEF);
        List<EmpDropDown> Dropdown(EmpDropDown objEmpDropDown);
    }
}
