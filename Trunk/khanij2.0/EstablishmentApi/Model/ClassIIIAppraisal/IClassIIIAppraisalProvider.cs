using EstablishmentApi.Factory;
using EstablishmentApi.Repository;
using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Model.ClassIIIAppraisal
{
    public interface IClassIIIAppraisalProvider : IDisposable, IRepository
    {
        List<ClassIIIAppraisalEF> GetList(ClassIIIAppraisalEF objClassIIIAppraisalEF);
        ClassIIIAppraisalEF GetDetails(ClassIIIAppraisalEF objClassIIIAppraisalEF);
        MessageEF AddPersonaldetails(ClassIIIAppraisalEF objClassIIIAppraisalEF);

    }
}
